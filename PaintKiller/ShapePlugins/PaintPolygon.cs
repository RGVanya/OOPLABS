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
    public class PaintPolygon : PaintLine
    {
        private Polygon polygon = new Polygon();
        public List<Point> points { get; private set; } = new List<Point>();

        public PaintPolygon(Canvas canvas, double x1, double y1, Pen pen = null, Brush brush = null) : base(canvas, x1, y1, pen, brush)
        {
            polygon.Points.Add(new Point(xStart, yStart));
            init();
        }


        public override void init()
        {
            polygon.Stroke = getPenBrush();
            polygon.Fill = getFillBrush();
            polygon.StrokeThickness = penThickness;
            polygon.Points = new PointCollection(points);
        }
        public override void Draw(Canvas canvas)
        {
            canvas.Children.Add(polygon);
        }


        public void AddNewPoint(Point pointToAdd)
        {
            points.Add(pointToAdd); 
            polygon.Points = new PointCollection(points);
        }
    }
}
