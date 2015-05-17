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
    public partial class Assign_Plan : Form
    {

        private DataSet users = new DataSet();
        private DataSet plans = new DataSet();
        private DataSet workouts = new DataSet();

        List_Plans lp = new List_Plans();
        Form_List_Users lu = new Form_List_Users();
        ListWorkouts lw = new ListWorkouts();

        private string clientid { get; set; }

        public Assign_Plan()
        {
            InitializeComponent();
        }

        private void Assign_Plan_Load(object sender, EventArgs e)
        {
            getData();
        }

        public void assignOpenInherit(int clientid) {
            this.Show();
            comboBox1.SelectedValue=clientid;
        }

        private void getData() {

            users = lu.getData();
            plans = lp.getData();
            workouts = lw.getWorkouts();
            

            try
            {
               comboBox1.DataSource = users.Tables[0];
               comboBox1.ValueMember = "client_id";
               comboBox1.DisplayMember = "client_id";

                comboBox2.DataSource = plans.Tables[0];
                comboBox2.ValueMember = "plan_id";
                comboBox2.DisplayMember = "plan_name";

                comboBox3.DataSource = workouts.Tables[0];
                comboBox3.ValueMember = "workout_id";
                comboBox3.DisplayMember = "name";
            }
            catch (Exception exc) {
                MessageBox.Show(exc.ToString());
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Search_Client s = new Search_Client();
            s.Show();
        }

        private void assignPlan() {
            try
            {
                DatabaseConnection c = new DatabaseConnection();
                c.connect();
                string stm = ("UPDATE  `fitdb`.`clients` SET  `plan_id` =  '" + comboBox2.SelectedValue.ToString() + "' WHERE  `clients`.`client_id` =" + comboBox1.SelectedValue.ToString() + ";");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                cmd.ExecuteNonQuery();
                c.closeConnection();
                MessageBox.Show("Diet Plan Assigned!", "Plan Assigned");
            }
            catch (Exception exc) {
                MessageBox.Show(exc.ToString());
            }
        }


        private void assignWorkout()
        {
            try
            {
                DatabaseConnection c = new DatabaseConnection();
                c.connect();
                string stm = ("UPDATE  `fitdb`.`clients` SET  `workout_id` =  '" + comboBox3.SelectedValue.ToString() + "' WHERE  `clients`.`client_id` =" + comboBox1.SelectedValue.ToString() + ";");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                cmd.ExecuteNonQuery();
                c.closeConnection();
                MessageBox.Show("Workout Assigned!", "Workout Assigned");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void assignBoth() {

            assignWorkout();
            assignPlan();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            assignPlan();          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            assignWorkout();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            assignBoth();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
