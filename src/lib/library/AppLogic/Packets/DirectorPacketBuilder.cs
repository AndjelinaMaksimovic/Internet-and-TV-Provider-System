using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic.Packets {
    internal class DirectorPacketBuilder {

        private PacketBuilder builder;

        public DirectorPacketBuilder(Packet.PacketType type) {
            
            switch(type) {
                case Packet.PacketType.INTERNET:
                    builder = new InternetPacketBuilder();
                    break;
                case Packet.PacketType.TV:
                    builder = new TVPacketBuilder();
                    break;
                case Packet.PacketType.COMBINED:
                    builder = new CombinedPacketBuilder();
                    break;
                default:
                    break;
            }
        }

        public Packet make(int id, string name, double price, int downloadSpeed, int uploadSpeed, int numberOfChannels) {
            builder.build(id, name, price, downloadSpeed, uploadSpeed, numberOfChannels);
            return builder.getProduct();
        }

        public void changeBuilder(Packet.PacketType type) {
            switch (type) {
                case Packet.PacketType.INTERNET:
                    builder = new InternetPacketBuilder();
                    break;
                case Packet.PacketType.TV:
                    builder = new TVPacketBuilder();
                    break;
                case Packet.PacketType.COMBINED:
                    builder = new CombinedPacketBuilder();
                    break;
                default:
                    break;
            }
        }

    }
}
