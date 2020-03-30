using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Library.Models
{
    public class User
    {
        public string Name { get; set; }
        List<Pawn> Pawns { get; set; }


        public User(string name)
        {
            this.Name = name;
           
        }
    }
}
