using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GameEngine.Library.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public string GameName { get; set; }

        public List<Pawn> Pawns;
        
        public User()
        {

        }

        public User(string name, int PlayerID, List<Pawn> Pawns, string GameName)
        {
            this.PlayerID = PlayerID;
            Name = name;
            this.Pawns = Pawns;
            this.GameName = GameName;
        }

        public Pawn PawnByID(int id)
        {
            return Pawns.Where(p => p.PawnNumber == id).FirstOrDefault();
        }
    }
}
