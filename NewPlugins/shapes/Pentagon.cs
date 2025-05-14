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

namespace Shapes
{
    [ShapeName("Пятиугольник")]
    public class Pentagon : BaseShape
    {
        public double xStart { get; set; }
        public double yStart { get; set; }
        public double radius { get; set; }
        private Polygon polygon = new Polygon();
        public List<Point> points = new List<Point>();
        public Pentagon(Canvas canvas, double x1, double y1, Pen pen = null, Brush brush = null) : base(canvas, pen, brush)
        {
            xStart = x1;
            yStart = y1;
            radius = 30;
            init();
        }  

        public override void UpdateShape(Canvas canvas, double new_x, double new_y)
        {
            radius = Math.Sqrt(Math.Pow(new_x - xStart, 2) + Math.Pow(new_y - yStart, 2));
            points.Clear();
            for (int i = 0; i < 5; i++)
            {
                double angle = 2 * Math.PI * i / 5 + 60;
                double x = xStart + radius * Math.Cos(angle);
                double y = yStart + radius * Math.Sin(angle);
                points.Add(new Point(x, y));
            }
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
