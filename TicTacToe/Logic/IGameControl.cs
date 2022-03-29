namespace TicTacToe.Logic
{
    public interface IGameControl
    {
        void Click(int x, int y);
        void AIMove();
    }
}