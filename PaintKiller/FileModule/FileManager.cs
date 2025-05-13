using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Win32;
using PaintKiller.ShapePlugins;
using Newtonsoft.Json;
using System.Windows.Shapes;
using System.Runtime.Remoting.Contexts;

namespace PaintKiller.FileModule
{
    static class FileManager
    {


        public static List<BaseShape> OpenUserFile()
        {
            List<BaseShape> shapes = new List<BaseShape>();
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Открытие файла",
                Filter = "Все файлы (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) 
            };
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            };
            if (openFileDialog.ShowDialog() == true)
            {
                string json = File.ReadAllText(openFileDialog.FileName);
                var list = JsonConvert.DeserializeObject<List<BaseShape>>(json, settings);
                shapes = list;
                return shapes;
            }
            return shapes;
        }

        public static void SaveUserFile(List<BaseShape> shapes) 
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Сохранение файла",
                Filter = "Все файлы (*.*)|*.*", // Фильтр форматов
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) // Открыть "Документы"
            };
            if (saveFileDialog.ShowDialog() == true)
            {               
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    Formatting = Formatting.Indented
                };
                string json = JsonConvert.SerializeObject(shapes, settings);
                File.WriteAllText(saveFileDialog.FileName, json);
            }
        }

    }
}
