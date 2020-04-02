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

        Pawn pawn = new Pawn(1, 30, "red");

        var okToMove = CheckIfItFits(pawn, 4);

        CheckIfResetIsNeeded(okToMove);

        Move();

        public static Pawn Move(GameBoard Squares, User user, Pawn pawn, int diceRoll)
        {
            var endSquare = pawn.Position + diceRoll; // Use this when running application 4Reeeeeaaaaall Boooyyy!!!

            Console.WriteLine("DiceRoll: " + diceRoll + "for user" + user.Name);

            for(int i = 0; i < diceRoll; i++)
            {
                pawn.Count += diceRoll;
                if (pawn.Position == 56)
                {
                    pawn.Position = 0;
                }
                
                pawn.Position += 1;
                Console.WriteLine("PawnPosition: " + pawn.Position);
                pawn.HasStarted = true;
            }

            Squares.OccupySquare(Squares, endSquare);
            
            return pawn;
        }

        public bool CheckIfItFits(Pawn pawn, int diceRoll)
        {
            if (56 % pawn.Count + 0.0 == 1)
            {
                Console.WriteLine("You have to stop at 56\n");
                return false;
            }
            else
            {
                return true;
            }
        }

        public void CheckIfReachedGoal(User user, Pawn pawn)
        {

            if (pawn.Count == 56)
            {
                user.Pawns.Remove(pawn);
                user.NonActivePawns.Add(pawn);
                Console.WriteLine($"You reached the finishline with your {pawn.PawnID} pawn");
            }

        }
        
        public static int GetUserChoice()
        {
            Console.WriteLine("1. Walk unWalked Pawn");
            Console.WriteLine("2. Choose Pawn");
            var choice= Console.ReadLine();
            return Convert.ToInt32(choice);
        }
        
        public static User ValidateUserPawn(User user, int choice, GameBoard gameBoard, int diceRoll)
        {
            var pawnMove = new PawnMove();
            switch (choice)
            {
                case 1:
                    var pawn = user.Pawns.Where(p => p.HasStarted == false).FirstOrDefault();
                    pawn.SetStartPosition(pawn);
                    Move(gameBoard, user, pawn, diceRoll);

                    break;
                case 2:
                    Console.WriteLine("1. Pawn 1");
                    Console.WriteLine("2. Pawn 2");
                    Console.WriteLine("3. Pawn 3");
                    Console.WriteLine("4. Pawn 4");
                    var pawnChoice = Console.ReadLine();
                    pawn = user.Pawns.Where(p => p.PawnID== Convert.ToInt32(pawnChoice)).FirstOrDefault();
                    Move(gameBoard, user, pawn, diceRoll);
                    pawnMove.CheckIfReachedGoal(user,
                        user.Pawns.Where(p => p.PawnID == Convert.ToInt32(pawnChoice)).FirstOrDefault());
                    break;
                default:
                    break;
            }

            return user;
        }
    }
}
