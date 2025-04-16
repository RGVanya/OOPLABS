using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaintKiller.ShapePlugins;

namespace PaintKiller.UndoRedoModule
{
    public class UndoRedo
    {
        Stack<BaseShape> PaintedShapes = new Stack<BaseShape>();
        Stack<BaseShape> DeletedShapes = new Stack<BaseShape>();

        public UndoRedo() 
        { 
        
        }

        public void StepBack()
        {
            if (PaintedShapes.Count == 0) { return; }
            DeletedShapes.Push(PaintedShapes.Pop());
        }

        public void StepForward()
        {
            if (DeletedShapes.Count == 0 ) { return;}

            PaintedShapes.Push(DeletedShapes.Pop()); PaintedShapes.Push(DeletedShapes.Pop());
        }

        public void Reset() 
        {
            PaintedShapes.Clear();
            DeletedShapes.Clear();
        }



    }
}
