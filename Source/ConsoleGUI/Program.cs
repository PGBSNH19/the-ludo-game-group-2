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


            
            var currentPawn = game.MovePawn(gameBoard, players.FirstOrDefault(), dice.RollDice());

            //foreach (var player in players)
            //{
            //    Console.WriteLine($"Name: {player.Name}   Color: {player.Pawns.Select(x => x.Color).FirstOrDefault()}     Dice: {dice.Roll}");
            //}
        }
    }
}
