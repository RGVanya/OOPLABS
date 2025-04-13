using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using PaintKiller.ShapePlugins;

namespace PaintKiller.PaintingModule
{
    internal class Painter
    {


        private BaseShape _currentShape;
        public Painter() { }

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


    }
}
