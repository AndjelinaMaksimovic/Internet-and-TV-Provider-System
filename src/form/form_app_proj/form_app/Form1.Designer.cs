using System;
using System.Drawing;
using System.Windows.Forms;
using library.Other;

namespace form_app {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private readonly string configFilePath = "C:\\Users\\radov\\Desktop\\Dizajniranje_softvera\\Projekat\\ClonedProject\\src\\config.txt";

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
        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.input_username = new System.Windows.Forms.TextBox();
            this.input_firstname = new System.Windows.Forms.TextBox();
            this.input_lastname = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panelClients = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Register new client";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 2;
            /*try {
                this.label2.Text = "Provider: " + TextParser.Parse(configFilePath)["PROVIDER"];
            }
            catch(Exception ex) {
                this.label2.Text = "Provider: NOT RECOGNIZED";
            }*/
            this.label2.Text = "Provider: NOT RECOGNIZED";
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
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(491, 79);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panelClients
            // 
            this.panelClients.Location = new System.Drawing.Point(11, 146);
            this.panelClients.Name = "panelClients";
            this.panelClients.Size = new System.Drawing.Size(197, 293);
            this.panelClients.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Clients";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(254, 146);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(227, 122);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(254, 312);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(227, 122);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Location = new System.Drawing.Point(527, 146);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(227, 122);
            this.flowLayoutPanel3.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "TV Packets";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Internet packets";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(524, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Combined packets";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panelClients);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.input_lastname);
            this.Controls.Add(this.input_firstname);
            this.Controls.Add(this.input_username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "ProviderApp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox input_username;
        private System.Windows.Forms.TextBox input_firstname;
        private System.Windows.Forms.TextBox input_lastname;
        private Button button1;
        private FlowLayoutPanel panelClients;
        private Label label4;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label3;
        private Label label5;
        private Label label6;
    }
}

