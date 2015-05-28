using MySql.Data.MySqlClient;
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
    public partial class Form_List_Users : Form
    {
        DatabaseConnection c = new DatabaseConnection();

        public Form_List_Users()
        {
            InitializeComponent();
        }

        private void Form_List_Users_Load(object sender, EventArgs e)
        {
            getData();
        }

        //ALL CLIENTS
        public DataSet getData() {
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter a = new MySqlDataAdapter();
                string stm = ("SELECT * FROM `clients`");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());

                a.SelectCommand = cmd;
                a.Fill(ds);
                a.Dispose();
                cmd.Dispose();
                c.closeConnection();

                listBox1.DataSource = ds.Tables[0];
                listBox1.ValueMember = "client_id";
                listBox1.DisplayMember = "forename";

                listBox2.DataSource = ds.Tables[0];
                listBox2.ValueMember = "client_id";
                listBox2.DisplayMember = "client_id";

                listBox3.DataSource = ds.Tables[0];
                listBox3.ValueMember = "client_id";
                listBox3.DisplayMember = "surname";

                listBox4.Visible = false;
                label4.Visible = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            return ds;
        }

        //CLIENTS WITHOUT PLANS
        private void getClientsWithNoPlan() {

            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter a = new MySqlDataAdapter();
                string stm = ("SELECT client_id,forename,surname FROM clients WHERE plan_id IS NULL");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());

                a.SelectCommand = cmd;
                a.Fill(ds);
                a.Dispose();
                cmd.Dispose();
                c.closeConnection();

                listBox1.DataSource = ds.Tables[0];
                listBox1.ValueMember = "client_id";
                listBox1.DisplayMember = "forename";

                listBox2.DataSource = ds.Tables[0];
                listBox2.ValueMember = "client_id";
                listBox2.DisplayMember = "client_id";

                listBox3.DataSource = ds.Tables[0];
                listBox3.ValueMember = "client_id";
                listBox3.DisplayMember = "surname";

                listBox4.Visible = false;
                label4.Visible = false;
                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        
        }

        //CLIENTS WITH PLANS
        private void getClientsPlans() {

            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter a = new MySqlDataAdapter();
                string stm = ("SELECT plans.plan_name,clients.client_id,clients.forename,clients.surname FROM plans INNER JOIN clients ON plans.plan_id=clients.plan_id");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());

                a.SelectCommand = cmd;
                a.Fill(ds);
                a.Dispose();
                cmd.Dispose();
                c.closeConnection();

                listBox1.DataSource = ds.Tables[0];
                listBox1.ValueMember = "client_id";
                listBox1.DisplayMember = "forename";

                listBox2.DataSource = ds.Tables[0];
                listBox2.ValueMember = "client_id";
                listBox2.DisplayMember = "client_id";

                listBox3.DataSource = ds.Tables[0];
                listBox3.ValueMember = "client_id";
                listBox3.DisplayMember = "surname";

                listBox4.DataSource = ds.Tables[0];
                listBox4.ValueMember = "client_id";
                listBox4.DisplayMember = "plan_name";

                listBox4.Visible = true;
                label4.Visible = true;


            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // getData();
        }

        private void Form_List_Users_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            determineList();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            determineList();
        }


        private String determineList() {
            String listtype="all";
            if (checkBox1.Checked == true) {
                checkBox2.Checked = false;
                listtype = "without";
                this.Width = 310;
                getClientsWithNoPlan();
                
            }
            else if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                listtype = "with";
                this.Width = this.Width + (listBox4.Width + 10);
                getClientsPlans();
                
            }
            else {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                listtype = "all";
                this.Width = 310;
                getData();
                
            }

            return listtype;
        }




        private void button1_Click(object sender, EventArgs e)
        {
            removeSelected();
        }


        private void removeSelected() {

            string selected = listBox1.SelectedValue.ToString();
            var confirm = MessageBox.Show("Are You Sure You Wish To Delete User, ID: "+selected,"Confirm Deletion", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {

                try
                {
                    c.connect();
                    string stm = ("DELETE FROM `clients` WHERE `clients`.`client_id` = "+selected);
                    MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Client Removed!", "Client Removed");
                    c.closeConnection();
                    determineList();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }

            }
            else { }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            client_profile profile = new client_profile();
            int clientid = Convert.ToInt32(listBox1.SelectedValue.ToString());
            profile.OpenMe(clientid);
        }


    }//BASE
}
