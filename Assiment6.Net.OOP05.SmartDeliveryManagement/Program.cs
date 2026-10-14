
using System.Threading.Channels;

namespace Assiment6.Net.OOP05.SmartDeliveryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Part 01 - Theoretical Questions

            #region Q1 - Object Copying

            // Q1-A - What happens when you assign one object variable to another?
            //Answer:Both variables refer to the same object in memory because the reference is copied, not the object .itself

            // Q1-B - Does assigning one object to another create a new object? Explain.
            //Answer:No, it does not create a new object. It only copies the reference, so both variables point to the same object in .memory

            // Q1-C - Difference between copying an object and copying its reference.
            //Answer:Object Copying: Creates a new object in memory. Changes to the copied object's own fields do not affect the original .object
            //Reference Copying: Does not create a new object.Both variables refer to the same object, so changes made through one variable are visible through the.other

            #endregion

            #region Q2 - Shallow Copy vs Deep Copy

            // Q2-A - What is a Shallow Copy?
            //Answer: A shallow copy creates a new object, but it copies the references of the reference-type members instead of creating new instances. As a result, both the original and the copied object share the same reference-type members.

            // Q2-B - What is a Deep Copy?
            //Answer: A deep copy creates a new object and also creates new instances of all reference-type members. This means that the original and the copied object do not share any reference-type members, and changes made to one object do not affect the other.

            // Q2-C - What happens to reference-type members in Shallow Copy?
            //Answer: In a shallow copy, reference-type members share the same referenced objects. Therefore, modifying a shared object through the copy also affects the .original

            // Q2-D - What happens to reference-type members in Deep Copy?
            //Answer: In a deep copy, reference-type members are also duplicated, creating new instances for the copied object. This means that changes made to reference-type members in one object do not affect the other object.

            // Q2-E - Give one situation where Deep Copy is safer.
            //Answer: Deep Copy is safer in situations where you want to ensure that changes made to the copied object do not affect the original object, especially when dealing with mutable reference-type members. For example, when working with complex data structures like trees or graphs, a deep copy ensures that modifications to the copied structure do not inadvertently alter the original structure.

            #endregion

            #region Q3 - Static Members

            // Q3-A - Static Field vs Instance Field.

            // Q3-B - Static Method and accessing instance members.

            // Q3-C - Static Constructor and when it executes.

            // Q3-D - Static Class and object creation.

            #endregion

            #region Q4 - Extension Methods

            // Q4-A - What is an Extension Method?

            // Q4-B - Keyword used in the first parameter.

            // Q4-C - Where must an Extension Method be declared?

            // Q4-D - Can Extension Methods access private members?

            #endregion

            #region Q5 - Partial Classes and Partial Methods

            // Q5-A - What is a Partial Class?

            // Q5-B - Why split one class into multiple files?

            // Q5-C - What is a Partial Method?

            // Q5-D - What happens if a partial method has no implementation?

            #endregion

            #endregion

            #region Part 02 - Practical
            DeliveryUtilities.PrintSystemTitle("Smart Delivery Management System", '=');
            #region 1 - Create Shipments
            // Create StandardShipment
            // Create ExpressShipment
            // Create InternationalShipment
            Shipment.GetTotalShipmentsCreated();
            DeliveryUtilities.PrintSystemTitle("Creating Shipments...", '=');
            Console.WriteLine();
            Shipment standardShipment = new StandardShipment("SH001", "Labtop",3, 50, new DeliveryAddress(15, "Main Street", "Cairo"), "In Transit");
            Shipment expressShipment = new ExpressShipment("SH002", "Mobile",2, 50, new DeliveryAddress(20, "Second Street", "Cairo"), "Out for Delivery.", 100);
            Shipment internationalShipment = new InternationalShipment("SH003", "Tv", 8, 50, new DeliveryAddress(25, "Third Street", "Cairo"), "Delivered", "Egypt", 500);

            #endregion
            // Demonstrate static constructor
            // GetTotalShipmentsCreated()
            Console.WriteLine();
            Console.WriteLine($"Total Shipments Created: {Shipment.GetTotalShipmentsCreated()}");
            Console.WriteLine();
            #region 2 - Object Reference Assignment
            Console.WriteLine();
            DeliveryUtilities.PrintSystemTitle("Object Copying",'=');
            Console.WriteLine();
            // Assign shipment1 to shipment2
            // Demonstrate same object reference
            Shipment temp = standardShipment.CopyShipment();
            Console.WriteLine($"Original Shipment  : {standardShipment.TrackingCode}");
            Console.WriteLine($"Copied Shipment  : {temp.TrackingCode}");
            Console.WriteLine();
            Console.WriteLine($"Same Object :{Shipment.ReferenceEquals(standardShipment, temp)}");
            Console.WriteLine();
            Shipment cloneShipment = standardShipment;
            Console.WriteLine($"Original Shipment  : {standardShipment.TrackingCode}");
            Console.WriteLine($"Assigned Shipment  : {cloneShipment.TrackingCode}");
            Console.WriteLine();
            Console.WriteLine($"Same Object :{Shipment.ReferenceEquals(standardShipment, cloneShipment)}");
            Console.WriteLine();

            #endregion

            #region 3 - Shallow Copy Demonstration
            // Create Shallow Copy
            // Print original and copied address
            // Change copied address
            // Print both addresses again
            // Compare DeliveryAddress references
            DeliveryUtilities.PrintSystemTitle("Shallow Copy", '-');
            Shipment shallowCopyShipment = standardShipment.ShallowCopy();
            Console.WriteLine($"Original Address: {standardShipment.Destination.city}");
            Console.WriteLine($"copied  Address: {shallowCopyShipment.Destination.city}");
            Console.WriteLine("Changing copied shipment address...");
            shallowCopyShipment.Destination.SetCity("Giza");
            Console.WriteLine($"Original Address after change: {standardShipment.Destination.city}");
            Console.WriteLine($"copied  Address after change: {shallowCopyShipment.Destination.city}");
            Console.WriteLine($"Same DeliveryAddress Object :  {ReferenceEquals(standardShipment.Destination, shallowCopyShipment.Destination)}");
            #endregion

            #region 4 - Deep Copy Demonstration
            // Create Deep Copy
            // Print original and copied address
            // Change copied address
            // Print both addresses again
            // Compare DeliveryAddress references
            DeliveryUtilities.PrintSystemTitle("Deep Copy", '-');
            Shipment deepCopyShipment = expressShipment.DeepCopy();
            Console.WriteLine($"Original Address: {expressShipment.Destination.city}");
            Console.WriteLine($"Deep Copy Address: {deepCopyShipment.Destination.city}");
            Console.WriteLine("Changing copied shipment address...");
            deepCopyShipment.Destination.SetCity("Giza");
            Console.WriteLine($"Original Address after change: {expressShipment.Destination.city}");
            Console.WriteLine($"Deep Copy Address after change: {deepCopyShipment.Destination.city}");
            Console.WriteLine($"Same Shipment object: {ReferenceEquals(expressShipment, deepCopyShipment)}");
            Console.WriteLine($"Same DeliveryAddress object: {ReferenceEquals(expressShipment.Destination, deepCopyShipment.Destination)}");
            #endregion


            #region Extension Methods Demonstration
            // GetSummary()
            DeliveryUtilities.PrintSystemTitle("Extension Methods", '=');
            Console.WriteLine($"{ standardShipment.GetSummary()}");
            Console.WriteLine($"{expressShipment.GetSummary()}");
            Console.WriteLine($"{internationalShipment.GetSummary()}");
            // IsDelivered()
            Console.WriteLine($"{standardShipment.TrackingCode} Is Delivered: {standardShipment.IsDelivered()}");
            Console.WriteLine($"{expressShipment.TrackingCode} Is Delivered: {expressShipment.IsDelivered()}");
            Console.WriteLine($"{internationalShipment.TrackingCode} Is Delivered: {internationalShipment.IsDelivered()}");
            #endregion

            #region Tracking Status Demonstration

            // UpdateTrackingStatus()
            // Display tracking status


            #endregion

            #region Partial Class and Partial Method

            // Demonstrate tracking functionality
            // Demonstrate OnTrackingStatusChanged()

            #endregion

            #region Assignment 04 Functionality


            #endregion

            #region Assignment Completed


            #endregion

            #endregion

        }
    }
}