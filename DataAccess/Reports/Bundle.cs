using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class Bundle
    {
        public static DataSet GetBundle(string conSTR , string date , string bundlenumber , string  destination, string BCO)
        {
            using (SqlConnection con = new SqlConnection(conSTR ))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_Bundle", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DATE", SqlDbType.VarChar).Value = date;
                da.SelectCommand.Parameters.Add("@BUNDLE", SqlDbType.VarChar).Value = bundlenumber;
                da.SelectCommand.Parameters.Add("@DESTINATION", SqlDbType.VarChar).Value = destination;
                da.SelectCommand.Parameters.Add("@BCO", SqlDbType.VarChar).Value = BCO;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
