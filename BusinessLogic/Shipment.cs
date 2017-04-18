using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic
{
    public class Shipment
    {
        public static DataSet GetShipmentsAndPaymentsBySOAID(Guid SOAID, string Constr)
        {
            return DAL.Shipment.GetShipmentsAndPaymentsBySoaId(SOAID, Constr);
        }
    }
}
