using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Library.Models
{
    public class User
    {
        public string Name { get; set; }
        public List<Pawn> Pawns;

        private User(string name)
        {
            Name = name;
            Pawns = Pawn.GetSetOfPawns();
        }

        //private User CreatePlayer(string name) => (new User(name));

        public static List<User> GetPlayersAndName(int numberOfPlayers)
        {
            var players = new List<User>();
            for (int i = 0; i < numberOfPlayers; i++)
            {

                Console.Write("Name: ");
                //var user = new User().CreatePlayer(Console.ReadLine());
                //players.Add(CreatePlayer(Console.ReadLine()));
                players.Add(new User(Console.ReadLine()));
            }

            return players;
        }
    }
}
