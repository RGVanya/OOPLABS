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
        private List<BaseShape> PaintedShapes = new List<BaseShape>();
        private Stack<BaseShape> DeletedShapes = new Stack<BaseShape>();

        public UndoRedo()
        {
            PaintedShapes = new List<BaseShape>();
            DeletedShapes = new Stack<BaseShape>();
        }

        public List<BaseShape> StepBack()
        {
            if (PaintedShapes.Count > 0)
            { 
                DeletedShapes.Push(PaintedShapes[PaintedShapes.Count - 1]);
                PaintedShapes.RemoveAt(PaintedShapes.Count - 1);
            }

            return GetPaintedShapeList();
        }

        public List<BaseShape> StepForward()
        {
            if (DeletedShapes.Count > 0)
            {
                PaintedShapes.Add(DeletedShapes.Pop());
            }
            return GetPaintedShapeList();
        }

        public void AddNewElement(BaseShape newEll)
        {
            PaintedShapes.Add(newEll);
            DeletedShapes.Clear();
        }

        public void Reset()
        {
            PaintedShapes.Clear();
            DeletedShapes.Clear();
        }

        public List<BaseShape> GetPaintedShapeList()
        {
            return PaintedShapes;
        }


    }
}
