using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Library.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public List<User> Users { get; set; }
        public int GameBoardID { get; set; }
        public GameBoard Squares { get; set; }

        public Game(List<User> users, GameBoard gameBoard)
        {
            Users = users;
            Squares = gameBoard;
        }        
    }
}
