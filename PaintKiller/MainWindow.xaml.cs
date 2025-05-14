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
using AttributeModule;
using EditorTools.ShapeLoadModule;
using EditorTools.Shapes;
using BaseShapeModule;
using EditorTools.UndoRedoModule;
using EditorTools.PaintingModule;
using EditorTools.FileModule;


namespace PaintKiller
{
    public partial class MainWindow : Window
    {
        private bool _IsDrawing = false;
        private Point _StartPoint;
        private BaseShape _currentShape;
        private ToggleButton selectedFillButton;
        private ToggleButton selectedStrokeButton;
        public Dictionary<string, Type> shapeTypes;

        private enum ColorTarget
        {
            Fill,
            Stroke
        }

        private ColorTarget currentTarget = ColorTarget.Fill;
        public Brush SelectedFillBrush { get; private set; } = Brushes.Transparent;
        public Brush SelectedStrokeBrush { get; private set; } = Brushes.Black;
        public Pen SelectedPen { get; private set; } = new Pen() {Thickness = 1, Brush = Brushes.Black };
        UndoRedo undoredo = new UndoRedo();

        public MainWindow()
        {

            InitializeComponent();
            settingsIntialize();
            
        }
        private void Mode_Checked(object sender, RoutedEventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb?.Tag?.ToString() == "Fill") {
                currentTarget = ColorTarget.Fill;
                selectedFillButton.IsChecked = true;
                SetChecksToggleButtons(selectedFillButton);
            }
                
            else if (rb?.Tag?.ToString() == "Stroke")
            {
                currentTarget = ColorTarget.Stroke;
                selectedStrokeButton.IsChecked = true;
                SetChecksToggleButtons(selectedStrokeButton);
            }
        }


        private void MyCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            _StartPoint = e.GetPosition(myCanvas);
            _IsDrawing = true;
            createNewShape();
        }

        private void createNewShape()
        {
            string shapeName = ShapesCBox.SelectedItem as string;
            _currentShape = (BaseShape)Activator.CreateInstance(shapeTypes[shapeName], myCanvas, _StartPoint.X, _StartPoint.Y, SelectedPen, SelectedFillBrush);
            Painter.PaintCanvas(myCanvas, _currentShape);
            undoredo.AddNewElement(_currentShape);
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
            if (_currentShape == null) { return; }
            Point currentPoint = e.GetPosition(myCanvas);
            Painter.AddPoint(myCanvas, _currentShape, currentPoint);
        }

        private void settingsIntialize()
        {

            //Инициализация параметров цвета
            SelectedFillBrush = Brushes.Transparent;
            SelectedStrokeBrush = Brushes.Black;
            SelectedPen = new Pen() { Brush = SelectedStrokeBrush, Thickness = 1 };

            //Кнопки начального цвета
            selectedFillButton = WhiteTBtn;
            selectedFillButton.IsChecked = true;
            selectedStrokeButton = BlackTBtn;


            //Поиск всех типов фигур
            InitShapeTypes();
            ShapesCBox.ItemsSource = shapeTypes.Keys;

        }


        private void InitShapeTypes()
        {
            shapeTypes = ShapeLoader.GetShapeTypes();
        }





        private void ColorToggleButton_Click(object sender, RoutedEventArgs e)
        {
            //ColorButtonsPanel
            var clicked = sender as ToggleButton;
            SetChecksToggleButtons(clicked);
            string colorName = clicked.Tag as string;
            var CurrBrush = (Brush)new BrushConverter().ConvertFromString(colorName);
            if (currentTarget == ColorTarget.Fill)
            {
                SelectedFillBrush = CurrBrush;
                selectedFillButton = clicked;
            }

            else
            {
                SelectedStrokeBrush = CurrBrush;
                SelectedPen.Brush = CurrBrush;
                selectedStrokeButton = clicked;
            }
        }

        private void SetChecksToggleButtons( ToggleButton isCheckedBtn)
        {
            foreach (var PanelObj in FillGridColorButtons.Children)
            {
                if (PanelObj is ToggleButton)
                {
                    ToggleButton ButtonColor = PanelObj as ToggleButton;
                    if (ButtonColor != isCheckedBtn)
                    {
                        ButtonColor.IsChecked = false;
                    }
                }
            }

        }

        private void ThicknessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SelectedPen.Thickness = ThicknessSlider.Value;
        }

        private void UndoButton_click(object sender, RoutedEventArgs e)
        {
            Painter.CanvasRepaint(myCanvas, undoredo.StepBack());
        }

        private void RedoButton_click(object sender, RoutedEventArgs e)
        {
            Painter.CanvasRepaint(myCanvas, undoredo.StepForward());
        }

        private void NewListButton_click(object sender, RoutedEventArgs e)
        {
            MakeNewList();
        }

        private void MakeNewList()
        {
            undoredo.Reset();
            Painter.CanvasRepaint(myCanvas, undoredo.GetPaintedShapeList());
            
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            FileManager.SaveUserFile(undoredo.GetPaintedShapeList());
            //MessageBox.Show("Ваш файл сохранён");
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            MakeNewList();

            foreach (BaseShape shape in FileManager.OpenUserFile())
            {
                shape.init();
                shape.Draw(myCanvas);
                undoredo.AddNewElement(shape);
            }
        }

        private void AddPluginButton_Click(object sender, RoutedEventArgs e)
        {
            AddShapeTypes();
        }

        private void AddShapeTypes()
        {
            var NewEll = ShapeLoader.AddNewShapeType();
            shapeTypes.Add(NewEll.Item1, NewEll.Item2);
            ShapesCBox.ItemsSource = shapeTypes.Keys;
        }
    }

}
