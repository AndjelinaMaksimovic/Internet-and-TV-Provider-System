using System;
using System.Drawing;
using System.Windows.Forms;

namespace form_app {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Register new client";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Provider Name";
            // 
            // input_username
            // 
            this.input_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.input_username.Font = new System.Drawing.Font("Arial", 10F);
            this.input_username.ForeColor = System.Drawing.SystemColors.GrayText;
            this.input_username.Location = new System.Drawing.Point(8, 64);
            this.input_username.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.input_username.MaximumSize = new System.Drawing.Size(113, 41);
            this.input_username.MinimumSize = new System.Drawing.Size(8, 8);
            this.input_username.Name = "input_username";
            this.input_username.Size = new System.Drawing.Size(113, 25);
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
            this.input_firstname.Location = new System.Drawing.Point(128, 64);
            this.input_firstname.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.input_firstname.MaximumSize = new System.Drawing.Size(113, 41);
            this.input_firstname.MinimumSize = new System.Drawing.Size(8, 8);
            this.input_firstname.Name = "input_firstname";
            this.input_firstname.Size = new System.Drawing.Size(113, 25);
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
            this.input_lastname.Location = new System.Drawing.Point(248, 64);
            this.input_lastname.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.input_lastname.MaximumSize = new System.Drawing.Size(113, 41);
            this.input_lastname.MinimumSize = new System.Drawing.Size(8, 8);
            this.input_lastname.Name = "input_lastname";
            this.input_lastname.Size = new System.Drawing.Size(113, 25);
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
            this.button1.Location = new System.Drawing.Point(368, 64);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 6;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Add new package";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 390);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.input_lastname);
            this.Controls.Add(this.input_firstname);
            this.Controls.Add(this.input_username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private Label label3;
    }
}

