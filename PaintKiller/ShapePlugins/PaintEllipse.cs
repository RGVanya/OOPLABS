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
    [ShapeName("Эллипс")]
    public class PaintEllipse : BaseShape
    {

        System.Windows.Shapes.Ellipse ellipse = new System.Windows.Shapes.Ellipse();
        public double xStart { get; private set; }
        public double yStart { get; private set; }
        public double width { get; private set; }
        public double height { get; private set; }
        public PaintEllipse(Canvas canvas, double x1, double y1, Pen pen = null, Brush brush = null) : base(canvas, pen, brush) 
        {

            xStart = x1;
            yStart = y1;    
            width = 0;
            height = 0;
            init();
        }


        public override void init()
        {
            ellipse.Stroke = getPenBrush();
            ellipse.Fill = getFillBrush();
            ellipse.StrokeThickness = penThickness;
            ellipse.Width = width;
            ellipse.Height = height;
        }

        public override void Draw(Canvas canvas)
        {
            Canvas.SetTop(ellipse, yStart);
            Canvas.SetLeft(ellipse, xStart);
            canvas.Children.Add(ellipse);
        }

        public override void UpdateShape(Canvas canvas, double new_x, double new_y)
        {
            width = Math.Abs(new_x - xStart);
            height = Math.Abs(new_y - yStart);

            ellipse.Width = width;
            ellipse.Height = height;

            if (new_x < xStart)
                Canvas.SetLeft(ellipse, new_x);
            if (yStart > new_y)
                Canvas.SetTop(ellipse, new_y);
        }

    }
}
