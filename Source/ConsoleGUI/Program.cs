using GameEngine.Library.Models;
using System;
using System.Linq;
using System.Threading;

namespace ConsoleGUI
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< Updated upstream

            ////////////////////////////////////////////
            ///      Create a new Game/ Match       ///
            //////////////////////////////////////////
            #region Creating new GAME
            var gameBoard = new GameBoard();
            var die = new Die();
            var playerList = User.CreateListOfPlayers(RunGUI.NumberOfPlayers());
            var game = new Game(playerList,gameBoard,die);
=======
            #region Creates an instance of RunGUI,GameInitializer and GameMotor
            var gUI = new RunGUI();
            var gameInitializer = new GameInitializer();
            var gameMotor = new GameMotor();
>>>>>>> Stashed changes
            #endregion
            var numberOfPlayers = gUI.NumberOfPlayers();
            #region Gets name on each player and pawncolor of choice and then add them to GameInitializers list of users
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                string name = gUI.GetAndReturnName();
                gUI.ShowPawnColorMenu();
                var colorOnPawn = gameInitializer.TranslateChoiceToColor(Console.ReadLine());
                var pawns = gameInitializer.CreateListOfPawns(colorOnPawn);
                gameInitializer.AddUserToPlayerList(new User(name, i, pawns));
            }
            #endregion
           
            
<<<<<<< Updated upstream
            bool gameEnd = false;
            while (gameEnd == false)
=======
            var die = gameInitializer.Die;
            gameInitializer.GameBoard.PopulateBoard();
            var gameBoard = gameInitializer.GameBoard;
            bool gameHasEnd = false;
            while (gameHasEnd == false)
>>>>>>> Stashed changes
            {
                for (int i = 0; i < gameInitializer.Users.Count; i++)
                {
                    // Get correct player
<<<<<<< Updated upstream
                    var player = game.PlayerByID(i+1);
                    RunGUI.ShowWhichPlayer(player);
                    //roll the dice
                    var dieResult = game.Dice.RollDice();
                    RunGUI.ShowDie(dieResult);

                    // Show a Menu of pawns => return choosen if not NULL
                    var IDOnPawn = RunGUI.TimeToChoosePawn(player); // Crashes when entering pawnID that no longer exist. 
                    var pawn = game.GetPawnByID(player,IDOnPawn); // This happened after seperating GUI from the logic
=======
                    var player = gameInitializer.PlayerByID(i + 1);
                    gUI.ShowWhichPlayer(player);
                    //roll the dice
                    gameMotor.RollDie(die);

                    gUI.ShowDie(die.Roll);

                    // Show a Menu of pawns => return choosen if not NULL
                    var IDOnPawn = gUI.TimeToChoosePawn(player, gameMotor); // Crashes when entering pawnID that no longer exist. 
                    var pawn = player.PawnByID(IDOnPawn); // This happened after seperating GUI from the logic
>>>>>>> Stashed changes

                    // Time to move pawn, 
                    Pawn.IfNotStartedSetStartPosition(pawn);

<<<<<<< Updated upstream
                    //Creates a new Move
                    var pawnMove = new PawnMove(pawn);
                    //Move Pawn, return landing square
                    var landingSquare = pawnMove.Move(dieResult);
                    RunGUI.WalkWithPawn(pawn, dieResult);

                    // If pawn position is higher than 56, remove and add to a seperate list
                    gameEnd = game.CheckIfReachedGoal(player, pawn, gameEnd);

                    //  Occupie square that pawn ends up on
                    game.GameBoard.OccupySquare(landingSquare);

                    
                    //
=======

                    //Move Pawn, return landing square
                    var landingSquare = gameMotor.Move(pawn, die.Roll);
                    gUI.WalkWithPawn(pawn, die.Roll);

                    // If pawn position is higher than 56, remove and add to a seperate list
                    gameHasEnd = gameMotor.CheckIfReachedGoal(player, pawn);

                    gameMotor.OccupySquare(gameBoard,landingSquare);

>>>>>>> Stashed changes
                }
            }

        }
    }
}
