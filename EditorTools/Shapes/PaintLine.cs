﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttributeModule;
using System.Windows.Controls;
using System.Windows.Media;
using BaseShapeModule;

namespace EditorTools.Shapes
{
    [ShapeName("Линия")]
    public class PaintLine : BaseShape
    {

        public double xStart { get; set; }
        public double yStart { get; set; }
        public double xEnd { get; set; }
        public double yEnd { get; set; }

        System.Windows.Shapes.Line line = new System.Windows.Shapes.Line();
        public PaintLine(Canvas canvas, double x1, double y1, Pen pen = null, Brush brush = null) : base(canvas, pen, brush)
        {
            this.xStart = x1;
            this.yStart = y1;
            this.xEnd = x1;
            this.yEnd = y1;
            init();
        }


        public override void init()
        {
            line.X1 = xStart;
            line.Y1 = yStart;
            line.X2 = xEnd;
            line.Y2 = yEnd;
            line.Stroke = getPenBrush();
            line.Fill = getFillBrush();
            line.StrokeThickness = penThickness;
        }


        public override void Draw(Canvas canvas)
        {
            canvas.Children.Add(line);
        }

        public override void UpdateShape(Canvas canvas, double new_x, double new_y)
        {
            line.X2 = new_x;
            line.Y2 = new_y;
            xStart = new_x;
            yStart = new_y;
        }
    }
}
