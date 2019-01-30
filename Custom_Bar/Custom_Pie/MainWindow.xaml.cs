using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Custom_Pie
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            canvas.Children.Add(DrawPie(135d));
            Path p = DrawPie(360 - 135d);

            p.Loaded += (s, e) =>
            {
                p.RenderTransformOrigin = new Point(0, 0);
                p.RenderTransform = new RotateTransform();
                var rt = (RotateTransform)p.RenderTransform;
                rt.BeginAnimation(RotateTransform.AngleProperty, new DoubleAnimation(90, 135, TimeSpan.FromSeconds(1)) { AutoReverse = true, RepeatBehavior = RepeatBehavior.Forever });
            };

            canvas.Children.Add(p);
        }



        private Path DrawPie(double _angle)
        {
            //半径
            double radius = 50.0;
            //角度
            double angle = _angle;

            Path path = new Path
            {
                Fill = (Brush)(new BrushConverter().ConvertFromString("#FFD6D0FF")),
                Stroke = (Brush)(new BrushConverter().ConvertFromString("#FFD6D0FF")),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(100)
            };

            PathGeometry pathGeometry = new PathGeometry();

            PathFigure pathFigure = new PathFigure
            {
                StartPoint = new Point(0, 0),
                IsClosed = true
            };

            // Starting Point
            LineSegment lineSegment = new LineSegment(new Point(radius, 0), true);
            // Arc
            ArcSegment arcSegment = new ArcSegment
            {
                IsLargeArc = angle >= 180.0,
                Point = new Point(Math.Cos(angle * Math.PI / 180) * radius, Math.Sin(angle * Math.PI / 180) * radius),
                Size = new Size(radius, radius),
                SweepDirection = SweepDirection.Clockwise
            };

            pathFigure.Segments.Add(lineSegment);
            pathFigure.Segments.Add(arcSegment);

            pathGeometry.Figures.Add(pathFigure);

            path.Data = pathGeometry;
            return path;
        }
    }
}
