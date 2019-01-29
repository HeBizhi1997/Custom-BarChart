using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Custom_Bar
{
    /// <summary>
    /// BarChart.xaml 的交互逻辑
    /// </summary>
    public partial class BarChartControl : UserControl
    {
        public BarChartControl()
        {
            InitializeComponent();
        }

        public Brush BorderBrush
        {
            get { return (Brush)GetValue(BorderBrushProperty); }
            set { SetValue(BorderBrushProperty, value); }
        }

        public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register("BorderBrush",
            typeof(Brush), typeof(BarChartControl),
            new PropertyMetadata(Brushes.Black));

        public Thickness BorderThickness
        {
            get { return (Thickness)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        public static readonly DependencyProperty BorderThicknessProperty =
            DependencyProperty.Register("BorderThickness",
                typeof(Thickness), typeof(BarChartControl),
                new PropertyMetadata(new Thickness(1.0, 0.0, 1.0, 1.0)));

        public AxisYModel AxisY
        {
            get { return (AxisYModel)GetValue(AxisYProperty); }
            set { SetValue(AxisYProperty, value); }
        }

        public static readonly DependencyProperty AxisYProperty = DependencyProperty.Register("AxisY",
            typeof(AxisYModel), typeof(BarChartControl),
            new PropertyMetadata(new AxisYModel()));

        public AxisXModel AxisX
        {
            get { return (AxisXModel)GetValue(AxisXProperty); }
            set { SetValue(AxisXProperty, value); }
        }

        public static readonly DependencyProperty AxisXProperty = DependencyProperty.Register("AxisX",
            typeof(AxisXModel), typeof(BarChartControl),
            new PropertyMetadata(new AxisXModel()));

        private void BarChartControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            MainBorder.BorderBrush = BorderBrush;
            MainBorder.BorderThickness = BorderThickness;

            SetYTitlesContent();

            SetXDatasContent();
        }

        private void SetXDatasContent()
        {
            var axisXModel = AxisX;
            if (axisXModel.Datas.Count > 0)
            {
                BottomCanvas.Height = axisXModel.Height;
                double width = MainBorder.ActualWidth;


                int count = axisXModel.Datas.Count;
                int index = 1;
                foreach (var data in axisXModel.Datas)
                {
                    var textblock = new TextBlock();
                    textblock.Text = data.Name;
                    textblock.Foreground = axisXModel.ForeGround;
                    textblock.TextAlignment = TextAlignment.Center;
                    //textblock.VerticalAlignment = VerticalAlignment.Top;
                    //textblock.Height = axisXModel.Height;
                    double textBlockWidth = axisXModel.LabelWidth;
                    textblock.Width = textBlockWidth;
                    //textblock.Padding = new Thickness(0, 0, 5, 0);
                    double leftLength = width * Convert.ToDouble(index) / (count + 1) - textBlockWidth / 2;
                    Canvas.SetLeft(textblock, leftLength);
                    BottomCanvas.Children.Add(textblock);

                    var stackPanel = new StackPanel();
                    stackPanel.Orientation = Orientation.Vertical;

                    var tbl = new TextBlock();
                    tbl.Height = 15;
                    tbl.Margin = new Thickness(0, 0, 0, 5);
                    tbl.Text = data.Value.ToString();
                    stackPanel.Children.Add(tbl);

                    var rectangle = new Rectangle();
                    rectangle.Width = data.BarWidth;
                    double maxValue = AxisY.Titles.Max(i => i.Value);
                    rectangle.Height = (data.Value / maxValue) * MainCanvas.ActualHeight;
                    var linearBrush = new LinearGradientBrush()
                    {
                        StartPoint = new Point(1, 0),
                        EndPoint = new Point(1, 1),
                        GradientStops = new GradientStopCollection()
                        {
                            new GradientStop()
                            {
                                Color = data.FillBrush,
                                Offset = 0
                            },
                            new GradientStop()
                            {
                                Color = data.FillEndBrush,
                                Offset = 1
                            }
                        }
                    };
                    rectangle.Fill = linearBrush;
                    stackPanel.Children.Add(rectangle);

                    double leftBarLength = width * Convert.ToDouble(index) / (count + 1) - data.BarWidth / 2;
                    Canvas.SetLeft(stackPanel, leftBarLength);

                    Canvas.SetTop(stackPanel, MainCanvas.ActualHeight - (rectangle.Height + 20));

                    MainCanvas.Children.Add(stackPanel);
                    index++;
                }
            }
        }

        private void SetYTitlesContent()
        {
            var axisYModel = AxisY;
            if (axisYModel.Titles.Count > 0)
            {
                LeftCanvas.Width = axisYModel.Width;
                double height = MainBorder.ActualHeight;

                int index = 0;
                int count = axisYModel.Titles.Count;
                foreach (var title in axisYModel.Titles)
                {
                    var textblock = new TextBlock();
                    textblock.Text = title.Name;
                    textblock.Foreground = axisYModel.ForeGround;
                    textblock.TextAlignment = TextAlignment.Right;
                    textblock.Width = axisYModel.Width;
                    double textBlockHeight = 18;
                    textblock.Height = textBlockHeight;
                    textblock.Padding = new Thickness(0, 0, 5, 0);
                    double topLength = height - height * Convert.ToDouble(index) / (count - 1) - textBlockHeight / 2;
                    Canvas.SetTop(textblock, topLength);
                    LeftCanvas.Children.Add(textblock);

                    var path = new Path();
                    path.Stroke = Brushes.DodgerBlue;
                    path.StrokeThickness = 0.5;

                    var startPoint = new Point(0, height - height * Convert.ToDouble(index) / (count - 1));
                    var endPoint = new Point(MainCanvas.ActualWidth, height - height * Convert.ToDouble(index) / (count - 1));
                    path.Data = new PathGeometry()
                    {
                        Figures = new PathFigureCollection()
                        {
                            new PathFigure()
                            {
                                IsClosed = true,
                                StartPoint = startPoint,
                                Segments = new PathSegmentCollection()
                                {
                                    new LineSegment() {Point = endPoint}
                                }
                            }
                        }
                    };
                    MainCanvas.Children.Add(path);
                    index++;
                }
            }
        }
    }

    public class AxisXModel
    {
        public double Height { get; set; }

        private double _lableWidth = 50;

        public double LabelWidth
        {
            get { return _lableWidth; }
            set { _lableWidth = value; }
        }

        public Brush ForeGround { get; set; }
        private List<DataModel> _titles = new List<DataModel>();

        public List<DataModel> Datas
        {
            get { return _titles; }
            set { _titles = value; }
        }
    }

    public class AxisYModel
    {
        public double Width { get; set; }

        public Brush ForeGround { get; set; }

        private List<DataModel> _titles = new List<DataModel>();

        public List<DataModel> Titles
        {
            get { return _titles; }
            set { _titles = value; }
        }
    }

    public class DataModel
    {
        public string Name { get; set; }
        public double Value { get; set; }

        private double _barWidth = 20;

        public double BarWidth
        {
            get { return _barWidth; }
            set { _barWidth = value; }
        }

        public Color FillBrush { get; set; }
        public Color FillEndBrush { get; set; }
    }
}
