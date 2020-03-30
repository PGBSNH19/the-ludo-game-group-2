using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Library.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public List<User> Users { get; set; }
        public int GameBoardID { get; set; }
        public GameBoard GameBoard { get; set; }
    }
}
