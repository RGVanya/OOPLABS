using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PaintKiller.AttributeModule;
using PaintKiller.ShapePlugins;

namespace PaintKiller.ShapeLoadModule
{
    public static class ShapeLoader
    {
        public static Dictionary<string, Type> GetShapeTypes()
        {
            var shapeDict = new Dictionary<string, Type>();
            var baseType = typeof(BaseShape);

            var types = Assembly.GetExecutingAssembly()
                           .GetTypes()
                           .Where(t => t.IsSubclassOf(baseType) && !t.IsAbstract && t.GetCustomAttribute<ShapeNameAttribute>() != null)
                           .ToList();
            foreach(var type in types)
            {
                var attr = type.GetCustomAttribute<ShapeNameAttribute>();
                if (attr != null)
                {
                    shapeDict[attr.DisplayName] = type;
                }
            }

            return shapeDict;
        }

    }
}
