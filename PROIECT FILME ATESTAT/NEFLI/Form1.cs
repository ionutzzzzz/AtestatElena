namespace NEFLI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        internal static string account = string.Empty;

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(10, "Nefli", $"Wellcome {Form2.account}!", ToolTipIcon.None);
            notifyIcon1.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            account = "Random";
            Form3 x = new Form3();
            x.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            account = "Elena";
            Form3 x = new Form3();
            x.Show();
            this.Hide();
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            account = "Lucas";
            Form3 x = new Form3();
            x.Show();
            this.Hide();
        }
    }
}