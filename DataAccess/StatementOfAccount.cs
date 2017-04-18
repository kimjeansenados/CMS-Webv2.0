using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StatementOfAccount
    {
        public static DataSet GetAll(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_StatementOfAccounts", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }            
        }
        public static DataSet GetSOADetails(Guid SOAID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_StatementOfAccountDetails", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@soaid", SqlDbType.UniqueIdentifier).Value = SOAID;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }   
        }

        public static DataSet GetSOAForPrint(DateTime BillingPeriodFrom, DateTime BillingPeriodTo, Guid CompanyId, Guid BillingPeriodId, Guid SOAId, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_print_StatementOfAccount", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@start", SqlDbType.DateTime).Value = BillingPeriodFrom;
                da.SelectCommand.Parameters.Add("@end", SqlDbType.DateTime).Value = BillingPeriodTo;
                da.SelectCommand.Parameters.Add("@companyid", SqlDbType.UniqueIdentifier).Value = CompanyId;
                da.SelectCommand.Parameters.Add("@billingperiodid", SqlDbType.UniqueIdentifier).Value = BillingPeriodId;
                da.SelectCommand.Parameters.Add("@soaid", SqlDbType.UniqueIdentifier).Value = SOAId;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        public static DataSet GetBySOAID(string SOAId, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_StatementOfAccount_by_soaId", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@soaid", SqlDbType.UniqueIdentifier).Value = SOAId;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }


    }
}
