using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Library.Models
{
    public class Pawn
    {
        public int PawnID { get; set; }
        public int Position { get; set; }
        public string Color { get; set; }
        public bool HasStarted { get; set; }
        public int Count { get; set; }
        public bool HasReachedGoal { get; set; }
        public Pawn(int PawnID, int Position, string Color)
        {
            this.PawnID = PawnID;
            this.Position = Position;
            this.Color = Color;
            this.HasReachedGoal = false;
        }             
    }
}
