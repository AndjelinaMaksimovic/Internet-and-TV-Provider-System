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
using library.AppLogic.Packets;

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
            fill_internet_packets_panel();
            fill_tv_packets_panel();
            fill_comb_packets_panel();
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
        private void fill_internet_packets_panel() {

            FlowLayoutPanel panel = this.panelInternetPackets;
            panel.Controls.Clear();

            var x = appLogic.getPacketsByType(library.AppLogic.Packets.Packet.PacketType.INTERNET);

            foreach (var packet in x) {
                Label lb = new Label();
                lb.Text = packet.Name.ToString() + " | " + packet.Price.ToString() + " | " + packet.Data["downloadSpeed"].ToString() + "/" + packet.Data["uploadSpeed"].ToString();
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.BorderStyle = BorderStyle.FixedSingle;
                lb.AutoSize = false;
                lb.Width = 160;
                lb.Height = 30;
                lb.Tag = packet.PacketID;

                panel.Controls.Add(lb);
            }

        }

        /* ********************************************************************
         * Popunjava panel odvojen za tv pakete
         * ******************************************************************** */
        private void fill_tv_packets_panel() {

            FlowLayoutPanel panel = this.panelTVPackets;
            panel.Controls.Clear();

            var x = appLogic.getPacketsByType(library.AppLogic.Packets.Packet.PacketType.TV);

            foreach (var packet in x) {
                Label lb = new Label();
                lb.Text = packet.Name.ToString() + " | " + packet.Price.ToString() + " | " + packet.Data["numberOfChannels"].ToString();
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.BorderStyle = BorderStyle.FixedSingle;
                lb.AutoSize = false;
                lb.Width = 160;
                lb.Height = 30;
                lb.Tag = packet.PacketID;

                panel.Controls.Add(lb);
            }
        }

        /* ********************************************************************
         * Popunjava panel odvojen za kombinovane pakete
         * ******************************************************************** */
        private void fill_comb_packets_panel() {

            FlowLayoutPanel panel = this.panelCombinedPackets;
            panel.Controls.Clear();

            var x = appLogic.getPacketsByType(library.AppLogic.Packets.Packet.PacketType.COMBINED);
            
            foreach (var packet in x) {
                Label lb = new Label();
                lb.Text = packet.Name.ToString() + " | " + packet.Price.ToString() + " | " + packet.Data["numberOfChannels"].ToString() + " | " + packet.Data["downloadSpeed"].ToString() + "/" + packet.Data["uploadSpeed"].ToString();
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.BorderStyle = BorderStyle.FixedSingle;
                lb.AutoSize = false;
                lb.Width = 160;
                lb.Height = 30;
                lb.Tag = packet.PacketID;

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
        private void parse_create_packet_form_closed(object sender, FormClosedEventArgs e) {
            fill_internet_packets_panel();
            fill_tv_packets_panel();
            fill_comb_packets_panel();
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
            newForm.FormClosed += parse_create_packet_form_closed;
            newForm.ShowDialog();
        }

        private void button_activate_deactivate_packets_Click(object sender, EventArgs e) {
            var newForm = new ActivateDeactivatePackets();
            newForm.ShowDialog();
        }
    }
}
