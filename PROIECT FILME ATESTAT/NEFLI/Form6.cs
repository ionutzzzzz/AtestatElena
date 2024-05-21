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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            string link = Form4.Link;
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.Dock = DockStyle.Fill;
            webBrowser.Width = this.Width;
            webBrowser.Height = this.Height;
            webBrowser.ScrollBarsEnabled = true;
            webBrowser.Visible = true;
            webBrowser.ScriptErrorsSuppressed = true;
            string url = link;
            string html = "<html style='width: 100%; height: 100%; margin: 0; padding: 0;'><head>";
            html += "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>";
            html += "</head><body style='width: 100%; height: 100%; margin: 0; padding: 0;'>";
            html += "<iframe id='video' src='https://www.youtube.com/embed/{0}' style=\"padding: 0px; width: 100%; height: 100%; border: none; display: block;\" allowfullscreen></iframe>";
            html += "</body></html>";
            webBrowser.DocumentText = string.Format(html, url.Split('=')[1]);
            webBrowser.Show();
            this.Controls.Add(webBrowser);

        }

       
    }
}
