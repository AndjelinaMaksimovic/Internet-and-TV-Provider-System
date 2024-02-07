using System;
using System.Data;
using System.Data.SQLite;
using library.Other;

namespace library.Database {

    public sealed class Database {

        private static Database Instance = null;
        private IDbConnection connection = null;
        private static readonly object _lock = new object(); // lock object that will be used to synchronize threads
        private string configFilepath = "C:\\Users\\radov\\Desktop\\Dizajniranje_softvera\\Projekat\\ClonedProject\\src\\config.txt";

        /* *********************************************************************************************************
         * Private Constructor
         * -------------------
         * Private constructor to prevent other objects from using the new() operator
         * ********************************************************************************************************* */
        private Database() {
            if(connection != null && connection.State == ConnectionState.Open) {
                connection.Close();
            }
            
            try {
                string connectionString = TextParser.Parse(configFilepath)["CONNSTRING"];
                connection = DatabaseConnectionFactory.CreateDatabaseConnection(connectionString);
                connection.Open();
            }
            catch(Exception ex) {
                Console.Write(ex.Message);
            }
            
        }

        /* *********************************************************************************************************
         * Get instance method
         * -------------------
         * ********************************************************************************************************* */
        public static Database GetInstance() {
            if (Instance == null) {
                lock (_lock) {
                    if (Instance == null) {
                        Instance = new Database();
                    }
                }
            }
            return Instance;
        }

        public DataTable Query(string sql) {
            DataTable dt = new DataTable();
            IDbCommand command = connection.CreateCommand();
            command.CommandText = sql;

            // Execute the SQL query and fill the DataTable with the results
            using (IDataReader reader = command.ExecuteReader()) {
                dt.Load(reader);
            }

            return dt;
        }

    }
}
