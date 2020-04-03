using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Library.Models
{
    public class Dice
    {
        private int roll;

        public Dice()
        {
            Roll = default;
        }

        public int Roll { get => roll; set => roll = value; }

        public int RollDice()
        {
            Random rnd = new Random();
            Roll = rnd.Next(1, 7);
            Console.WriteLine($"Lets roll the dice! Result: {Roll}");
            
            return Roll;
        }
    }
}
