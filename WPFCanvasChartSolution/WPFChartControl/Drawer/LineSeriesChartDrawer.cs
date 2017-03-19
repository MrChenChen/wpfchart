using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using IgorCrevar.WPFChartControl.Model;
using System.Collections.ObjectModel;

namespace IgorCrevar.WPFChartControl.Drawer
{
    public class LineSeriesChartDrawer : AbstractChartDrawer
    {

        protected IList<IList<Point>> chartPoints;

        public Action<DrawingContext> DrawingCanvas;

        public IList<IList<Point>> ChartPoints
        {
            set
            {
                value = chartPoints;
            }
            get
            {
                return chartPoints;
            }
        }

        public LineSeriesChartDrawer(IList<IList<Point>> chartPoints)
        {
            this.chartPoints = chartPoints;
            Settings = new WPFCanvasChart.WPFCanvasChartSettings();
            Settings.ZoomXYAtSameTime = true;
        }

        public LineSeriesChartDrawer(IList<Point> chartPoints)
            : this(new List<IList<Point>>() { chartPoints })
        {
        }

        private void DrawDot(Point point, DrawingContext ctx, LegendItem item)
        {
            if (item.IsDotEnable)
            {
                ctx.DrawEllipse(item.DotBrush, item.DotPen, point, item.DotRadius, item.DotRadius);
            }
        }

        public override void Draw(DrawingContext ctx)
        {
            if (DrawingCanvas != null) DrawingCanvas(ctx);
            for (int j = 0; j < chartPoints.Count; ++j)
            {
                var seriePoints = chartPoints[j];
                if (seriePoints.Count < 2)
                {
                    continue;
                }
                //Legend[j].LinePen.Freeze();
                Point prevPoint = Chart.Point2ChartPoint(seriePoints[0]);
                DrawDot(prevPoint, ctx, Legend[j]);            //Draw Previous Point
                for (int i = 1; i < seriePoints.Count; ++i)
                {
                    var currPoint = Chart.Point2ChartPoint(seriePoints[i]);
                    ctx.DrawLine(Legend[j].LinePen, prevPoint, currPoint);   //Draw Line Between Two Points
                    prevPoint = currPoint;
                    DrawDot(prevPoint, ctx, Legend[j]);        //Draw Current Point
                }
            }
        }

        public override MinMax GetMinMax()
        {
            MinMax minMax = new MinMax(true);
            foreach (var serie in chartPoints)
            {
                foreach (var p in serie)
                {
                    minMax.Update(p, p);
                }
            }

            if (minMax.minY == minMax.maxY)
            {
                minMax.maxY += 1.0d;
                minMax.minY -= 1.0d;
            }

            return minMax;
        }

        protected override void OnUpdate()
        {
            if (Legend == null)
            {
                Legend = new ObservableCollection<LegendItem>();
                for (int i = 0; i < chartPoints.Count; ++i)
                {
                    Legend.Add(new LegendItem());
                }
            }

            if (chartPoints.Count != Legend.Count)
            {
                throw new ArgumentException(string.Format(
                    "chartPoints.Count = {0} and Legend.Count = {1}. Lists must contains same number of elements",
                    chartPoints.Count, Legend.Count));
            }
        }

    }
}
