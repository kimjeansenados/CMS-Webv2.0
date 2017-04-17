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
    public class Employee_Info
    {


        public static DataSet GetEmployeeName(string conStr)
        {
            return DAL.EmployeeInfo.GetEmployeeName(conStr);
        }

        public static DataSet GetEmployeeById(Guid EmployeeId, string conStr)
        {
            return DAL.EmployeeInfo.GetEmployeeNameById(EmployeeId,conStr);
        }

        public static DataSet GetEmployee(string conStr)
        {
            return DAL.EmployeeInfo.GetEmployee(conStr);
        }

        public static DataSet GetEmployeeBySearch(Guid bcoId, Guid revenueUnitTypeId, Guid rUnitId, string conStr)
        {
            return DAL.EmployeeInfo.GetEmployeeBySearch(bcoId, revenueUnitTypeId, rUnitId, conStr);
        }


        public static void InsertEmployee(Guid Departmentid, Guid PositionId, Guid AssignedToAreaId , string firstname, string lastname, string middlename,
            DateTime birthday, string telno, string mobileno, string email, string license, DateTime licenseExpiration,Guid createdby, string conStr)
        {
             DAL.EmployeeInfo.InsertEmployee(Departmentid, PositionId, AssignedToAreaId, firstname, lastname, middlename,
                birthday, telno, mobileno, email, license, licenseExpiration, createdby, conStr);
        }

        public static void UpdateEmployee(Guid EmployeeId, Guid departmentId, Guid positionId, string firstname, string lastname, string middlename,
            DateTime birthday, string telno, string mobileno, string email, string license, DateTime licenseExpiration, Guid createdby, 
            Guid assignedToAreaId, string conStr)
        {
            DAL.EmployeeInfo.UpdateEmployee(EmployeeId, departmentId, positionId, firstname, lastname, middlename,
               birthday, telno, mobileno, email, license, licenseExpiration, createdby, assignedToAreaId, conStr);
        }

        public static void DeleteEmployee(Guid employeeId, int Flag, string conStr)
        {
            DAL.EmployeeInfo.DeleteEmployee(employeeId, Flag, conStr);
        }
    }
}
