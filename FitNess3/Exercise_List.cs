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
    public partial class Exercise_List : Form
    {
        public Exercise_List()
        {
            InitializeComponent();
        }

        private void Exercise_List_Load(object sender, EventArgs e)
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

                string stm = ("SELECT * FROM `exercises`");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());

                a.SelectCommand = cmd;
                a.Fill(ds);
                a.Dispose();
                cmd.Dispose();
                c.closeConnection();

                listBox1.DataSource = ds.Tables[0];
                listBox1.ValueMember = "exercise_id";
                listBox1.DisplayMember = "name";

                listBox2.DataSource = ds.Tables[0];
                listBox2.ValueMember = "exercise_id";
                listBox2.DisplayMember = "description";


            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            return ds;
        }



        private void removeExercise()
        {

            string selected = listBox1.SelectedValue.ToString();
            var confirm = MessageBox.Show("Are You Sure You Wish To Delete Exercise, ID: " + selected, "Confirm Deletion", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {

                try
                {
                    DatabaseConnection c = new DatabaseConnection();
                    c.connect();
                    string stm = ("DELETE FROM `fitdb`.`exercises` WHERE `exercises`.`exercise_id` = " + selected);
                    MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Exercise Removed!", "Exercise Removed");
                    c.closeConnection();
                    getData();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }

            }
            else { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            removeExercise();
        }


    }//BASE
}
