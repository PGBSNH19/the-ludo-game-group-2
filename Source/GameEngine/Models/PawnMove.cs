using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Library.Models
{
    public class PawnMove
    {
        private Pawn pawn;
        public Pawn Pawn { get => pawn; set => pawn = value; }

        public PawnMove(Pawn pawn)
        {
            Pawn = pawn;
        }

        public int Move(int dieRoll)
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
    }
}
