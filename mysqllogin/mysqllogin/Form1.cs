using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace mysqllogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private MySqlConnection getDBConnection(string server, string username, string password, string database)
        {
            MySqlConnection connection = new MySqlConnection("server = " + server + "; database = " + database + "; user = " + username + "; password = " + password + "; ssl mode = none;");
            try
            {
                connection.Open();
            }
            catch(MySqlException ex)
            {
                if(ex.Number == 1042)
                {
                    MessageBox.Show("Server is down.");
                }
            }
            return connection;
        }
        private void login_Click(object sender, EventArgs e)
        {
            if(userInput.Text == "" || passwordInput.Text == "")
            {
                MessageBox.Show("Please, insert credentials.");
            }
            else
            {
                MySqlConnection conn = getDBConnection("localhost", "root", "rootpassword", "test");
                if(conn.State == ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT password FROM users WHERE username=@val1 AND password =@val2", conn);
                    cmd.Parameters.AddWithValue("@val1", userInput.Text);
                    cmd.Parameters.AddWithValue("@val2", passwordInput.Text);
                    cmd.Prepare();
                    MySqlDataReader res = cmd.ExecuteReader();
                    if (res.Read())
                    {
                        if(userInput.Text == "admin")
                        {
                            Form2 admin = new Form2();
                            admin.Show();
                            this.Hide();
                        }
                        else
                        {
                            Form3 user = new Form3();
                            user.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login attempt failed.");
                    }
                }
            }
        }

        private void password_Click(object sender, EventArgs e)
        {

        }
    }
}
