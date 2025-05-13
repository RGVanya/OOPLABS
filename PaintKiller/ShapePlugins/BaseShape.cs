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
        public double penThickness { get; set; } = 2.0;
        public string penBrush { get; set; } = "Black";
        public string fillBrush { get; set; } = "Transparent";


        private Canvas canvas;
       


        public BaseShape(Canvas canvas, Pen pen_value = null, Brush brush_value = null)
        {
            this.canvas = canvas;

            if (pen_value != null) 
            {
                penThickness = pen_value.Thickness;
                penBrush = pen_value.Brush.ToString();
            }
            if (brush_value != null)
            {
                fillBrush = brush_value.ToString();
            }
        }

        public Brush getPenBrush() => (Brush)new BrushConverter().ConvertFromString(penBrush);
        public Brush getFillBrush() => (Brush)new BrushConverter().ConvertFromString(fillBrush);

        public abstract void Draw(Canvas canvas);
        public virtual void UpdateShape(Canvas canvas, double new_x, double new_y)
        {

        
        
        }

        public abstract void init();

    }
}
