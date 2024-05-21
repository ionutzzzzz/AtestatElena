using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEFLI
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Create Now
        {
            string email = textBox1.Text;
            string parola1 = textBox2.Text;
            string parola2 = textBox4.Text;
            string nume = textBox3.Text;

            if (parola1 != parola2)
            {
                MessageBox.Show("Parolele Nu Coincid Intre ele!");
                return;
            }

            Users.InsertUser(email, parola1, nume);
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e) // LOG IN
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }
    }
}
