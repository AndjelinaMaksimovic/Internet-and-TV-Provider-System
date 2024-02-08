﻿using System;
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

namespace form_app {
    public partial class ProviderApp : Form {

        private readonly string configFilePath = "../../../../../config.txt";
        private Database instance = null;

        public ProviderApp() {
            InitializeComponent();

            instance = Database.GetInstance();
            fill_components();
            this.filter_clients_tb.KeyUp += parse_keyup_filter_clients;
        }

        /* ********************************************************************
         * Popunjava sve komponente na strani
         * ******************************************************************** */
        private void fill_components() {
            fill_provider_name_label(this.providerName);
            fill_clients_panel(this.panelClients, "SELECT * FROM Client", new Dictionary<string, object>());
            fill_internet_packets_panel(this.panelInternetPackets);
            fill_tv_packets_panel(this.panelTVPackets);
            fill_comb_packets_panel(this.panelCombinedPackets);
        }

        /* ********************************************************************
         * Popunjava panel za klijente
         * ******************************************************************** */
        private void fill_clients_panel(FlowLayoutPanel panel, string sql, Dictionary<string, object> keyValuePairs) {
            panel.Controls.Clear();
            DataTable dt = instance.Query(sql, keyValuePairs);
            
            foreach (DataRow dr in dt.Rows) {
                Label lb = new Label(); // Create label for client name
                lb.Text = dr["username"].ToString();
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.AutoSize = false;
                lb.Width = 120; // Adjust width as needed
                lb.Height = 26;

                // Add label and button to a panel
                Panel clientPanel = new FlowLayoutPanel();
                clientPanel.Controls.Add(lb);
                clientPanel.AutoSize = true;
                clientPanel.BorderStyle = BorderStyle.FixedSingle;

                // Add panel containing label and button to the main panel
                panel.Controls.Add(clientPanel);
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
                lb.TextAlign = ContentAlignment.MiddleCenter;
                panel.Controls.Add(lb);
            }
        }

        /* ********************************************************************
         * Popunjava naziv provajdera
         * ******************************************************************** */
        private void fill_provider_name_label(Label labelref) {
            labelref.Text = "Provider: ";
            try { labelref.Text += TextParser.Parse(configFilePath)["PROVIDER"]; }
            catch (Exception ex) { labelref.Text += "NOT RECOGNIZED"; }
        }

        /* ********************************************************************
         * Event handler za pretrazivanje klijenata po korisnickom imenu
         * ******************************************************************** */
        private void parse_keyup_filter_clients(object sender, KeyEventArgs e) {
            
            string text = this.filter_clients_tb.Text.Trim();
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("@param1", "%" + text + "%");
            string sql = "SELECT * FROM Client WHERE username like @param1";

            fill_clients_panel(panelClients, sql, keyValuePairs);
        }
    }
}
