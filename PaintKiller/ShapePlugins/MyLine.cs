using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PaintKiller.ShapePlugins
{
    public class MyLine : BaseShape
    {

        protected double xStart;
        protected double yStart;
        protected double xEnd;
        protected double yEnd;
        System.Windows.Shapes.Line line = new System.Windows.Shapes.Line();

        public MyLine(Canvas canvas, double x1, double y1, double x2, double y2, Pen pen = null, Brush brush = null) : base(canvas, pen, brush)
        {
            this.xStart = x1;
            this.yStart = y1;
            this.xEnd = x2;
            this.yEnd = y2;

            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = this.pen.Brush;
            line.Fill = this.brush;
        }


        public override void Draw(Canvas canvas)
        {

            canvas.Children.Add(line);
            //Canvas.SetLeft(line, xStart);
            //Canvas.SetTop(line, yStart);
        }

        public override void UpdateShape(Canvas canvas, double new_x, double new_y)
        {
            line.X2 = new_x;
            line.Y2 = new_y;
            xStart = new_x;
            yStart = new_y;
        }


        private void PositionSet(double x1, double x2, double y1, double y2)
        {

            if (x2 < x1)
            {
                xStart = x2;
            }
            else
            {
                xStart = x1;
            }

            if (y2 < y1)
            {
                yStart = y2;
            }
            else
            {
                yStart = y1;
            }
        }
    }
}
