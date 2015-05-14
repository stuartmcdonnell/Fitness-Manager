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
    public partial class Workout_Add : Form
    {
        public Workout_Add()
        {
            InitializeComponent();
        }

        private void Workout_Add_Load(object sender, EventArgs e)
        {
            getExc();
            getWorkouts();
            getWorkoutExc();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addWorkout();
            getWorkouts();
            textBox1.Clear();
        }


        private void getExc()
        {
            ListExc lexc = new ListExc();
            DataSet exc = new DataSet();
            exc = lexc.getExc();

            comboBox1.DataSource = exc.Tables[0];
            comboBox1.ValueMember = "exercise_id";
            comboBox1.DisplayMember = "name";

        }

        private void getWorkouts()
        {

            ListWorkouts lw = new ListWorkouts();
            DataSet workouts = new DataSet();
            workouts = lw.getWorkouts();

            comboBox2.DataSource = workouts.Tables[0];
            comboBox2.ValueMember = "workout_id";
            comboBox2.DisplayMember = "name";
        }


        private void addWorkout()
        {
            try
            {
                DatabaseConnection c = new DatabaseConnection();
                c.connect();
                string stm = ("INSERT INTO `fitdb`.`workouts` (`name`) VALUES ('" + textBox1.Text + "');");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Workout Added!");
                c.closeConnection();
                getWorkouts();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }


        private void getWorkoutExc()
        {
            DatabaseConnection c = new DatabaseConnection();
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter a = new MySqlDataAdapter();
                string stm = ("SELECT workout_exc_id,exercises.name,exercises.description,workouts_exc.notes FROM workouts_exc INNER JOIN exercises ON workouts_exc.exercise_id=exercises.exercise_id WHERE workout_id =" + comboBox2.SelectedValue.ToString() + "");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());

                a.SelectCommand = cmd;
                a.Fill(ds);
                a.Dispose();
                cmd.Dispose();
                c.closeConnection();

                listBox1.DataSource = ds.Tables[0];
                listBox1.ValueMember = "workout_exc_id";
                listBox1.DisplayMember = "name";

                listBox2.DataSource = ds.Tables[0];
                listBox2.ValueMember = "workout_exc_id";
                listBox2.DisplayMember = "description";

                listBox3.DataSource = ds.Tables[0];
                listBox3.ValueMember = "workout_exc_id";
                listBox3.DisplayMember = "notes";


            }
            catch (Exception exc)
            {
                // MessageBox.Show("Invalid Plan!");
                // MessageBox.Show(exc.ToString());
            }

        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getWorkoutExc();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addExercise();
            getWorkoutExc();
            richTextBox1.Clear();
        }

        private void addExercise()
        {

            DatabaseConnection c = new DatabaseConnection();
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter a = new MySqlDataAdapter();
                string stm = ("INSERT INTO `fitdb`.`workouts_exc` (`workout_id`, `exercise_id`, `notes`) VALUES ('"+comboBox2.SelectedValue.ToString()+"', '"+comboBox1.SelectedValue.ToString()+"', '"+richTextBox1.Text+"');");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());

                a.SelectCommand = cmd;
                a.Fill(ds);
                a.Dispose();
                cmd.Dispose();
                c.closeConnection();


            }
            catch (Exception exc)
            {
                // MessageBox.Show("Invalid Plan!");
                // MessageBox.Show(exc.ToString());
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selected = listBox2.SelectedValue.ToString();
            var confirm = MessageBox.Show("Are You Sure You Wish To Delete Exercise, ID: " + selected, "Confirm Deletion", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {

                try
                {
                    DatabaseConnection c = new DatabaseConnection();
                    c.connect();
                    string stm = ("DELETE FROM `fitdb`.`workouts_exc` WHERE `workouts_exc`.`workout_exc_id` = " + selected);
                    MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Exercise Removed!", "Exercise Removed");
                    c.closeConnection();
                    getWorkoutExc();

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }

            }
            else { }
        }


        private void removeExervise() { 
        
        
        

        
        }



    }//BASE
}
