using GameEngine.Library.Models;
using System;
using System.Linq;

namespace ConsoleGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            var dice = new Dice();

            var players = User.GetPlayersAndName(menu.HowManyPlayers());
            var gameBoard = new GameBoard();

            var game = new Game(players, gameBoard);
            var pawnMove = new PawnMove();
            var count = 0;

            var pawnStartTest = players[0].Pawns;
            pawnStartTest.FirstOrDefault().SetStartPosition(pawnStartTest.FirstOrDefault());

            while (players[0].UserScore <= 56)
            {

                if (count % 1 == 0)
                {
                    var choice = PawnMove.GetUserChoice();
                    var userTest = PawnMove.ValidateUserPawn(players[0], choice, gameBoard, dice.RollDice());

                    count++;

                }
                Console.ReadLine();
            }
        }

        
    }
}
