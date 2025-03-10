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
        private bool _IsDrawing = false;
        private Point _StartPoint;
        private Rectangle _currentRectangle;

        public MainWindow()
        {
            InitializeComponent();
            //MyRectangle rect = new MyRectangle(myCanvas, 10, 10, 100, 200);
            //rect.Draw(myCanvas);
            //MyLine line = new MyLine(myCanvas, 10, 10, 100, 200);
            //line.Draw(myCanvas);
        }

        //Работает только с прямоугольником, как тестовый вариант для проверки рисования
        private void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _StartPoint = e.GetPosition(myCanvas);
            _IsDrawing = true;


            _currentRectangle = new Rectangle
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Fill = Brushes.Transparent
            };


            Canvas.SetLeft(_currentRectangle, _StartPoint.X);
            Canvas.SetTop(_currentRectangle, _StartPoint.Y);
            myCanvas.Children.Add(_currentRectangle);
        }

        //Работает только с прямоугольником, как тестовый вариант для проверки рисования
        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_IsDrawing) return;

            // Текущая позиция мыши
            Point currentPoint = e.GetPosition(myCanvas);

            // Вычисляем новые размеры
            double width = Math.Abs(currentPoint.X - _StartPoint.X);
            double height = Math.Abs(currentPoint.Y - _StartPoint.Y);

            _currentRectangle.Width = width;
            _currentRectangle.Height = height;

            // Корректируем позицию, если мышь идёт влево/вверх
            if (currentPoint.X < _StartPoint.X)
                Canvas.SetLeft(_currentRectangle, currentPoint.X);
            if (currentPoint.Y < _StartPoint.Y)
                Canvas.SetTop(_currentRectangle, currentPoint.Y);
        }

        //Работает только с прямоугольником, как тестовый вариант для проверки рисования
        private void myCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _IsDrawing = false;
        }
    }

}
