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
       
        public Pawn PawnByID(User user, int id)
        {
            var pawn = user.Pawns.Where(p => p.PawnColorID == id).FirstOrDefault();
            return pawn;
        }

        public bool CheckIfReachedGoal(User user, Pawn pawn, bool finishline)
        {
            if (pawn.Count == 56)
            {
                //user.Pawns.Remove(pawn);
                //user.NonActivePawns.Add(pawn);
                Console.WriteLine($"You reached the finishline with your {pawn.PawnColorID} pawn");
                pawn.HasReachedGoal = true;
                finishline = false;
            }

            if (CountActivePawns(user).Count == 0)
            {
                Console.WriteLine("Congrats you won!");
                finishline = true;
            }
            return finishline;
        }

        public List<Pawn> CountActivePawns(User user)
        {
            return user.Pawns.Where(p => p.HasReachedGoal == false).ToList();
        }

        public Pawn GetPawnByID(User user, int pawnID)
        {
            while (true)
            {
                var pawn = PawnByID(user, pawnID);
                if (pawn != null)
                {
                    return pawn;
                }
            }
        }

        public Die RollDie(Die die)
        {
            Random rnd = new Random();
            die.Roll = rnd.Next(1, 7);

            return die;
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

        public void OccupySquare(List<Square> gameBoard, int endSquare)
        {
            var square = gameBoard.Where(sq => sq.SquareNumber == endSquare).FirstOrDefault();

            if (endSquare > 56)
            {
                return;
            }
            square.IsEmpty = false;
        }
    }
}
