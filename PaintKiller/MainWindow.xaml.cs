﻿using System;
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
        private MyRectangle _currentRectangle;
        private BaseShape _currentShape;

        public MainWindow()
        {
            InitializeComponent();
        }

        //Работает только с прямоугольником, как тестовый вариант для проверки рисования
        private void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _StartPoint = e.GetPosition(myCanvas);
            _IsDrawing = true;

            //прямоугольник
            //_currentShape = new MyRectangle(myCanvas, _StartPoint.X, _StartPoint.Y, _StartPoint.X , _StartPoint.Y);

            //линия
            //_currentShape = new MyLine(myCanvas, _StartPoint.X, _StartPoint.Y, _StartPoint.X, _StartPoint.Y);
            
            
            //работает вроде со всеми классами.
            _currentShape.Draw(myCanvas);

        }

        //Работает только с прямоугольником, как тестовый вариант для проверки рисования
        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_IsDrawing) return;

            // Текущая позиция мыши
            Point currentPoint = e.GetPosition(myCanvas);
            _currentShape.UpdateShape(myCanvas, currentPoint.X, currentPoint.Y);

        }

        //Работает только с прямоугольником, как тестовый вариант для проверки рисования
        private void myCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _IsDrawing = false;
        }
    }

}
