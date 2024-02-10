using library.AppLogic;
using library.AppLogic.Clients;
using library.AppLogic.Interfaces;
using library.AppLogic.Packets;
using library.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form_app {
    public partial class ActivateDeactivatePackets : Form {

        private Database instance = null;
        private IAppLogicFacade appLogic = null;
        private string selectedClientID = null;
        private Color selectColor = Color.Bisque;
        public ActivateDeactivatePackets(IAppLogicFacade appLogic) {
            InitializeComponent();

            this.appLogic = appLogic;
            instance = Database.GetInstance();
            fill_clients_list();
        }

        private void fill_clients_list() {
            List<string> clientNames = new List<string>();

            var clients = appLogic.getAllClients("");

            foreach (var client in clients) {
                clientNames.Add(client.Username.ToString());
            }

            clients_list.DataSource = clientNames;
           

            if (clients_list.Items.Count > 0) {
                clients_list.SelectedIndex = 0;

                string selectedClientName = clients_list.SelectedItem.ToString();
                var selectedClient = clients.FirstOrDefault(c => c.Username.ToString() == selectedClientName);
                selectedClientID = selectedClient?.ClientID.ToString();
                FillPacketCheckboxes(selectedClientID);
            }

            clients_list.SelectedIndexChanged += clients_list_SelectedIndexChanged;
        }

        private void clients_list_SelectedIndexChanged(object sender, EventArgs e) {

            string selectedClientName = clients_list.SelectedItem.ToString();
            var clients = appLogic.getAllClients(selectedClientName);
            selectedClientID = clients.FirstOrDefault()?.ClientID.ToString();

            FillPacketCheckboxes(selectedClientID);
        }
        private void FillPacketCheckboxes(string clientID) {

            clients_packets_list.Items.Clear();

            if (clientID == null)
                return;

            string sql = "SELECT * FROM ClientPacket cp JOIN Packet p ON p.packetid = cp.packetid WHERE cp.clientid = @id";
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("@id", clientID);

            DataTable dt = instance.Query(sql, keyValuePairs);
            foreach (DataRow dr in dt.Rows) {
                clients_packets_list.Items.Add(dr["name"], false);
            }

        }
        private void label1_Click(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }
    }
}
