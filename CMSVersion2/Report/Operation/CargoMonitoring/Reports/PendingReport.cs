namespace CMSVersion2.Report.Operation.CargoMonitoring.Reports
{
    using Models;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for PendingReport.
    /// </summary>
    public partial class PendingReport : Telerik.Reporting.Report
    {
        public PendingReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            var objectDataSource = new Telerik.Reporting.ObjectDataSource();
            DataTable dataTable = ReportGlobalModel.table1;
            objectDataSource.DataSource = dataTable;
            table1.DataSource = objectDataSource;

            txtFrom.Value = ReportGlobalModel.Date;
            txtTo.Value = ReportGlobalModel.Remarks;
        }
    }
}