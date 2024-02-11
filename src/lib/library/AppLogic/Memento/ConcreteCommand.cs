using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic.Memento {
    internal class ConcreteCommand : ICommandMemento {

        private Dictionary<string, object> parameters;  // type: INSERT | table: ClientPacket | clientID: 1 | packetID: 1
        private Database.Database instance;

        public ConcreteCommand(Dictionary<string, object> parameters, Database.Database instance) {
            this.parameters = parameters;
            this.instance = instance;
        }

        public void undo() {
            string type = parameters["type"].ToString().ToLower();
            string table = parameters["table"].ToString().ToLower();  // client, packet, clientPacket
            string sql;
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

            //Console.WriteLine(type + " " + table);

            switch(type) {
                case "insert":  // insert moze biti nad tabelom Client, Packet, ClientPacket
                    //Console.WriteLine("INSERT");
                    if (table == "client") {
                        //Console.WriteLine(" INTO CLIENT");
                        sql = "DELETE FROM Client WHERE username = @param1";
                        keyValuePairs.Add("@param1", parameters["username"].ToString());
                        executeSQL(sql, keyValuePairs);
                    }
                    else if(table == "packet") {
                        sql = "DELETE FROM Packet WHERE PacketID = @param1";
                        keyValuePairs.Add("@param1", parameters["packetID"].ToString());
                        executeSQL(sql, keyValuePairs);
                    }
                    else if(table == "clientpacket") {
                        sql = "DELETE FROM ClientPacket WHERE ClientID = @param1 AND PacketID = @param2";
                        keyValuePairs.Add("@param1", parameters["clientID"].ToString());
                        keyValuePairs.Add("@param2", parameters["packetID"].ToString());
                        executeSQL(sql, keyValuePairs);
                    }
                    else {
                        // ...
                    }
                    break;

                case "delete":  // delete moze biti samo nad tabelom ClientPacket
                    if(table == "clientpacket") {
                        sql = "INSERT INTO ClientPacket (ClientID, PacketID) VALUES (@param1, @param2)";
                        keyValuePairs.Add("@param1", parameters["clientID"].ToString());
                        keyValuePairs.Add("@param2", parameters["packetID"].ToString());
                        executeSQL(sql, keyValuePairs);
                    }
                    else {
                        // ...
                    }
                    break;

                default:
                    break;
            }
        }

        private void executeSQL(string sql, Dictionary<string, object> parameters) {
            instance.Query(sql, parameters);
        }

    }
}
