using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace PaintKiller.ShapePlugins
{
    public class MyPolygon : MyLine
    {
        //private List<Point> points = new List<Point>();
        private Point newPoint;
        private Polygon polygon = new Polygon();

        public MyPolygon(Canvas canvas, double x1, double y1, double x2, double y2, Pen pen = null, Brush brush = null) : base(canvas, x1, x2, y1, y2, pen, brush)
        {
            xStart = x1;
            yStart = y1;
            //newPoint = new Point(xStart, yStart);
            //points.Add(newPoint);

            polygon.Points.Add(new Point(xStart, yStart));
            polygon.Stroke = this.pen.Brush;
            polygon.Fill = this.brush;
            polygon.StrokeThickness = this.pen.Thickness;

        }

        public override void Draw(Canvas canvas)
        {
            canvas.Children.Add(polygon);
        }
        public override void UpdateShape(Canvas canvas, double new_x, double new_y)
        {
        }

        public void AddNewPoint(Point pointToAdd)
        {
            newPoint = pointToAdd;
            polygon.Points.Add(pointToAdd);
        }
    }
}
