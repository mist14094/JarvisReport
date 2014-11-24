using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void ShieldChart1_TakeDataSource(object sender, Shield.Web.UI.ChartTakeDataSourceEventArgs e)
    {
        List<BrowsersUsagePerYear> datasource = new List<BrowsersUsagePerYear>() 
            { 
                new BrowsersUsagePerYear() { Chrome = 0, Firefox = 0, IE = 76.2, Mozilla = 16.5, Opera = 1.6, Safari = 0 },
                new BrowsersUsagePerYear() { Chrome = 0, Firefox = 23.6, IE = 68.9, Mozilla = 2.8, Opera = 1.5, Safari = 0 },
                new BrowsersUsagePerYear() { Chrome = 0, Firefox = 29.9, IE = 60.6, Mozilla = 2.5, Opera = 1.5, Safari = 0 },
                new BrowsersUsagePerYear() { Chrome = 0, Firefox = 36.3, IE = 56.0, Mozilla = 1.2, Opera = 1.6, Safari = 1.8 },
                new BrowsersUsagePerYear() { Chrome = 3.6, Firefox = 44.4, IE = 46.0, Mozilla = 0, Opera = 2.4, Safari = 2.7 },
                new BrowsersUsagePerYear() { Chrome = 9.8, Firefox = 46.4, IE = 37.2, Mozilla = 0, Opera = 2.3, Safari = 3.6 },
                new BrowsersUsagePerYear() { Chrome = 22.4, Firefox = 43.5, IE = 27.5, Mozilla = 0, Opera = 2.2, Safari = 3.8 },
                new BrowsersUsagePerYear() { Chrome = 34.6, Firefox = 37.7, IE = 20.2, Mozilla = 0, Opera = 2.5, Safari = 4.2 }
            };

        ShieldChart1.DataSource = datasource;
        ShieldChart1.DataBind();
    }

    private class BrowsersUsagePerYear
    {
        public double Chrome { get; set; }
        public double Firefox { get; set; }
        public double IE { get; set; }
        public double Mozilla { get; set; }
        public double Opera { get; set; }
        public double Safari { get; set; }
    }
}