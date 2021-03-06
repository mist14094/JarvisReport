﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JarvisBusinessAccess;
using NLog;

public partial class BarCharts : System.Web.UI.Page
{
    JarvisBusinessAccessBase JarvisBA = new JarvisBusinessAccessBase();
    internal Logger nlog = LogManager.GetCurrentClassLogger();
    protected void Page_Load(object sender, EventArgs e)
    {
        nlog.Trace("JarvisWeb:BarCharts:Page_Load::Entering");
        try
        {
            if (!IsPostBack)
            {
                DataSet ds = JarvisBA.GetViewandProcedureName();
                ddViewsList.DataSource = ds;
                ddViewsList.DataValueField = "name";
                ddViewsList.DataTextField = "name";
                ddViewsList.DataBind();
            }
        }

        catch (Exception ex)
        {
            nlog.Error("JarvisWeb:BarCharts:Page_Load::Error", ex);
            throw ex;
        }
        finally
        {
            nlog.Trace("JarvisWeb:BarCharts:Page_Load::Leaving");

        }
    }
    protected void ddViewsList_SelectedIndexChanged(object sender, EventArgs e)
    {
        nlog.Trace("JarvisWeb:BarCharts:ddViewsList_SelectedIndexChanged::Entering");
        try
        {

            string strobjectname = ddViewsList.SelectedValue.ToString().Substring(0, ddViewsList.SelectedValue.ToString().IndexOf(" - ["));
            string strobjecttype = ddViewsList.SelectedValue.ToString().Substring(ddViewsList.SelectedValue.ToString().IndexOf(" - [") + 3).Replace("[", "").Replace("]", "");
            gvSampleData.DataSource = JarvisBA.GetSampleData(strobjectname,strobjecttype);
            gvSampleData.DataBind();

            ddXValue.DataSource = JarvisBA.GetViewColumnName(strobjectname);
            ddXValue.DataTextField = "column_name";
            ddXValue.DataValueField = "column_name";
            ddXValue.DataBind();
            ddXValue.Items.Insert(0, "");

            ddYValue.DataSource = JarvisBA.GetViewColumnName(strobjectname);
            ddYValue.DataTextField = "column_name";
            ddYValue.DataValueField = "column_name";
            ddYValue.DataBind();
            ddYValue.Items.Insert(0,"");

            PlotChart(JarvisBA.GetSampleData(strobjectname, strobjecttype));
        }

        catch (Exception ex)
        {
            nlog.Error("JarvisWeb:BarCharts:ddViewsList_SelectedIndexChanged::Error", ex);
            throw ex;
        }
        finally
        {
            nlog.Trace("JarvisWeb:BarCharts:ddViewsList_SelectedIndexChanged::Leaving");

        }

    }

    private void PlotChart(DataSet getSampleData)
    {
        ShieldChart1.PrimaryHeader.Text = "Sample";
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {


    }
}