using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using DAL = DataAccess;


namespace BusinessLogic
{
    public class ApplicableRate
    {
        public static DataSet GetApplicableRate(string conSTR)
        {
            return DAL.ApplicableRate.GetApplicableRate(conSTR);
        }


        public static DataSet GetFreeApplicableRate(string conSTR)
        {
            return DAL.ApplicableRate.GetFreeApplicableRate(conSTR);
        }


        public static void UpdateApplicableRate(Guid ApplicableRateId, Guid Createdby, string applicableratename, string description, string conStr)
        {
            DAL.ApplicableRate.UpdateApplicableRate(ApplicableRateId, Createdby, applicableratename, description, conStr);

        }
        public static void InsertApplicableRate(Guid Createdby, string applicableratename, string description, int Flag, string conStr)
        {
            DAL.ApplicableRate.InsertApplicableRate(Createdby, applicableratename, description, Flag, conStr);

        }

        public static void DeleteApplicableRate(Guid ApplicableRateId, int Flag, string conStr)
        {
            DAL.ApplicableRate.DeleteApplicableRate(ApplicableRateId, Flag, conStr);
        }
        public static DataSet GetApplicableRateID(Guid ApplicableRateID, string conSTR)
        {
            return DAL.ApplicableRate.GetApplicableRateID(ApplicableRateID, conSTR);

        }
    }
}
