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

        private void button2_Click(object sender, EventArgs e)
        {
            Assign_Plan ap = new Assign_Plan();
            ap.assignOpenInherit(Int32.Parse(listBox1.SelectedValue.ToString()));
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Show_Plan_Content sp = new Show_Plan_Content();
            //string planid = "7";
            string planid = listbox_plan.GetItemText(listbox_plan.SelectedItem);
            if (planid != "")
            {
                sp.showInherit(planid);
            }
            else
            {
                MessageBox.Show("Client Does Not Have A Diet Plan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Show_Workout_Content sw = new Show_Workout_Content();
            //string planid = "7";
            string workoutid = listBox1.GetItemText(listBox1.SelectedItem);
            if (workoutid != "")
            {
                sw.showInherit(workoutid);
            }
            else {
                MessageBox.Show("Client Does Not Have A Workout Plan!", "Error",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            client_profile profile = new client_profile();
            int clientid = Convert.ToInt32(listbox_clientID.GetItemText(listbox_clientID.SelectedItem).ToString());
            profile.OpenMe(clientid);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Client_Edit editclient = new Client_Edit();
            string clientid = listbox_clientID.GetItemText(listbox_clientID.SelectedItem).ToString();
            editclient.openMe(clientid);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string clientid = listbox_clientID.GetItemText(listbox_clientID.SelectedItem).ToString();
            Client_Progress progress = new Client_Progress(clientid);
            progress.Show();
        }

    }
}
