using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAL = BusinessLogic;

namespace CMS2.API.Controllers
{
    public class ShipmentController : ApiController
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Shipment"].ConnectionString;
        public List<BusinessLogic.Invoice> getinvoices([FromUri] DateTime start, [FromUri] DateTime end)
        {
            return BAL.Invoice.GetInvoices(start, end, connectionString);
        }
    }
}
