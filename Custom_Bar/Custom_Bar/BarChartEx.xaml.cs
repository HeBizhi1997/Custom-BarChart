﻿using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Custom_Bar
{
    /// <summary>
    /// BarChartEx.xaml 的交互逻辑
    /// </summary>
    public partial class BarChartEx : UserControl
    {

        #region Tempelete DependencyProperty

        #region 文本

        [Description("标题文本"), Category("文本")]
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(BarChartEx), new PropertyMetadata(string.Empty));

        [Description("备注文本"), Category("文本")]
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return (string)GetValue(RemarkProperty); }
            set { SetValue(RemarkProperty, value); }
        }
        public static readonly DependencyProperty RemarkProperty =
            DependencyProperty.Register("Remark", typeof(string), typeof(BarChartEx), new PropertyMetadata(string.Empty));
        
        #endregion
        
        #region 背景色

        [Description("标题背景色"), Category("背景色")]
        /// <summary>
        /// 标题背景色
        /// </summary>
        public Brush TitleBackground
        {
            get { return (Brush)GetValue(TitleBackgroundProperty); }
            set { SetValue(TitleBackgroundProperty, value); }
        }
        public static readonly DependencyProperty TitleBackgroundProperty =
            DependencyProperty.Register("TitleBackground", typeof(Brush), typeof(BarChartEx), new PropertyMetadata(Brushes.Transparent));

        [Description("备注背景色"), Category("背景色")]
        /// <summary>
        /// 备注背景色
        /// </summary>
        public Brush RemarkBackground
        {
            get { return (Brush)GetValue(RemarkBackgroundProperty); }
            set { SetValue(RemarkBackgroundProperty, value); }
        }
        public static readonly DependencyProperty RemarkBackgroundProperty =
            DependencyProperty.Register("RemarkBackground", typeof(Brush), typeof(BarChartEx), new PropertyMetadata(Brushes.Transparent));

        [Description("进度条背景色"), Category("背景色")]
        /// <summary>
        /// 进度条背景色
        /// </summary>
        public Brush BarBackground
        {
            get { return (Brush)GetValue(BarBackgroundProperty); }
            set { SetValue(BarBackgroundProperty, value); }
        }
        public static readonly DependencyProperty BarBackgroundProperty =
            DependencyProperty.Register("BarBackground", typeof(Brush), typeof(BarChartEx), new PropertyMetadata((Brush)(new BrushConverter().ConvertFromString("#FF00BBB3"))));

        #endregion

        #region 前景色

        [Description("标题前景色"), Category("前景色")]
        /// <summary>
        /// 标题前景色
        /// </summary>
        public Brush TitleForeground
        {
            get { return (Brush)GetValue(TitleForegroundProperty); }
            set { SetValue(TitleForegroundProperty, value); }
        }
        public static readonly DependencyProperty TitleForegroundProperty =
            DependencyProperty.Register("TitleForeground", typeof(Brush), typeof(BarChartEx), new PropertyMetadata(Brushes.White));

        [Description("备注前景色"), Category("前景色")]
        /// <summary>
        /// 备注前景色
        /// </summary>
        public Brush RemarkForeground
        {
            get { return (Brush)GetValue(RemarkForegroundProperty); }
            set { SetValue(RemarkForegroundProperty, value); }
        }
        public static readonly DependencyProperty RemarkForegroundProperty =
            DependencyProperty.Register("RemarkForeground", typeof(Brush), typeof(BarChartEx), new PropertyMetadata(Brushes.White));

        [Description("x轴数据前景色"), Category("前景色")]
        /// <summary>
        /// x轴前景色
        /// </summary>
        public Brush XAxisForeground
        {
            get { return (Brush)GetValue(XAxisForegroundProperty); }
            set { SetValue(XAxisForegroundProperty, value); }
        }
        public static readonly DependencyProperty XAxisForegroundProperty =
            DependencyProperty.Register("XAxisForeground", typeof(Brush), typeof(BarChartEx), new PropertyMetadata(Brushes.White));

        [Description("y轴数据前景色"), Category("前景色")]
        /// <summary>
        /// 进度数据前景色
        /// </summary>
        public Brush BarDateForeground
        {
            get { return (Brush)GetValue(BarDateForegroundProperty); }
            set { SetValue(BarDateForegroundProperty, value); }
        }
        public static readonly DependencyProperty BarDateForegroundProperty =
            DependencyProperty.Register("BarDateForeground", typeof(Brush), typeof(BarChartEx), new PropertyMetadata(Brushes.White));

        #endregion

        #region 字号

        [Description("标题字号"), Category("字号")]
        /// <summary>
        /// 标题字号
        /// </summary>
        public double TitleFontSize
        {
            get { return (double)GetValue(TitleFontSizeProperty); }
            set { SetValue(TitleFontSizeProperty, value); }
        }
        public static readonly DependencyProperty TitleFontSizeProperty =
            DependencyProperty.Register("TitleFontSize", typeof(double), typeof(BarChartEx), new PropertyMetadata(26d));

        [Description("备注字号"), Category("字号")]
        /// <summary>
        /// 备注字号
        /// </summary>
        public double RemarkFontSize
        {
            get { return (double)GetValue(RemarkFontSizeProperty); }
            set { SetValue(RemarkFontSizeProperty, value); }
        }
        public static readonly DependencyProperty RemarkFontSizeProperty =
            DependencyProperty.Register("RemarkFontSize", typeof(double), typeof(BarChartEx), new PropertyMetadata(10d));

        [Description("x轴数据字号"), Category("字号")]
        /// <summary>
        /// x轴数据字号
        /// </summary>
        public double XAxisFontSize
        {
            get { return (double)GetValue(XAxisFontSizeProperty); }
            set { SetValue(XAxisFontSizeProperty, value); }
        }
        public static readonly DependencyProperty XAxisFontSizeProperty =
            DependencyProperty.Register("XAxisFontSize", typeof(double), typeof(BarChartEx), new PropertyMetadata(12d));

        [Description("y轴数据字号"), Category("字号")]
        /// <summary>
        /// 进度数据字号
        /// </summary>
        public double BarDateFontSize
        {
            get { return (double)GetValue(BarDateFontSizeProperty); }
            set { SetValue(BarDateFontSizeProperty, value); }
        }
        public static readonly DependencyProperty BarDateFontSizeProperty =
            DependencyProperty.Register("BarDateFontSize", typeof(double), typeof(BarChartEx), new PropertyMetadata(8d));

        #endregion

        #region 字体

        [Description("标题字体"), Category("字体")]
        /// <summary>
        /// 标题字体
        /// </summary>
        public FontFamily TitleFontFamily
        {
            get { return (FontFamily)GetValue(TitleFontFamilyProperty); }
            set { SetValue(TitleFontFamilyProperty, value); }
        }
        public static readonly DependencyProperty TitleFontFamilyProperty =
            DependencyProperty.Register("TitleFontFamily", typeof(FontFamily), typeof(BarChartEx), new PropertyMetadata(new FontFamily("Simsun")));

        [Description("备注字体"), Category("字体")]
        /// <summary>
        /// 备注字体
        /// </summary>
        public FontFamily RemarkFontFamily
        {
            get { return (FontFamily)GetValue(RemarkFontFamilyProperty); }
            set { SetValue(RemarkFontFamilyProperty, value); }
        }
        public static readonly DependencyProperty RemarkFontFamilyProperty =
            DependencyProperty.Register("RemarkFontFamily", typeof(FontFamily), typeof(BarChartEx), new PropertyMetadata(new FontFamily("Simsun")));

        [Description("x轴数据字体"), Category("字体")]
        /// <summary>
        /// x轴数据字体
        /// </summary>
        public FontFamily XAxisFontFamily
        {
            get { return (FontFamily)GetValue(XAxisFontFamilyProperty); }
            set { SetValue(XAxisFontFamilyProperty, value); }
        }
        public static readonly DependencyProperty XAxisFontFamilyProperty =
            DependencyProperty.Register("XAxisFontFamily", typeof(FontFamily), typeof(BarChartEx), new PropertyMetadata(new FontFamily("Simsun")));

        [Description("y轴数据字体"), Category("字体")]
        /// <summary>
        /// 进度数据字体
        /// </summary>
        public FontFamily BarDateFontFamily
        {
            get { return (FontFamily)GetValue(BarDateFontFamilyProperty); }
            set { SetValue(BarDateFontFamilyProperty, value); }
        }
        public static readonly DependencyProperty BarDateFontFamilyProperty =
            DependencyProperty.Register("BarDateFontFamily", typeof(FontFamily), typeof(BarChartEx), new PropertyMetadata(new FontFamily("Simsun")));

        #endregion

        #region 其他样式控制属性

        [Description("进度条宽度"), Category("其他样式属性")]
        /// <summary>
        /// 进度条宽度
        /// </summary>
        public double BarWidth
        {
            get { return (double)GetValue(BarWidthProperty); }
            set { SetValue(BarWidthProperty, value); }
        }
        public static readonly DependencyProperty BarWidthProperty =
            DependencyProperty.Register("BarWidth", typeof(double), typeof(BarChartEx), new PropertyMetadata(20d));

        [Description("动画加载时间"), Category("其他样式属性")]
        /// <summary>
        /// 动画加载时间
        /// </summary>
        public double AnimotionSpeed
        {
            get { return (double)GetValue(AnimotionSpeedProperty); }
            set { SetValue(AnimotionSpeedProperty, value); }
        }
        public static readonly DependencyProperty AnimotionSpeedProperty =
            DependencyProperty.Register("AnimotionSpeed", typeof(double), typeof(BarChartEx), new PropertyMetadata(2d));

        #endregion

        #endregion

        #region Data Property

        [Description("X轴绑定对象(string)"), Category("数据处理")]
        /// <summary>
        /// X轴关联属性名
        /// </summary>
        public string XValuePath
        {
            get { return (string)GetValue(XValuePathProperty); }
            set { SetValue(XValuePathProperty, value); }
        }
        public static readonly DependencyProperty XValuePathProperty =
            DependencyProperty.Register("XValuePath", typeof(string), typeof(BarChartEx), new PropertyMetadata(string.Empty, (s, e) =>
            {
                BarChartEx chartEx = s as BarChartEx;
                if (chartEx.YValuePath != string.Empty && chartEx.dataSource != null)
                {
                    chartEx._Content.Children.Clear();
                    CreateBarChart(chartEx);
                }
            }));

        [Description("Y轴绑定对象(string)"), Category("数据处理")]
        /// <summary>
        /// Y轴关联属性名
        /// </summary>
        public string YValuePath
        {
            get { return (string)GetValue(YValuePathProperty); }
            set { SetValue(YValuePathProperty, value); }
        }
        public static readonly DependencyProperty YValuePathProperty =
            DependencyProperty.Register("YValuePath", typeof(string), typeof(BarChartEx), new PropertyMetadata(string.Empty, (s, e) =>
             {
                 BarChartEx chartEx = s as BarChartEx;

                 Calulate_Data2Height_Value(chartEx);

                 if (chartEx.XValuePath != string.Empty && chartEx.dataSource != null)
                 {
                     chartEx._Content.Children.Clear();
                     CreateBarChart(chartEx);
                 }
             }));

        [Description("数据源"), Category("数据处理")]
        /// <summary>
        /// 数据源
        /// </summary>
        private dynamic dataSource;
        public dynamic DataSource
        {
            get { return dataSource; }
            set
            {
                dataSource = value;

                if (XValuePath != string.Empty && YValuePath != string.Empty)
                {
                    _Content.Children.Clear();
                    CreateBarChart(this);
                }
            }
        }

        /// <summary>
        /// Y轴的数据转化成相应的条图的高度的比例
        /// </summary>
        private int _data2BarHeight { get; set; } = 2;

        #endregion

        public BarChartEx()
        {
            InitializeComponent();
            //设置一个默认的背景色
            Background = (Brush)(new BrushConverter().ConvertFromString("#FF5DC6C6"));
        }

        #region OtherMethods

        /// <summary>
        /// 创建一条数据（数据值，条图，相应X轴的数据）
        /// </summary>
        /// <param name="date">Y轴数据</param>
        /// <param name="x">X轴数据</param>
        /// <returns></returns>
        private StackPanel GetBar(double date, dynamic x)
        {
            //进度条容器
            StackPanel _item = new StackPanel
            {
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(0, 0, 10, 0)
            };
            //数据部分
            TextBlock _data = new TextBlock()
            {
                Text = date.ToString("f2"),
                Margin = new Thickness(0, 0, 0, 5),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = BarDateForeground,
                FontSize = BarDateFontSize,
                FontFamily = BarDateFontFamily
            };
            //进度条
            Border _bar = new Border
            {
                Background = BarBackground,
                Width = BarWidth,
                Height = date * _data2BarHeight,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom
            };
            //添加进度条的加载动画
            _bar.Loaded += (s, e) =>
            {
                DoubleAnimation animation = new DoubleAnimation
                {
                    From = 0,
                    To = date * _data2BarHeight,
                    Duration = TimeSpan.FromSeconds(AnimotionSpeed)
                };
                _bar.BeginAnimation(Border.HeightProperty, animation);
            };

            _item.Children.Add(_data);
            _item.Children.Add(_bar);

            //x轴的数据
            TextBlock _x = new TextBlock()
            {
                Text = x + "",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = XAxisForeground,
                FontSize = XAxisFontSize,
                FontFamily = XAxisFontFamily
            };
            //添加x轴数据旋转的动画 防止文本重叠
            _x.Loaded += (s, e) =>
            {
                _x.RenderTransformOrigin = new Point(1, 1);
                _x.RenderTransform = new RotateTransform();
                var rt = (RotateTransform)_x.RenderTransform;
                rt.BeginAnimation(RotateTransform.AngleProperty, new DoubleAnimation(0, -45, TimeSpan.FromSeconds(AnimotionSpeed)));
            };
            //一列容器（包括x轴）
            StackPanel _Item = new StackPanel
            {
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
            };

            _Item.Children.Add(_item);
            _Item.Children.Add(_x);

            return _Item;
        }

        /// <summary>
        /// 创建图表
        /// </summary>
        /// <param name="chartEx"></param>
        private static void CreateBarChart(BarChartEx chartEx)
        {
            foreach (var item in chartEx.dataSource)
            {
                dynamic xValue = 0, yValue = 0;

                //通过映射获取数据集中的值
                xValue = item.GetType().GetProperty(chartEx.XValuePath).GetValue(item);
                yValue = item.GetType().GetProperty(chartEx.YValuePath).GetValue(item);

                var bar = chartEx.GetBar(yValue, xValue);
                bar.Height = chartEx._Content.Height;
                chartEx._Content.Children.Add(bar);
            }
        }

        /// <summary>
        /// 计算Y的数据值和条图高像素设置的比例
        /// </summary>
        /// <param name="chartEx"></param>
        private static void Calulate_Data2Height_Value(BarChartEx chartEx)
        {
            if (chartEx.dataSource != null)
            {
                double maxValue = 0;
                //遍历取得数据源中最大的Y值
                foreach (var item in chartEx.dataSource)
                {
                    dynamic temp = item.GetType().GetProperty(chartEx.YValuePath).GetValue(item);
                    try
                    {
                        double flag = temp;
                        maxValue = maxValue > flag ? maxValue : flag;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Y数据类型错误");
                    }
                }
                //将条图区域的高和Y值的比例作为换算比例
                //50在这用作Y数据Text和X轴数据Text的控件高总和的估值 （暂时没必要精确）
                chartEx._data2BarHeight = int.Parse(((chartEx._Content.ActualHeight - 50) / maxValue).ToString());
            }
        }
        #endregion

    }
}
