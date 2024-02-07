using System;
using System.Drawing;
using System.Windows.Forms;
using library.Other;
using library.Database;
using System.Collections.Generic;
using System.Data;

namespace form_app {
    partial class Form1 {
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
         * input_textbox_Enter
         * input_username_Leave
         * input_firstname_Leave
         * input_lastname_Leave
         * ----------------------
         * Metode se koriste kako bi se kreirao efekat placeholder teksta kod
         * text box-ova
         * ******************************************************************** */
        private void input_textbox_Enter(object sender, EventArgs e) {
            switch (((TextBox)sender).Text) {
                case "username":
                    this.input_username.Text = "";
                    this.input_username.ForeColor = System.Drawing.SystemColors.WindowText;
                    break;
                case "First name":
                    this.input_firstname.Text = "";
                    this.input_firstname.ForeColor = System.Drawing.SystemColors.WindowText;
                    break;
                case "Last name":
                    this.input_lastname.Text = "";
                    this.input_lastname.ForeColor = System.Drawing.SystemColors.WindowText;
                    break;
                default:
                    break;
            }
        }

        private void input_username_Leave(object sender, EventArgs e) {
            if (input_username.Text == "") {
                input_username.Text = "username";
                input_username.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        private void input_firstname_Leave(object sender, EventArgs e) {
            if (input_firstname.Text == "") {
                input_firstname.Text = "First name";
                input_firstname.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        private void input_lastname_Leave(object sender, EventArgs e) {
            if (input_lastname.Text == "") {
                input_lastname.Text = "Last name";
                input_lastname.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

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
                lb.Click += (sender, e) => {
                    lb.BackColor = (lb.BackColor == Color.Green) ? SystemColors.Control : Color.Green;
                };
                panel.Controls.Add(lb);
            }
        }
        /* ********************************************************************
         * Popunjava panel odvojen internet pakete
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
            this.label_register_new_client          = new System.Windows.Forms.Label();
            this.label_provider_name                = new System.Windows.Forms.Label();
            this.input_username                     = new System.Windows.Forms.TextBox();
            this.input_firstname                    = new System.Windows.Forms.TextBox();
            this.input_lastname                     = new System.Windows.Forms.TextBox();
            this.button_register_client             = new System.Windows.Forms.Button();
            this.panelClients                       = new System.Windows.Forms.FlowLayoutPanel();
            this.label_clients                      = new System.Windows.Forms.Label();
            this.panelTVPackets                     = new System.Windows.Forms.FlowLayoutPanel();
            this.panelInternetPackets               = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCombinedPackets               = new System.Windows.Forms.FlowLayoutPanel();
            this.label_tv_packets                   = new System.Windows.Forms.Label();
            this.label_internet_packets             = new System.Windows.Forms.Label();
            this.label_comb_packets                 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_register_new_client
            // 
            this.label_register_new_client.AutoSize = true;
            this.label_register_new_client.Location = new System.Drawing.Point(12, 49);
            this.label_register_new_client.Name = "label_register_new_client";
            this.label_register_new_client.Size = new System.Drawing.Size(119, 16);
            this.label_register_new_client.TabIndex = 1;
            this.label_register_new_client.Text = "Register new client";
            // 
            // label_provider_name
            // 
            this.label_provider_name.AutoSize = true;
            this.label_provider_name.Location = new System.Drawing.Point(12, 9);
            this.label_provider_name.Name = "label2";
            this.label_provider_name.Size = new System.Drawing.Size(98, 16);
            this.label_provider_name.TabIndex = 2;
            try {
                this.label_provider_name.Text = "Provider: " + TextParser.Parse(configFilePath)["PROVIDER"];
            }
            catch(Exception ex) {
                this.label_provider_name.Text = "Provider: NOT RECOGNIZED";
            }
            //this.label2.Text = "Provider: NOT RECOGNIZED";
            // 
            // input_username
            // 
            this.input_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.input_username.Font = new System.Drawing.Font("Arial", 10F);
            this.input_username.ForeColor = System.Drawing.SystemColors.GrayText;
            this.input_username.Location = new System.Drawing.Point(11, 79);
            this.input_username.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.input_username.MaximumSize = new System.Drawing.Size(150, 41);
            this.input_username.MinimumSize = new System.Drawing.Size(10, 8);
            this.input_username.Name = "input_username";
            this.input_username.Size = new System.Drawing.Size(150, 27);
            this.input_username.TabIndex = 3;
            this.input_username.Text = "username";
            this.input_username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.input_username.Enter += new System.EventHandler(this.input_textbox_Enter);
            this.input_username.Leave += new System.EventHandler(this.input_username_Leave);
            // 
            // input_firstname
            // 
            this.input_firstname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.input_firstname.Font = new System.Drawing.Font("Arial", 10F);
            this.input_firstname.ForeColor = System.Drawing.SystemColors.GrayText;
            this.input_firstname.Location = new System.Drawing.Point(171, 79);
            this.input_firstname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.input_firstname.MaximumSize = new System.Drawing.Size(150, 41);
            this.input_firstname.MinimumSize = new System.Drawing.Size(10, 8);
            this.input_firstname.Name = "input_firstname";
            this.input_firstname.Size = new System.Drawing.Size(150, 27);
            this.input_firstname.TabIndex = 4;
            this.input_firstname.Text = "First name";
            this.input_firstname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.input_firstname.Enter += new System.EventHandler(this.input_textbox_Enter);
            this.input_firstname.Leave += new System.EventHandler(this.input_firstname_Leave);
            // 
            // input_lastname
            // 
            this.input_lastname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.input_lastname.Font = new System.Drawing.Font("Arial", 10F);
            this.input_lastname.ForeColor = System.Drawing.SystemColors.GrayText;
            this.input_lastname.Location = new System.Drawing.Point(331, 79);
            this.input_lastname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.input_lastname.MaximumSize = new System.Drawing.Size(150, 41);
            this.input_lastname.MinimumSize = new System.Drawing.Size(10, 8);
            this.input_lastname.Name = "input_lastname";
            this.input_lastname.Size = new System.Drawing.Size(150, 27);
            this.input_lastname.TabIndex = 5;
            this.input_lastname.Text = "Last name";
            this.input_lastname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.input_lastname.Enter += new System.EventHandler(this.input_textbox_Enter);
            this.input_lastname.Leave += new System.EventHandler(this.input_lastname_Leave);
            // 
            // button_register_client
            // 
            this.button_register_client.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_register_client.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_register_client.Location = new System.Drawing.Point(491, 79);
            this.button_register_client.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_register_client.Name = "button1";
            this.button_register_client.Size = new System.Drawing.Size(100, 30);
            this.button_register_client.TabIndex = 6;
            this.button_register_client.Text = "Register";
            this.button_register_client.UseVisualStyleBackColor = true;
            // 
            // panelClients
            // 
            this.panelClients.Location = new System.Drawing.Point(11, 146);
            this.panelClients.Name = "panelClients";
            this.panelClients.Size = new System.Drawing.Size(197, 293);
            this.panelClients.TabIndex = 8;
            fill_clients_panel(this.panelClients);
            // 
            // label_clients
            // 
            this.label_clients.AutoSize = true;
            this.label_clients.Location = new System.Drawing.Point(12, 127);
            this.label_clients.Name = "label4";
            this.label_clients.Size = new System.Drawing.Size(47, 16);
            this.label_clients.TabIndex = 9;
            this.label_clients.Text = "Clients";
            // 
            // panelTVPackets
            // 
            this.panelTVPackets.Location = new System.Drawing.Point(254, 146);
            this.panelTVPackets.Name = "panelTVPackets";
            this.panelTVPackets.Size = new System.Drawing.Size(227, 122);
            this.panelTVPackets.TabIndex = 10;
            fill_tv_packets_panel(panelTVPackets);
            // 
            // panelInternetPackets
            // 
            this.panelInternetPackets.Location = new System.Drawing.Point(254, 312);
            this.panelInternetPackets.Name = "panelInternetPackets";
            this.panelInternetPackets.Size = new System.Drawing.Size(227, 122);
            this.panelInternetPackets.TabIndex = 11;
            fill_internet_packets_panel(panelInternetPackets);
            // 
            // panelCombinedPackets
            // 
            this.panelCombinedPackets.Location = new System.Drawing.Point(527, 146);
            this.panelCombinedPackets.Name = "panelCombinedPackets";
            this.panelCombinedPackets.Size = new System.Drawing.Size(227, 122);
            this.panelCombinedPackets.TabIndex = 12;
            fill_comb_packets_panel(panelCombinedPackets);
            // 
            // label_tv_packets
            // 
            this.label_tv_packets.AutoSize = true;
            this.label_tv_packets.Location = new System.Drawing.Point(251, 127);
            this.label_tv_packets.Name = "label3";
            this.label_tv_packets.Size = new System.Drawing.Size(77, 16);
            this.label_tv_packets.TabIndex = 13;
            this.label_tv_packets.Text = "TV Packets";
            // 
            // label_internet_packets
            // 
            this.label_internet_packets.AutoSize = true;
            this.label_internet_packets.Location = new System.Drawing.Point(254, 290);
            this.label_internet_packets.Name = "label5";
            this.label_internet_packets.Size = new System.Drawing.Size(101, 16);
            this.label_internet_packets.TabIndex = 14;
            this.label_internet_packets.Text = "Internet packets";
            // 
            // label_comb_packets
            // 
            this.label_comb_packets.AutoSize = true;
            this.label_comb_packets.Location = new System.Drawing.Point(524, 127);
            this.label_comb_packets.Name = "label6";
            this.label_comb_packets.Size = new System.Drawing.Size(120, 16);
            this.label_comb_packets.TabIndex = 15;
            this.label_comb_packets.Text = "Combined packets";
            // 
            // TIM_01_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.label_comb_packets);
            this.Controls.Add(this.label_internet_packets);
            this.Controls.Add(this.label_tv_packets);
            this.Controls.Add(this.panelCombinedPackets);
            this.Controls.Add(this.panelInternetPackets);
            this.Controls.Add(this.panelTVPackets);
            this.Controls.Add(this.label_clients);
            this.Controls.Add(this.panelClients);
            this.Controls.Add(this.button_register_client);
            this.Controls.Add(this.input_lastname);
            this.Controls.Add(this.input_firstname);
            this.Controls.Add(this.input_username);
            this.Controls.Add(this.label_provider_name);
            this.Controls.Add(this.label_register_new_client);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TIM_01_Form";
            this.Text = "ProviderApp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_register_new_client;
        private System.Windows.Forms.Label label_provider_name;
        private System.Windows.Forms.TextBox input_username;
        private System.Windows.Forms.TextBox input_firstname;
        private System.Windows.Forms.TextBox input_lastname;
        private Button button_register_client;
        private FlowLayoutPanel panelClients;
        private Label label_clients;
        private FlowLayoutPanel panelTVPackets;
        private FlowLayoutPanel panelInternetPackets;
        private FlowLayoutPanel panelCombinedPackets;
        private Label label_tv_packets;
        private Label label_internet_packets;
        private Label label_comb_packets;
    }
}

