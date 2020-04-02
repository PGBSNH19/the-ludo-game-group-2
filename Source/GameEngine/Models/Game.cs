using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Library.Models
{
    public class Game
    {
        private Dice dice;
        private GameBoard gameBoard;
        private List<User> users;

        //public int GameID { get; set; }
        //public int GameBoardID { get; set; }
        public List<User> Users { get => users; set => users = value; }
        public GameBoard GameBoard { get => gameBoard; set => gameBoard = value; }
        public Dice Dice { get => dice; set => dice = value; }


        public Game(List<User> users, GameBoard gameBoard, Dice dice)
        {
            Users = users;
            GameBoard = gameBoard;
            Dice = dice;
        }

        public User GetPlayer(string name)
        {
            return users.Where(u => u.Name == name).FirstOrDefault();
        }

        //public void MoveX(GameBoard gameBoard, User user, Pawn Pawn, int diceRoll)
        //{
        //    var endSquare = Pawn.Position + diceRoll; // Use this when running application 4Reeeeeaaaaall Boooyyy!!!

        //    Console.WriteLine("DiceRoll: " + diceRoll + "for user" + user.Name);

        //    for (int i = 0; i < diceRoll; i++)
        //    {
        //        pawn.Count += diceRoll;
        //        if (pawn.Position == 56)
        //        {
        //            pawn.Position = 0;
        //        }

        //        pawn.Position += 1;
        //        Console.WriteLine("PawnPosition: " + pawn.Position);
        //        pawn.HasStarted = true;
        //    }

        //    Squares.OccupySquare(Squares, endSquare);


        //}
    }
}
