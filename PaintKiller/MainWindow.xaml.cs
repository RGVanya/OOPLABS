using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PaintKiller.PaintingModule;
using PaintKiller.ShapePlugins;


namespace PaintKiller
{
    public partial class MainWindow : Window
    {
        private bool _IsDrawing = false;
        private Point _StartPoint;
        //private MyRectangle _currentRectangle;
        private BaseShape _currentShape;




        private static readonly string[] ShapeNames = new string[] {"Прямоугольник", "Линия", "Ломанная", "Полигон", "Эллипс" };

        public MainWindow()
        {

            InitializeComponent();
            settingsIntialize();
            Painter painter = new Painter();
        }


        private void MyCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            _StartPoint = e.GetPosition(myCanvas);
            _IsDrawing = true;


            //прямоугольник
            _currentShape = new MyRectangle(myCanvas, _StartPoint.X, _StartPoint.Y, _StartPoint.X , _StartPoint.Y);


            //линия
            //_currentShape = new MyLine(myCanvas, _StartPoint.X, _StartPoint.Y, _StartPoint.X, _StartPoint.Y);


            //Эллипс
            //_currentShape = new MyEllipse(myCanvas, _StartPoint.X, _StartPoint.Y);


            //ломанная
            //_currentShape = new MyPolyline(myCanvas, _StartPoint.X, _StartPoint.Y, _StartPoint.X, _StartPoint.Y);


            //полигон
            _currentShape = new MyPolygon(myCanvas, _StartPoint.X, _StartPoint.Y, _StartPoint.X, _StartPoint.Y);


            //работает вроде со всеми классами.
            Painter.PaintCanvas(myCanvas, _currentShape);

        }


        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_IsDrawing) return;
            Point currentPoint = e.GetPosition(myCanvas);
            Painter.ShapeUpdater(myCanvas, _currentShape, currentPoint);
        }


        private void myCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _IsDrawing = false;
        }

        private void myCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point currentPoint = e.GetPosition(myCanvas);
            Painter.AddPoint(myCanvas, _currentShape, currentPoint);
        }

        private void settingsIntialize()
        {
            for (int i = 0; i < ShapeNames.Length; i++)
            {
                ShapesCBox.Items.Add(ShapeNames[i]);
            }
        }

        private void ColorToggleButton_Click(object sender, RoutedEventArgs e)
        {
            //ColorButtonsPanel
            var clicked = sender as ToggleButton;
            foreach (var PanelObj in GridColorButtons.Children)
            {
                if (PanelObj is ToggleButton)
                {
                    ToggleButton ButtonColor = PanelObj as ToggleButton;
                    if ( ButtonColor != clicked)
                    {
                        ButtonColor.IsChecked = false;
                    }
                }
            }
        }
    }

}
