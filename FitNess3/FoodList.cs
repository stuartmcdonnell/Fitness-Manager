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
    public partial class FoodList : Form
    {
        public FoodList()
        {
            InitializeComponent();
        }

        private void FoodList_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            removeFood();
        }


        private void getData() {

            DataSet ds = new DataSet();
            ListFoods lf = new ListFoods();
            ds = lf.getFoods();
            try
            {

                listBox1.DataSource = ds.Tables[0];
                listBox1.ValueMember = "food_id";
                listBox1.DisplayMember = "food_id";

                listBox2.DataSource = ds.Tables[0];
                listBox2.ValueMember = "food_id";
                listBox2.DisplayMember = "name";

                listBox3.DataSource = ds.Tables[0];
                listBox3.ValueMember = "food_id";
                listBox3.DisplayMember = "calories";

                listBox4.DataSource = ds.Tables[0];
                listBox4.ValueMember = "food_id";
                listBox4.DisplayMember = "protein";

                listBox5.DataSource = ds.Tables[0];
                listBox5.ValueMember = "food_id";
                listBox5.DisplayMember = "carbs";

                listBox6.DataSource = ds.Tables[0];
                listBox6.ValueMember = "food_id";
                listBox6.DisplayMember = "fat";

            }
            catch (Exception exc)
            {
                //MessageBox.Show(exc.ToString());
            }
        
        }

        private void removeFood() {

            string selected = listBox1.SelectedValue.ToString();
            var confirm = MessageBox.Show("Are You Sure You Wish To Delete Food, ID: " + selected, "Confirm Deletion", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {

                try
                {
                    DatabaseConnection c = new DatabaseConnection();
                    c.connect();
                    string stm = ("DELETE FROM `foods` WHERE `foods`.`food_id` = " + selected);
                    MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Food Removed!", "Food Removed");
                    c.closeConnection();
                    getData();
                }
                catch (Exception exc)
                {
                    //MessageBox.Show(exc.ToString());
                }

            }
            else
            {}
        }

    }
}
