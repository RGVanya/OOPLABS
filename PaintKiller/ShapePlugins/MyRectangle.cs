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
    public class MyRectangle : RectShape
    {
        public MyRectangle(Canvas canvas, int x1, int y1, int x2, int y2 ) : base(canvas, x1, y1, x2, y2) 
        { 
        
        }

        public MyRectangle(Canvas canvas, int x1, int y1, int x2, int y2, Pen pen, Brush brush) : base(canvas, x1, y1, x2, y2, pen, brush)
        {

        }

        public MyRectangle(Canvas canvas, int x1, int y1, int x2, int y2, Pen pen) : base(canvas, x1, y1, x2, y2, pen)
        {

        }
        public MyRectangle(Canvas canvas, int x1, int y1, int x2, int y2, Brush brush) : base(canvas, x1, y1, x2, y2, brush)
        {

        }

        public override void Draw(Canvas canvas) {
            // Создаем прямоугольник
            System.Windows.Shapes.Rectangle rect = new System.Windows.Shapes.Rectangle
            {
                Width = this.width,
                Height = this.height,
                Stroke = this.pen.Brush,
                Fill = this.brush
            };

            canvas.Children.Add(rect);
            Canvas.SetLeft(rect, 1); 
            Canvas.SetTop(rect, 0);  
        }

    }
}
