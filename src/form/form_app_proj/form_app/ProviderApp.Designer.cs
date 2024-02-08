using System;
using System.Drawing;
using System.Windows.Forms;
using library.Other;
using library.Database;
using System.Collections.Generic;
using System.Data;

namespace form_app {
    partial class ProviderApp {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private readonly string configFilePath = "../../../../../config.txt";

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Custom helper functions

        /* ********************************************************************
         * Popunjava panel odvojen za klijente
         * ******************************************************************** */
        private void fill_clients_panel(FlowLayoutPanel panel) {
            Database instance = Database.GetInstance();
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            DataTable dt = instance.Query("SELECT * FROM client", keyValuePairs);
            foreach (DataRow dr in dt.Rows) {
                Label lb = new Label();
                lb.Text = dr["username"].ToString();
                lb.TextAlign = ContentAlignment.MiddleLeft;
                lb.BorderStyle = BorderStyle.FixedSingle;
                lb.AutoSize = false;
                lb.Width = 130;
                lb.Height = 26;

                lb.Name = "label_" + dr["clientid"];
                panel.Controls.Add(lb);
            }
        }
        /* ********************************************************************
         * Popunjava panel odvojen za internet pakete
         * ******************************************************************** */
        private void fill_internet_packets_panel(FlowLayoutPanel panel) {
            Database instance = Database.GetInstance();
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
            Database instance = Database.GetInstance();
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
            Database instance = Database.GetInstance();
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

        private void fill_provider_name_label(Label labelref) {
            labelref.Text = "Provider: ";
            try { labelref.Text += TextParser.Parse(configFilePath)["PROVIDER"]; }
            catch (Exception ex) { labelref.Text += "NOT RECOGNIZED"; }
        }

        private void fill_components() {
            fill_provider_name_label(this.providerName);
            fill_clients_panel(this.panelClients);
            fill_internet_packets_panel(this.panelInternetPackets);
            fill_tv_packets_panel(this.panelTVPackets);
            fill_comb_packets_panel(this.panelCombinedPackets);
        }

        private void parse_keyup_filter_clients(object sender, KeyEventArgs e) {
            this.panelClients.Controls.Clear();
            string text = this.filter_clients_tb.Text.Trim();

            Database instance = Database.GetInstance();
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("@param1", "%" +  text + "%");
            DataTable dt = instance.Query("SELECT * FROM Client WHERE username like @param1", keyValuePairs);

            foreach (DataRow dr in dt.Rows) {
                Label lb = new Label();
                lb.Text = dr["username"].ToString();
                lb.TextAlign = ContentAlignment.MiddleLeft;
                lb.BorderStyle = BorderStyle.FixedSingle;
                lb.AutoSize = false;
                lb.Width = 130;
                lb.Height = 26;

                lb.Name = "label_" + dr["clientid"];
                this.panelClients.Controls.Add(lb);
            }
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panelClients = new System.Windows.Forms.FlowLayoutPanel();
            this.label_clients = new System.Windows.Forms.Label();
            this.panelTVPackets = new System.Windows.Forms.FlowLayoutPanel();
            this.panelInternetPackets = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCombinedPackets = new System.Windows.Forms.FlowLayoutPanel();
            this.label_tv_packets = new System.Windows.Forms.Label();
            this.label_internet_packets = new System.Windows.Forms.Label();
            this.label_comb_packets = new System.Windows.Forms.Label();
            this.button_register_client = new System.Windows.Forms.Button();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.providerName = new System.Windows.Forms.Label();
            this.filter_clients_tb = new System.Windows.Forms.TextBox();
            this.filter_clients_label = new System.Windows.Forms.Label();
            this.button_create_packet = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelClients
            // 
            this.panelClients.AutoScroll = true;
            this.panelClients.Location = new System.Drawing.Point(26, 128);
            this.panelClients.Name = "panelClients";
            this.panelClients.Size = new System.Drawing.Size(210, 293);
            this.panelClients.TabIndex = 8;
            fill_clients_panel(this.panelClients);
            // 
            // label_clients
            // 
            this.label_clients.AutoSize = true;
            this.label_clients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_clients.Location = new System.Drawing.Point(23, 104);
            this.label_clients.Name = "label_clients";
            this.label_clients.Size = new System.Drawing.Size(72, 25);
            this.label_clients.TabIndex = 9;
            this.label_clients.Text = "Clients";
            // 
            // panelTVPackets
            // 
            this.panelTVPackets.AutoScroll = true;
            this.panelTVPackets.Location = new System.Drawing.Point(254, 128);
            this.panelTVPackets.Name = "panelTVPackets";
            this.panelTVPackets.Size = new System.Drawing.Size(227, 209);
            this.panelTVPackets.TabIndex = 10;
            // 
            // panelInternetPackets
            // 
            this.panelInternetPackets.AutoScroll = true;
            this.panelInternetPackets.Location = new System.Drawing.Point(513, 128);
            this.panelInternetPackets.Name = "panelInternetPackets";
            this.panelInternetPackets.Size = new System.Drawing.Size(227, 209);
            this.panelInternetPackets.TabIndex = 11;
            // 
            // panelCombinedPackets
            // 
            this.panelCombinedPackets.AutoScroll = true;
            this.panelCombinedPackets.Location = new System.Drawing.Point(773, 128);
            this.panelCombinedPackets.Name = "panelCombinedPackets";
            this.panelCombinedPackets.Size = new System.Drawing.Size(227, 209);
            this.panelCombinedPackets.TabIndex = 12;
            // 
            // label_tv_packets
            // 
            this.label_tv_packets.AutoSize = true;
            this.label_tv_packets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_tv_packets.Location = new System.Drawing.Point(251, 104);
            this.label_tv_packets.Name = "label_tv_packets";
            this.label_tv_packets.Size = new System.Drawing.Size(114, 25);
            this.label_tv_packets.TabIndex = 13;
            this.label_tv_packets.Text = "TV Packets";
            // 
            // label_internet_packets
            // 
            this.label_internet_packets.AutoSize = true;
            this.label_internet_packets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_internet_packets.Location = new System.Drawing.Point(510, 104);
            this.label_internet_packets.Name = "label_internet_packets";
            this.label_internet_packets.Size = new System.Drawing.Size(150, 25);
            this.label_internet_packets.TabIndex = 14;
            this.label_internet_packets.Text = "Internet packets";
            // 
            // label_comb_packets
            // 
            this.label_comb_packets.AutoSize = true;
            this.label_comb_packets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_comb_packets.Location = new System.Drawing.Point(770, 104);
            this.label_comb_packets.Name = "label_comb_packets";
            this.label_comb_packets.Size = new System.Drawing.Size(175, 25);
            this.label_comb_packets.TabIndex = 15;
            this.label_comb_packets.Text = "Combined packets";
            // 
            // button_register_client
            // 
            this.button_register_client.Location = new System.Drawing.Point(254, 380);
            this.button_register_client.Name = "button_register_client";
            this.button_register_client.Size = new System.Drawing.Size(148, 41);
            this.button_register_client.TabIndex = 16;
            this.button_register_client.Text = "Register new client";
            this.button_register_client.UseVisualStyleBackColor = true;
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.providerName);
            this.headerPanel.Location = new System.Drawing.Point(26, 12);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(974, 71);
            this.headerPanel.TabIndex = 17;
            // 
            // providerName
            // 
            this.providerName.AutoSize = true;
            this.providerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.providerName.Location = new System.Drawing.Point(3, 16);
            this.providerName.Name = "providerName";
            this.providerName.Size = new System.Drawing.Size(0, 38);
            this.providerName.TabIndex = 0;
            // 
            // filter_clients_tb
            // 
            this.filter_clients_tb.Location = new System.Drawing.Point(112, 427);
            this.filter_clients_tb.Name = "filter_clients_tb";
            this.filter_clients_tb.Size = new System.Drawing.Size(129, 22);
            this.filter_clients_tb.TabIndex = 18;
            // 
            // filter_clients_label
            // 
            this.filter_clients_label.AutoSize = true;
            this.filter_clients_label.Location = new System.Drawing.Point(25, 430);
            this.filter_clients_label.Name = "filter_clients_label";
            this.filter_clients_label.Size = new System.Drawing.Size(80, 16);
            this.filter_clients_label.TabIndex = 19;
            this.filter_clients_label.Text = "Filter clients:";
            // 
            // button_create_packet
            // 
            this.button_create_packet.Location = new System.Drawing.Point(418, 380);
            this.button_create_packet.Name = "button_create_packet";
            this.button_create_packet.Size = new System.Drawing.Size(148, 41);
            this.button_create_packet.TabIndex = 20;
            this.button_create_packet.Text = "Create packet";
            this.button_create_packet.UseVisualStyleBackColor = true;
            // 
            // ProviderApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 480);
            this.Controls.Add(this.button_create_packet);
            this.Controls.Add(this.filter_clients_label);
            this.Controls.Add(this.filter_clients_tb);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.button_register_client);
            this.Controls.Add(this.label_comb_packets);
            this.Controls.Add(this.panelCombinedPackets);
            this.Controls.Add(this.label_internet_packets);
            this.Controls.Add(this.label_tv_packets);
            this.Controls.Add(this.panelInternetPackets);
            this.Controls.Add(this.panelTVPackets);
            this.Controls.Add(this.label_clients);
            this.Controls.Add(this.panelClients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProviderApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TIM1 Provider App";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            fill_components();

        }

        #endregion
        private FlowLayoutPanel panelClients;
        private Label label_clients;
        private FlowLayoutPanel panelTVPackets;
        private FlowLayoutPanel panelInternetPackets;
        private FlowLayoutPanel panelCombinedPackets;
        private Label label_tv_packets;
        private Label label_internet_packets;
        private Label label_comb_packets;
        private Button button_register_client;
        private Panel headerPanel;
        private Label providerName;
        private TextBox filter_clients_tb;
        private Label filter_clients_label;
        private Button button_create_packet;
    }
}

