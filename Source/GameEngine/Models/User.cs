using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GameEngine.Library.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public List<Pawn> Pawns;
      
        
        public User(string name, int PlayerID, List<Pawn> pawns)
        {
            this.PlayerID = PlayerID;
            Name = name;
            //  Pawns = GameInitializer.CreateListOfPawns();
            Pawns = pawns;
            
        }      
    }
}
