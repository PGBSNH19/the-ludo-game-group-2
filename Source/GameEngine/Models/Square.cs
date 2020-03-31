using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Library.Models
{
    public class Square
    {
        public int SquareID { get; set; }
        public int SquareNumber { get; set; }
        public int GameBoardID { get; set; }
        public bool IsEmpty { get; set; }

        public Square(int number)
        {
            SquareNumber = number;
            IsEmpty = true;
        }

        
    }
}
