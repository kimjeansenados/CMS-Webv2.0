using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class Unbundle
    {
        public static DataSet GetUnbundle(string conSTR, string DateStr, string SackNoStr, string OriginStr , string BCO)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_Unbundle", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DATE", SqlDbType.VarChar).Value = DateStr;
                da.SelectCommand.Parameters.Add("@SACKNO", SqlDbType.VarChar).Value = SackNoStr;
                da.SelectCommand.Parameters.Add("@ORIGIN", SqlDbType.VarChar).Value = OriginStr;
                da.SelectCommand.Parameters.Add("@BCO", SqlDbType.VarChar).Value = BCO;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
