using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttributeModule;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using BaseShapeModule;

namespace EditorTools.Shapes
{
    [ShapeName("Ломанная")]
    public class PaintPolyline : PaintLine
    {
        private Polyline polyline = new Polyline();
        public List<Point> points { get; set; } = new List<Point>();

        public PaintPolyline(Canvas canvas, double x1, double y1, Pen pen = null, Brush brush = null) : base(canvas, x1, y1, pen, brush)
        {
            brush = Brushes.Transparent;
            points.Add(new Point(xStart, yStart));
            init();
        }

        public override void init()
        {
            polyline.Stroke = getPenBrush();
            polyline.Fill = getFillBrush();
            polyline.StrokeThickness = penThickness;
            polyline.Points = new PointCollection(points);
        }


        public override void Draw(Canvas canvas)
        {
            canvas.Children.Add(polyline);
        }

        public void AddNewPoint(Point pointToAdd)
        {
            //polyline.Points.Add(pointToAdd);
            points.Add(pointToAdd);
            polyline.Points = new PointCollection(points);
        }
    }
}
