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
            var endSquare = pawnToMove.Position + diceRoll; // Use this when running application 4Reeeeeaaaaall Boooyyy!!!

            Console.WriteLine("DiceRoll: " + diceRoll);

            if (pawnToMove.Color == "Yellow" && pawnToMove.HasStarted == false)
            {
                pawnToMove.Position = 0;
                pawnToMove.HasStarted = true;
            }

            else if (pawnToMove.Color == "Blue" && pawnToMove.HasStarted == false)
            {
                pawnToMove.Position = 13;
                pawnToMove.HasStarted = true;
            }

            else if (pawnToMove.Color == "Red" && pawnToMove.HasStarted == false)
            {
                pawnToMove.Position = 26;
                pawnToMove.HasStarted = true;

            }

            else if (pawnToMove.Color == "Green" && pawnToMove.HasStarted == false)
            {
                pawnToMove.Position = 39;
                pawnToMove.HasStarted = true;
            }

            

            foreach (var item in Squares.Squares)
            {
                if (item.SquareNumber % 57 == 0)
                {
                    Console.WriteLine("Congrats");
                    user.Pawns.Remove(pawnToMove);
                    user.NonActivePawns.Add(pawnToMove);
               }
                else if(item.IsEmpty == false)
                {
                    Console.WriteLine("You wanna push?????");                  
                    Console.ReadKey();
                   
                }
                else
                {                   
                    if (pawnToMove.Position == 57) 
                    {
                        pawnToMove.Position = 0;
                    }

                    pawnToMove.Position += 1;
                    Console.WriteLine("PawnPosition: " + pawnToMove.Position);
                   
                }
            }
            Squares.OccupySquare(Squares, endSquare);

            return pawnToMove;
        }       
    }
}
