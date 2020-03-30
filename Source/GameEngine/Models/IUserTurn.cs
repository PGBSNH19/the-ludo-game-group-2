namespace GameEngine.Library.Models
{
    public interface IUserTurn
    {
        IUserTurn PlayerRoleDice(User user);
        IUserTurn PlayerMovePawn(Pawn pawn, int stepToMove);
    }
}