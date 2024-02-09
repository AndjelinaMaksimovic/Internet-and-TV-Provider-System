using library.AppLogic.Interfaces;
using library.AppLogic.Clients;
using library.AppLogic.Packets;
using library.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic {
    public class AppLogic : IAppLogicFacade {

        private string _configFilepath = "../../../../../config.txt";
        private ClientLogic _clientLogic;
        private PacketLogic _packetLogic;

        public AppLogic() {
            _clientLogic = new ClientLogic();
            _packetLogic = new PacketLogic();
        }

        public string getProviderName() {
            return TextParser.Parse(_configFilepath)["PROVIDER"];
        }

        public IEnumerable<Client> getAllClients(string like) {

            IEnumerable<Client> returnValue = null;

            try {
                string sql = "SELECT * FROM Client";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                
                if (like != "") {
                    sql += " WHERE username LIKE @param1";
                    parameters.Add("@param1", "%" + like + "%");
                }
                returnValue = _clientLogic.getAllClients(sql, parameters);
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return returnValue;
        }

        public void registerClient(string username, string firstName, string lastName) {
            string sql = "INSERT INTO Client (username, firstname, lastname) VALUES (@param1, @param2, @param3)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@param1", username);
            parameters.Add("@param2", firstName);
            parameters.Add("@param3", lastName);

            _clientLogic.addNewClient(sql, parameters); // u slucaju da dodje do izuzetka delegira se do prozora forme
        }

        IEnumerable<Packet> IAppLogicFacade.getPacketsByType(Packet.PacketType type) {

            IEnumerable<Packet> returnValue = null;
            string sql = "";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            switch(type) {
                case Packet.PacketType.INTERNET:
                    sql = "SELECT * FROM Packet p JOIN InternetPacket i ON p.PacketID = i.PacketID";
                    returnValue = _packetLogic.getInternetPackets(sql, parameters);
                    break;

                case Packet.PacketType.TV:
                    sql = "SELECT * FROM Packet p JOIN TVPacket t ON p.PacketID = t.PacketID";
                    returnValue = _packetLogic.getTVPackets(sql, parameters);
                    break;

                case Packet.PacketType.COMBINED:
                    break;

                default:
                    break;
            }

            return returnValue;
        }
    }
}
