using System;
using System.Collections.Generic;
using System.Text;

namespace Assiment6.Net.OOP05.SmartDeliveryManagement
{
    class DeliveryAddress
    {
       public string city { get; set; }
      public string street { get; }
       public int buildingNumber { get; }

        public DeliveryAddress(int buildingNumber, string street, string city) 
        {
            this.buildingNumber = buildingNumber;
            this.street = street;
            this.city = city;
        }

      

        public void SetCity(string City)
        {
            if (!string.IsNullOrWhiteSpace(City))
            {
                this.city = City;
            }

        }
        public string GetFullAddress()
        {
            return $"{buildingNumber} {street} Street , {city}";
        }


    }
}
