using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Reports
{
    public class GatewayInbound
    {
        public static DataSet GetGatewayInbound(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_GatewayInbound", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.Add("@DATE1", SqlDbType.Date).Value = date1;
                //da.SelectCommand.Parameters.Add("@DATE2", SqlDbType.Date).Value = date2;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
