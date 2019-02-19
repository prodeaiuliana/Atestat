using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mysqllogin
{
    public partial class Form2 : Form
    {
        private Form1 mainForm;
        public Form2(Form1 f1)
        {
            InitializeComponent();
            mainForm = f1;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Show();
        }
    }
}
