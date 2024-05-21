using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace NEFLI
{
    internal class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        internal Movie(int id, string title, string type, string description, string link)
        {
            Id = id;
            Title = title;
            Type = type;
            Description = description;
            Link = link;
        }

        internal static string path = Application.StartupPath;
        internal static string Connection = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={path}Database.mdf;Integrated Security=True";
        internal static SqlConnection conn = new SqlConnection(Connection);
        internal static SqlCommand cmd = new SqlCommand();
        internal static SqlDataAdapter adapter = new SqlDataAdapter();

        internal static Movie Select(string title)
        {
            DataTable data = new DataTable();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = $"SELECT * FROM Movie WHERE Title LIKE '%{title}%'";
            adapter.SelectCommand = cmd;
            adapter.Fill(data);
            int id = 0;
            string type, description, link;
            try
            {
                 id = Convert.ToInt32(data.Rows[0][0]);
                 type = data.Rows[0][2].ToString().Trim();
                 description = data.Rows[0][3].ToString().Trim();
                 link = data.Rows[0][4].ToString().Trim();
            }
            catch(Exception e)
            {
                type = description = link = string.Empty;
            }
            
            conn.Close();
            return new Movie(id, title, type, description, link);
        }
    }
}
