using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic.Packets {
    public class PacketLogic {

        private Database.Database instance = null;

        public PacketLogic() {
        
            instance = Database.Database.GetInstance();

        }

        public IEnumerable<Packet> getInternetPackets(string sql, Dictionary<string, object> parameters) {

            DataTable dt = instance.Query(sql, parameters);
            List<Packet> packets = new List<Packet>();

            foreach (DataRow dr in dt.Rows) {
                int id = Convert.ToInt32(dr["packetid"]);
                string name = Convert.ToString(dr["name"]);
                double price = Convert.ToDouble(dr["price"]);
                int downSpeed = Convert.ToInt32(dr["downloadspeed"]);
                int upSpeed = Convert.ToInt32(dr["uploadspeed"]);

                Dictionary<string, int> data = new Dictionary<string, int>();
                data.Add("downloadSpeed", downSpeed);
                data.Add("uploadSpeed", upSpeed);

                packets.Add(new Packet(id, name, price, data));
            }

            return packets;

        }

        public IEnumerable<Packet> getTVPackets(string sql, Dictionary<string, object> parameters) {

            DataTable dt = instance.Query(sql, parameters);
            List<Packet> packets = new List<Packet>();

            foreach (DataRow dr in dt.Rows) {
                int id = Convert.ToInt32(dr["packetid"]);
                string name = Convert.ToString(dr["name"]);
                double price = Convert.ToDouble(dr["price"]);
                int channels = Convert.ToInt32(dr["numberofchannels"]);

                Dictionary<string, int> data = new Dictionary<string, int>();
                data.Add("numberOfChannels", channels);

                packets.Add(new Packet(id, name, price, data));
            }

            return packets;

        }

        public IEnumerable<Packet> getCombinedPackets(string sql, Dictionary<string, object> parameters) {
            return null; // TO DO
        }

    }
}
