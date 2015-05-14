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
    public partial class Search_Plan : Form
    {

        DatabaseConnection c = new DatabaseConnection();

        public Search_Plan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchPlan();
            this.Dispose();
        }

        private void Search_Plan_Load(object sender, EventArgs e)
        {

        }

        private void searchPlan() {

            try
            {
                Search_Results_Client sr = new Search_Results_Client();
                c.connect();
                string stm = ("SELECT `plan_name` FROM `plans` WHERE `plan_id` = "+planid_textbox.Text+"");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());

                String planString = Convert.ToString(cmd.ExecuteScalar());
                MessageBox.Show(planString, "Plan Name for ID: "+planid_textbox.Text);
                c.closeConnection();

            }
            catch (Exception exc)
            {
                MessageBox.Show("Search Returned No Results!", "Error");
                MessageBox.Show(exc.ToString());
                c.closeConnection();
            }
        }

        private void Search_Plan_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            planid_textbox.Clear();
        }


    }
}
