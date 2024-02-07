using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;       // Potrebno instalirati: References -> Manage NuGet Packages -> Search: System.Data.SQLite
using System.Threading.Tasks;
using System.Collections.Generic;

namespace library.Database {

    public sealed class Database {

        private static Database Instance = null;
        private static readonly object _lock = new object(); // lock object that will be used to synchronize threads
        private static readonly string _config = "../../../../config.txt";
        private SQLiteConnection sqlite;

        /* *********************************************************************************************************
         * Private Constructor
         * -------------------
         * Private constructor to prevent other objects from using the new() operator
         * ********************************************************************************************************* */
        private Database() {
            sqlite = new SQLiteConnection("Data Source=C:\\Users\\radov\\Desktop\\Dizajniranje_softvera\\Projekat\\ClonedProject\\src\\db\\sbb_database.db");
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
    }
}
