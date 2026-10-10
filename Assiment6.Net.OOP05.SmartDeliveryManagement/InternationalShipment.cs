using System;
using System.Collections.Generic;
using System.Text;

namespace Assiment6.Net.OOP05.SmartDeliveryManagement
{
    internal class InternationalShipment : Shipment, ITrackable, IInsurable
    {
        // ==========================================
        // FIELDS
        // ==========================================

        #region Fields

        // Destination Country
        // Customs Fee

        string destinationCountry;
        decimal customsFee;

        #endregion


        // ==========================================
        // PROPERTIES
        // ==========================================

        #region Properties

        // DestinationCountry
        // Cannot be null, empty, or whitespace.
        public string DestinationCountry
        {
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    destinationCountry = value;
                }
            }
            get { return destinationCountry; }
        }

        // CustomsFee
        // Must be greater than or equal to 0.
        public decimal CustomsFee
        {
            set
            {
                if (value >= 0)
                {
                    customsFee = value;
                }
            }
            get { return customsFee; }
        }

        // EstimatedCost
        // Override the inherited property.
        //
        // Formula:
        // DeliveryFee + (Weight * 5) + CustomsFee
        override public decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5) + CustomsFee;
            }
        }


        #endregion


        // ==========================================
        // CONSTRUCTOR
        // ==========================================

        #region Constructor

        //Create a constructor that initializes all inherited members and the new properties.
        public InternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee,
            DeliveryAddress Destination, string destinationCountry, decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, Destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }
        #endregion
        // ==========================================
        // Methods
        // ==========================================

        #region Methods
        override public void PrintShipment()
        {
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight} Kg");
            Console.WriteLine($"Delivery Fee: {DeliveryFee} EGP");
            Console.WriteLine($"Destination Country : {DestinationCountry}");
            Console.WriteLine($"Customs Fee: {CustomsFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");

        }

        public string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} has been Delivered.";

        }
        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.12m; // 12% of the estimated cost
        }
        #endregion
    }
}
