﻿using GameEngine.Library;
using GameEngine.Library.Models;
using System;
using GameEngine.Library.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ConsoleGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new LudoGameContext();

            var loadSavedGame = false;
            var gUI = new RunGUI();
            var gameInitializer = new GameInitializer();
            var gameMotor = new GameMotor();

            Console.WriteLine("Do you want to load a saved game? y/n");
            var answer = Console.ReadLine();

            if (answer == "y")
            {
                var gameNames = context.Users
                    .Select(x => x.GameName)
                    .Distinct().ToList();

                foreach (var game in gameNames)
                {
                    Console.WriteLine($"Saved Game: { game }");
                }

                var userGameToLoad = Console.ReadLine();
                loadSavedGame = true;
                gameInitializer.Users = context.Users.Where(u => u.GameName == userGameToLoad).ToList();
                foreach (var user in gameInitializer.Users)
                {
                    user.Pawns = context.Pawns.Where(p => p.UserID == user.UserID).ToList();
                }
            }
            else
            {
                var numberOfPlayers = gUI.NumberOfPlayers();
                Console.Write("Name your game: ");
                var gameName = Console.ReadLine();
                for (int i = 1; i <= numberOfPlayers; i++)
                {
                    string name = gUI.GetAndReturnName();
                    gUI.ShowPawnColorMenu();
                    var colorOnPawn = gameInitializer.TranslateChoiceToColor(Console.ReadLine());
                    var pawns = gameInitializer.CreateListOfPawns(colorOnPawn);
                    gameInitializer.AddUserToPlayerList(new User(name, i, pawns, gameName));
                }
            }

            var playerList = gameInitializer.Users;
            var die = gameInitializer.Die;
            gameInitializer.GameBoard.PopulateBoard();
            var gameBoard = gameInitializer.GameBoard;
            bool gameHasEnd = false;
            while (gameHasEnd == false)
            {
                Console.WriteLine("Do you want to quit and save your game for later? y/n");
                answer = Console.ReadLine();
                if (answer == "y")
                {
                    if (loadSavedGame == true)
                    {
                        foreach (var player in playerList)
                        {
                            context.Entry(player).State = EntityState.Modified;
                            context.SaveChanges();
                        }
                    }
                    else
                    {
                        foreach (var player in gameInitializer.Users)
                        {
                            context.Users.Add(player);
                            context.SaveChanges();
                            foreach (var paw in player.Pawns)
                            {
                                paw.UserID = player.UserID;
                                context.Pawns.Add(paw);
                                context.SaveChanges();
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < gameInitializer.Users.Count; i++)
                    {
                        // Get correct player
                        var player = gameInitializer.PlayerByID(i + 1);
                        gUI.ShowWhichPlayer(player);

                        //roll the dice
                        gameMotor.RollDie(die);
                        gUI.ShowDie(die.Roll);

                        // Show a Menu of pawns => return choosen if not NULL
                        var IDOnPawn = gUI.TimeToChoosePawn(player); // Crashes when entering pawnID that no longer exist. 
                        var pawn = player.PawnByID(IDOnPawn); // This happened after seperating GUI from the logic

                        // Time to move pawn, 
                        //Move Pawn, return landing square
                        gameInitializer.IfNotStartedSetStartPosition(pawn);
                        var landingSquare = gameMotor.Move(pawn, die.Roll);
                        gUI.WalkWithPawn(pawn, die.Roll);

                        // If pawn position is higher than 56, change bool to hasReachedGoal == true;
                        gameHasEnd = gameMotor.CheckIfReachedGoal(player, pawn);
                        gameMotor.OccupySquare(gameBoard, landingSquare);
                    }
                }
            }
        }
    }
}
