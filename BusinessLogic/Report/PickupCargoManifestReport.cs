using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class PickupCargoManifestReport
    {
        public static DataSet GetPickupCargoManifest(string conSTR , string Area , string AWB , string Date ,string BCOStr )
        {
            return DAL.Reports.PickupCargoManifest.GetPickupCargoManifest(conSTR , Area, AWB , Date , BCOStr);
        }
    }
}
