﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Library.Models
{
    public static class PawnMove
    {
        //public int Moves { get; set; }
        //public int PawnID { get; set; }

        public static void Move(GameBoard Squares, User user, Pawn pawn, int diceRoll)
        {
            var endSquare = pawn.Position + diceRoll; // Use this when running application 4Reeeeeaaaaall Boooyyy!!!

            Console.WriteLine("DiceRoll: " + diceRoll + "for user" + user.Name);

            for(int i = 0; i < diceRoll; i++)
            {
                pawn.Count += diceRoll;
                if (pawn.Position == 56)
                {
                    pawn.Position = 0;
                }
                
                pawn.Position += 1;
                Console.WriteLine("PawnPosition: " + pawn.Position);
                pawn.HasStarted = true;
            }

            Squares.OccupySquare(Squares, endSquare);
            
            
        }

        public static bool IsItLastSquare(User user,Pawn pawn, int diceRoll)
        {
            if ((pawn.Count + 0.0 + diceRoll) % 56  == 0)
            {
                Console.WriteLine("You have to stop at 56\n");
                return false;
            }
            else
            {
                var pawnRemove= user.Pawns.Where(p=> p.PawnID == pawn.PawnID).FirstOrDefault();
                user.Pawns.Remove(pawnRemove);
                user.NonActivePawns.Add(pawnRemove);
                return true;
            }
        }

        public static bool ReachedEndPoint(Pawn pawn, int roll)
        {
            if (pawn.Count + roll > 56)
            {
                return true;

            }
            else if (pawn.Count == 0)
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        public static void CheckIfReachedGoal(User user, Pawn pawn)
        {

            if (pawn.Count == 56)
            {
                user.Pawns.Remove(pawn);
                user.NonActivePawns.Add(pawn);
                Console.WriteLine($"You reached the finishline with your {pawn.PawnID} pawn");
            }

        }
        
        public static int GetUserChoice()
        {
            Console.WriteLine("1. Walk unWalked Pawn");
            Console.WriteLine("2. Choose Pawn");
            var choice= Console.ReadLine();
            return Convert.ToInt32(choice);
        }
        
        public static Pawn SetPawnToMove(User user, int choice)
        {
            
            if (choice== 1)
            {
                return user.Pawns.Where(p => p.HasStarted == false).FirstOrDefault();
                //pawn.SetStartPosition(pawn);
            }
            else
            {
                Console.WriteLine("1. Pawn 1");
                Console.WriteLine("2. Pawn 2");
                Console.WriteLine("3. Pawn 3");
                Console.WriteLine("4. Pawn 4");
                var pawnChoice = Console.ReadLine();
                return user.Pawns.Where(p => p.PawnID == Convert.ToInt32(pawnChoice)).FirstOrDefault();
                 
            }
        }
    }
}