using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace TicTacToe.Renderer
{
    public class Display : FrameworkElement
    {
        //IGameModel model;
        int model = 1;
        Size size;

        public void Resize(Size size)
        {
            this.size = size;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (model != null && size.Width > 50 && size.Height > 50)
            {
                double tileLength = size.Height / model; // / model.GameMatrix.GetLength(0);

                drawingContext.DrawRectangle(Brushes.Black, new Pen(Brushes.Black, 0),
                    new Rect(0, 0, tileLength, tileLength));
            }
        }
    }
}
