using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PaintKiller.AttributeModule;

namespace PaintKiller.ShapePlugins
{
    [ShapeName("Линия")]
    public class PaintLine : BaseShape
    {

        protected double xStart;
        protected double yStart;
        protected double xEnd;
        protected double yEnd;
        System.Windows.Shapes.Line line = new System.Windows.Shapes.Line();

        public PaintLine(Canvas canvas, double x1, double y1, Pen pen = null, Brush brush = null) : base(canvas, pen, brush)
        {
            this.xStart = x1;
            this.yStart = y1;
            this.xEnd = x1;
            this.yEnd = y1;

            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x1;
            line.Y2 = y1;
            line.Stroke = this.pen.Brush;
            line.Fill = this.brush;
            line.StrokeThickness = this.pen.Thickness;
        }


        public override void Draw(Canvas canvas)
        {
            canvas.Children.Add(line);
        }

        public override void UpdateShape(Canvas canvas, double new_x, double new_y)
        {
            line.X2 = new_x;
            line.Y2 = new_y;
            xStart = new_x;
            yStart = new_y;
        }
    }
}
