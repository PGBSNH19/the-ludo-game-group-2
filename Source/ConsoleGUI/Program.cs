using GameEngine.Library;
using GameEngine.Library.Models;
using System;
using GameEngine.Library.Context;

namespace ConsoleGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new LudoGameContext();

            #region Creates an instance of RunGUI,GameInitializer and GameMotor
            var gUI = new RunGUI();
            var gameInitializer = new GameInitializer();
            var gameMotor = new GameMotor();
            #endregion
            var numberOfPlayers = gUI.NumberOfPlayers();
            #region Gets name on each player and pawncolor of choice and then add them to GameInitializers list of users
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                string name = gUI.GetAndReturnName();
                gUI.ShowPawnColorMenu();
                var colorOnPawn = gameInitializer.TranslateChoiceToColor(Console.ReadLine());
                var pawns = gameInitializer.CreateListOfPawns(colorOnPawn);
                gameInitializer.AddUserToPlayerList(new User(name, i, pawns));
            }
            #endregion
           
            var die = gameInitializer.Die;
            gameInitializer.GameBoard.PopulateBoard();
            var gameBoard = gameInitializer.GameBoard;
            bool gameHasEnd = false;
            while (gameHasEnd == false)
            {
                Console.WriteLine("Do you want to quit and save your game for later? y/n");
                var answer = Console.ReadLine();
                if (answer == "y")
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
