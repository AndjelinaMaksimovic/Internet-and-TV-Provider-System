namespace form_app {
    partial class ActivateDeactivatePackets {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.clients_list = new System.Windows.Forms.ComboBox();
            this.label_clients_name = new System.Windows.Forms.Label();
            this.label_owned_packets = new System.Windows.Forms.Label();
            this.clients_packets_list = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // clients_list
            // 
            this.clients_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clients_list.FormattingEnabled = true;
            this.clients_list.Location = new System.Drawing.Point(24, 76);
            this.clients_list.Name = "clients_list";
            this.clients_list.Size = new System.Drawing.Size(180, 24);
            this.clients_list.TabIndex = 0;
            // 
            // label_clients_name
            // 
            this.label_clients_name.AutoSize = true;
            this.label_clients_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_clients_name.Location = new System.Drawing.Point(28, 42);
            this.label_clients_name.Name = "label_clients_name";
            this.label_clients_name.Size = new System.Drawing.Size(119, 25);
            this.label_clients_name.TabIndex = 1;
            this.label_clients_name.Text = "Client Name";
            this.label_clients_name.Click += new System.EventHandler(this.label1_Click);
            // 
            // label_owned_packets
            // 
            this.label_owned_packets.AutoSize = true;
            this.label_owned_packets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_owned_packets.Location = new System.Drawing.Point(299, 42);
            this.label_owned_packets.Name = "label_owned_packets";
            this.label_owned_packets.Size = new System.Drawing.Size(148, 25);
            this.label_owned_packets.TabIndex = 2;
            this.label_owned_packets.Text = "Owned packets";
            this.label_owned_packets.Click += new System.EventHandler(this.label2_Click);
            // 
            // clients_packets_list
            // 
            this.clients_packets_list.FormattingEnabled = true;
            this.clients_packets_list.Location = new System.Drawing.Point(304, 76);
            this.clients_packets_list.Name = "clients_packets_list";
            this.clients_packets_list.Size = new System.Drawing.Size(168, 191);
            this.clients_packets_list.TabIndex = 3;
            // 
            // ActivateDeactivatePackets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clients_packets_list);
            this.Controls.Add(this.label_owned_packets);
            this.Controls.Add(this.label_clients_name);
            this.Controls.Add(this.clients_list);
            this.Name = "ActivateDeactivatePackets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ActivateDeactivatePackets";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox clients_list;
        private System.Windows.Forms.Label label_clients_name;
        private System.Windows.Forms.Label label_owned_packets;
        private System.Windows.Forms.CheckedListBox clients_packets_list;
    }
}