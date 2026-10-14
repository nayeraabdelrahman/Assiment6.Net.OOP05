using System;
using System.Collections.Generic;
using System.Text;

namespace Assiment6.Net.OOP05.SmartDeliveryManagement
{
    internal class DeliveryCenter
    {
        // ==========================================
        // FIELDS
        // ==========================================

        #region Fields

        // Center Name
        // Private Shipment[] array.
        // Maximum size = 20.
        string centerName;
        string driver;
        Shipment[] shipments;


        #endregion
        // ==========================================
        // PROPERTIES
        // ==========================================
        #region Properties
        public string CenterName
        {
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    centerName = value;
                }
            }
            get { return centerName; }
        }
        public string Driver
        {
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    driver = value;
                }
            }
            get { return driver; }
        }
        #endregion
        // ==========================================
        // CONSTRUCTOR
        // ==========================================

        #region Constructor

        // Initialize the Shipment array
        // with a size of 20.
        public DeliveryCenter()
        {
            shipments = new Shipment[20];
        }

        #endregion

        // ==========================================
        // INTEGER INDEXER
        // ==========================================

        #region Integer Indexer

        public Shipment this[int index]
        {
            get
            {
                if (index >= 0 && index < shipments.Length)
                {
                    return shipments[index];
                }
                else
                {
                    return default;
                }
            }
            set
            {
                if (index >= 0 && index < shipments.Length)
                {
                    shipments[index] = value;
                }
            }
        }

        #endregion

        // ==========================================
        // STRING INDEXER
        // ==========================================

        #region String Indexer

        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i] != null)
                    {
                        if (shipments[i].TrackingCode == trackingCode)
                        {
                            return shipments[i];
                        }
                    }
                }

                return default;
            }
        }
        #endregion
        // ==========================================
        // METHODS
        // ==========================================

        #region Methods

        // AddShipment(Shipment shipment)
        // Add the shipment to the first available position.
        // Return true:if added successfully.Return false:if the DeliveryCenter is full.
        public bool AddShipment(Shipment shipment)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] == null)
                {
                    shipments[i] = shipment;
                    Console.WriteLine("Shipment Added Successfully");
                    return true;
                }
            }
            return false;
        }

        // ------------------------------------------
        // RemoveShipment
        // ------------------------------------------
        // Search using tracking code.
        // If found: Remove shipment - Return true.
        // If not found:Return false.
        public bool RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] != null && shipments[i].TrackingCode == trackingCode)
                {
                    shipments[i] = null;
                    Console.WriteLine("Shipment removed successfully");
                    return true;
                }
            }
            return false;
        }


        // ------------------------------------------
        // PrintAllShipments
        // ------------------------------------------

        // Print all stored shipments.
        public void PrintAllShipments()
        {
            foreach (var shipment in shipments)
            {
                if (shipment != null)
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine(shipment.GetType().Name + ":");
                    shipment.PrintShipment();

                }
            }
        }
        public void PrintTrackingStatuses()
        {
            foreach (var shipment in shipments)
            {
                if (shipment != null)
                {
                    ITrackable trackable = (ITrackable)shipment;
                    Console.WriteLine(trackable.GetTrackingStatus());


                }
            }

        }

        public void PrintInsuranceCosts(DeliveryReport report)
        {
            foreach (var shipment in shipments)
            {
                if (shipment != null)
                {
                    IInsurable insurable = (IInsurable)shipment;
                    report.PrintInsurance(insurable);
                }
            }
        }
        #endregion
    }
}
