using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic
{
    public class StatementOfAccount
    {
        public static DataSet GetAll(string conSTR)
        {
            return DAL.StatementOfAccount.GetAll(conSTR);
        }

        public static DataSet GetSOADetails(Guid SOAID, string conSTR)
        {
            return DAL.StatementOfAccount.GetSOADetails(SOAID, conSTR);
        }
    }
}
