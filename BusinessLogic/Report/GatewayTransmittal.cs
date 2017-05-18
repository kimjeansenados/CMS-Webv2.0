using System.Data;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class GatewayTransmittal
    {
        public static DataSet GetGWTransmittal(string conSTR)
        {
            return DAL.Reports.GatewayTransmittal.GetGatewayTransmittal(conSTR);
        }

        public static DataSet GetGWOutbound(string conSTR)
        {
            return DAL.Reports.GatewayOutbound.GetGatewayOutbound(conSTR);
        }

        public static DataSet GetGWInbound(string conSTR)
        {
            return DAL.Reports.GatewayInbound.GetGatewayInbound(conSTR);
        }
        public static DataSet GetCargoTransfer(string conSTR)
        {
            return DAL.Reports.CargoTransfer.GetGatewayOutbound(conSTR);
        }

        public static DataSet GetHoldCargo(string conSTR)
        {
            return DAL.Reports.HoldCargo.GetGatewayOutbound(conSTR);
        }

        
    }
}
