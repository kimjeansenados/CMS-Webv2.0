using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class AirwayBill
    {
        public static DataSet GetAwbInfoByAwbNo(string awbNo, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_Search_AwbNo", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@AwbNo", SqlDbType.NVarChar).Value = awbNo;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static DataSet GetDetailsAwbNo(string awbNo, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_Transaction_AwbNo", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@AwbNo", SqlDbType.NVarChar).Value = awbNo;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        
       
    }
}
