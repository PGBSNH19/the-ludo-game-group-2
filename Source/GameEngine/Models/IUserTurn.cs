using System.Collections.Generic;

namespace GameEngine.Library.Models
{
    public interface IUserTurn
    {
        public List<User> Users { get; set; }
        public GameBoard GameBoard { get; set; }
        public Dice Dice { get; set; }

    }
}