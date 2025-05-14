using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EditorTools.Shapes;
using BaseShapeModule;

namespace EditorTools.UndoRedoModule
{
    public class UndoRedo
    {
        private Stack<BaseShape> PaintedShapes = new Stack<BaseShape>();
        private Stack<BaseShape> DeletedShapes = new Stack<BaseShape>();

        public UndoRedo()
        {
            PaintedShapes = new Stack<BaseShape>();
            DeletedShapes = new Stack<BaseShape>();
        }

        public List<BaseShape> StepBack()
        {
            if (PaintedShapes.Count > 0)
            {
                DeletedShapes.Push(PaintedShapes.Pop());
            }

            return GetPaintedShapeList();
        }

        public List<BaseShape> StepForward()
        {
            if (DeletedShapes.Count > 0)
            {
                PaintedShapes.Push(DeletedShapes.Pop());
            }
            return GetPaintedShapeList();
        }

        public void AddNewElement(BaseShape newEll)
        {
            PaintedShapes.Push(newEll);
            DeletedShapes.Clear();
        }

        public void Reset()
        {
            PaintedShapes.Clear();
            DeletedShapes.Clear();
        }

        public List<BaseShape> GetPaintedShapeList()
        {
            return PaintedShapes.Reverse().ToList();
        }


    }
}
