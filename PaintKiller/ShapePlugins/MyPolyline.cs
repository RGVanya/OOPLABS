using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaintKiller.ShapePlugins
{
    public class MyPolyline : MyLine
    {
        private Polyline polyline = new Polyline();

        public MyPolyline(Canvas canvas, double x1, double y1, double x2, double y2, Pen pen = null, Brush brush = null) : base(canvas, x1, x2, y1, y2, pen, brush)
        {
            xStart = x1;
            yStart = y1;

            polyline.Points.Add(new Point(xStart, yStart));
            polyline.Stroke = this.pen.Brush;
            polyline.Fill = this.brush;
            polyline.StrokeThickness = this.pen.Thickness;

        }

        public override void Draw(Canvas canvas) 
        { 
            canvas.Children.Add(polyline);
        }

        public void AddNewPoint(Point pointToAdd) 
        {
            polyline.Points.Add(pointToAdd);
        }

    }
}

