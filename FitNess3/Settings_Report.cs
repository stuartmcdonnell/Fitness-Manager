using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitNess3
{
    public partial class Settings_Report : Form
    {
        public Settings_Report()
        {
            InitializeComponent();
        }

        private void Settings_Report_Load(object sender, EventArgs e)
        {

            DatabaseConnection c = new DatabaseConnection();
            c.connect();
            c.closeConnection();

            label4.Text = c.host;
            label5.Text = c.database;
            label6.Text = c.userid;

        }
    }
}
