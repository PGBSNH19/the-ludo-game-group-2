using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GameEngine.Library.Models
{
    public class Pawn
    {
        //[Key]
        //public int ID { get; set; }     
        public int PawnID { get; set; }
        public int PawnColorID { get; set; }       
        public int Position { get; set; }
        public string Color { get; set; }
        public bool HasStarted { get; set; }
        public int Count { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }
        public bool HasReachedGoal { get; set; }
        public Pawn(int PawnID, int Position, string Color)
        {
            this.PawnColorID = PawnID;
            this.Position = Position;
            this.Color = Color;
            this.HasReachedGoal = false;
        }             
    }
}
