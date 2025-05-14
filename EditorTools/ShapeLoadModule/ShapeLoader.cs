using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using BaseShapeModule;
using AttributeModule;
using EditorTools.FileModule;

namespace EditorTools.ShapeLoadModule
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
            foreach (var type in types)
            {
                var attr = type.GetCustomAttribute<ShapeNameAttribute>();
                if (attr != null)
                {
                    shapeDict[attr.DisplayName] = type;
                }
            }

            return shapeDict;
        }


        public static (string, Type) AddNewShapeType()
        {
            string attr = String.Empty;
            Type type = null;
            OpenFileDialog FileDialog = new OpenFileDialog
            {
                Title = "Выберете плагин",
                Filter = "plugins (*.dll*)|*.dll*", 
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };
            if (FileDialog.ShowDialog() == true)
            {
                string filePath = FileDialog.FileName;
                Assembly pluginAssembly = Assembly.LoadFrom(filePath);
                var baseType = typeof(BaseShape);
                var shapeType = pluginAssembly.GetTypes()
                .Where(t => t.IsSubclassOf(baseType) && !t.IsAbstract && t.GetCustomAttribute<ShapeNameAttribute>() != null);
                if (shapeType.Any() == true)
                {
                    type = shapeType.First();
                    attr = type.GetCustomAttribute<ShapeNameAttribute>().DisplayName;
                }

            }
            return (attr, type);

        }

    }
}
