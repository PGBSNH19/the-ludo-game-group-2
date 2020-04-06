using GameEngine.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Library
{
    public class GameInitializer
    {
        private List<User> users;

        //private List<User> users;

        public List<User> Users { get => users; set => users = value; }
        public Die Die { get; set; }
        public GameBoard GameBoard { get; set; }

        public GameInitializer()
        {
            Users = new List<User>();
            Die = new Die();
            GameBoard = new GameBoard();
        }

        public void AddUserToPlayerList(User user)
        {
            users.Add(user);
        }

        public User PlayerByID(int playerID)
        {
            return users.Where(u => u.UserID == playerID).FirstOrDefault();
        }

        public List<Pawn> CreateListOfPawns(string color)
        {

            List<Pawn> pawns = new List<Pawn>();
            for (int i = 1; i <= 4; i++)
            {
                var pawn = new Pawn(i, default, color);
                pawns.Add(pawn);
            }
            return pawns;
        }

        public string TranslateChoiceToColor(string userChoice)
        {
            return userChoice switch
            {
                "1" => "Blue",
                "2" => "Green",
                "3" => "Red",
                "4" => "Yellow",
                _ => "Gold"
            };
        }

        public static void SetStartPosition(Pawn pawn)
        {
            pawn.Position = pawn.Color switch
            {
                "Red" => 0,
                "Yellow" => 10,
                "Green" => 20,
                "Blue" => 30,
                _ => 0
            };
        }

        public void IfNotStartedSetStartPosition(Pawn pawn)
        {
            if (pawn.HasStarted == false)
            {
                SetStartPosition(pawn);
                pawn.HasStarted = true;
            }
        }
    }
}
