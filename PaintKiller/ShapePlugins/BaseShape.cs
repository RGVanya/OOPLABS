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
        protected Brush brush = Brushes.Transparent;
        protected Pen pen = new Pen(Brushes.Black, 2.0);
        protected Canvas canvas;



        public BaseShape(Canvas canvas, Pen pen_value = null, Brush brush_value = null)
        {
            this.canvas = canvas;

            if (pen_value != null) 
            {
                this.pen = pen_value;
            }
            if (brush_value != null)
            {
                this.brush = brush_value;
            }
        }


        public abstract void Draw(Canvas canvas);
        public abstract void UpdateShape(Canvas canvas, double new_x, double new_y);

    }
}
