using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Library.Models
{
    public class Die
    {
        private int roll;
        public int Roll { get => roll; set => roll = value; }

        public Die()
        {
            Roll = default;
        }
         
    }
}
