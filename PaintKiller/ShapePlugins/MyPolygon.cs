using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using PaintKiller.AttributeModule;

namespace PaintKiller.ShapePlugins
{
    [ShapeName("Полигон")]
    public class MyPolygon : MyLine
    {
        private Polygon polygon = new Polygon();

        public MyPolygon(Canvas canvas, double x1, double y1, Pen pen = null, Brush brush = null) : base(canvas, x1, y1, pen, brush)
        {
            xStart = x1;
            yStart = y1;

            polygon.Points.Add(new Point(xStart, yStart));
            polygon.Stroke = this.pen.Brush;
            polygon.Fill = this.brush;
            polygon.StrokeThickness = this.pen.Thickness;

        }

        public override void Draw(Canvas canvas)
        {
            canvas.Children.Add(polygon);
        }


        public void AddNewPoint(Point pointToAdd)
        {
            polygon.Points.Add(pointToAdd);
        }
    }
}
