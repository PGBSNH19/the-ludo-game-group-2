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

        public static int Move(GameBoard Squares,User user, Pawn pawn, int diceRoll)
        {
            var pawnToMove = user.Pawns.FirstOrDefault();
            var endSquare = pawnToMove.Position + diceRoll; // Use this when running application 4Reeeeeaaaaall Boooyyy!!!


            Console.WriteLine("DiceRoll: " + diceRoll + "for user" + user.Name);

            //if(pawnToMove.HasStarted == false) { 
            //    pawnToMove.SetStarPosition(pawnToMove);
            //    //kalla på en metod som get nytt värde
            //}
           
            for(int i = pawn.Position; i < endSquare; i++)
            {
                if (pawn.Position == 56)
                {
                    pawn.Position = 0;
                }
                else if (endSquare > 56)
                {
                    Console.WriteLine("You have to stop at 56\n");
                    return 0;
                }
                pawn.Position += 1;
                Console.WriteLine("PawnPosition: " + pawn.Position);
                pawn.HasStarted = true;
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
                try
                {
                    user.Pawns.Remove(user.Pawns[0]);
                    user.NonActivePawns.Add(user.Pawns[0]);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                    Console.ReadKey();
                }
                finally
                {
                    Console.WriteLine($" {user.Name} reached end with one pawn!!");
                }
                
            }

            //if (user.Pawns.Count == 0)
            //{
            //    Console.WriteLine($" {user.Name} won the game!!");
            //}

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
                    Move(gameBoard, user,pawn, diceRoll);
                    break;
                default:
                    break;
            }

            return user;
        }
    }
}
