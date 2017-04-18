namespace CMSVersion2.Report.Operation.Manifest.Reports
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for Report1.
    /// </summary>
    public partial class PickupReport : Telerik.Reporting.Report
    {
        public PickupReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //var objectDataSource = new Telerik.Reporting.ObjectDataSource();
            //DataTable dataTable = null; //TrackingReportGlobalModel.table;
            //objectDataSource.DataSource = dataTable;
            //table1.DataSource = objectDataSource;

        }
    }
}