using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class CollectionReport
    {
        public static DataSet GetCollection(string conSTR, string bcostr ,string type,DateTime? date1,DateTime? date2)
        {
            return DAL.Reports.Collection.GetCollection(conSTR, bcostr, type, date1, date2);
        }
    }
}
