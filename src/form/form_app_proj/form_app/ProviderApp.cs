using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using library.Other;
using library.Database;
using library.AppLogic.Interfaces;

namespace form_app {
    public partial class ProviderApp : Form {

        private Database instance = null;
        private string selectedClientID = null;                 // decide which user is currently selected
        private Color selectColor = Color.LightGreen;           // color used to display selected users and their packets
        private IAppLogicFacade appLogic = null;

        public ProviderApp(IAppLogicFacade appLogicFacade) {
            InitializeComponent();

            appLogic = appLogicFacade;
            instance = Database.GetInstance();
            fill_components();
            this.filter_clients_tb.KeyUp += parse_keyup_filter_clients;
        }

        /* ********************************************************************
         * Popunjava sve komponente na strani
         * ******************************************************************** */
        private void fill_components() {
            fill_provider_name_label();
            fill_clients_panel();
            fill_internet_packets_panel(this.panelInternetPackets);
            fill_tv_packets_panel(this.panelTVPackets);
            fill_comb_packets_panel(this.panelCombinedPackets);
        }

        /* ********************************************************************
         * Popunjava panel za klijente
         * ******************************************************************** */
        private void fill_clients_panel() {
            FlowLayoutPanel panel = this.panelClients;
            string like = this.filter_clients_tb.Text;

            panel.Controls.Clear();

            var x = appLogic.getAllClients(like);

            foreach (var client in x) {
                Label lb = new Label(); // Create label for client name
                lb.Text = client.Username.ToString();
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.AutoSize = false;
                lb.Width = 120; // Adjust width as needed
                lb.Height = 26;
                lb.Tag = client.ClientID;
                
                if (selectedClientID != null && lb.Tag.ToString() == selectedClientID) {
                    lb.BackColor = selectColor;
                }
                lb.Click += ClientLabel_Click;
                lb.BorderStyle = BorderStyle.FixedSingle;
                
                panel.Controls.Add(lb);
            }
        }
        /* ********************************************************************
         * Promena boje selektovanih paketa i korisnika
         * ******************************************************************** */
        private void clearAllSelections() {
            foreach (Label control in panelClients.Controls) {
                control.BackColor = SystemColors.Control;
            }

            foreach (Label lb in panelTVPackets.Controls) {
                lb.BackColor = SystemColors.Control;
            }

            foreach (Label lb in panelInternetPackets.Controls) {
                lb.BackColor = SystemColors.Control;
            }

            foreach (Label lb in panelCombinedPackets.Controls) {
                lb.BackColor = SystemColors.Control;
            }
        }
        /* ********************************************************************
         * Event selekcije korisnika
         * ******************************************************************** */
        private void ClientLabel_Click(object sender, EventArgs e) {

            clearAllSelections();

            Label clickedLabel = (Label)sender;

            if (clickedLabel.Tag.ToString() == selectedClientID) {
                selectedClientID = null;
                return; // deselect
            }

            clickedLabel.BackColor = selectColor;
            this.selectedClientID = clickedLabel.Tag.ToString();

            string sql = "SELECT * FROM ClientPacket WHERE clientid = @id";
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("@id", clickedLabel.Tag.ToString());

            DataTable dt = instance.Query(sql, keyValuePairs);
            foreach(DataRow dr in dt.Rows) {
                var packetid = dr["packetid"].ToString();

                foreach(Label lb in panelTVPackets.Controls) {
                    if(lb.Tag.ToString() == packetid) lb.BackColor = selectColor;
                }

                foreach (Label lb in panelInternetPackets.Controls) {
                    if (lb.Tag.ToString() == packetid) lb.BackColor = selectColor;
                }

                foreach (Label lb in panelCombinedPackets.Controls) {
                    if (lb.Tag.ToString() == packetid) lb.BackColor = selectColor;
                }
            }
        }

        /* ********************************************************************
         * Popunjava panel odvojen za internet pakete
         * ******************************************************************** */
        private void fill_internet_packets_panel(FlowLayoutPanel panel) {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            DataTable dt = instance.Query("SELECT * FROM packet p JOIN internetpacket i on p.packetid = i.packetid", keyValuePairs);

            foreach (DataRow dr in dt.Rows) {
                Label lb = new Label();
                lb.Text = dr["name"].ToString() + " | " + dr["price"] + " | " + dr["downloadspeed"] + "/" + dr["uploadspeed"];
                lb.TextAlign = ContentAlignment.MiddleLeft;
                lb.BorderStyle = BorderStyle.FixedSingle;
                lb.AutoSize = false;
                lb.Width = 160;
                lb.Height = 30;
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.Tag = dr["packetid"];
                panel.Controls.Add(lb);
            }
        }

        /* ********************************************************************
         * Popunjava panel odvojen za tv pakete
         * ******************************************************************** */
        private void fill_tv_packets_panel(FlowLayoutPanel panel) {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            DataTable dt = instance.Query("SELECT * FROM packet p JOIN tvpacket t on p.packetid = t.packetid", keyValuePairs);

            foreach (DataRow dr in dt.Rows) {
                Label lb = new Label();
                lb.Text = dr["name"].ToString() + " | " + dr["price"] + " | " + dr["numberofchannels"];
                lb.TextAlign = ContentAlignment.MiddleLeft;
                lb.BorderStyle = BorderStyle.FixedSingle;
                lb.AutoSize = false;
                lb.Width = 160;
                lb.Height = 30;
                lb.Tag = dr["packetid"];
                lb.TextAlign = ContentAlignment.MiddleCenter;
                panel.Controls.Add(lb);
            }
        }

        /* ********************************************************************
         * Popunjava panel odvojen za kombinovane pakete
         * ******************************************************************** */
        private void fill_comb_packets_panel(FlowLayoutPanel panel) {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            DataTable dt = instance.Query("SELECT * FROM packet p JOIN combpacket c JOIN internetpacket i JOIN tvpacket t on p.packetid = c.packetid AND c.InternetPacketID = i.packetid and c.TVPacketID = t.PacketID", keyValuePairs);

            foreach (DataRow dr in dt.Rows) {
                Label lb = new Label();
                lb.Text = dr["name"].ToString() + " | " + dr["price"] + " | " + dr["downloadspeed"] + "/" + dr["uploadspeed"] + " | " + dr["numberofchannels"];
                lb.TextAlign = ContentAlignment.MiddleLeft;
                lb.BorderStyle = BorderStyle.FixedSingle;
                lb.AutoSize = false;
                lb.Width = 160;
                lb.Height = 30;
                lb.Tag = dr["packetid"];
                lb.TextAlign = ContentAlignment.MiddleCenter;
                panel.Controls.Add(lb);
            }
        }

        /* ********************************************************************
         * Popunjava naziv provajdera
         * ******************************************************************** */
        private void fill_provider_name_label() {
            Label labelref = this.providerName;
            labelref.Text = "Provider: ";
            try { labelref.Text += appLogic.getProviderName(); }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                labelref.Text += "NOT RECOGNIZED";
            }
        }

        /* ********************************************************************
         * Event handler za pretrazivanje klijenata po korisnickom imenu
         * ******************************************************************** */
        private void parse_keyup_filter_clients(object sender, KeyEventArgs e) {
            fill_clients_panel();
        }
        /* ********************************************************************
         * Poziva se nakon sto se zatvori prozor za dodavanje novog klijenta
         * ******************************************************************** */
        private void parse_register_client_form_closed(object sender, FormClosedEventArgs e) {
            fill_clients_panel();
        }
        /* ********************************************************************
         * Event nakon klika dugmeta za dodavanje novog korisnika
         * ******************************************************************** */
        private void button_register_client_Click(object sender, EventArgs e) {
            var newForm = new AddUser();
            newForm.FormClosed += parse_register_client_form_closed;
            newForm.ShowDialog();
        }

        private void button_create_packet_Click(object sender, EventArgs e) {
            var newForm = new CreatePacket();
            newForm.ShowDialog();
        }
    }
}
