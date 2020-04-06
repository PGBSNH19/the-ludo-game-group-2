using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Library.Models
{
    public class User
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public List<Pawn> Pawns;
        public List<Pawn> NonActivePawns = new List<Pawn>();
        public int UserScore { get; set; }

        private User(string name, int numberOfPlayers)
        {
            PlayerID = numberOfPlayers;
            Name = name;
            Pawns = Pawn.GetSetOfPawns();
            UserScore = 0;
        }

        public static List<User> CreateListOfPlayers(int numberOfPlayers)
        {
            var players = new List<User>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.Write("Name: ");
                players.Add(new User(Console.ReadLine(), i+1));
            }

            return players;
        }
    }
}
