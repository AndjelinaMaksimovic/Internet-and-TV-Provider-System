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
                lb.Width = 180;
                lb.Height = 30;

                // TO DO - SELECT
                lb.MouseEnter += (sender, e) => {
                    lb.BackColor = Color.LightGray;
                };

                lb.MouseLeave += (sender, e) => {
                    lb.BackColor = SystemColors.Control;
                };
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
                lb.Width = 220;
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
                lb.Width = 220;
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
                lb.Width = 220;
                lb.Height = 30;
                lb.TextAlign = ContentAlignment.MiddleCenter;
                panel.Controls.Add(lb);
            }
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label_provider_name = new System.Windows.Forms.Label();
            this.panelClients = new System.Windows.Forms.FlowLayoutPanel();
            this.label_clients = new System.Windows.Forms.Label();
            this.panelTVPackets = new System.Windows.Forms.FlowLayoutPanel();
            this.panelInternetPackets = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCombinedPackets = new System.Windows.Forms.FlowLayoutPanel();
            this.label_tv_packets = new System.Windows.Forms.Label();
            this.label_internet_packets = new System.Windows.Forms.Label();
            this.label_comb_packets = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_provider_name
            // 
            this.label_provider_name.AutoSize = true;
            this.label_provider_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_provider_name.Location = new System.Drawing.Point(285, 41);
            this.label_provider_name.Name = "label_provider_name";
            this.label_provider_name.Size = new System.Drawing.Size(456, 38);
            this.label_provider_name.TabIndex = 2;
            this.label_provider_name.Text = "Provider: NOT RECOGNIZED";
            // 
            // panelClients
            // 
            this.panelClients.Location = new System.Drawing.Point(26, 128);
            this.panelClients.Name = "panelClients";
            this.panelClients.Size = new System.Drawing.Size(195, 293);
            this.panelClients.TabIndex = 8;
            fill_clients_panel(this.panelClients);
            // 
            // label_clients
            // 
            this.label_clients.AutoSize = true;
            this.label_clients.Location = new System.Drawing.Point(23, 109);
            this.label_clients.Name = "label_clients";
            this.label_clients.Size = new System.Drawing.Size(47, 16);
            this.label_clients.TabIndex = 9;
            this.label_clients.Text = "Clients";
            // 
            // panelTVPackets
            // 
            this.panelTVPackets.Location = new System.Drawing.Point(254, 128);
            this.panelTVPackets.Name = "panelTVPackets";
            this.panelTVPackets.Size = new System.Drawing.Size(227, 209);
            this.panelTVPackets.TabIndex = 10;
            // 
            // panelInternetPackets
            // 
            this.panelInternetPackets.Location = new System.Drawing.Point(513, 128);
            this.panelInternetPackets.Name = "panelInternetPackets";
            this.panelInternetPackets.Size = new System.Drawing.Size(227, 209);
            this.panelInternetPackets.TabIndex = 11;
            // 
            // panelCombinedPackets
            // 
            this.panelCombinedPackets.Location = new System.Drawing.Point(773, 128);
            this.panelCombinedPackets.Name = "panelCombinedPackets";
            this.panelCombinedPackets.Size = new System.Drawing.Size(227, 209);
            this.panelCombinedPackets.TabIndex = 12;
            // 
            // label_tv_packets
            // 
            this.label_tv_packets.AutoSize = true;
            this.label_tv_packets.Location = new System.Drawing.Point(251, 109);
            this.label_tv_packets.Name = "label_tv_packets";
            this.label_tv_packets.Size = new System.Drawing.Size(77, 16);
            this.label_tv_packets.TabIndex = 13;
            this.label_tv_packets.Text = "TV Packets";
            // 
            // label_internet_packets
            // 
            this.label_internet_packets.AutoSize = true;
            this.label_internet_packets.Location = new System.Drawing.Point(510, 109);
            this.label_internet_packets.Name = "label_internet_packets";
            this.label_internet_packets.Size = new System.Drawing.Size(101, 16);
            this.label_internet_packets.TabIndex = 14;
            this.label_internet_packets.Text = "Internet packets";
            // 
            // label_comb_packets
            // 
            this.label_comb_packets.AutoSize = true;
            this.label_comb_packets.Location = new System.Drawing.Point(770, 109);
            this.label_comb_packets.Name = "label_comb_packets";
            this.label_comb_packets.Size = new System.Drawing.Size(120, 16);
            this.label_comb_packets.TabIndex = 15;
            this.label_comb_packets.Text = "Combined packets";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(254, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 41);
            this.button1.TabIndex = 16;
            this.button1.Text = "Register new client";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ProviderApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 480);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_comb_packets);
            this.Controls.Add(this.panelCombinedPackets);
            this.Controls.Add(this.label_internet_packets);
            this.Controls.Add(this.label_tv_packets);
            this.Controls.Add(this.panelInternetPackets);
            this.Controls.Add(this.panelTVPackets);
            this.Controls.Add(this.label_clients);
            this.Controls.Add(this.panelClients);
            this.Controls.Add(this.label_provider_name);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ProviderApp";
            this.Text = "ProviderApp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_provider_name;
        private FlowLayoutPanel panelClients;
        private Label label_clients;
        private FlowLayoutPanel panelTVPackets;
        private FlowLayoutPanel panelInternetPackets;
        private FlowLayoutPanel panelCombinedPackets;
        private Label label_tv_packets;
        private Label label_internet_packets;
        private Label label_comb_packets;
        private Button button1;
    }
}

