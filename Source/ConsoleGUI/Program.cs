using GameEngine.Library;
using GameEngine.Library.Models;
using GameEngine.Library.Context;
using System;
using System.Linq;

namespace ConsoleGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new LudoGameContext();

            #region Creating new GAME

            var gameInitializer = new GameInitializer();
            var gameMotor = new GameMotor();

            //var die = new Die();
            var playerList = gameInitializer.CreateListOfPlayers(RunGUI.NumberOfPlayers());
            var gameBoard = gameInitializer.PopulateBoard();

            var game = new Game(gameInitializer);
            #endregion
            
            bool gameHasEnd = false;
            while (gameHasEnd == false)
            {
                Console.WriteLine("Do you want to quit and save your game for later? y/n");
                var answer = Console.ReadLine();
                if (answer == "y")
                {
                    
                    foreach (var player in playerList)
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
                else
                {
                    for (int i = 0; i < playerList.Count; i++)
                    {
                        // Get correct player
                        var player = gameInitializer.PlayerByID(playerList, i + 1);
                        RunGUI.ShowWhichPlayer(player);
                        //roll the dice
                        var dieResult = gameMotor.RollDie(gameInitializer.Die);
                        RunGUI.ShowDie(dieResult.Roll);

                        // Show a Menu of pawns => return choosen if not NULL
                        var IDOnPawn = RunGUI.TimeToChoosePawn(player, gameMotor); // Crashes when entering pawnID that no longer exist. 
                        var pawn = gameMotor.GetPawnByID(player, IDOnPawn); // This happened after seperating GUI from the logic

                        // Time to move pawn, 
                        gameInitializer.IfNotStartedSetStartPosition(pawn);

                        //Creates a new Move

                        //Move Pawn, return landing square
                        var landingSquare = gameMotor.Move(pawn, dieResult.Roll);
                        RunGUI.WalkWithPawn(pawn, dieResult.Roll);

                        // If pawn position is higher than 56, remove and add to a seperate list
                        gameHasEnd = gameMotor.CheckIfReachedGoal(player, pawn, gameHasEnd);

                        //  Occupie square that pawn ends up on
                        gameMotor.OccupySquare(gameBoard, landingSquare);

                        //


                    }
                }
                
            }
            
        }
    }
}
