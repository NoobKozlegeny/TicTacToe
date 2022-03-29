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
            if (!IsAITheWinner() && !IsPlayerTheWinner())
            {
                GameMatrix[x, y] = "X";
                AIMove();
            }
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
        public bool IsX(int x, int y)
        {
            return GameMatrix[x, y] == "X" ? true : false;
        }
        public bool IsO(int x, int y)
        {
            return GameMatrix[x, y] == "O" ? true : false;
        }

        public bool IsPlayerTheWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (IsX(i,0) && IsX(i,1) && IsX(i,2))
                {
                    return true;
                }
            }
            for (int j = 0; j < 3; j++)
            {
                if (IsX(0,j) && IsX(1,j) && IsX(2,0))
                {
                    return true;
                }
            }
            if(IsX(0,0) && IsX(1,1) && IsX(2,2))
            {
                return true;
            }
            else if (IsX(0,2) && IsX(1,1) && IsX(2,0))
            {
                return true;
            }
            return false;
        }
        public bool IsAITheWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (IsO(i, 0) && IsO(i, 1) && IsO(i, 2))
                {
                    return true;
                }
            }
            for (int j = 0; j < 3; j++)
            {
                if (IsO(0, j) && IsO(1, j) && IsO(2, 0))
                {
                    return true;
                }
            }
            if (IsO(0, 0) && IsO(1, 1) && IsO(2, 2))
            {
                return true;
            }
            else if (IsO(0, 2) && IsO(1, 1) && IsO(2, 0))
            {
                return true;
            }
            return false;
        }
    }
}
