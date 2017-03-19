using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace IgorCrevar.WPFChartControl.Model
{
    public class LegendItem : INotifyPropertyChanged
    {
        private Color lineColor = Colors.Transparent;
        public Color LineColor
        {
            get
            {
                if (lineColor != Colors.Transparent) return lineColor;
                var line = LinePen.Brush as SolidColorBrush;
                if (line != null) return line.Color;
                var dot = DotPen.Brush as SolidColorBrush;
                if (dot != null) return dot.Color;
                var dotbrush = DotBrush as SolidColorBrush;
                if (dotbrush != null) return dotbrush.Color;
                return Colors.Black;
            }
            set
            {
                lineColor = value;
                OnPropertyChanged("LineColor");
            }
        }

        public Pen LinePen = new Pen(Brushes.Black, 1);

        public Pen DotPen = new Pen(Brushes.Black, 1);

        public Brush DotBrush = Brushes.Black;

        public double DotRadius = 1.0d;

        public bool IsDotEnable = false;

        string name = string.Empty;

        public string Name
        {
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
            get
            {
                return name;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
