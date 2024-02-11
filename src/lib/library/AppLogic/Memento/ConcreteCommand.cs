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

            switch(type) {
                case "insert":  // insert moze biti nad tabelom Client, Packet, ClientPacket
                    
                    if (table == "client") {
                        sql = "DELETE FROM Client WHERE username = @param1";
                        keyValuePairs.Add("@param1", parameters["username"].ToString());
                        executeSQL(sql, keyValuePairs);
                    }
                    else if(table == "packet") {
                        sql = "DELETE FROM Packet WHERE PacketID = @param1";
                        keyValuePairs.Add("@param1", parameters["packetID"].ToString());
                        executeSQL(sql, keyValuePairs);

                        string packetType = parameters["packetType"].ToString().ToLower();
                        string sql1;
                        string tabela;

                        if(packetType == "internet") { tabela = "internetpacket"; }
                        else if(packetType == "tv") { tabela = "tvpacket"; }
                        else if(packetType == "combined") { tabela = "combpacket"; }
                        else { tabela = "NO_TABLE"; }

                        sql1 = "DELETE FROM " + tabela + " WHERE packetid = @param1";
                        executeSQL(sql1, keyValuePairs);
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

        public void redo() {
            undo();
        }

        private void executeSQL(string sql, Dictionary<string, object> parameters) {
            instance.Query(sql, parameters);
        }

    }
}
