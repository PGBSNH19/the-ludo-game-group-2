using GameEngine.Library;
using GameEngine.Library.Models;
using System;
using System.Linq;
using System.Threading;

namespace ConsoleGUI
{
    class Program
    {
        static void Main(string[] args)
        {
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
                    gameInitializer.IfNotStartedSetStartPosition(pawn);


                    //Move Pawn, return landing square
                    var landingSquare = gameMotor.Move(pawn, die.Roll);
                    gUI.WalkWithPawn(pawn, die.Roll);

                    // If pawn position is higher than 56, remove and add to a seperate list
                    gameHasEnd = gameMotor.CheckIfReachedGoal(player, pawn);

                    gameMotor.OccupySquare(gameBoard,landingSquare);

                }
            }

        }
    }
}
