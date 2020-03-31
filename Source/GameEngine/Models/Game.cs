using GameEngine.Library.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Library.Models
{
    public class Game: IGame, IUserTurn
    {
        public IUserTurn UserTurn { get; set; }

        public int GameID { get; set; }
        public List<User> Users { get; set; }
        public int GameBoardID { get; set; }
        public GameBoard Squares { get; set; }
        public Dice Dice { get; set; }

        public Game(List<User> Users, GameBoard Squares, Dice Dice)
        {
            this.Users = Users;
            this.Squares = Squares;
            this.Dice = Dice;
        }

        public  IGame StartMatch(List<User> Users, GameBoard Squares, Dice Dice)
        {
            new Game(Users,Squares, Dice);
            return this;
        }

        public IGame RollDice(Dice dice)
        {
            Random rnd = new Random();

            dice.Roll = rnd.Next(1, 7);
            return this;
        }

        public IGame MovePawn(Game game, User user, int diceRoll)
        {
            Console.WriteLine(Squares.Squares.Count);

            var pawnToMove = user.Pawns.FirstOrDefault();

            for (int i = 0; i <= diceRoll; i++)
            {
                Console.WriteLine(pawnToMove.Position += 1);
            }
            Squares.OccupySquare(game);
            return this;
        }

        public IUserTurn Turn()
        {

            return new UserTurn();
        }
    }
}
