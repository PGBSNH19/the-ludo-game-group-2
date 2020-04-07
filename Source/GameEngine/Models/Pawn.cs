using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Library.Models
{
    public class Pawn
    {
        public int PawnID { get; set; }
        public int PawnNumber { get; set; }
        public int Position { get; set; }
        public string Color { get; set; }
        public bool HasStarted { get; set; }
        public int Count { get; set; }
        public bool HasReachedGoal { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }

        public Pawn(int PawnNumber, int Position, string Color)
        {
            this.PawnNumber = PawnNumber;
            this.Position = Position;
            this.Color = Color;
            this.HasReachedGoal = false;
        }
    }
}
