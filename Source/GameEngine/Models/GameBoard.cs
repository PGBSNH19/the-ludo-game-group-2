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

        public void OccupySquare(Game game)
        {
            var squareList = game.Squares.Squares;
            var userList = game.Users;

            var square = squareList
                .Where(sq => userList.Any(u => u.Pawns.Any(p => p.Position == sq.SquareNumber)))
                .FirstOrDefault();

            square.IsEmpty = false;
        }
    }
}
