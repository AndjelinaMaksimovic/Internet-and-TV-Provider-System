using System;
using System.Collections.Generic;
using System.Data;
using library.AppLogic;

namespace test_ca {
    internal class Program {
        static void Main(string[] args) {

            AppLogic l = new AppLogic();

            var x = l.getPacketByName("NET 100");

            if (x != null) {
                Console.WriteLine(x);
            }
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
