using GameEngine.Library.Models;
using GameEngine.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleGUI
{
    public static class RunGUI
    {
        public static int NumberOfPlayers()
        {
            Console.Clear();
            Console.Write($"Number of players: ");
            var amount = int.Parse(Console.ReadLine());
            return amount;
        }

        public static int GetNames(int numberOfPlayers) // Not sure how to fix this GUI with logic
        {
            Console.WriteLine("Enter Name:");
            for (int i = 0; i < numberOfPlayers; i++)
            {

            }
            return 0;
        }

        public static void ShowWhichPlayer(User user)
        {
            Console.Clear();
            Console.WriteLine($"Player ID: {user.UserID} Name: {user.Name}");
            Console.WriteLine("Enter key...");
            Console.ReadKey();
        }

        public static void ShowDie(int rollResult)
        {
            Console.Clear();
            Console.WriteLine($"Lets roll the dice! Result: {rollResult}");
            Console.WriteLine("Enter key...");
            Console.ReadKey();
        }

        public static int TimeToChoosePawn(User user, GameMotor gameMotor)
        {
            Console.Clear();
            foreach (var pawn in gameMotor.CountActivePawns(user))
            {
                Console.WriteLine($"Pawn: {pawn.PawnID}");
            }
            Console.Write("Enter pawn to move: =>");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static void WalkWithPawn(Pawn pawn,int dieResult)
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
