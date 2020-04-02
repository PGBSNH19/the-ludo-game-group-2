using GameEngine.Library.Models;
using System;
using System.Linq;

namespace ConsoleGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating a LIST of Players, that has its own pawns
            var playerList = User.GetPlayersAndName(Menu.HowManyPlayers());
            //

            // Creating ONE Player, that has its own pawns
            Console.WriteLine("Name: ");
            var username = Console.ReadLine();
            var user = new User(username);
            //

            // GameBoard- LIST of squares
            var gameBoard = new GameBoard();

            // Dice- With method Roll Dice
            var dice = new Dice();
            
            



            ////////////////////////////////////////////
            ///      Create a new Game/ Match       ///
            //////////////////////////////////////////

            var game = new Game(playerList,gameBoard,dice);
            var jonny = game.GetPlayer(user.Name);
            
            

        }

        
    }
}
