using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class DailyTripReport
    {
        public static DataSet GetDailyTrip(string conSTR, string DateStr, string AreaStr , String BCO)
        {
            return DAL.Reports.DailyTrip.GetDailyTrip(conSTR, DateStr, AreaStr , BCO);
        }
    }
}
