using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Library.Models
{
    public class GameBoard
    {
        public List<Square> Squares { get; set; }

        public GameBoard()
        {
            Squares = PopulateBoard();
        }

        public static List<Square> PopulateBoard()
        {
            var list = new List<Square>();
            for (int i = 1; i <= 57; i++)
            {
                list.Add(new Square(i));
            }
            return list;
        }

        public void OccupySquare(GameBoard gameBoard, int endSquare)
        {
            var square = gameBoard.Squares.Where(sq => sq.SquareNumber == endSquare).FirstOrDefault();
            square.IsEmpty = false;
        }
    }
}
