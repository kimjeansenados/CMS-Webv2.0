using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class GatewayOutbound
    {
         public static DataSet GetGatewayOutbound(string conSTR, string DateStr, string GatewayStr, string BCOStr, string BatchStr)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_GatewayOutbound", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DATE1", SqlDbType.VarChar).Value = DateStr;
                da.SelectCommand.Parameters.Add("@GATEWAY", SqlDbType.VarChar).Value = GatewayStr;
                da.SelectCommand.Parameters.Add("@BCO", SqlDbType.VarChar).Value = BCOStr;
                da.SelectCommand.Parameters.Add("@BATCH", SqlDbType.VarChar).Value = BatchStr;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
