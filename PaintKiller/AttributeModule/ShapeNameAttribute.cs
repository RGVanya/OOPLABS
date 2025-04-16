using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintKiller.AttributeModule
{
    public class ShapeNameAttribute : Attribute
    {
        public string DisplayName { get; }
        public ShapeNameAttribute(string name) 
        {
            DisplayName = name;
        }
    }
}
