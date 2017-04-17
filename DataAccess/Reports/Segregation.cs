using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class Segregation
    {
        public static DataSet GetSegregation(string conSTR,string DateStr ,string DriverStr,string CheckerStr,string PlateNoStr,string BCOStr , string City)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_Segregation", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DATE", SqlDbType.VarChar).Value = DateStr;
                da.SelectCommand.Parameters.Add("@DRIVER", SqlDbType.VarChar).Value = DriverStr;
                da.SelectCommand.Parameters.Add("@CHECKER", SqlDbType.VarChar).Value = CheckerStr;
                da.SelectCommand.Parameters.Add("@PLATENO", SqlDbType.VarChar).Value = PlateNoStr;
                da.SelectCommand.Parameters.Add("@BCO", SqlDbType.VarChar).Value = BCOStr;
                da.SelectCommand.Parameters.Add("@CITY", SqlDbType.VarChar).Value = City;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
