﻿using GameEngine.Library.Models;
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
            Console.WriteLine($"Player ID: {user.PlayerID} Name: {user.Name}");
        }

        public static void ShowDie(int rollResult)
        {
            Console.WriteLine($"Lets roll the dice! Result: {rollResult}");
        }

        public static int TimeToChoosePawn(User user)
        {
            foreach (var pawn in user.Pawns)
            {
                Console.WriteLine($"Pawn: {pawn.PawnID}");
            }
            Console.Write("Enter pawn to move: =>");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static void WalkWithPawn(Pawn pawn,int dieResult)
        {
            var start = pawn.Count - dieResult;
            var end = pawn.Count;
            if (pawn.Count + dieResult > 56)
            {
                var left = 56 - pawn.Count;
                Console.WriteLine($"Current position: {pawn.Count}\nYou need to hit a: {left}\n");
            }
            else
            {
                if (start <= 0)
                {
                    start = 1;
                }

                for (int i = start; i <= end; i++)
                {
                    Console.Write($"_{i} ");
                    Thread.Sleep(800);
                }
            }



        }
    }
}
