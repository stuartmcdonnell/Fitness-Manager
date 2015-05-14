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
    public partial class Show_Plan_Content : Form
    {

        public Show_Plan_Content()
        {
            InitializeComponent();
        }

        private void Show_Plan_Content_Load(object sender, EventArgs e)
        {
            ListPlans lp = new ListPlans();
            DataSet planlist = new DataSet();
            planlist = lp.getPlans();
            comboBox1.DataSource = planlist.Tables[0];
            comboBox1.ValueMember = "plan_id";
            comboBox1.DisplayMember = "plan_name";
        }


        public DataSet getData()
        {
            listBox1.Visible = false;
            listBox2.Visible = false;

            DatabaseConnection c = new DatabaseConnection();
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter a = new MySqlDataAdapter();
                string stm = ("SELECT foods.name,plan_foods.time FROM plan_foods INNER JOIN foods ON plan_foods.food_id=foods.food_id WHERE plan_id="+comboBox1.SelectedValue.ToString()+"");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());

                a.SelectCommand = cmd;
                a.Fill(ds);
                a.Dispose();
                cmd.Dispose();
                c.closeConnection();

                listBox1.DataSource = ds.Tables[0];
                listBox1.ValueMember = "name";
                listBox1.DisplayMember = "name";

                listBox2.DataSource = ds.Tables[0];
                listBox2.ValueMember = "name";
                listBox2.DisplayMember = "time";


            }
            catch (Exception exc)
            {
            }

            listBox1.Visible = true;
            listBox2.Visible = true;

            return ds;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Show_Plan_Content_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //GET CALORIES
        public int getTotalCalories() {

            DatabaseConnection c = new DatabaseConnection();
            DataSet ds = new DataSet();
            int totalCalories = 0;
            try
            {
                MySqlDataAdapter a = new MySqlDataAdapter();
                string stm = ("SELECT foods.food_id,foods.calories FROM foods INNER JOIN plan_foods ON foods.food_id=plan_foods.food_id WHERE plan_id=" + comboBox1.SelectedValue.ToString() + "");
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
                string stm = ("SELECT foods.food_id,foods.protein FROM foods INNER JOIN plan_foods ON foods.food_id=plan_foods.food_id WHERE plan_id=" + comboBox1.SelectedValue.ToString() + "");
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
                string stm = ("SELECT foods.food_id,foods.carbs FROM foods INNER JOIN plan_foods ON foods.food_id=plan_foods.food_id WHERE plan_id=" + comboBox1.SelectedValue.ToString() + "");
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
                string stm = ("SELECT foods.food_id,foods.fat FROM foods INNER JOIN plan_foods ON foods.food_id=plan_foods.food_id WHERE plan_id=" + comboBox1.SelectedValue.ToString() + "");
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


        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            getData();
            calories_label.Text = getTotalCalories().ToString();
            proteinlabel.Text = getTotalProtein().ToString();
            carbstotal.Text = getTotalCarbs().ToString();
            fattotal.Text = getTotalFat().ToString();
            Cursor.Current = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string path = getPath();
            if (path == "null" || path == "invalid")
            {
                Console.WriteLine("Path Selection Terminated by user");
            }
            else
            {
                generatePDF gpdf = new generatePDF();
                gpdf.ExportToPdf(this.getData().Tables[0], path);
            }
            Cursor.Current = Cursors.Default;
        }

        private string getPath()
        {
            string path = "null";
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath.ToString();
            }
            else
            {
                path = "invalid";
            }
            return path;
        }

    }
}
