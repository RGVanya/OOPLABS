using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PaintKiller.ShapePlugins;

namespace PaintKiller
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyRectangle rect = new MyRectangle(myCanvas, 10, 10, 100, 200);
            rect.Draw(myCanvas);
            MyLine line = new MyLine(myCanvas, 10, 10, 100, 200);
            line.Draw(myCanvas);
        }

    }

}
