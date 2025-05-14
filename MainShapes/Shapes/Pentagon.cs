using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseShapeModule;
using AttributeModule;
using System.Windows.Controls;
using System.Windows.Media;

namespace Shapes
{
    [ShapeName("Пятиугольник")]
    public class Pentagon : BaseShape
    {

        Pentagon(Canvas canvas, double x1, double y1, Pen pen = null, Brush brush = null) : base(canvas, pen, brush)
        {
        
        }  

        public override void UpdateShape(Canvas canvas, double new_x, double new_y)
        {
            
        }


        public override void init()
        {
            
        }

        public override void Draw(Canvas canvas)
        {

        }
    }
}
