using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class CargoTransfer
    {
        public static DataSet GetCargoTransfer(string conSTR ,string date1 , string origin , string destination)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_CargoTransfer", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DATE1", SqlDbType.VarChar).Value = date1;
                da.SelectCommand.Parameters.Add("@ORIGIN", SqlDbType.VarChar).Value = origin;
                da.SelectCommand.Parameters.Add("@DESTINATION", SqlDbType.VarChar).Value = destination;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }


    }
}
