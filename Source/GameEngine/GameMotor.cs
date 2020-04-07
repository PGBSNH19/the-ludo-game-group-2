using GameEngine.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Library
{
    public class GameMotor
    {
        public GameInitializer GameInitializer { get; set; }

        public bool CheckIfReachedGoal(User user, Pawn pawn)
        {
            if (pawn.Count == 56)
            {
                Console.WriteLine($"You reached the finishline with your {pawn.PawnNumber} pawn");
                pawn.HasReachedGoal = true;
                return false;
            }

            if (CountActivePawns(user).Count == 0)
            {
                Console.WriteLine("Congrats you won!");
                return true;
            }
            return false;
        }

        public List<Pawn> CountActivePawns(User user)
        {
            return user.Pawns.Where(p => p.HasReachedGoal == false).ToList();
        }



        public void RollDie(Die die)
        {
            Random rnd = new Random();
            die.Roll = rnd.Next(1, 7);
        }

        public int Move(Pawn pawn, int dieRoll)
        {
            var endSquare = pawn.Position + dieRoll;

            if (pawn.Count + dieRoll > 56)
            {
                return pawn.Position;
            }
            else
            {
                for (int i = 0; i < dieRoll; i++)
                {
                    if (pawn.Position == 56)
                    {
                        pawn.Position = 0;
                    }

                    pawn.Position += 1;
                }
                pawn.Count += dieRoll;
                return endSquare;
            }
        }

        public void OccupySquare(GameBoard gameBoard, int endSquare)
        {
            if (endSquare > 56)
            {
                return;
            }
            gameBoard.Squares.Where(sq => sq.SquareNumber == endSquare).FirstOrDefault().IsEmpty = false;
        }
    }
}
