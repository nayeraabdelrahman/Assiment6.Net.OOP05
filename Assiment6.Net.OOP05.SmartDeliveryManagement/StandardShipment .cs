using System;
using System.Collections.Generic;
using System.Text;

namespace Assiment6.Net.OOP05.SmartDeliveryManagement
{
    internal class StandardShipment : Shipment, ITrackable, IInsurable
    {
        // ==========================================
        // PROPERTIES
        // ==========================================
       
        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5);
            }
        }
        // ==========================================
        // CONSTRUCTOR
        // ==========================================

        #region Constructor

        // Create a constructor that initializes
        // all inherited members using
        // constructor chaining.

        public StandardShipment(string trackingCode, string description,
            decimal weight, decimal deliveryFee, DeliveryAddress Destination, string trackingStatus)
            : base(trackingCode, description, weight, deliveryFee, Destination, trackingStatus)
        {
          Console.WriteLine("Standard Shipment Created");
      
        }
      
        #endregion
        // ==========================================
        // Methods
        // ==========================================

        #region Methods

        public override void PrintShipment()
        {
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight} Kg");
            Console.WriteLine($"Delivery Fee: {DeliveryFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");

        }

        
        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.05m; // 5% of the estimated cost
        }
        #endregion

    }
}
