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
    public partial class List_Plans : Form
    {
        DatabaseConnection c = new DatabaseConnection();

        public List_Plans()
        {
            InitializeComponent();
        }

        private void List_Plans_Load(object sender, EventArgs e)
        {
            getData();
        }

        public DataSet getData()
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter a = new MySqlDataAdapter();

                string stm = ("SELECT `plan_id`, `plan_name` FROM `plans`");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());

                a.SelectCommand = cmd;
                a.Fill(ds);
                a.Dispose();
                cmd.Dispose();
                c.closeConnection();
               
                listBox1.DataSource = ds.Tables[0];
                listBox1.ValueMember = "plan_id";
                listBox1.DisplayMember = "plan_id";

                listBox2.DataSource = ds.Tables[0];
                listBox2.ValueMember = "plan_id";
                listBox2.DisplayMember = "plan_name";


            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            return ds;
        }

        private void List_Plans_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            removePlan();
        }


        private void removePlan()
        {

            string selected = listBox1.SelectedValue.ToString();
            var confirm = MessageBox.Show("Are You Sure You Wish To Delete Plan, ID: " + selected, "Confirm Deletion", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {

                try
                {
                    DatabaseConnection c = new DatabaseConnection();
                    c.connect();
                    string stm = ("DELETE FROM `fitdb`.`plans` WHERE `plans`.`plan_id` = " + selected);
                    MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Plan Removed!", "Plan Removed");
                    c.closeConnection();
                    getData();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }

            }
            else{ }
        }

    }//BASE
}
