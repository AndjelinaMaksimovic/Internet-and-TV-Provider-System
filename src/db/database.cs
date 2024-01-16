/*
 * The Singleton pattern solves two problems at the same time, violating the Single Responsibility Principle:
 *      1)  Ensure that a class has just a single instance
 *      2)  Provide a global access point to that instance
 */

using System;
using System.Data.SQLite;

namespace database {

    public class Database {

        private static Database _instance;                  // Field for storing the singleton instance of a class
        private static object lockObject = new object();    // Adding a lock object for thread safety
        private SQLiteConnection connection;

        private Database() {
            connection = new SQLiteConnection("Data Source=./databases/sbb_database.db");
            connection.Open();
        }
        
        public static Database GetInstance() {
            Console.WriteLine("Called");
            if (_instance == null)
                _instance = new Database();
            return _instance;
        }

        /*public void Query(string sql) {
            Console.WriteLine($"Executing query: {sql}");

            // Execute SQLite query
            using (var command = new SQLiteCommand(sql, connection)) {
                using (var reader = command.ExecuteReader()) {

                    for (int i = 0; i < reader.FieldCount; i++) {
                        Console.Write(reader.GetName(i) + "\t");
                    }
                    Console.WriteLine();

                    while (reader.Read()) {
                        for (int i = 0; i < reader.FieldCount; i++) {
                            Console.Write(reader[i] + "\t");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
        */
    }
}