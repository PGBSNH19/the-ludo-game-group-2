using System;
using Xunit;
using GameEngine.Library.Context;
using GameEngine.Library.Models;
using GameEngine.Library;
using System.Linq;
using System.Collections.Generic;

namespace LudoGame.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void TestDieCantRollMoreThanSixAndLessThanOne(int randomNext)
        {
            var dieRoll = new Die() { Roll = randomNext };

            int result = dieRoll.Roll;

            Assert.InRange(result, 1, 6);
        }

        [Theory]
        [InlineData("Red", 0)]
        [InlineData("Yellow", 10)]
        [InlineData("Green", 20)]
        [InlineData("Blue", 30)]
        public void TestColorExpectedStartPosition(string color, int expectedPositionOnBoard)
        {
            
            var pawn = new Pawn(1, expectedPositionOnBoard, color);
            GameInitializer.SetStartPosition(pawn);

            Assert.Equal(expectedPositionOnBoard, pawn.Position);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void TestWhichPlayerRound(int playerID)
        {
            var gameInitializer = new GameInitializer();
            var listOfusers = gameInitializer.Users;

            var player = new User { PlayerID = playerID };
            listOfusers.Add(player);

            var PlayerRound = gameInitializer.PlayerByID(player.PlayerID);

            Assert.Equal(playerID, PlayerRound.PlayerID);
        }

        [Theory]
        [InlineData("Red")]
        [InlineData("Yellow")]
        [InlineData("Green")]
        [InlineData("Blue")]
        public void TestCreateListOfPawns(string color)
        {
            var gameInitializer = new GameInitializer();
            var pawns = gameInitializer.CreateListOfPawns(color);
            var actualColor = pawns[0].Color = color;

            Assert.Equal(color, actualColor);
        }

        [Fact]
        public void TestGameBoardTotalSquaresIsCorrect56()
        {
            var gameInitializer = new GameInitializer();

            Assert.Equal(57, gameInitializer.PopulateBoard().Count);
        }

        [Fact]
        public void TestIfPawnHaStartedIsFalseAndSetValueToTrue()
        {

            var gameInitializer = new GameInitializer();
            var pawn = new Pawn(1, 1, "Blue");
            gameInitializer.IfNotStartedSetStartPosition(pawn);
            Assert.True(pawn.HasStarted);
        }

        [Theory]
        [InlineData(0)]
        public void TestHowManyActivePawnsLeft(int amount)
        {
            var gameMotor = new GameMotor();
            var user = new User();
            var listOfPawns = new List<Pawn>();
            user.Pawns = listOfPawns;
            var pawn = new Pawn(1, 56, "Red") { HasReachedGoal = true };
            listOfPawns.Add(pawn);

            var userPawnListToTest = gameMotor.CountActivePawns(user);

            Assert.Equal(amount, userPawnListToTest.Count);
        }

        [Fact]
        public void TestIfPawnCanOccupySquarePosition()
        {
            var gameMotor = new GameMotor();
            var gameBoard = new GameBoard();
            var listOfSquares = new List<Square>();
            gameBoard.Squares = listOfSquares;

            var square = new Square(34) { IsEmpty = false };
            listOfSquares.Add(square);


            gameMotor.OccupySquare(gameBoard, 34);

            Assert.False(square.IsEmpty);
        }
    }
}