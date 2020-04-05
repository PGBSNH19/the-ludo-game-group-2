using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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

        public User PlayerByID(int playerID)
        {
            var user= users.Where(u => u.PlayerID == playerID).FirstOrDefault();
            Console.WriteLine($"Player ID: {user.PlayerID} Name: {user.Name}");
            return user;
        }

        private Pawn PawnByID(User user, int id)
        {
            var pawn = user.Pawns.Where(p => p.PawnID == id).FirstOrDefault();
            return pawn;
        }

        public bool CheckIfReachedGoal(User user, Pawn pawn, bool finishline)
        {
            if (pawn.Count == 56)
            {
                user.Pawns.Remove(pawn);
                user.NonActivePawns.Add(pawn);
                Console.WriteLine($"You reached the finishline with your {pawn.PawnID} pawn");
                Console.WriteLine($"NonActive: {user.NonActivePawns.Count}");
                finishline = false;
            }
            if (user.Pawns.Count==0)
            {
                Console.WriteLine("Congrats you won!");
                finishline = true;
            }
            return finishline;
        }

        public Pawn GetPawnByMenu(User user)
        {
            while (true)
            {
                var pawnID = PawnMove.PawnMenu(user);
                var pawn = PawnByID(user, pawnID);
                if (pawn != null)
                {
                    return pawn;
                }
            }
        }
    }
}
