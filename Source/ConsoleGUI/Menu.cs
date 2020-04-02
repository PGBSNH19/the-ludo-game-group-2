using GameEngine.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGUI
{
    public class Menu
    {
        public static int HowManyPlayers()
        {
            Console.WriteLine($"Number of players:");
            var amount = int.Parse(Console.ReadLine());
            Console.WriteLine();

            return amount;
        }
    }
}
