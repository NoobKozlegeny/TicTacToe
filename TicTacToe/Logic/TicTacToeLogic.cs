using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Logic
{
    public class TicTacToeLogic : IGameModel, IGameControl
    {
        static Random r = new Random();
        public string[,] GameMatrix { get; set; }

        public TicTacToeLogic()
        {
            GameMatrix = new string[3, 3];
        }

        public void Click(int x, int y)
        {
            GameMatrix[x, y] = "X";
        }

        public void AIMove()
        {
            bool MovedRight = false;
            while (!MovedRight)
            {
                int randX = r.Next(0, 4);
                int randY = r.Next(0, 4);

                if (GameMatrix[randX,randY]==null)
                {
                    GameMatrix[randX, randY] = "O";
                    MovedRight = true;
                }
            }
        }
    }
}
