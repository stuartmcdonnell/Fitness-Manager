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
    public partial class Add_Diet_Plan : Form
    {
        public Add_Diet_Plan()
        {
            InitializeComponent();
            getFoods();
            getPlans();
            comboBox2.SelectedIndex = -1;
        }

        private void Add_Diet_Plan_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void addPlan() {
            try
            {
                DatabaseConnection c = new DatabaseConnection();
                c.connect();
                string stm = ("INSERT INTO `fitdb`.`plans` (`plan_name`) VALUES ('" + textBox1.Text + "');");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Plan Added!");
                c.closeConnection();
                getPlans();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void addFoods() {

            DatabaseConnection c = new DatabaseConnection();
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter a = new MySqlDataAdapter();
                string stm = ("INSERT INTO `fitdb`.`plan_foods` (`plan_id`, `food_id`, `time`, `notes`) VALUES ('" + comboBox2.SelectedValue.ToString() + "', '" + comboBox1.SelectedValue.ToString() + "', '" + dateTimePicker1.Value.ToLongTimeString() + "', '"+richTextBox1.Text+"');");
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

        private void getFoods() {
            ListFoods lf = new ListFoods();
            DataSet foods = new DataSet();
            foods = lf.getFoods();

            comboBox1.DataSource = foods.Tables[0];
            comboBox1.ValueMember = "food_id";
            comboBox1.DisplayMember = "name";

        }

        private void getPlans() {

            List_Plans lp = new List_Plans();
            DataSet plans = new DataSet();
            plans = lp.getData();

            comboBox2.DataSource = plans.Tables[0];
            comboBox2.ValueMember = "plan_id";
            comboBox2.DisplayMember = "plan_name";
        }

        private void getPlanFoods() {
            DatabaseConnection c = new DatabaseConnection();
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter a = new MySqlDataAdapter();
                string stm = ("SELECT plan_foods.plan_food_id,foods.name,plan_foods.time,plan_foods.notes FROM plan_foods INNER JOIN foods ON plan_foods.food_id=foods.food_id WHERE plan_id=" + comboBox2.SelectedValue.ToString() + "");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());

                a.SelectCommand = cmd;
                a.Fill(ds);
                a.Dispose();
                cmd.Dispose();
                c.closeConnection();

                listBox1.DataSource = ds.Tables[0];
                listBox1.ValueMember = "plan_food_id";
                listBox1.DisplayMember = "name";

                listBox2.DataSource = ds.Tables[0];
                listBox2.ValueMember = "plan_food_id";
                listBox2.DisplayMember = "time";

                listBox3.DataSource = ds.Tables[0];
                listBox3.ValueMember = "plan_food_id";
                listBox3.DisplayMember = "notes";

            }
            catch (Exception exc)
            {
               // MessageBox.Show("Invalid Plan!");
               // MessageBox.Show(exc.ToString());
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            addPlan();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            addFoods();
            getPlanFoods();
            setTotals();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker1.Value.ToLongTimeString());
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex >= 0)
            {
                //MessageBox.Show(comboBox2.SelectedIndex.ToString());
                Cursor.Current = Cursors.WaitCursor;
                getPlanFoods();
                setTotals();
                Cursor.Current = Cursors.Default;
            }
        }


        //GET PLAN CONTENTS

        //GET CALORIES
        public int getTotalCalories()
        {

            DatabaseConnection c = new DatabaseConnection();
            DataSet ds = new DataSet();
            int totalCalories = 0;
            try
            {
                MySqlDataAdapter a = new MySqlDataAdapter();
                string stm = ("SELECT foods.food_id,foods.calories FROM foods INNER JOIN plan_foods ON foods.food_id=plan_foods.food_id WHERE plan_id=" + comboBox2.SelectedValue.ToString() + "");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());

                a.SelectCommand = cmd;
                a.Fill(ds);
                a.Dispose();
                cmd.Dispose();
                c.closeConnection();

                DataTable table;
                table = ds.Tables[0];

                object sumObject;
                sumObject = table.Compute("Sum(calories)", "");
                totalCalories = Int32.Parse(sumObject.ToString());

            }
            catch (Exception exc)
            {
            }
            return totalCalories;
        }

        //GET PROTEIN
        public int getTotalProtein()
        {

            DatabaseConnection c = new DatabaseConnection();
            DataSet ds = new DataSet();
            int totalProtein = 0;
            try
            {
                MySqlDataAdapter a = new MySqlDataAdapter();
                string stm = ("SELECT foods.food_id,foods.protein FROM foods INNER JOIN plan_foods ON foods.food_id=plan_foods.food_id WHERE plan_id=" + comboBox2.SelectedValue.ToString() + "");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());

                a.SelectCommand = cmd;
                a.Fill(ds);
                a.Dispose();
                cmd.Dispose();
                c.closeConnection();

                DataTable table;
                table = ds.Tables[0];

                object sumObject;
                sumObject = table.Compute("Sum(protein)", "");
                totalProtein = Int32.Parse(sumObject.ToString());

            }
            catch (Exception exc)
            {
            }
            return totalProtein;
        }

        //GET carbs
        public int getTotalCarbs()
        {

            DatabaseConnection c = new DatabaseConnection();
            DataSet ds = new DataSet();
            int totalCarbs = 0;
            try
            {
                MySqlDataAdapter a = new MySqlDataAdapter();
                string stm = ("SELECT foods.food_id,foods.carbs FROM foods INNER JOIN plan_foods ON foods.food_id=plan_foods.food_id WHERE plan_id=" + comboBox2.SelectedValue.ToString() + "");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());

                a.SelectCommand = cmd;
                a.Fill(ds);
                a.Dispose();
                cmd.Dispose();
                c.closeConnection();

                DataTable table;
                table = ds.Tables[0];

                object sumObject;
                sumObject = table.Compute("Sum(carbs)", "");
                totalCarbs = Int32.Parse(sumObject.ToString());

            }
            catch (Exception exc)
            {
            }
            return totalCarbs;
        }

        //GET fat
        public int getTotalFat()
        {

            DatabaseConnection c = new DatabaseConnection();
            DataSet ds = new DataSet();
            int totalFat = 0;
            try
            {
                MySqlDataAdapter a = new MySqlDataAdapter();
                string stm = ("SELECT foods.food_id,foods.fat FROM foods INNER JOIN plan_foods ON foods.food_id=plan_foods.food_id WHERE plan_id=" + comboBox2.SelectedValue.ToString() + "");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());

                a.SelectCommand = cmd;
                a.Fill(ds);
                a.Dispose();
                cmd.Dispose();
                c.closeConnection();

                DataTable table;
                table = ds.Tables[0];

                object sumObject;
                sumObject = table.Compute("Sum(fat)", "");
                totalFat = Int32.Parse(sumObject.ToString());

            }
            catch (Exception exc)
            {
            }
            return totalFat;
        }


        public void setTotals() {

            carbtotal.Text = getTotalCarbs().ToString();
            prototal.Text = getTotalProtein().ToString();
            fattotal.Text = getTotalFat().ToString();
            caltotal.Text = getTotalCalories().ToString();

        }

        private void removeFood() {

            string selected = listBox2.SelectedValue.ToString();
            var confirm = MessageBox.Show("Are You Sure You Wish To Delete Food, ID: " + selected, "Confirm Deletion", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {

                try
                {
                    DatabaseConnection c = new DatabaseConnection();
                    c.connect();
                    string stm = ("DELETE FROM `fitdb`.`plan_foods` WHERE `plan_foods`.`plan_food_id` =" + selected);
                    MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Food Removed!", "Food Removed");
                    c.closeConnection();
                    getPlanFoods();
                    setTotals();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }

            }
            else { }
            

        
        }


        private void button1_Click_2(object sender, EventArgs e)
        {
            removeFood();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                this.Width = 660;
            }
            else {
                this.Width = 380;
            }
        }

    }//BASE
}
