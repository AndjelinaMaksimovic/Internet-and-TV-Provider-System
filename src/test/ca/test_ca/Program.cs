using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library.Other;

namespace test_ca {
    internal class Program {
        static void Main(string[] args) {
            var pairs = TextParser.Parse("C:\\Users\\radov\\Desktop\\Dizajniranje_softvera\\Projekat\\ClonedProject\\src\\config.txt");
            Console.WriteLine(pairs["PROVIDER"]);
            Console.WriteLine(pairs["CONNSTRING"]);

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
