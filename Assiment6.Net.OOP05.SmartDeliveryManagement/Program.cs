
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

        }
    }
}