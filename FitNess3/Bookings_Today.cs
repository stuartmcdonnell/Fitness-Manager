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
    public partial class Bookings_Today : Form
    {

        string[] dates { get; set; }

        public Bookings_Today()
        {
            InitializeComponent();
        }

        private void Bookings_Today_Load(object sender, EventArgs e)
        {
            allBookings();
        }

        private void allBookings() { 
        
            DataSet searchSet = new DataSet();
            DatabaseConnection c = new DatabaseConnection();

            string selected_date = radCalendar1.SelectedDate.ToShortDateString();

            radCalendar1.SpecialDays.Clear();

            try
            {
                Search_Results_Client sr = new Search_Results_Client();
                c.connect();
                string stm = ("SELECT * FROM `bookings` WHERE 1");
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
            //return searchSet;
        }

        private void getToday() {

            DatabaseConnection c = new DatabaseConnection();

            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter a = new MySqlDataAdapter();

                string stm = ("SELECT `booking_date`,`booking_id`,`booking_time`,CONCAT(clients.forename,' ', clients.surname) AS fullname FROM `bookings` INNER JOIN clients WHERE bookings.client_id = clients.client_id AND `booking_date` = '"+radCalendar1.SelectedDate.ToShortDateString()+"'");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());

                a.SelectCommand = cmd;
                a.Fill(ds);
                a.Dispose();
                cmd.Dispose();
                c.closeConnection();
               
                listBox1.DataSource = ds.Tables[0];
                listBox1.ValueMember = "booking_time";
                listBox1.DisplayMember = "booking_time";

                listBox2.DataSource = ds.Tables[0];
                listBox2.ValueMember = "fullname";
                listBox2.DisplayMember = "fullname";


            }
            catch (Exception exc)
            {
                //MessageBox.Show(exc.ToString());
        }
        
        
        
        }

        private void radCalendar1_SelectionChanged(object sender, EventArgs e)
        {
            if (dates.Contains(radCalendar1.SelectedDate.ToShortDateString()))//SESSION EXISTS
            {
                getToday();
            }
            else
            {//SESSION DOESNT EXIST
                getToday();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }//BASE
}
