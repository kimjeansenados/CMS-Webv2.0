using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class SegregationReport
    {
        public static DataSet GetSegregation(string conSTR, string DateStr ,string DriverStr, string CheckerStr,string PlateNoStr,string BCOStr , string City)
        {
            return DAL.Reports.Segregation.GetSegregation(conSTR, DateStr, DriverStr, CheckerStr, PlateNoStr, BCOStr , City);
        }
    }
}
