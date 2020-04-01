using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Library.Models
{
    public class UserTurn : IUserTurn
    {
        

        public IUserTurn PlayerRoleDice(User user)
        {
            throw new NotImplementedException();
        }

        public IUserTurn PlayerMovePawn(Pawn pawn, int stepToMove)
        {
            throw new NotImplementedException();
        }
    }
}
