using GameEngine.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine.Library
{
    public class GameInitializer
    {
        public List<User> Users { get; set; }
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
            Users.Add(user);
        }


        public User PlayerByID(int playerID)
        {
            return Users.Where(u => u.PlayerID == playerID).FirstOrDefault();
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

        public List<Square> PopulateBoard()
        {
            GameBoard.Squares = new List<Square>();
            for (int i = 1; i <= 57; i++)
            {
                GameBoard.Squares.Add(new Square(i));
            }
            return GameBoard.Squares;
        }
    }
}
