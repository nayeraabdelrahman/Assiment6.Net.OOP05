using System;
using System.Collections.Generic;
using System.Text;

namespace Assiment6.Net.OOP05.SmartDeliveryManagement
{
    class DeliveryAddress
    {
        string city;
        string street;
        int buildingNumber;

        public DeliveryAddress(int buildingNumber, string street, string city)
        {
            this.buildingNumber = buildingNumber;
            this.street = street;
            this.city = city;
        }
        public void SetCity(string city)
        {

            this.city = city;
        }
        public string GetFullAddress()
        {
            return $"{buildingNumber} {street} Street , {city}";
        }


    }
}
