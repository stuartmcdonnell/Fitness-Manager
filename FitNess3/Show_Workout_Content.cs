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
    public partial class Show_Workout_Content : Form
    {
        public Show_Workout_Content()
        {
            InitializeComponent();
        }

        private void Show_Workout_Content_Load(object sender, EventArgs e)
        {
            ListWorkouts lw = new ListWorkouts();
            DataSet workoutlist = new DataSet();
            workoutlist = lw.getWorkouts();
            comboBox1.DataSource = workoutlist.Tables[0];
            comboBox1.ValueMember = "workout_id";
            comboBox1.DisplayMember = "name";
        }


        private DataSet getData() {

            listBox1.Visible = false;
            listBox2.Visible = false;
            listBox3.Visible = false;

            DatabaseConnection c = new DatabaseConnection();
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter a = new MySqlDataAdapter();
                string stm = ("SELECT * FROM workouts_exc INNER JOIN exercises ON workouts_exc.exercise_id=exercises.exercise_id WHERE workout_id=" + comboBox1.SelectedValue.ToString() + "");
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
            }

            listBox1.Visible = true;
            listBox2.Visible = true;
            listBox3.Visible = true;


            return ds;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getData();
        }

        private string getPath(){
            string path = "null";
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath.ToString();
            }
            else {
                path = "invalid";
            }
            return path;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            string path = getPath();
            if (path == "null" || path == "invalid")
            {
                Console.WriteLine("Path Selection Terminated by user");
            }
            else {
                generateWorkoutPDF gpdf = new generateWorkoutPDF();
                gpdf.ExportToPdf(this.getData().Tables[0], path);
            }
            Cursor.Current = Cursors.Default;
        }

    }//BASE
}
