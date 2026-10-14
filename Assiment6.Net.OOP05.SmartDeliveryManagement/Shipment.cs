using System;
using System.Collections.Generic;
using System.Text;

namespace Assiment6.Net.OOP05.SmartDeliveryManagement
{
        abstract partial class Shipment
        {
            string trackingCode;
            string description;
            decimal weight;
            decimal deliveryFee;
            // Destination Property-Type: DeliveryAddress
            // Public get and set.
            public DeliveryAddress Destination { get; set; }

            //4 - Static Field
            public static int TotalShipmentsCreated;

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
            public Shipment() : this("Unknown", "Unknown", 1, 50.0m, default, "Unknown")
        {

        }
            public Shipment(string trackingCode) : this(trackingCode, "Unknown", 1, 50.0m, default, "Unknown")
        {

        }

            // Constructor 2-
            // Receives: trackingCode-description-weight-deliveryFee-destination
            public Shipment(string trackingCode, string description,
            decimal weight, decimal deliveryFee, DeliveryAddress Destination, string trackingStatus)
            {
                TrackingCode = trackingCode;
                Description = description;
                Weight = weight;
                DeliveryFee = deliveryFee;
                this.Destination = Destination;
            TrackingStatus = trackingStatus;
            TotalShipmentsCreated++;
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
        // Implement the partial method OnTrackingStatusChanged 
        public partial string OnTrackingStatusChanged(string newStatus)
        {
            TrackingStatus = newStatus;
            return TrackingStatus;
        }
        // ==========================================
        //Object Copying
        // ==========================================
        #region 1 - Object Copying
        public Shipment CopyShipment()
        {
            TotalShipmentsCreated++;
            return (Shipment)this.MemberwiseClone();
        }


        #endregion

        #region 2 - Shallow Copy

           public Shipment ShallowCopy()
            {
            TotalShipmentsCreated++;
            return (Shipment) this.MemberwiseClone();
            }


        #endregion

        #region 3 - Deep Copy

        // DeepCopy()
        // Independent DeliveryAddress
        public Shipment DeepCopy()
        {
            Shipment deepCopyShipment = (Shipment)this.MemberwiseClone();
           deepCopyShipment.TrackingCode = this.TrackingCode;
            deepCopyShipment.Description = this.Description;
            deepCopyShipment.Weight = this.Weight;
            deepCopyShipment.DeliveryFee = this.DeliveryFee;
           if(this.Destination != null)
            {
                deepCopyShipment.Destination = new DeliveryAddress(this.Destination.buildingNumber, this.Destination.street, this.Destination.city);
            }TotalShipmentsCreated++;
            return deepCopyShipment;
        }

        #endregion

        #region 5 - Static Constructor

        // Initialize shipment counter
        // Display initialization message
        static Shipment()
        {
            Console.WriteLine();
            Console.WriteLine("Shipment System Initialized");
            Console.WriteLine();
            TotalShipmentsCreated = 0;
        }
        #endregion

        #region 6 - Static Method

        // GetTotalShipmentsCreated()
        public static int GetTotalShipmentsCreated()
        {
            return TotalShipmentsCreated;
        }

        #endregion
        #endregion
    }
}
