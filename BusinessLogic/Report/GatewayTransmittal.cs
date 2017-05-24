using System;
using System.Data;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class GatewayTransmittal
    {
        public static DataSet GetGWTransmittal(string conSTR,string DateStr ,string GatewayStr ,string BCOStr ,string BatchStr)
        {
            return DAL.Reports.GatewayTransmittal.GetGatewayTransmittal(conSTR, DateStr, GatewayStr, BCOStr, BatchStr);
        }

        public static DataSet GetGWOutbound(string conSTR,string DateStr ,string GatewayStr ,string BCOStr ,string BatchStr)
        {
            return DAL.Reports.GatewayOutbound.GetGatewayOutbound(conSTR, DateStr, GatewayStr, BCOStr, BatchStr);
        }

        public static DataSet GetGWInbound(string conSTR, string DateStr,string GatewayStr,string BCOStr,string ComTypeStr)
        {
            return DAL.Reports.GatewayInbound.GetGatewayInbound(conSTR, DateStr, GatewayStr, BCOStr, ComTypeStr);
        }
        public static DataSet GetCargoTransfer(string conSTR , string date1, string origin, string destination)
        {
            return DAL.Reports.CargoTransfer.GetCargoTransfer(conSTR , date1, origin, destination );
        }

        public static DataSet GetHoldCargo(string conSTR, DateTime dateFrom, DateTime dateTo, string bco)
        {
            return DAL.Reports.HoldCargo.GetGatewayOutbound(conSTR, dateFrom, dateTo, bco);
        }
        
        public static DataSet GetGatewayList(string conSTR , string date)
        {
            return DAL.Reports.GatewayTransmittal.GetGatewayList(conSTR, date);
        }

        public static DataSet GetGatewayOutBoundList(string conSTR, string date)
        {
            return DAL.Reports.GatewayTransmittal.GetGatewayOutBoundList(conSTR, date);
        }
        public static DataSet GetGatewayInBoundList(string conSTR, string date)
        {
            return DAL.Reports.GatewayTransmittal.GetGatewayInBoundList(conSTR, date);
        }

    }
}
