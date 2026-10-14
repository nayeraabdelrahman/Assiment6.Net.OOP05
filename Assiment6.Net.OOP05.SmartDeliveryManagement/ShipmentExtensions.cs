using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assiment6.Net.OOP05.SmartDeliveryManagement
{
    internal static class ShipmentExtensions
    {
        public static string GetSummary(this Shipment shipment)
        {
            return $"{shipment.TrackingCode} |{shipment.GetType().Name} |{shipment.Weight} kg| {shipment.GetTrackingStatus()}";
        }
        public static bool IsDelivered(this Shipment shipment)
        {
        return shipment.GetTrackingStatus() == "Delivered";

        }
    }
}
