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

            // Player one First time //var jonny = game.GetPlayerByName(user.Name);
            var player1 = game.GetPlayerByID(1);

            // player 1 roll the dice
            var diceResult = game.Dice.RollDice();

            // Player 1 choose to walk with his 1st pawn
            var jonnysPawnByID = game.GetPlayerPawnByID(player1, 1);

            if (jonnysPawnByID.HasStarted == false)
            {
                jonnysPawnByID.SetStartPosition(jonnysPawnByID);
                var landsOnSquare = PawnMove.Move(jonnysPawnByID,diceResult);
                game.GameBoard.OccupySquare(landsOnSquare);
            }
            else
            {
                var landsOnSquare = PawnMove.Move(jonnysPawnByID, diceResult);
                game.GameBoard.OccupySquare(landsOnSquare);

            }




            //

        }


    }
}
