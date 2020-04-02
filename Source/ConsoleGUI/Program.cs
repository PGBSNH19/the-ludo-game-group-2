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
               
                if(count % 1 == 0)
                {
                    //var diceRoll = dice.RollDice();
                    var choice = PawnMove.GetUserChoice();
                    var userTest = PawnMove.ValidateUserPawn(players[0], choice, gameBoard, dice.RollDice());
                    //pawnMove.Move(gameBoard, players[0], dice.RollDice());
                    pawnMove.CheckIfReachedGoal(userTest);
                    count++;

                }

                //if (count % 2 == 0)
                //{
                //    var diceRoll = dice.RollDice();
                //    pawnMove.Move(gameBoard, players[1], diceRoll);
                //    pawnMove.CheckIfReachedGoal(players[1]);
                //}

                //var currentPawn = newMove.Move(gameBoard, players.FirstOrDefault(), dice.RollDice());

                //if (players[0].UserScore % 56 == 0)
                //{
                //    Console.WriteLine("you won bitch");
                //                       
                //}
                Console.ReadLine();
            }

           //foreach (var player in players)
            //{
            //    Console.WriteLine($"Name: {player.Name}   Color: {player.Pawns.Select(x => x.Color).FirstOrDefault()}     Dice: {dice.Roll}");
            //}
        }

        
    }
}
