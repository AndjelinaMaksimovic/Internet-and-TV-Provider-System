using System;
using System.Data;
using library.Database;

namespace test_ca {
    internal class Program {
        static void Main(string[] args) {
            
            Database db = Database.GetInstance();
            var x = db.Query("SELECT * FROM Client");

            foreach (DataRow row in x.Rows) {
                foreach(var e in row.ItemArray) {
                    Console.Write(e + " ");
                }
                Console.WriteLine();
            }

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
