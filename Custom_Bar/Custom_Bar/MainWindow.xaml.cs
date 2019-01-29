using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;

namespace Custom_Bar
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            List<Bar> _bar = new List<Bar>
            {
                new Bar() { BarName = "Rajesh", Value = 80 },
                new Bar() { BarName = "Suresh", Value = 60 },
                new Bar() { BarName = "Dan", Value = 40 },
                new Bar() { BarName = "Sevenx", Value = 67 },
                new Bar() { BarName = "Patel", Value = 15 },
                new Bar() { BarName = "Joe", Value = 70 },
                new Bar() { BarName = "Bill", Value = 90 },
                new Bar() { BarName = "Vlad", Value = 23 },
                new Bar() { BarName = "Steve", Value = 12 },
                new Bar() { BarName = "Pritam", Value = 100 },
                new Bar() { BarName = "Genis", Value = 54 },
                new Bar() { BarName = "Ponnan", Value = 84 },
                new Bar() { BarName = "Mathew", Value = 43 }
            };
            this.DataContext = new RecordCollection(_bar);

            //数据源是一个动态集合
            MyTable.YValuePath = "Data";
            MyTable.XValuePath = "Name";
            MyTable.DataSource = new RecordCollection(_bar);

            //数据源是一个列表
            //MyTable.YValuePath = "Value";
            //MyTable.XValuePath = "BarName";
            //MyTable.DataSource = _bar;



        }
    }

    class RecordCollection : ObservableCollection<Record>
    {

        public RecordCollection(List<Bar> barvalues)
        {
            Random rand = new Random();
            BrushCollection brushcoll = new BrushCollection();

            foreach (Bar barval in barvalues)
            {
                int num = rand.Next(brushcoll.Count / 3);
                Add(new Record(barval.Value, brushcoll[num], barval.BarName));
            }
        }

    }

    class BrushCollection : ObservableCollection<Brush>
    {
        public BrushCollection()
        {
            Type _brush = typeof(Brushes);
            PropertyInfo[] props = _brush.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                Brush _color = (Brush)prop.GetValue(null, null);
                if (_color != Brushes.LightSteelBlue && _color != Brushes.White &&
                     _color != Brushes.WhiteSmoke && _color != Brushes.LightCyan &&
                     _color != Brushes.LightYellow && _color != Brushes.Linen)
                    Add(_color);
            }
        }
    }

    class Bar
    {

        public string BarName { set; get; }

        public int Value { set; get; }

    }

    class Record : INotifyPropertyChanged
    {
        public Brush Color { set; get; }

        public string Name { set; get; }

        private int _data;
        public int Data
        {
            set
            {
                if (_data != value)
                {
                    _data = value;

                }
            }
            get
            {
                return _data;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Record(int value, Brush color, string name)
        {
            Data = value;
            Color = color;
            Name = name;
        }

        protected void PropertyOnChange(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
}
