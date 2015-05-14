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
    public partial class Search_Results_Client : Form
    {

        private DataSet ds = new DataSet();

        public Search_Results_Client()
        {
            InitializeComponent();
        }

        private void Search_Results_Load(object sender, EventArgs e)
        {

        }


        public void displayResults(DataSet dataIn){

            this.ds = dataIn;

            this.Show();
            listbox_clientID.DataSource = ds.Tables[0];
            listbox_clientID.ValueMember = "client_id";
            listbox_clientID.DisplayMember = "client_id";

            listbox_forename.DataSource = ds.Tables[0];
            listbox_forename.ValueMember = "client_id";
            listbox_forename.DisplayMember = "forename";

            listbox_surname.DataSource = ds.Tables[0];
            listbox_surname.ValueMember = "client_id";
            listbox_surname.DisplayMember = "surname";

            listbox_plan.DataSource = ds.Tables[0];
            listbox_plan.ValueMember = "client_id";
            listbox_plan.DisplayMember = "plan_id";

            listbox_planname.DataSource = ds.Tables[0];
            listbox_planname.ValueMember = "client_id";
            listbox_planname.DisplayMember = "plan_name";

            listBox1.DataSource = ds.Tables[0];
            listBox1.ValueMember = "client_id";
            listBox1.DisplayMember = "workout_id";

            listBox2.DataSource = ds.Tables[0];
            listBox2.ValueMember = "client_id";
            listBox2.DisplayMember = "name";

        }


        private void button1_Click(object sender, EventArgs e)
        {
            ds.Clear();
            this.Dispose();
        }

        private void Search_Results_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Dispose();
        }

    }
}
