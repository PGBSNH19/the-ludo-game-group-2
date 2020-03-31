using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Library.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public List<User> Users { get; set; }
        public int GameBoardID { get; set; }
        public GameBoard Squares { get; set; }

        public Game(List<User> users, GameBoard gameBoard)
        {
            Users = users;
            Squares = gameBoard;
        }

        public Pawn MovePawn(GameBoard Squares, User user, int diceRoll)
        {
            var pawnToMove = user.Pawns.FirstOrDefault();

            Console.WriteLine("DiceRoll: " + diceRoll);

            var endSquare =pawnToMove.Position + diceRoll; // Use this when running application 4Reeeeeaaaaall Boooyyy!!!


            foreach (var item in Squares.Squares)
            {
                if (item.SquareNumber % 57 == 0)
                {
                    Console.WriteLine("Congrats");
                }
                else if(item.IsEmpty == false)
                {
                    Console.WriteLine("You wanna push?????");
                    Console.ReadKey();
                }
                else
                {
                    pawnToMove.Position += 1;
                    Console.WriteLine("PawnPosition: " + pawnToMove.Position);
                    Squares.OccupySquare(Squares, pawnToMove);
                }
            }

            return pawnToMove;
        }
    }
}
