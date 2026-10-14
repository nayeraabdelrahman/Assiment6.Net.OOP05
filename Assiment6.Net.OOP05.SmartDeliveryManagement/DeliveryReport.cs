using System;
using System.Collections.Generic;
using System.Text;

namespace Assiment6.Net.OOP05.SmartDeliveryManagement
{
    internal class DeliveryReport
    {
        public void PrintShipment(ITrackable shipment)
        {
            Console.WriteLine(shipment.GetTrackingStatus());

        }
        public void PrintInsurance(IInsurable shipment)
        {
            Console.WriteLine($"{shipment.GetType().Name.Replace("Shipment", " Shipment")} Insurance: {shipment.CalculateInsurance():F2} EGP");

        }
    }
}
