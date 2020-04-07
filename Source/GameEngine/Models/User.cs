using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace GameEngine.Library.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public int PlayerID { get; set; }
        public string Name { get; set; }

        public ICollection<Pawn> Pawns;
        
        public User()
        {

        }

        public User(string name, int PlayerID, ICollection<Pawn> Pawns)
        {
            this.PlayerID = PlayerID;
            Name = name;
            this.Pawns = Pawns;
        }

        public Pawn PawnByID(int id)
        {
            return Pawns.Where(p => p.PawnNumber == id).FirstOrDefault();
        }
    }
}
