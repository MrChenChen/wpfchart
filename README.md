# WPFCanvasChart

### Customizable WPF charting for large number of elements
There are controls for: Line series charts, Bar charts, Stacked bar charts, etc. 
You can also use WPFCanvasChartComponent class directly(look at WPFCanvasChartTest example). The class will do for you things like axis drawing, point translation, zooming, scrolling, etc... Actual chart content is drawn by user.
Both WPFCanvasChartComponent and WPFChartControl are fast and customizable.

### How to use?
Its easy! Just look at WPFChartControlExample or WPFCanvasChartTest example projects in solution.
Using chart control is easy. In XAML:
``` xml
...
xmlns:chart="clr-namespace:IgorCrevar.WPFChartControl;assembly=WPFChartControl"
...
<chart:ChartControl Drawer="{Binding Path=YourCustomDrawer}" />
```
In ViewModel you can do something like:
``` c#
private AbstractChartDrawer lineSeriesChartDrawer;

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
```
etc
Check example for more options for every drawer...

Also you can use WPFCanvasChartComponent directly (from WPFCanvasChart project)
- Before using, instance of WPFCanvasChart must be created
- after that, you must set min/max x/y of your chart values using WPFCanvasChart  instance SetMinMax method
- you must implement IWPFCanvasChartDrawer interface
- draw call on WPFCanvasChart instance will draw chart(step above must be executed before drawing!)
- IWPFCanvasChartDrawer method public void Draw(DrawingContext ctx) is used to draw actual graph
- Inside public void Draw(DrawingContext ctx) use Point2ChartPoint to convert your actual value to chart point

#### Note:
Chart is fast if canvas used for charting is inside Viewbox(like in code snippet bellow). If canvas is inside some other container(for example grid like in second code snippet bellow. This is how chart is created inside chart control), than performances dramatically decrease. Why? I do not know yet.
``` xml
<!-- fast -->
<Viewbox Stretch="Fill" Grid.Row="1">
	<Canvas Name="Canvas" Width="350" Height="190" />
</Viewbox>

<!-- slow :( -->
<Grid Grid.Row="0" Grid.Column="1" Name="CanvasParent" 
	HorizontalAlignment="Stretch" VerticalAlignment="Stretch">
	<Canvas Name="Canvas" Width="{Binding Path=ActualWidth, ElementName=CanvasParent, Mode=OneWay}"
		Height="{Binding Path=ActualHeight, ElementName=CanvasParent, Mode=OneWay}"/>
</Grid>
```
