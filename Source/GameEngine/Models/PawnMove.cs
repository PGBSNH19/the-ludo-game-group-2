﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Library.Models
{
    public class PawnMove
    {
        private Pawn pawn;

        //public int Moves { get; set; }
        //public int PawnID { get; set; }
        public Pawn Pawn { get => pawn; set => pawn = value; }

        public PawnMove(Pawn pawn)
        {
            Pawn = pawn;
        }

        public int Move(int diceRoll)
        {
            var endSquare = pawn.Position + diceRoll;

            if (pawn.Count + diceRoll > 56)
            {
                Console.WriteLine($"You have to stop at 56\n");
                return pawn.Position;
            }
            else
            {
                for (int i = 0; i < diceRoll; i++)
                {
                    if (pawn.Position == 56)
                    {
                        pawn.Position = 0;
                    }

                    pawn.Position += 1;

                    Console.WriteLine("Position: " + pawn.Position);
                }
                pawn.Count += diceRoll;
                Console.WriteLine($"Count: {pawn.Count}");
                return endSquare;
            }
        }

        public bool IsItLastSquare(User user, int diceRoll)
        {
            if ((pawn.Count + 0.0 + diceRoll) % 56 == 0)
            {
                Console.WriteLine("You have to stop at 56\n");
                return false;
            }
            else
            {
                var pawnRemove = user.Pawns.Where(p => p.PawnID == pawn.PawnID).FirstOrDefault();
                user.Pawns.Remove(pawnRemove);
                user.NonActivePawns.Add(pawnRemove);
                return true;
            }
        }

        public bool ReachedEndPoint(int roll)
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

        public static int PawnMenu(User user)
        {
            foreach (var pawn in user.Pawns)
            {
                Console.WriteLine($"Pawn: {pawn.PawnID}");
            }
            Console.Write("Enter pawn to move: =>");
            var choice = Console.ReadLine();
            return Convert.ToInt32(choice);
        }
    }
}
