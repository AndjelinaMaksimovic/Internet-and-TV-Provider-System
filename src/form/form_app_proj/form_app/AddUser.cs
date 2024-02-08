using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form_app
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isValid = true; // Track overall validation status

            // Validate name TextBox
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Username is required.");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(textBox1, ""); // Clear error message
            }

            // Validate email TextBox
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider2.SetError(textBox2, "First name is required.");
                isValid = false;
            }
            else
            {
                errorProvider2.SetError(textBox2, ""); // Clear error message
            }

            // Validate password TextBox
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                errorProvider3.SetError(textBox3, "Last name is required.");
                isValid = false;
            }
            else
            {
                errorProvider3.SetError(textBox3, ""); // Clear error message
            }

            if (isValid)
            {
                // If all validations pass, proceed with further actions
                MessageBox.Show("Form submitted successfully!");
            }
        }
    }
}
