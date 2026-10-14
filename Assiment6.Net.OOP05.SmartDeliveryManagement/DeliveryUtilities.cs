using System;
using System.Collections.Generic;
using System.Text;

namespace Assiment6.Net.OOP05.SmartDeliveryManagement
{
    internal static class DeliveryUtilities
    {
       public static void PrintSeparator(char separator)
        {
            Console.WriteLine(new string(separator, 42));
        }
        public static void PrintSystemTitle(string message,char separator)
        {
            PrintSeparator(separator);
            Console.WriteLine(message);
            PrintSeparator(separator);
        }
    }
}
