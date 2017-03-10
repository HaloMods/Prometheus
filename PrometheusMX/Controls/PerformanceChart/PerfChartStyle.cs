using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Prometheus.Controls
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class PerfChartStyle
    {
        private ChartPen verticalGridPen;
        private ChartPen horizontalGridPen;
        private ChartPen avgLinePen;
        private ChartPen chartLinePen;

        private Color backgroundColorTop = Color.DarkGreen;
        private Color backgroundColorBottom = Color.DarkGreen;

        private bool showVerticalGridLines = true;
        private bool showHorizontalGridLines = true;
        private bool showAverageLine = true;
        private bool antiAliasing = true;

        public PerfChartStyle() {
            verticalGridPen = new ChartPen();
            horizontalGridPen = new ChartPen();
            avgLinePen = new ChartPen();
            chartLinePen = new ChartPen();
        }

        public bool ShowVerticalGridLines {
            get { return showVerticalGridLines; }
            set { showVerticalGridLines = value; }
        }

        public bool ShowHorizontalGridLines {
            get { return showHorizontalGridLines; }
            set { showHorizontalGridLines = value; }
        }

        public bool ShowAverageLine {
            get { return showAverageLine; }
            set { showAverageLine = value; }
        }

        public ChartPen VerticalGridPen {
            get { return verticalGridPen; }
            set { verticalGridPen = value; }
        }

        public ChartPen HorizontalGridPen {
            get { return horizontalGridPen; }
            set { horizontalGridPen = value; }
        }

        public ChartPen AvgLinePen {
            get { return avgLinePen; }
            set { avgLinePen = value; }
        }

        public ChartPen ChartLinePen {
            get { return chartLinePen; }
            set { chartLinePen = value; }
        }

        public bool AntiAliasing {
            get { return antiAliasing; }
            set { antiAliasing = value; }
        }

        public Color BackgroundColorTop {
            get { return backgroundColorTop; }
            set { backgroundColorTop = value; }
        }

        public Color BackgroundColorBottom {
            get { return backgroundColorBottom; }
            set { backgroundColorBottom = value; }
        }
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class ChartPen
    {
        private Pen pen;

        public ChartPen() {
            pen = new Pen(Color.Black);
        }

        public Color Color {
            get { return pen.Color; }
            set { pen.Color = value; }
        }

        public DashStyle DashStyle {
            get { return pen.DashStyle; }
            set { pen.DashStyle = value; }
        }

        public float Width {
            get { return pen.Width; }
            set { pen.Width = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Pen Pen {
            get { return pen; }
        }
    }
}
