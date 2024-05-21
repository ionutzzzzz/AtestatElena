using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEFLI
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        internal static string Link = string.Empty;

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Text = $"Nefli ({Form3.Movie})";
            Movie film = Movie.Select(Form3.Movie);
            label1.Text = "Movie: " + Form3.Movie;
            label2.Text = "Genul Programului: " + film.Type;
            label3.Text = "Descriere: " + film.Description;
            pictureBox1.Image = (Image)(Form3.image);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Movie film = Movie.Select(Form3.Movie);
            Link = film.Link;
            Form6 f = new Form6();
            f.Show();
        }
    }
}
