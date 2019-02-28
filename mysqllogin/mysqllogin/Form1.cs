using System;
using System.Data;
using System.Windows.Forms;
using System.Net.Http;
using MySql.Data.MySqlClient;

namespace mysqllogin
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }
        private async void login_Click(object sender, EventArgs e)
        {
            if(userInput.Text == "" || passwordInput.Text == "")
            {
                MessageBox.Show("Please, insert credentials.");
            }
            else
            {
                try
                {
                    string res = await client.GetStringAsync("http://localhost:3000/login?name=" + userInput.Text + "&password=" + passwordInput.Text);
                    if (Int32.Parse(res) >= 0)
                    {
                        if (res == "1")
                        {
                            Form2 admin = new Form2(this);
                            admin.Show();
                            this.Hide();
                        }
                        else
                        {
                            Form3 user = new Form3(this);
                            user.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login attempt failed.");
                    }
                }
                catch
                {
                    MessageBox.Show("Server is down.");
                }
            }
        }

        private void password_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
