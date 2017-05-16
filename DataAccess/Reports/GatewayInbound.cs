using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Reports
{
    public class GatewayInbound
    {
        public static DataSet GetGatewayInbound(string conSTR,string DateStr,string GatewayStr,string BCOStr,string ComTypeStr)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_GatewayInbound", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DATE1", SqlDbType.VarChar).Value = DateStr;
                da.SelectCommand.Parameters.Add("@GATEWAY", SqlDbType.VarChar).Value = GatewayStr;
                da.SelectCommand.Parameters.Add("@BCO", SqlDbType.VarChar).Value = BCOStr;
                da.SelectCommand.Parameters.Add("@COMTYPE", SqlDbType.VarChar).Value = ComTypeStr;

                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
