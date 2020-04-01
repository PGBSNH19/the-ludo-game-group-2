using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Library.Models
{
    public class PawnMove
    {
        public int Moves { get; set; }
        public int PawnID { get; set; }

        public int Move(GameBoard Squares, User user, int diceRoll)
        {
            var pawnToMove = user.Pawns.FirstOrDefault();
            var endSquare = pawnToMove.Position + diceRoll; // Use this when running application 4Reeeeeaaaaall Boooyyy!!!


            Console.WriteLine("DiceRoll: " + diceRoll + "for user" + user.Name);

            if(pawnToMove.HasStarted == false) { 
                pawnToMove.SetStarPosition(pawnToMove);
                //kalla på en metod som get nytt värde
            }
           
            for(int i = pawnToMove.Position; i < endSquare; i++)
            {
                if (pawnToMove.Position == 56)
                {
                    pawnToMove.Position = 0;
                }
                pawnToMove.Position += 1;
                Console.WriteLine("PawnPosition: " + pawnToMove.Position);
            }

            //foreach (var item in Squares.Squares)
            //{
            //    
            //    else if (item.IsEmpty == false)
            //    {
            //        Console.WriteLine("You wanna push?????");
            //        Console.ReadKey();
            //    }
            //    else
            //    {
            //        

            //    }
            //}

            Squares.OccupySquare(Squares, endSquare);

            return endSquare;
        }

        public void CheckIfReachedGoal(User user)
        {

            if (user.Pawns[0].Position % 56 == 0)
            {
                Console.WriteLine($"You reached the finishline with your {user.Pawns[0].PawnID} pawn" );
                user.Pawns.Remove(user.Pawns[0]);
                user.NonActivePawns.Add(user.Pawns[0]);
            }

            if (user.Pawns.Count == 0)
            {
                Console.WriteLine($" {user.Name} won the game!!");
            }

        }
    }
}
