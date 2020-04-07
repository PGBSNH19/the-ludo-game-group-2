using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Library.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public List<Pawn> Pawns;
        public int UserScore { get; set; }

        public User(string name, int idOfPlayer)
        {
            UserID = idOfPlayer;
            Name = name;
            Pawns = GameInitializer.CreateListOfPawns();
            UserScore = 0;
        }

        public Pawn PawnByID(int id)
        {
            return Pawns.Where(p => p.PawnID == id).FirstOrDefault();
        }
    }
}
