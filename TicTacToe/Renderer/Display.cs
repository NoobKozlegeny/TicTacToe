using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TicTacToe.Logic;

namespace TicTacToe.Renderer
{
    public class Display : FrameworkElement
    {
        IGameModel model;
        Size size;

        public void Resize(Size size)
        {
            this.size = size;
        }

        public void SetupModel(IGameModel model)
        {
            this.model = model;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (model != null && size.Width > 50 && size.Height > 50)
            {
                double rectWidth = size.Width / model.GameMatrix.GetLength(1);
                double rectHeight = size.Height / model.GameMatrix.GetLength(0);

                drawingContext.DrawRectangle(Brushes.Black, new Pen(Brushes.Black, 0),
                    new Rect(0, 0, rectWidth, rectHeight));

                for (int i = 0; i < model.GameMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < model.GameMatrix.GetLength(1); j++)
                    {
                        ImageBrush imageBrush = new ImageBrush();
                        switch (model.GameMatrix[i, j])
                        {
                            case "X":
                                imageBrush = new ImageBrush(
                                    new BitmapImage(new Uri(Path.Combine("img", "X.bmp"), UriKind.RelativeOrAbsolute)));
                                break;
                            case "0":
                                imageBrush = new ImageBrush(
                                    new BitmapImage(new Uri(Path.Combine("img", "O.bmp"), UriKind.RelativeOrAbsolute)));
                                break;
                            default:
                                imageBrush = new ImageBrush(
                                    new BitmapImage(new Uri(Path.Combine("img", "nothing.bmp"), UriKind.RelativeOrAbsolute)));
                                break;
                        }

                        drawingContext.DrawRectangle(imageBrush
                                    , new Pen(Brushes.Black, 0),
                                    new Rect(j * rectWidth, i * rectHeight, rectWidth, rectHeight)
                                    );
                    }
                }
            }
        }
    }
}
