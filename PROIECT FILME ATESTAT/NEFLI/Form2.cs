using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NEFLI
{

    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        internal static string account = string.Empty;

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.PlaceholderText = "Email or phone number";
            label4.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Users utilizator = Users.SelectUser(textBox1.Text, textBox2.Text);

            if (utilizator.IdUser != 0)
            {
                account = utilizator.Username;
                Form1 x = new Form1();
                x.Show();
                this.Hide();
                return;
            }
            
            label4.Visible = true;
            errorProvider1.SetError(textBox1, "informatii de conectare gresite");
            errorProvider1.SetError(textBox2, "informatii de conectare gresite");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void label5_Click(object sender, EventArgs e) // Create Account Label
        {
            Form5 f = new Form5();
            f.Show();
            this.Hide();
        }
    }
}
