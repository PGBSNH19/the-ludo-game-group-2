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
            var numberOfPlayers = menu.HowManyPlayers();
            
            var turn = new Game(numberOfPlayers)
                .RollDice(new Dice())
                .Turn();

            Console.WriteLine(turn.Users.Where(x=> x.Name == "William").FirstOrDefault());
            Console.WriteLine();
            //game.MovePawn(game, players.FirstOrDefault(), dice.RollDice());
            //foreach (var player in players)
            //{
            //    Console.WriteLine($"Name: {player.Name}   Color: {player.Pawns.Select(x => x.Color).FirstOrDefault()}     Dice: {dice.Roll}");
            //}
        }
    }
}
