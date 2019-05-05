using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mysqllogin
{
    public partial class Form2 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private Form1 mainForm;
        public Form2(Form1 f1)
        {
            InitializeComponent();
            getGrid();
            mainForm = f1;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Show();
        }

        private async void getGrid()
        {
            string res = await client.GetStringAsync("http://localhost:3000/users");
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(res);
            dataGridView1.DataSource = dt;
        }

    }
}
