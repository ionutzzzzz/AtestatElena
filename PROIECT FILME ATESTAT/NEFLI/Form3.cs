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
	public partial class Form3 : Form
	{
		public Form3()
		{
			InitializeComponent();
		}

		internal static List<string> Titles = new List<string>();

		internal static string Movie = string.Empty;
		internal static Bitmap image;

		private void Form3_Load(object sender, EventArgs e)
		{
			string path = Application.StartupPath;
			string[] Post = Directory.GetFiles(@$"{path}Post");
			List<Label> labels = new List<Label>();
			foreach (var ctrl in this.Controls)
			{
				if(ctrl is Label && ctrl != label1 && ctrl != label2)
				{
					Label label = (Label)ctrl;
					labels.Add(label);
					Titles.Add(label.Text);
				}
			}
			foreach (var ctrl in this.Controls)
			{
				if (ctrl is PictureBox && ctrl != pictureBox1)
				{
					PictureBox box = (PictureBox)ctrl;
					string name = (string)box.Name.Substring(10);
					int id = Convert.ToInt32(name);
					Label select = new Label();
					foreach(Label label in labels)
					{
						if (label.Name.Contains((id + 1).ToString()))
						{
							select = label;
							break;
						}
					}
					box.Name = select.Text;
					box.Click += Picture_Click;
				}
			}
		}

		private void Picture_Click(object? sender, EventArgs e)
		{
			PictureBox? picture = sender as PictureBox;
			Movie = picture.Name;
			image = new Bitmap(picture.Image);
			Form4 f = new Form4();
			f.Show();
		}

		private void label1_MouseHover(object sender, EventArgs e)
		{
			label1.Font = new Font("Segoe UI", 14, FontStyle.Bold);
		}

		private void label1_MouseLeave(object sender, EventArgs e)
		{
			label1.Font = new Font("Segoe UI", 14, FontStyle.Regular);
		}

		private void label2_MouseHover(object sender, EventArgs e)
		{
			label2.Font = new Font("Segoe UI", 14, FontStyle.Bold);
		}

		private void label2_MouseLeave(object sender, EventArgs e)
		{
			label2.Font = new Font("Segoe UI", 14, FontStyle.Regular);
		}

		private void label1_Click(object sender, EventArgs e) // Seriale
		{

		}

		private void label2_Click(object sender, EventArgs e) // Filme
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e) // Search
		{
			string search = textBox1.Text;
			List<string> selection = new List<string>();
			foreach(string text in Titles)
			{
				if(text.ToLower().Contains(search.ToLower()))
				{
					selection.Add(text);    
				}
			}

		}
	}
}
