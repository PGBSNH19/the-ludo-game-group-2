using GameEngine.Library.Models;
using GameEngine.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleGUI
{
    public class RunGUI
    {
        public int NumberOfPlayers()
        {
            Console.Clear();
            Console.Write($"Number of players: ");
            var amount = int.Parse(Console.ReadLine());
            return amount;
        }

        public string GetAndReturnName() // Not sure how to fix this GUI with logic
        {
            Console.WriteLine("Enter Name:");
            return Console.ReadLine();
        }

        public void ShowPawnColorMenu()
        {
            Console.WriteLine();
            Console.WriteLine($"1. Blue");
            Console.WriteLine($"2. Green");
            Console.WriteLine($"3. Red");
            Console.WriteLine($"4. Yellow");
            Console.WriteLine();
        }

        public void ShowWhichPlayer(User user)
        {
            Console.Clear();
            Console.WriteLine($"Player ID: {user.PlayerID} Name: {user.Name}");
            Console.WriteLine("Enter key...");
            Console.ReadKey();
        }

        public void ShowDie(int rollResult)
        {
            Console.Clear();
            Console.WriteLine($"Lets roll the dice! Result: {rollResult}");
            Console.WriteLine("Enter key...");
            Console.ReadKey();
        }

        public int TimeToChoosePawn(User user)
        {
            Console.Clear();
            var pawnsLeft = user.Pawns.Where(p=> p.HasReachedGoal == false).ToList();
            foreach (var pawn in pawnsLeft)
            {
                Console.WriteLine($"Pawn: {pawn.PawnNumber}");
            }
            Console.Write("Enter pawn to move: =>");
            return Convert.ToInt32(Console.ReadLine());
        }

        public void WalkWithPawn(Pawn pawn,int dieResult)
        {
            Console.Clear();
            var start = (pawn.Count - dieResult)+ 1;
            var end = pawn.Count;
            if (pawn.Count + dieResult > 56)
            {
                var left = 56 - pawn.Count;
                Console.WriteLine($"Current position: {pawn.Count}\nYou need to hit a: {left}\n");
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    Console.Write($"_{i} ");
                    //Thread.Sleep(800);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Enter key...");
            Console.ReadKey();
        }
    }
}
