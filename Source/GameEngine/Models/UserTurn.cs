using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Library.Models
{
    public class UserTurn : IUserTurn
    {
        public List<User> Users { get; set; }
        public GameBoard GameBoard { get; set; }
        public Dice Dice { get; set; }
    }
}
