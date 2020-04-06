using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Library.Models
{
    public class GameBoard
    {
        private List<Square> squares;

        public List<Square> Squares { get => squares; set => squares = value; }

        public GameBoard()
        {
            Squares = squares;
        }

        public void PopulateBoard()
        {
            squares = new List<Square>();
            for (int i = 1; i <= 57; i++)
            {
                squares.Add(new Square(i));
            }
        }
    }
}
