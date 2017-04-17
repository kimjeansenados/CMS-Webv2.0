using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class UnbundleReport
    {
        public static DataSet GetBundle(string conSTR , string DateStr , string SackNoStr , string OriginStr , string BCO)
        {
            return DAL.Reports.Unbundle.GetUnbundle(conSTR , DateStr, SackNoStr, OriginStr , BCO);
        }
    }
}