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
<<<<<<< Updated upstream
            Squares = PopulateBoard();
        }

        public List<Square> PopulateBoard()
=======
            Squares = squares;
        }

        public void PopulateBoard()
>>>>>>> Stashed changes
        {
            squares = new List<Square>();
            for (int i = 1; i <= 57; i++)
            {
                squares.Add(new Square(i));
            }
<<<<<<< Updated upstream
            return squares;
        }

        public void OccupySquare(int endSquare)
        {
            var square = squares.Where(sq => sq.SquareNumber == endSquare).FirstOrDefault();

            if (endSquare > 56)
            {
                return;
            }
            square.IsEmpty = false;
=======
>>>>>>> Stashed changes
        }
    }
}
