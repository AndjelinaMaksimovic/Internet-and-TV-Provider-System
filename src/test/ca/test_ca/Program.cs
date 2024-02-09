using System;
using System.Collections.Generic;
using System.Data;
using library.AppLogic;

namespace test_ca {
    internal class Program {
        static void Main(string[] args) {

            AppLogic l = new AppLogic();

            var x = l.getAllClients("");

            foreach (var client in x) {
                Console.WriteLine(client.ClientID + " " + client.Username + " " + client.FirstName + " " + client.LastName);
            }

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
