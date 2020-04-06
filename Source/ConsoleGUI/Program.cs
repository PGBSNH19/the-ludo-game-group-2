using GameEngine.Library.Models;
using System;
using System.Linq;

namespace ConsoleGUI
{
    class Program
    {
        static void Main(string[] args)
        {

            ////////////////////////////////////////////
            ///      Create a new Game/ Match       ///
            //////////////////////////////////////////
            #region Creating new GAME
            var gameBoard = new GameBoard();
            var die = new Die();
            var playerList = User.CreateListOfPlayers(RunGUI.NumberOfPlayers());
            var game = new Game(playerList,gameBoard,die);
            #endregion
            
            bool gameEnd = false;
            while (gameEnd == false)
            {
                for (int i = 0; i < playerList.Count; i++)
                {
                    // Get correct player
                    var player = game.PlayerByID(i+1);
                    RunGUI.ShowWhichPlayer(player);
                    //roll the dice
                    var dieResult = game.Dice.RollDice();
                    RunGUI.ShowDie(dieResult);

                    // Show a Menu of pawns => return choosen if not NULL
                    var IDOnPawn = RunGUI.TimeToChoosePawn(player); // Crashes when entering pawnID that no longer exist. 
                    var pawn = game.GetPawnByID(player,IDOnPawn); // This happened after seperating GUI from the logic

                    // Time to move pawn, 
                    Pawn.IfNotStartedSetStartPosition(pawn);

                    //Creates a new Move
                    var pawnMove = new PawnMove(pawn);
                    //Move Pawn, return landing square
                    var landingSquare = pawnMove.Move(dieResult);
                    RunGUI.WalkWithPawn(pawn, dieResult);

                    // If pawn position is higher than 56, remove and add to a seperate list
                    gameEnd = game.CheckIfReachedGoal(player, pawn, gameEnd);

                    //  Occupie square that pawn ends up on
                    game.GameBoard.OccupySquare(landingSquare);

                    
                    //
                }
            }
            
        }
    }
}
