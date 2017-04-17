using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class DailyTrip
    {
        public static DataSet GetDailyTrip(string conSTR, string DateStr, string AreaStr , string BCO)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_DailyTripReport", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DATE", SqlDbType.VarChar).Value = DateStr;
                da.SelectCommand.Parameters.Add("@BCO", SqlDbType.VarChar).Value = BCO;
                da.SelectCommand.Parameters.Add("@AREA", SqlDbType.VarChar).Value = AreaStr;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
