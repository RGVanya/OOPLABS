using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using PaintKiller.AttributeModule;

namespace PaintKiller.ShapePlugins
{
    [ShapeName("Ломанная")]
    public class MyPolyline : MyLine
    {
        private Polyline polyline = new Polyline();

        public MyPolyline(Canvas canvas, double x1, double y1, Pen pen = null, Brush brush = null) : base(canvas, x1, y1, pen, brush)
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

