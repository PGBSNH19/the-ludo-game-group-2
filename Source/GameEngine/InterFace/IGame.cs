using GameEngine.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Library.InterFace
{
    public interface IGame
    {
        //public IGame StartMatch(int numberOfPlayers);
        public IGame RollDice();
        //public IGame MovePawn(GameBoard gameBoard, User user, int diceRoll);
        public IUserTurn Turn();
    }
}
