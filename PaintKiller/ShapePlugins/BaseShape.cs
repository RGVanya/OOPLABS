using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace PaintKiller.ShapePlugins
{
    public abstract class BaseShape
    {
        protected Brush brush;
        protected Pen pen;
        protected Canvas canvas;

        public BaseShape(Canvas canvas)
        {
            this.pen = new Pen(Brushes.Black, 1.0);
            this.brush = Brushes.White;
            this.canvas = canvas;
        }
        public BaseShape(Canvas canvas, Pen pen_value)
        {
            this.pen = pen_value;
            this.brush = Brushes.Transparent;
            this.canvas = canvas;
        }

        public BaseShape(Canvas canvas, Brush brush_value)
        {
            this.pen = new Pen(Brushes.Black, 1.0);
            this.brush = brush_value;
            this.canvas = canvas;
        }
        public BaseShape(Canvas canvas, Pen pen_value, Brush brush_value)
        {
            this.pen = pen_value;
            this.brush = brush_value;
            this.canvas = canvas;
        }


        public abstract void Draw(Canvas canvas);


    }
}
