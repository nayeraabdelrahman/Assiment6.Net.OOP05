using System;
using System.Collections.Generic;
using System.Text;

namespace Assiment6.Net.OOP05.SmartDeliveryManagement
{
        abstract class Shipment
        {
            string trackingCode;
            string description;
            decimal weight;
            decimal deliveryFee;
            // Destination Property-Type: DeliveryAddress
            // Public get and set.
            public DeliveryAddress Destination { get; set; }

            // ==========================================
            // PROPERTIES
            // ==========================================

            #region Properties
            public string TrackingCode
            {
                private set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        trackingCode = value;
                    }
                }
                get { return trackingCode; }
            }

            // Description Property Public get and set.
            // Description cannot be: null-empty-whitespace
            //If invalid: Keep the previous valid value.
            public string Description
            {
                set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        description = value;
                    }
                }
                get { return description; }
            }

            // Weight Property:Public get and set.
            // Weight must be greater than 0.
            // If invalid: Keep the previous valid value.
            public decimal Weight
            {
                set
                {
                    if (value > 0)
                    {
                        weight = value;
                    }
                }
                get { return weight; }
            }

            // DeliveryFee PropertyPublic getter-Private setter.
            // DeliveryFee must be greater than 0.
            public decimal DeliveryFee
            {
                private set
                {
                    if (value > 0)
                    {
                        deliveryFee = value;
                    }
                }
                get { return deliveryFee; }
            }


            // EstimatedCost: Convert to abstract property. Every child class will implement it.
            abstract public decimal EstimatedCost { get; }
            #endregion
            // ==========================================
            // CONSTRUCTORS
            // ==========================================

            #region Constructors

            // Constructor 1 -Receives:trackingCode
            // Default values:Description = "Unknown"-Weight = 1-DeliveryFee = 50-Destination = default
            public Shipment() : this("Unknown", "Unknown", 1, 50.0m, default)
            {

            }
            public Shipment(string trackingCode) : this(trackingCode, "Unknown", 1, 50.0m, default)
            {

            }

            // Constructor 2-
            // Receives: trackingCode-description-weight-deliveryFee-destination
            public Shipment(string trackingCode, string description,
            decimal weight, decimal deliveryFee, DeliveryAddress Destination)
            {
                TrackingCode = trackingCode;
                Description = description;
                Weight = weight;
                DeliveryFee = deliveryFee;
                this.Destination = Destination;
            }

            #endregion

            // ==========================================
            // METHODS
            // ==========================================
            #region Methods

            // UpdateDeliveryFee(decimal newFee)
            // Update DeliveryFee only if
            // newFee > 0.
            public void UpdateDeliveryFee(decimal newFee)
            {
                if (newFee > 0)
                {
                    this.deliveryFee = newFee;
                }
            }
            //Updates the shipment weight.
            public void UpdateWeight(decimal newWeight)
            {
                if (newWeight > 0)
                {
                    Weight = newWeight;
                }
            }
            //Updates the shipment weight after adding the extra packing weight.
            public void UpdateWeight(decimal newWeight, decimal extrapackingWeight)
            {
                if (extrapackingWeight > 0 && newWeight > 0)
                    Weight = newWeight + extrapackingWeight;
                else if (newWeight > 0)
                    Weight = newWeight;
            }

        //PrintShipment() :Each shipment type prints its own information.
        public abstract void PrintShipment();
       
        // ==========================================
        //Object Copying
        // ==========================================
        #region 1 - Object Copying
        public Shipment CopyShipment()
        {
 
            return (Shipment)this.MemberwiseClone();
        }
       

        #endregion


        #endregion
    }
}
