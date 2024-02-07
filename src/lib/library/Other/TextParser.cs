using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Other {
    public sealed class TextParser {

        /* *********************************************************************************************************
         * Parse
         * Parse text from given input file
         * Separates PROVIDER and CONNSTRING from config file
         * ********************************************************************************************************* */
        public static Dictionary<string, string> Parse(string input) {

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            int lineCount = 0;
            foreach (var line in File.ReadAllLines(input)) {
                string[] splits = line.Split('#');
                keyValuePairs.Add(splits[0].Trim(), splits[1].Trim());
                lineCount++;
            }

            if (lineCount != 2) {
                throw new Exception("Config file not valid!");
            }

            if (!keyValuePairs.ContainsKey("PROVIDER")) {
                throw new Exception("Provider not mentioned!");
            }

            if (!keyValuePairs.ContainsKey("CONNSTRING")) {
                throw new Exception("Connstring not mentioned!");
            }

            if (!File.Exists(keyValuePairs["CONNSTRING"].Replace("Data Source=", "").Replace(";", ""))) {
                throw new Exception("Given path does not exist!");
            }

            return keyValuePairs;
        }
    }
}
