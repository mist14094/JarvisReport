<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>
<%@ Register TagPrefix="shield" Namespace="Shield.Web.UI" Assembly="Shield.Web.UI, Version=1.7.2.0, Culture=neutral, PublicKeyToken=d849307612f07c09" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       
    <shield:ShieldChart ID="ShieldChart1" Width="100%" Height="400px" runat="server" 
        OnTakeDataSource="ShieldChart1_TakeDataSource"
        CssClass="chart">
        <PrimaryHeader Text="Browser usage per year"></PrimaryHeader>
        <ExportOptions AllowExportToImage="false" AllowPrint="false" />
        <Axes>
            <shield:ChartAxisX CategoricalValues="2004, 2005, 2006, 2007, 2008, 2009, 2010, 2011">
            </shield:ChartAxisX>
        </Axes>
        <DataSeries>
            <shield:ChartAreaSeries DataFieldY="Chrome" CollectionAlias="Chrome">
                <Settings StackMode="Normal"></Settings>
            </shield:ChartAreaSeries>
            <shield:ChartAreaSeries DataFieldY="Firefox" CollectionAlias="Firefox">
                <Settings StackMode="Normal"></Settings>
            </shield:ChartAreaSeries>
            <shield:ChartAreaSeries DataFieldY="IE" CollectionAlias="Internet Explorer">
                <Settings StackMode="Normal"></Settings>
            </shield:ChartAreaSeries>
             <shield:ChartAreaSeries DataFieldY="Mozilla" CollectionAlias="Mozilla">
                 <Settings StackMode="Normal"></Settings>
            </shield:ChartAreaSeries>
             <shield:ChartAreaSeries DataFieldY="Opera" CollectionAlias="Opera">
                 <Settings StackMode="Normal"></Settings>
            </shield:ChartAreaSeries>
             <shield:ChartAreaSeries DataFieldY="Safari" CollectionAlias="Safari">
                 <Settings StackMode="Normal"></Settings>
            </shield:ChartAreaSeries>
        </DataSeries>
    </shield:ShieldChart>
</asp:Content>

