using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_solution;
using System.Data;

namespace lib_solution {
    internal class Program {
        static void Main(string[] args) {

            var x = TXTParser.Parse("C:\\Users\\radov\\Desktop\\Dizajniranje_softvera\\Projekat\\ClonedProject\\src\\config.txt");

            Console.WriteLine(x["CONNSTRING"]);
            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

/*
  // citanje iz baze proba
    DataTable dt = db.ExecuteQuery("SELECT * FROM Client");
    foreach(DataRow dr in dt.Rows) {
        foreach (var item in dr.ItemArray) {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
*/

