using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NEFLI
{
    internal class Users
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string PasswordKey { get; set; }
        public string Username { get; set; }

        public Users(int id, string email, string password, string username)
        {
            this.IdUser = id;
            this.Email = email;
            this.PasswordKey = password;
            this.Username = username;
        }

        internal static SqlConnection conn = Movie.conn;
        internal static SqlCommand cmd = Movie.cmd;
        internal static SqlDataAdapter adapter = Movie.adapter;

        public static void InsertUser(string email, string password, string username)
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO Users (Email, PasswordKey, Username) VALUES ('{email}', '{password}', '{username}')";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }

        public static Users SelectUser(string email, string password)
        {
            DataTable data = new DataTable();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = $"SELECT * FROM Users WHERE CONVERT(VARCHAR, Email) = '{email}' AND CONVERT(VARCHAR, PasswordKey) = '{password}'";
            adapter.SelectCommand = cmd;
            adapter.Fill(data);
            conn.Close();
            if (data.Rows.Count == 0)
            {
                return new Users(0, "", "", "");
            }
            int id = Convert.ToInt32(data.Rows[0][0]);
            string username = data.Rows[0][3].ToString();            
            return new Users(id, email, password, username);
        }
    }
}
