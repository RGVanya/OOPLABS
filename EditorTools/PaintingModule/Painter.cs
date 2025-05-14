using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BaseShapeModule;
using System.Windows.Controls;
using System.Windows;

namespace EditorTools.PaintingModule
{
    public class Painter
    {



        Painter()
        {

        }

        public static void PaintCanvas(Canvas canvas, BaseShape ShapeToPaint)
        {

            ShapeToPaint.Draw(canvas);
        }


        public static void ShapeUpdater(Canvas canvas, BaseShape shapeToUpdate, Point newPoint)
        {

            shapeToUpdate.UpdateShape(canvas, newPoint.X, newPoint.Y);
        }




        public static void AddPoint(Canvas canvas, BaseShape shape, Point currentPoint)
        {

            Type type = shape.GetType();
            MethodInfo method = type.GetMethod("AddNewPoint");
            if (method != null)
            {

                method.Invoke(shape, new object[] { currentPoint });
            }
            else
            {
                return;
            }
        }

        public static void CanvasRepaint(Canvas canvas, List<BaseShape> shapes)
        {
            canvas.Children.Clear();
            foreach (BaseShape shape in shapes)
            {
                shape.Draw(canvas);
            }
        }


    }
}
