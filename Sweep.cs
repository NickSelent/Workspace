using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BobNet
{
    public class Sweep
    {
        Line line = new Line();
        Canvas canvas;
        Ellipse radarScreen;


        double X1 = 0;
        double Y1 = 0;

        int centerPoint;
        int u;

        public Sweep(Canvas mainCanvas, Ellipse screen)
        {
            canvas = mainCanvas;
            radarScreen = screen;
            Add();
        }

        private void Add()
        {
            u = 26;
            X1 = radarScreen.Width / 2;
            Y1 = radarScreen.Height / 2;

            centerPoint = (int)radarScreen.Width / 2;

            line.X1 = X1;
            line.Y1 = Y1;
            line.X2 = X1 + (int)(centerPoint * Math.Sin(Math.PI * u / 180));
            line.Y2 = Y1 - (int)(centerPoint * Math.Cos(Math.PI * u / 180));

            SolidColorBrush greenBrush = new SolidColorBrush()
            {
                Color = Colors.Green
            };
            line.StrokeThickness = 1;
            line.Stroke = greenBrush;

            canvas.Children.Add(line);
        }

        public void Move()
        {
            u++;
            line.X2 = X1 + (int)(centerPoint * Math.Sin(Math.PI * u / 180));
            line.Y2 = Y1 - (int)(centerPoint * Math.Cos(Math.PI * u / 180));
        }
    }
}
