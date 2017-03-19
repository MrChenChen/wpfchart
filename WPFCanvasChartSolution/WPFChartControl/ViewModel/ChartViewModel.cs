using System.ComponentModel;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Media;
using IgorCrevar.WPFChartControl.Model;
using IgorCrevar.WPFChartControl.Drawer;

namespace IgorCrevar.WPFChartControl.ViewModel
{
    class ChartViewModel : INotifyPropertyChanged
    {
        private string tTitle = string.Empty;
        private string xAxisText = string.Empty;
        private string yAxisText = string.Empty;

        private string posX;
        public string PosX
        {
            get { return posX; }
            set { posX = value; OnPropertyChanged("PosX"); }
        }


        private string posY;
        public string PosY
        {
            get { return posY; }
            set { posY = value; OnPropertyChanged("PosY"); }
        }

        private Visibility horizScrollVisibility = Visibility.Collapsed;
        private Visibility vertScrollVisibility = Visibility.Collapsed;
        private Visibility legendVisibility = Visibility.Visible;
        private Visibility postionVisibility = Visibility.Collapsed;


        private ObservableCollection<LegendItem> legend = new ObservableCollection<LegendItem>();
        private Brush background;
        private double legendWidth;

        public void Update(AbstractChartDrawer drawer)
        {
            XAxisText = drawer.XAxisText;
            YAxisText = drawer.YAxisText;
            Title = drawer.Title;
            HorizScrollVisibility = drawer.HorizScrollVisibility;
            VertScrollVisibility = drawer.VertScrollVisibility;
            PostionVisibility = drawer.PostionVisibility;
            LegendVisibility = drawer.ShowLegendIten && drawer.Legend != null && drawer.Legend.Count != 0 ? Visibility.Visible : Visibility.Collapsed;
            Background = drawer.Background;
            legend.Clear();
            if (drawer.Legend != null)
            {
                foreach (var it in drawer.Legend)
                {
                    legend.Add(it);
                }
            }
        }

        public string Title
        {
            get
            {
                return tTitle;
            }

            set
            {
                if (Title != value)
                {
                    tTitle = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        public string XAxisText
        {
            get
            {
                return xAxisText;
            }

            set
            {
                if (xAxisText != value)
                {
                    xAxisText = value;
                    OnPropertyChanged("XAxisText");
                }
            }
        }

        public string YAxisText
        {
            get
            {
                return yAxisText;
            }

            set
            {
                if (yAxisText != value)
                {
                    yAxisText = value;
                    OnPropertyChanged("YAxisText");
                }
            }
        }

        public Visibility HorizScrollVisibility
        {
            get
            {
                return horizScrollVisibility;
            }

            set
            {
                if (horizScrollVisibility != value)
                {
                    horizScrollVisibility = value;
                    OnPropertyChanged("HorizScrollVisibility");
                }
            }
        }

        public Visibility VertScrollVisibility
        {
            get
            {
                return vertScrollVisibility;
            }

            set
            {
                if (vertScrollVisibility != value)
                {
                    vertScrollVisibility = value;
                    OnPropertyChanged("VertScrollVisibility");
                }
            }
        }

        public Visibility LegendVisibility
        {
            get
            {
                return legendVisibility;
            }

            set
            {
                if (legendVisibility != value)
                {
                    legendVisibility = value;
                    OnPropertyChanged("LegendVisibility");
                }
            }
        }

        public Visibility PostionVisibility
        {
            get { return postionVisibility; }
            set { postionVisibility = value; OnPropertyChanged("PostionVisibility"); }
        }

        public double LegendWidth
        {
            get
            {
                return legendWidth;
            }

            set
            {
                if (legendWidth != value)
                {
                    legendWidth = value;
                    OnPropertyChanged("LegendWidth");
                }
            }
        }

        public ObservableCollection<LegendItem> Legend
        {
            get
            {
                return legend;
            }
        }

        public Brush Background
        {
            get
            {
                return background;
            }

            set
            {
                if (background != value)
                {
                    background = value;
                    OnPropertyChanged("Background");
                }
            }
        }

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
