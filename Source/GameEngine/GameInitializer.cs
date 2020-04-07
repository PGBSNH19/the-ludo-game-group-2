using GameEngine.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Library
{
    public class GameInitializer
    {
        //private List<User> users;

        private List<User> Users { get; set; }
        public Die Die { get; set; }
        public GameBoard GameBoard { get; set; }
        
        public GameInitializer()
        {
            Users = new List<User>();
            Die = new Die();
            GameBoard = new GameBoard();
        }

        public List<User> CreateListOfPlayers(int numberOfPlayers)
        {
            var players = new List<User>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.Write("Name: ");
                players.Add(new User(Console.ReadLine(), i + 1));
            }

            return players;
        }

        public User PlayerByID(List<User> users, int playerID)
        {
            return users.Where(u => u.PlayerID == playerID).FirstOrDefault();
        }

        public static List<Pawn> CreateListOfPawns()
        {
            ShowPawnColorMenu();

            var color = TranslateChoiceToColor(Console.ReadLine());
            List<Pawn> pawns = new List<Pawn>();
            for (int i = 1; i <= 4; i++)
            {
                var pawn = new Pawn(i, default, color);
                pawns.Add(pawn);
            }
            return pawns;
        }

        private static void ShowPawnColorMenu()
        {
            Console.WriteLine();
            Console.WriteLine($"1. Blue");
            Console.WriteLine($"2. Green");
            Console.WriteLine($"3. Red");
            Console.WriteLine($"4. Yellow");
            Console.WriteLine();
        }

        private static string TranslateChoiceToColor(string userChoice)
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
