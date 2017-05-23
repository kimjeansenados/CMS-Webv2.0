using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class BundleReport
    {
        public static DataSet GetBundle(string conSTR, string date, string bundlenumber , string bco)
        {
            return DAL.Reports.Bundle.GetBundle(conSTR , date , bundlenumber , bco);
        }

        public static DataSet GetBundleNumber(string conSTR, string date)
        {
            return DAL.Reports.Bundle.GetBundleNumber(conSTR, date);
        }
    }
}
