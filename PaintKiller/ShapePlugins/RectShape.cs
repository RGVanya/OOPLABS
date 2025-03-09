using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace PaintKiller.ShapePlugins
{
    public abstract class RectShape : BaseShape
    {
        protected int xStart;
        protected int yStart;
        protected int width;
        protected int height;


        public RectShape(Canvas canvas, int x1, int y1, int x2, int y2,  Pen pen, Brush brush) : base(canvas, pen, brush) 
        {
            PositionSet(x1, x2, y1, y2);
        }

        public RectShape(Canvas canvas, int x1, int y1, int x2, int y2) : base(canvas)
        {
            PositionSet(x1, x2, y1, y2);
        }
        public RectShape(Canvas canvas, int x1, int y1, int x2, int y2, Pen pen) : base(canvas, pen)
        {
            PositionSet(x1, x2, y1, y2); ;
        }

        public RectShape(Canvas canvas, int x1, int y1, int x2, int y2, Brush brush) : base(canvas, brush)
        {
            PositionSet(x1, x2, y1, y2);
        }

        private void PositionSet(int x1, int x2, int y1, int y2)
        {
            if (x2 < x1)
            {
                xStart = x2;
            }
            else
            {
                xStart = x1;
            }
            height = Math.Abs(y1 - y2);
            width = Math.Abs(x1 - x2);
        }
        
    }
}
