using GameEngine.Library.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Library.Models
{
    public class Game : IGame, IUserTurn
    {
        public IUserTurn UserTurn { get; set; }

        public int GameID { get; set; }
        public User User { get => user; set => user = value; }
        public List<User> Users { get => users; set => users = value; }
        public int GameBoardID { get => gameBoardID; set => gameBoardID = value; }
        public GameBoard GameBoard { get => gameBoard; set => gameBoard = value; }
        public Dice Dice { get => dice; set => dice = value; }

        //Use private variables to be able to reach them in the below methods. 
        // Step 1. Create private variables for every instance  you need.
        // Step 2. Instansiate every class that will be used as a parameter.
        // Step 3. Dont forget to change below code to private variables.
        private int diceResult; // ta bort denna?
        private User user;
        private List<User> users;
        private int gameBoardID;
        private GameBoard gameBoard;
        private Dice dice;

        public Game(int numberOfPlayers)
        {
            Users = User.GetPlayersAndName(numberOfPlayers);
            GameBoard = GameBoard;
            Dice = Dice;
        }

        //public IGame StartMatch(int numberOfPlayers)
        //{
        //    new Game(numberOfPlayers);
        //    return this;
        //}

        public IGame RollDice(Dice dice)
        {
            diceResult = dice.RollDice();
            return this;
        }

        //public IGame MovePawn(GameBoard gameBoard, User user, int diceRoll)
        public IGame MovePawn(Game game)
        {
            Console.WriteLine(GameBoard.Squares.Count);

            var pawnToMove = game.User.Pawns.FirstOrDefault();

            for (int i = 0; i <= game.Dice.Roll; i++)
            {
                Console.WriteLine(pawnToMove.Position += 1);
            }
            game.GameBoard.OccupySquare(game.GameBoard, pawnToMove);
            return this;
        }

        public IUserTurn Turn()
        {

            return new UserTurn();
        }
    }
}
