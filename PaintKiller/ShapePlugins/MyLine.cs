using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace PaintKiller.ShapePlugins
{
    public class MyLine : RectShape
    {
        public MyLine(Canvas canvas, int x1, int y1, int x2, int y2, Pen pen, Brush brush) : base(canvas, x1, y1, x2, y2, pen, brush)
        {
       
        }

        public MyLine(Canvas canvas, int x1, int y1, int x2, int y2, Pen pen) : base(canvas, x1, y1, x2, y2, pen)
        {

        }

        public MyLine(Canvas canvas, int x1, int y1, int x2, int y2, Brush brush) : base(canvas, x1, y1, x2, y2, brush)
        {

        }

        public MyLine(Canvas canvas, int x1, int y1, int x2, int y2) : base(canvas, x1, y1, x2, y2)
        {

        }


        public override void Draw(Canvas canvas)
        {
            System.Windows.Shapes.Line line = new System.Windows.Shapes.Line()
            {
                X1 = 50,
                Y1 = 50,
                X2 = 200,
                Y2 = 200,
                Stroke = this.pen.Brush,
                Fill = this.brush
            };

            canvas.Children.Add(line);
            Canvas.SetLeft(line, 50);
            Canvas.SetTop(line, 50);
        }
    }
}
