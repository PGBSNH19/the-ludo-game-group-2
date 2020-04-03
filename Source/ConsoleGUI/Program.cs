using GameEngine.Library.Models;
using System;
using System.Linq;

namespace ConsoleGUI
{
    class Program
    {
        static void Main(string[] args)
        {

            // Creating ONE Player, that has its own pawns
            //Console.WriteLine("Name: ");
            //var username = Console.ReadLine();
            //var user = new User(username,1);
            //

            // GameBoard- LIST of squares
            var gameBoard = new GameBoard();

            // Dice- With method Roll Dice
            var dice = new Dice();

            ////////////////////////////////////////////
            ///      Create a new Game/ Match       ///
            //////////////////////////////////////////

            // Creating a LIST of Players, that has its own pawns
            var playerList = User.GetPlayersAndName(Menu.HowManyPlayers());
            //
            var game = new Game(playerList,gameBoard,dice);

            bool gameEnd= false;
            while (gameEnd == false)
            {
                for (int i = 0; i < playerList.Count; i++)
                {
                    // Get correct player
                    var player = game.PlayerByID(i+1);

                    //roll the dice
                    var diceResult = game.Dice.RollDice();

                    //Show a menu, choose wich pawn to move and returns that number/ ID
                    var pawnID = PawnMove.GetUserChoice();
                    Console.WriteLine();

                    // Get the pawn that player choosed
                    var pawn = game.PawnByID(player, pawnID);

                    // Time to move pawn, 
                    //If it hasn't moved before 
                    if (pawn.HasStarted == false)
                    {
                        Pawn.SetStartPosition(pawn);
                        pawn.HasStarted = true;
                    }

                    //Move Pawn, return landing square
                    var landsOnSquare = PawnMove.Move(pawn, diceResult);

                    // If pawn position is higher than 56, remove and add to a seperate list
                    gameEnd= game.CheckIfReachedGoal(player, pawn, gameEnd);

                    //  Occupie square that pawn ends up on
                    game.GameBoard.OccupySquare(landsOnSquare);

                    
                    //
                }
            }
            
        }
    }
}
