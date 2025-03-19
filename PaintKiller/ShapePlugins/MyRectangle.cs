using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace PaintKiller.ShapePlugins
{
    public class MyRectangle : BaseShape
    {

        protected double xStart;
        protected double yStart;
        protected double width;
        protected double height;

        System.Windows.Shapes.Rectangle rect = new System.Windows.Shapes.Rectangle();


        public MyRectangle(Canvas canvas, double x1, double y1, double x2, double y2, Pen pen = null, Brush brush = null) : base(canvas, pen, brush)
        {
            PositionSet(x1, x2, y1, y2);
            rect.Width = this.width;
            rect.Height = this.height;
            rect.Stroke = this.pen.Brush;
            rect.Fill = this.brush;
            xStart = x1;
            yStart = y1;
        }


        public override void Draw(Canvas canvas) {
            // Создаем прямоугольник
 

            canvas.Children.Add(rect);
            Canvas.SetLeft(rect, xStart); 
            Canvas.SetTop(rect, yStart);  
        }

        public override void UpdateShape(Canvas canvas, double new_x, double new_y)
        {
            // Вычисляем новые размеры
            //PositionSet(xStart, new_x, yStart, new_y);
            width = Math.Abs(new_x - xStart);
            height = Math.Abs(new_y - yStart);


            rect.Width = width;
            rect.Height = height;      

            // Корректируем позицию, если мышь идёт влево/вверх
            if (xStart > new_x)
                Canvas.SetLeft(rect, new_x);
            if (yStart > new_y)
                Canvas.SetTop(rect, new_y);
        }

        private void PositionSet(double x1, double x2, double y1, double y2)
        {

            if (x2 < x1)
            {
                xStart = x2;
            }
            else
            {
                xStart = x1;
            }

            if (y2 < y1)
            {
                yStart = y2;
            }
            else
            {
                yStart = y1;
            }
            height = Math.Abs(x1 - x2);
            width = Math.Abs(y1 - y2);


        }

    }
}
