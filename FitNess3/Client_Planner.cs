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
    public partial class Client_Planner : Form
    {


        string Date_Selected { get; set; }
        int client_id { get; set; }
        string[] dates { get; set; }
        public Client_Planner(int clientid)
        {
            this.client_id = clientid;
            InitializeComponent();
        }


        private void getNotesTime() {

            DatabaseConnection c = new DatabaseConnection();

            try
            {
                c.connect();
                string stm = ("SELECT `booking_notes`,`booking_time` FROM `bookings` WHERE `booking_date` = "+"'"+radCalendar1.SelectedDate.ToShortDateString()+"'"+" AND `client_id` = "+this.client_id);
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                MySqlDataReader reader = cmd.ExecuteReader();

                
                while (reader.Read())
                {

                    string time = reader["booking_time"].ToString();
                    //label1.Text = ("Session Time: " + time);

                    DateTime conv = DateTime.ParseExact(time, "HH:mm:ff", null);
                    dateTimePicker1.Value = conv;

                    

                    richTextBox1.Text = reader["booking_notes"].ToString();
                    

                }

                reader.Dispose();
                c.closeConnection();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
                c.closeConnection();
            }
        
        }

        private void removeSession() {


            DatabaseConnection c = new DatabaseConnection();

            try
            {
                c.connect();

                string stm = "DELETE FROM `bookings` WHERE `bookings`.`booking_date` = '"+radCalendar1.SelectedDate.ToShortDateString()+"'";
                Console.WriteLine(stm);
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                cmd.ExecuteNonQuery();
                c.closeConnection();

                getBookingsForClient();
                
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.ToString());

            }
        
        
        
        }

        private void addSession() {

            DatabaseConnection c = new DatabaseConnection();

            try
            {
                c.connect();

                string stm = "INSERT INTO `bookings` (`client_id`, `booking_date`, `booking_notes`, `booking_time`) VALUES ('" + this.client_id.ToString() + "', '" + radCalendar1.SelectedDate.ToShortDateString() + "', '" + richTextBox1.Text + "', '" + dateTimePicker1.Value.ToShortTimeString() + "')";
                Console.WriteLine(stm);
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                cmd.ExecuteNonQuery();
                c.closeConnection();

                getBookingsForClient();
               
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.ToString());

            }
        
        
        
        }


        private void updateSession() {

            DatabaseConnection c = new DatabaseConnection();
           
            try
            {
                c.connect();
                
                string stm = "UPDATE bookings SET `booking_time` = "+"'"+dateTimePicker1.Value.ToShortTimeString()+"'"+" ,`booking_notes` = "+"'"+richTextBox1.Text+"'"+" WHERE `booking_date` =  "+"'"+radCalendar1.SelectedDate.ToShortDateString()+"'"+"AND client_id="+client_id.ToString();
                Console.WriteLine(stm);
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                cmd.ExecuteNonQuery();
                c.closeConnection();

            }
            catch (Exception exc) {

                MessageBox.Show(exc.ToString());

            }
        
        
        
        }

        private DataSet getBookingsForClient()
        {

            DataSet searchSet = new DataSet();
            DatabaseConnection c = new DatabaseConnection();

            radCalendar1.SpecialDays.Clear();

            try
            {
                Search_Results_Client sr = new Search_Results_Client();
                c.connect();
                string stm = ("SELECT * FROM `bookings` WHERE `client_id` = "+client_id.ToString()+"");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                MySqlDataAdapter a = new MySqlDataAdapter();

                a.SelectCommand = cmd;
                a.Fill(searchSet);
                a.Dispose();

                c.closeConnection();

                radCalendar1.SelectedDates.Clear();

                int columindex = 2;
                dates = new string[searchSet.Tables[0].Rows.Count];

                for (int index = 0; index < searchSet.Tables[0].Rows.Count; index++){
                    dates[index] = searchSet.Tables[0].Rows[index][columindex].ToString();
                }

                foreach (string date in dates)
                {
                    Console.WriteLine(date);
                    radCalendar1.SpecialDays.Add(DateTime.Parse(date));

                }

                
                

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
                c.closeConnection();
            }

            return searchSet;
        }


        private void radCalendar1_SelectionChanged(object sender, EventArgs e)
        {

            if (dates.Contains(radCalendar1.SelectedDate.ToShortDateString()))//SESSION EXISTS
            {
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
                getNotesTime();
            }
            else {//SESSION DOESNT EXIST
                dateTimePicker1.Value = DateTime.Now;
                richTextBox1.Clear();
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }





        private void Client_Planner_Load(object sender, EventArgs e)
        {
            getBookingsForClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addSession();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateSession();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            removeSession();
        }



    }
}
