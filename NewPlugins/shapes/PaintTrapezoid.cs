using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseShapeModule;
using AttributeModule;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace NewPlugins.shapes
{
    [ShapeName("Трапеция")]
    public class PaintTrapezoid : BaseShape
    {
        private Polygon polygon = new Polygon();
        public List<Point> points = new List<Point>();
        public double xStart { get; set; }
        public double yStart { get; set; }
        public double radius { get; set; }

        public PaintTrapezoid(Canvas canvas, double x1, double y1, Pen pen = null, Brush brush = null) : base(canvas, pen, brush)
        {
            xStart = x1;
            yStart = y1;
            radius = 0;
            init();
        }

        public override void UpdateShape(Canvas canvas, double new_x, double new_y)
        {

            radius = Math.Sqrt(Math.Pow(new_x - xStart, 2) + Math.Pow(new_y - yStart, 2));
            points.Clear();
            points.Add(new Point(xStart - radius, yStart - radius - 0.1 * radius));
            points.Add(new Point(xStart + radius, yStart - radius - 0.1 * radius));
            points.Add(new Point(xStart + 1.7 * radius, yStart + radius + 0.1 * radius));
            points.Add(new Point(xStart - 1.7 * radius, yStart + radius + 0.1 * radius));
            polygon.Points = new PointCollection(points);
        }

        public override void init()
        {
            polygon.Stroke = getPenBrush();
            polygon.Fill = getFillBrush();
            polygon.Points = new PointCollection(points);
            polygon.StrokeThickness = penThickness;
        }

        public override void Draw(Canvas canvas)
        {
            canvas.Children.Add(polygon);
        }

    }
}
