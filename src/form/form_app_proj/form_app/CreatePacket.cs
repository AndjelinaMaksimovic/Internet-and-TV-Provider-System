using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using library.Database;

namespace form_app {
    public partial class CreatePacket : Form {

        private Database instance = null;

        public CreatePacket() {
            InitializeComponent();

            instance = Database.GetInstance();
            fill_cb_packet_types();
        }

        private void fill_cb_packet_types() {
            this.choose_packet_type_cb.Items.Clear();
            this.choose_packet_type_cb.Items.Add("Internet packet");
            this.choose_packet_type_cb.Items.Add("TV packet");
            this.choose_packet_type_cb.Items.Add("Combined packet");
        }

        private void parse_cb_change(object sender, EventArgs e) {
            ComboBox comboBox = (ComboBox)sender;
            object selectedValue = comboBox.SelectedItem;
            string selectedText = null;

            if (selectedValue != null) {
                selectedText = selectedValue.ToString();
            }

            switch (selectedText) {
                case "Internet packet":
                    show_internet_packet_creation_dialog();
                    break;

                case "TV packet":
                    show_tv_packet_creation_dialog();
                    break;

                case "Combined packet":
                    show_combined_packet_creation_dialog();
                    break;

                default:
                    break;
            }
        }

        private void show_internet_packet_creation_dialog() {

            panel_show_details.Controls.Clear();
            
            TextBox packetName = new TextBox();
            TextBox packetPrice = new TextBox();
            TextBox downloadSpeed = new TextBox();
            TextBox uploadSpeed = new TextBox();

            Label name = new Label();
            name.Text = "Name";
            name.AutoSize = false;
            name.Width = 50;
            name.TextAlign = ContentAlignment.MiddleLeft;

            Label price = new Label();
            price.Text = "Price";
            price.AutoSize = false;
            price.Width = 50;
            price.TextAlign = ContentAlignment.MiddleLeft;

            Label ds = new Label();
            ds.Text = "Download";
            ds.AutoSize = false;
            ds.Width = 80;
            ds.TextAlign = ContentAlignment.MiddleLeft;

            Label us = new Label();
            us.Text = "Upload";
            us.AutoSize = false;
            us.Width = 80;
            us.TextAlign = ContentAlignment.MiddleLeft;

            panel_show_details.Controls.Add(packetName);    panel_show_details.Controls.Add(name);
            panel_show_details.Controls.Add(packetPrice);   panel_show_details.Controls.Add(price);
            panel_show_details.Controls.Add(downloadSpeed); panel_show_details.Controls.Add(ds);
            panel_show_details.Controls.Add(uploadSpeed);   panel_show_details.Controls.Add(us);
            
            add_create_button(panel_show_details);
        }

        private void show_tv_packet_creation_dialog() {
            panel_show_details.Controls.Clear();

            TextBox packetName = new TextBox();
            TextBox packetPrice = new TextBox();
            TextBox numberOfChannels = new TextBox();

            Label name = new Label();
            name.Text = "Name";
            name.AutoSize = false;
            name.Width = 50;
            name.TextAlign = ContentAlignment.MiddleLeft;

            Label price = new Label();
            price.Text = "Price";
            price.AutoSize = false;
            price.Width = 50;
            price.TextAlign = ContentAlignment.MiddleLeft;

            Label channels = new Label();
            channels.Text = "Channels";
            channels.AutoSize = false;
            channels.Width = 80;
            channels.TextAlign = ContentAlignment.MiddleLeft;

            panel_show_details.Controls.Add(packetName);        panel_show_details.Controls.Add(name);
            panel_show_details.Controls.Add(packetPrice);       panel_show_details.Controls.Add(price);
            panel_show_details.Controls.Add(numberOfChannels);  panel_show_details.Controls.Add(channels);

            add_create_button(panel_show_details);
        }

        private void show_combined_packet_creation_dialog() {
            panel_show_details.Controls.Clear();

            TextBox packetName = new TextBox();
            TextBox packetPrice = new TextBox();
            ComboBox internetPacket = new ComboBox();
            ComboBox tvPacket = new ComboBox();

            internetPacket.DropDownStyle = ComboBoxStyle.DropDownList;
            tvPacket.DropDownStyle = ComboBoxStyle.DropDownList;

            fill_available_internet_packets(internetPacket);
            fill_available_tv_packets(tvPacket);

            Label name = new Label();
            name.Text = "Name";
            name.AutoSize = false;
            name.Width = 50;
            name.TextAlign = ContentAlignment.MiddleLeft;

            Label price = new Label();
            price.Text = "Price";
            price.AutoSize = false;
            price.Width = 50;
            price.TextAlign = ContentAlignment.MiddleLeft;

            Label internet = new Label();
            internet.Text = "Internet";
            internet.AutoSize = false;
            internet.Width = 50;
            internet.TextAlign = ContentAlignment.MiddleLeft;

            Label tv = new Label();
            tv.Text = "TV";
            tv.AutoSize = false;
            tv.Width = 50;
            tv.TextAlign = ContentAlignment.MiddleLeft;

            panel_show_details.Controls.Add(packetName);        panel_show_details.Controls.Add(name);
            panel_show_details.Controls.Add(packetPrice);       panel_show_details.Controls.Add(price);
            panel_show_details.Controls.Add(internetPacket);    panel_show_details.Controls.Add(internet);
            panel_show_details.Controls.Add(tvPacket);          panel_show_details.Controls.Add(tv);

            add_create_button(panel_show_details);
        }

        private void add_create_button(Panel panelRef) {
            Button createButton = new Button();
            createButton.Text = "Create";
            createButton.Cursor = Cursors.Arrow;

            createButton.Click += (sender, e) => {
                this.Close();
            };

            panelRef.Controls.Add(createButton);
        }

        private void fill_available_internet_packets(ComboBox reference) {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            DataTable dt = instance.Query("SELECT * FROM packet p JOIN internetpacket i on p.packetid = i.packetid", keyValuePairs);

            foreach (DataRow dr in dt.Rows) {
                reference.Items.Add(dr["name"]);
            }
        }

        private void fill_available_tv_packets(ComboBox reference) {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            DataTable dt = instance.Query("SELECT * FROM packet p JOIN tvpacket t on p.packetid = t.packetid", keyValuePairs);

            foreach (DataRow dr in dt.Rows) {
                reference.Items.Add(dr["name"]);
            }
        }
    }
}
