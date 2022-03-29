using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using TicTacToe.Logic;

namespace TicTacToe.Controller
{
    public class GameController
    {
        IGameControl control;

        public GameController(IGameControl control)
        {
            this.control = control;
        }

        public void MousePressed(int x, int y, double gridHeight, double gridWidth)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                control.Click(
                    ConvertCoordToX(y, gridHeight),
                    ConvertCoordToY(x, gridWidth)
                    );
            }
        }

        private int ConvertCoordToX(int coord, double gridHeight)
        {
            //double heightSep = gridHeight / 3;
            double heightSep = gridHeight / 3;

            if (coord < heightSep)
            {
                return 0;
            }
            else if (coord < (heightSep * 2))
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        private int ConvertCoordToY(int coord, double gridWidth)
        {
            //double heightSep = gridHeight / 3;
            double widthSep = gridWidth / 3;

            if (coord < widthSep)
            {
                return 0;
            }
            else if (coord < (widthSep * 2))
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}
