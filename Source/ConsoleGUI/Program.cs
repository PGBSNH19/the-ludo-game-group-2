using GameEngine.Library;
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
            #region Initilize Classes
            using var context = new LudoGameContext();

            var loadSavedGame = false;
            var gUI = new RunGUI();
            var game = new GameInitializer();
            var gameMotor = new GameMotor();
            game.GameBoard.PopulateBoard();
            #endregion
            var loadGameAnswer = "";
            bool validChoice = false;
            LoadSavedGameOrCreateNewGame(context, ref loadSavedGame, gUI, game, ref loadGameAnswer, ref validChoice);
            Console.Clear();

            bool gameHasEnd = false;
            while (gameHasEnd == false)
            {
                gameHasEnd = PlayerTurn(gUI, game, gameMotor, gameHasEnd);
                Console.Clear();

                var exitGameAnswer = "";
                bool validChoiceInGame = false;
                ContinueOrExit(context, loadSavedGame, game, ref exitGameAnswer, ref validChoiceInGame);
                Console.Clear();
            }
        }

        private static void ContinueOrExit(LudoGameContext context, bool loadSavedGame, GameInitializer game, ref string exitGameAnswer, ref bool validChoiceInGame)
        {
            while (validChoiceInGame == false)
            {
                exitGameAnswer = Menu.DisplayMessageReturnUserInput("y. = Quit & Save Game\n" +
                                                                    "n. = Continue playing\n" +
                                                                    "q. = Quit without saving");
                switch (exitGameAnswer)
                {
                    case "y":
                        if (loadSavedGame == true)
                        {
                            foreach (var user in game.Users)
                            {
                                context.Entry(user).State = EntityState.Modified;
                            }
                        }
                        else
                        {
                            foreach (var user in game.Users)
                            {
                                context.Users.Add(user);
                                context.SaveChanges();
                                foreach (var paw in user.Pawns)
                                {
                                    paw.UserID = user.UserID;
                                    context.Pawns.Add(paw);
                                }
                            }
                        }
                        context.SaveChanges();
                        Environment.Exit(0);
                        break;
                    case "n":
                        validChoiceInGame = true;
                        break;
                    case "q":
                        Console.WriteLine("Thanks for playing The Ludo Game! :)");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("No valid input");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        private static void LoadSavedGameOrCreateNewGame(LudoGameContext context, ref bool loadSavedGame, RunGUI gUI, GameInitializer game, ref string loadGameAnswer, ref bool validChoice)
        {
            while (validChoice == false)
            {
                loadGameAnswer = Menu.DisplayMessageReturnUserInput("y. = Load saved game\n" +
                                                                    "n. = Create new game");
                switch (loadGameAnswer)
                {
                    case "y":
                        var gameNames = context.Users
                        .Select(x => x.GameName)
                        .Distinct().ToList();

                        foreach (var gameName in gameNames)
                        {
                            Console.WriteLine($"Saved Game: { gameName }");
                        }
                        var userGameToLoad = Console.ReadLine();
                        game.Users = context.Users.Where(u => u.GameName == userGameToLoad).ToList();

                        foreach (var user in game.Users)
                        {
                            user.Pawns = context.Pawns.Where(p => p.UserID == user.UserID).ToList();
                        }


                        loadSavedGame = true;
                        validChoice = true;
                        break;
                    case "n":
                        var numberOfPlayers = gUI.NumberOfPlayers();
                        var nameOfGame = Menu.DisplayMessageReturnUserInput("Name your game: ");
                        for (int i = 1; i <= numberOfPlayers; i++)
                        {
                            string name = gUI.GetAndReturnName();
                            gUI.ShowPawnColorMenu();
                            var colorOnPawn = game.TranslateChoiceToColor(Console.ReadLine());
                            var pawns = game.CreateListOfPawns(colorOnPawn);
                            game.AddUserToPlayerList(new User(name, i, pawns, nameOfGame));
                        }
                        validChoice = true;
                        break;
                    default:
                        Console.WriteLine("No valid input");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        private static bool PlayerTurn(RunGUI gUI, GameInitializer game, GameMotor gameMotor, bool gameHasEnd)
        {
            for (int i = 0; i < game.Users.Count; i++)
            {
                var player = game.PlayerByID(i + 1);
                gUI.ShowWhichPlayer(player);

                gameMotor.RollDie(game.Die);
                gUI.ShowDie(game.Die.Roll);

                var IDOnPawn = gUI.TimeToChoosePawn(player); 
                var pawn = player.PawnByID(IDOnPawn); 

                game.IfNotStartedSetStartPosition(pawn);
                var landingSquare = gameMotor.Move(pawn, game.Die.Roll);
                gUI.WalkWithPawn(pawn, game.Die.Roll);

                gameHasEnd = gameMotor.CheckIfReachedGoal(player, pawn, gameHasEnd);
                gameMotor.OccupySquare(game.GameBoard, landingSquare);
            }

            return gameHasEnd;
        }
    }
}
