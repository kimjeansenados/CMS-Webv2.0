using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class GatewayTransmittal
    {
        public static DataSet GetGatewayTransmittal(string conSTR ,string DateStr , string GatewayStr , string BCOStr , string BatchStr)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_GatewayTransmittal", con);
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

        public static DataSet GetGatewayList(string conSTR , string date)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_GetGatewayList", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DATE1", SqlDbType.VarChar).Value = date;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
    }
}
