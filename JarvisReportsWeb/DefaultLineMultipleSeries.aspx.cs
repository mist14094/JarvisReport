using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shield.Web.UI;
using JarvisBusinessAccess;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var JarvisBA = new JarvisBusinessAccess.JarvisBusinessAccessBase();
        var ds=   JarvisBA.GetSampleData("Account", "V");
        ShieldChart1.Width = Unit.Percentage(100);
        ShieldChart1.Height = Unit.Pixel(900);

        string XAxisColumnName = "TicketDate";
        ShieldChart1.PrimaryHeader.Text = "Truck Samples : ";
        ShieldChart1.SecondaryHeader.Text = "Generated on " + DateTime.Now.ToString(CultureInfo.InvariantCulture);
        ShieldChart1.ExportOptions.AllowExportToImage = true;
        ShieldChart1.ExportOptions.AllowPrint = true;
        ShieldChart1.TooltipSettings.AxisMarkers.Enabled = true;
        ShieldChart1.TooltipSettings.AxisMarkers.Mode = ChartXYMode.XY;
        ShieldChart1.TooltipSettings.AxisMarkers.Width = new Unit(1);
        ShieldChart1.TooltipSettings.AxisMarkers.ZIndex = 3;
        ShieldChart1.ZoomMode = ChartXYMode.X;
        //ShieldChart1.IsInverted = true;

        if (ds == null) return;
        if (ds.Tables.Count > 0)
        {
            var chartAxisX = new ChartAxisX
            {
                CategoricalValues =
                    ds.Tables[0].AsEnumerable().Select(row => row[XAxisColumnName].ToString()).ToArray(),
                AxisTickText = { TextAngle = 270, Y = 75 }
            };
            var chartAxisY = new ChartAxisY { AxisTickText = { Format = "{text}" }, Title = { Text = "Y Axis" } };
            ShieldChart1.Axes.Add(item: chartAxisX);
            ShieldChart1.Axes.Add(item: chartAxisY);
            ShieldChart1.TooltipSettings.ChartBound = true;


            ChartLineSeries chartBarLineSeries = new ChartLineSeries();
            chartBarLineSeries.Settings.DataPointText.Enabled = true;
            chartBarLineSeries.DataFieldY = "amount";
            chartBarLineSeries.CollectionAlias = "Posts per Day";
            chartBarLineSeries.Settings.StackMode = ChartStackMode.Normal;
            ShieldChart1.DataSeries.Add(chartBarLineSeries);


            chartBarLineSeries = new ChartLineSeries();
            chartBarLineSeries.Settings.DataPointText.Enabled = true;
            chartBarLineSeries.DataFieldY = "shift_seq";
            chartBarLineSeries.CollectionAlias = "Posts per Day1";
            chartBarLineSeries.Settings.StackMode = ChartStackMode.Normal;
            ShieldChart1.DataSeries.Add(chartBarLineSeries);

            ShieldChart1.DataSource = ds;
            ShieldChart1.DataBind();
        }
    }

     
}