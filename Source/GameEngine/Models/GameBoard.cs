﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Library.Models
{
    public class GameBoard
    {
        private List<Square> squares;

        public List<Square> Squares { get => squares; set => squares = value; }

        public GameBoard()
        {
            Squares = PopulateBoard();
        }

        public List<Square> PopulateBoard()
        {
            squares = new List<Square>();
            for (int i = 1; i <= 57; i++)
            {
                squares.Add(new Square(i));
            }
            return squares;
        }

        // Maybe move to game? 
        public void OccupySquare(/*GameBoard gameBoard,*/ int endSquare)
        {
            var square = squares.Where(sq => sq.SquareNumber == endSquare).FirstOrDefault();

            if (endSquare > 56)
            {
                return;
            }
            square.IsEmpty = false;
            //Console.WriteLine($"Squarenumber {square.SquareNumber} is set to empty: {square.IsEmpty}");
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("--------------------------------------------------------------------------------------------");

        }
    }
}
