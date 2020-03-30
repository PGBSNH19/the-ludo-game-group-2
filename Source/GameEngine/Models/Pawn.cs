using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Library.Models
{
    public class Pawn
    {
        public int Position { get; set; }
        public string Color { get; set; }
        public int SquareID { get; set; }
        public int UserID { get; set; }
    }
}
