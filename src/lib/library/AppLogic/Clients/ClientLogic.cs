﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library.Database;
using library.AppLogic.Packets;

namespace library.AppLogic.Clients {
    public class ClientLogic {

        private Database.Database instance = null;

        public ClientLogic() { 
            instance = Database.Database.GetInstance();
        }

        public IEnumerable<Client> getAllClients(string sql, Dictionary<string, object> parameters) {
            List<Client> clients = new List<Client>();

            DataTable dt = instance.Query(sql, parameters);
            foreach (DataRow dr in dt.Rows) {
                int id = Convert.ToInt32(dr["clientid"]);
                string username = Convert.ToString(dr["username"]);
                string firstName = Convert.ToString(dr["firstname"]);
                string lastName = Convert.ToString(dr["lastname"]);
                clients.Add(new Client(id, username, firstName, lastName));
            }

            return clients;
        }
        
        public IEnumerable<Tuple<int, int>> getPacketsForClient(string sql, Dictionary<string, object> parameters) {
            
            List<Tuple<int, int>> pairs = new List<Tuple<int, int>>();

            DataTable dt = instance.Query(sql, parameters);
            foreach (DataRow dr in dt.Rows) {
                int clientId = Convert.ToInt32(dr["clientid"]);
                int packetId = Convert.ToInt32(dr["packetid"]);
     
                pairs.Add(new Tuple<int, int>(clientId, packetId));
            }

            return pairs;
        }
        
        public void addNewClient(string sql, Dictionary<string , object> parameters) {
            instance.Query(sql, parameters);    // u slucaju da dodje do izuzetka delegira se do prozora forme
        }

    }
}
