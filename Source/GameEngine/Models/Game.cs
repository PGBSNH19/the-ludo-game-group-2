using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;

namespace GameEngine.Library.Models
{
    public class Game
    {         
        private GameInitializer gameInitializer;       
        [NotMapped]        
        public GameInitializer GameInitializer { get => gameInitializer; set => gameInitializer = value; }

        public Game(GameInitializer gameInitializer)
        {
            GameInitializer = gameInitializer;
                     
        }             
    }
}
