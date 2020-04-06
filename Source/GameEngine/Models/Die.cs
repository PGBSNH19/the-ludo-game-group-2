using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Library.Models
{
    public class Die
    {
        private int roll;

        public Die()
        {
            Roll = default;
        }

        public int Roll { get => roll; set => roll = value; }

        public int RollDice()
        {
            Random rnd = new Random();
            Roll = rnd.Next(1, 7);
            
            return Roll;
        }
    }
}
