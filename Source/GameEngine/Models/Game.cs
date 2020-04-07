using GameEngine.Library.Context;

namespace GameEngine.Library.Models
{
    public class Game
    {         
        private GameInitializer gameInitializer;   
        public GameInitializer GameInitializer { get => gameInitializer; set => gameInitializer = value; }

        public Game(GameInitializer gameInitializer)
        {
            GameInitializer = gameInitializer;    
        }
    }
}
