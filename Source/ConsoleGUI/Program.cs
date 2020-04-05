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
            // GameBoard- LIST of squares
            var gameBoard = new GameBoard();

            // Dice- With method Roll Dice
            var dice = new Dice();

            // Creating a LIST of Players, that has its own pawns
            var playerList = User.GetPlayersAndName(Menu.HowManyPlayers());
            //
            var game = new Game(playerList,gameBoard,dice);
            #endregion
            bool gameEnd = false;
            while (gameEnd == false)
            {
                for (int i = 0; i < playerList.Count; i++)
                {
                    // Get correct player
                    var player = game.PlayerByID(i+1);

                    //roll the dice
                    var diceResult = game.Dice.RollDice();

                    #region Previous Pawn Menu and Get Pawn Method
                    ////Show a menu, choose wich pawn to move and returns that number/ ID
                    //var pawnID = PawnMove.PawnMenu(player);
                    //Console.WriteLine();

                    //// Get the pawn that player choosed
                    //var pawn = game.PawnByID(player, pawnID);
                    #endregion
                    // Show a Menu of pawns => return choosen if not NULL
                    var pawn = game.GetPawnByMenu(player);

                    // Time to move pawn, 
                    //If it hasn't moved before 

                    Pawn.IfNotStartedSetStartPosition(pawn);
                    #region Previous Check if not started give position
                    if (pawn.HasStarted == false)
                    {
                        Pawn.SetStartPosition(pawn);
                        pawn.HasStarted = true;
                    }
                    #endregion

                    //Creates a new Move
                    var pawnMove = new PawnMove(pawn);

                    //Move Pawn, return landing square
                    var landingSquare = pawnMove.Move(diceResult);

                    // If pawn position is higher than 56, remove and add to a seperate list
                    gameEnd= game.CheckIfReachedGoal(player, pawn, gameEnd);

                    //  Occupie square that pawn ends up on
                    game.GameBoard.OccupySquare(landingSquare);

                    
                    //
                }
            }
            
        }
    }
}
