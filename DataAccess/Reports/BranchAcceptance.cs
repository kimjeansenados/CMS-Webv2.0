using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class BranchAcceptance
    {
        public static DataSet GetBranchAcceptance(string conSTR, string Date, string Area , string Batch , string BCO)
        {
            try {
                using (SqlConnection con = new SqlConnection(conSTR))
                {

                    SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_BranchAcceptance", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DATE", SqlDbType.VarChar).Value = Date;
                    da.SelectCommand.Parameters.Add("@AREA", SqlDbType.VarChar).Value = Area;
                    da.SelectCommand.Parameters.Add("@BATCH", SqlDbType.VarChar).Value = Batch;
                    da.SelectCommand.Parameters.Add("@BCO", SqlDbType.VarChar).Value = BCO;

                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
