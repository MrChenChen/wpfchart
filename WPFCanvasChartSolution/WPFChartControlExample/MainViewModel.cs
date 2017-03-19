using System;
using System.Collections.Generic;
using System.ComponentModel;
using IgorCrevar.WPFCanvasChart;
using IgorCrevar.WPFCanvasChart.Interpolators;
using System.Windows;
using System.Windows.Media;
using IgorCrevar.WPFChartControl.Model;
using IgorCrevar.WPFChartControl.Drawer;

namespace WPFChartControlExample
{
    class MainViewModel : INotifyPropertyChanged
    {

        private AbstractChartDrawer lineSeriesChartDrawer;


        public MainViewModel()
        {
            var rnd = new Random();

            var serie1 = new List<Point>();
            var serie2 = new List<Point>();
            var item1 = new LegendItem();
            item1.DotRadius = 2;
            item1.IsDotEnable = true;
            item1.DotBrush = Brushes.Transparent;
            item1.DotPen = new Pen(Brushes.Red, 1);
            item1.Name = "Red";
            item1.LinePen = new Pen(Brushes.Red, 1);



            var item2 = new LegendItem();
            item2.Name = "Blue";
            item2.LinePen = new Pen(Brushes.Blue, 0);



            for (int i = 0; i < 50; ++i)
            {
                serie1.Add(new Point(i, rnd.NextDouble() * 200 - 100));
                serie2.Add(new Point(i + 1, rnd.NextDouble() * 200 - 100));
            }

            LineSeriesChartDrawer = new LineSeriesChartDrawer(new List<IList<Point>>{
                serie1, serie2
            });

            (LineSeriesChartDrawer as LineSeriesChartDrawer).Title = "12345";

            lineSeriesChartDrawer.Legend = new List<LegendItem>();
            lineSeriesChartDrawer.ShowLegendIten = true;
            lineSeriesChartDrawer.Legend.Add(item1);
            lineSeriesChartDrawer.Legend.Add(item2);


            var setting = lineSeriesChartDrawer.Settings = new WPFCanvasChartSettings();
            setting.FontSize = 12;
            setting.ZoomXYAtSameTime = true;


            

        }

        //public AbstractChartDrawer BarChartDrawer
        //{
        //    get
        //    {
        //        return barChartDrawer;
        //    }

        //    set
        //    {
        //        if (barChartDrawer != value)
        //        {
        //            barChartDrawer = value;
        //            OnPropertyChanged("BarChartDrawer");
        //        }
        //    }
        //}

        public AbstractChartDrawer LineSeriesChartDrawer
        {
            get
            {
                return lineSeriesChartDrawer;
            }

            set
            {
                if (lineSeriesChartDrawer != value)
                {
                    lineSeriesChartDrawer = value;
                    OnPropertyChanged("LineSeriesChartDrawer");
                }
            }
        }

        //public AbstractChartDrawer StackedBarChartDrawer
        //{
        //    get
        //    {
        //        return stackedBarChartDrawer;
        //    }

        //    set
        //    {
        //        if (stackedBarChartDrawer != value)
        //        {
        //            stackedBarChartDrawer = value;
        //            OnPropertyChanged("StackedBarChartDrawer");
        //        }
        //    }
        //}

        #region INotifyPropertyChanged part
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
