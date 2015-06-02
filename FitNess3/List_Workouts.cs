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
    public partial class List_Workouts : Form
    {
        public List_Workouts()
        {
            InitializeComponent();
        }

        private void List_Workouts_Load(object sender, EventArgs e)
        {
            getData();
        }

        public DataSet getData()
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter a = new MySqlDataAdapter();
                DatabaseConnection c = new DatabaseConnection();
                string stm = ("SELECT `workout_id`, `name` FROM `workouts`");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());

                a.SelectCommand = cmd;
                a.Fill(ds);
                a.Dispose();
                cmd.Dispose();
                c.closeConnection();

                listBox1.DataSource = ds.Tables[0];
                listBox1.ValueMember = "workout_id";
                listBox1.DisplayMember = "workout_id";

                listBox2.DataSource = ds.Tables[0];
                listBox2.ValueMember = "workout_id";
                listBox2.DisplayMember = "name";


            }
            catch (Exception exc)
            {
                //MessageBox.Show(exc.ToString());
            }
            return ds;
        }


        private void removeWorkout()
        {

            string selected = listBox1.SelectedValue.ToString();
            var confirm = MessageBox.Show("Are You Sure You Wish To Delete Workout, ID: " + selected, "Confirm Deletion", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {

                try
                {
                    DatabaseConnection c = new DatabaseConnection();
                    c.connect();
                    string stm = ("DELETE FROM `workouts` WHERE `workouts`.`workout_id` = " + selected);
                    MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Workout Removed!", "Workout Removed");
                    c.closeConnection();
                    getData();
                }
                catch (Exception exc)
                {
                    //MessageBox.Show(exc.ToString());
                }

            }
            else { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            removeWorkout();
        }


    }//BASE
}
