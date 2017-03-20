using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace FitNess3
{
    public partial class Home : Form
    {

        DatabaseConnection c = new DatabaseConnection();
        public Form_Login loginf = new Form_Login();

        public Home()
        {
            InitializeComponent();
            firstRun();
            logoutToolStripMenuItem.Enabled = false;
            changePasswordToolStripMenuItem.Enabled = false;
            loginToolStripMenuItem.Enabled = true;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();

            if (System.IO.Directory.Exists("UserPictures"))
            {
                Console.WriteLine("Profile Picture Folder Exists! Continue...");
            }
            else {
                System.IO.Directory.CreateDirectory("UserPictures");
            }

        }

        private void firstRun() {

            

            if (File.Exists("config.xml"))
            {
                Console.WriteLine("CONFIG EXISTS... LOADING");
            }
            else {
                Console.WriteLine("CONFIG DOESNT EXIST... CREATING");
                try
                {

                    string input = Microsoft.VisualBasic.Interaction.InputBox("Please Enter Your User ID"+Environment.NewLine+"This can be found in your welcmail."+Environment.NewLine+"Contact Support for Further Assistance.", "Welcome to FitNess Manager", "", -1, -1);

                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.IndentChars = "\t";
                    XmlWriter writer = XmlWriter.Create("config.xml", settings);


                    writer.WriteStartDocument();
                    writer.WriteStartElement("config");


                    writer.WriteStartElement("userid");
                    writer.WriteString(input);
                    writer.WriteEndElement();


                    MySqlConnection admin = new MySqlConnection(
                        "Server=localhost;" +
                        "Database=manager_clients;" +
                        "Uid=fitdb_user;" +
                        "password=123456;"
                        );

                    admin.Open();
                    string stm = ("SELECT `database_name` FROM clients WHERE `userid` = "+"'"+input+"'");
                    MySqlCommand cmd = new MySqlCommand(stm, admin);
                    string database_name = Convert.ToString(cmd.ExecuteScalar());
                    admin.Close();

                    admin.Open();
                    string stm2 = ("SELECT `host` FROM clients WHERE `userid` = " + "'" + input + "'");
                    MySqlCommand cmd2 = new MySqlCommand(stm2, admin);
                    string host = Convert.ToString(cmd2.ExecuteScalar());
                    admin.Close();

                    //ONE
                    writer.WriteStartElement("database");
                    writer.WriteString(database_name);
                    writer.WriteEndElement();

                    writer.WriteStartElement("host");
                    writer.WriteString(host);
                    writer.WriteEndElement();

                    writer.WriteEndDocument();
                    writer.Close();

                    if ((database_name == "") || (host == "")) {


                        MessageBox.Show("Error Downloading User Settings" + Environment.NewLine + "Please Contact Support!","Error",  MessageBoxButtons.OK,MessageBoxIcon.Error);
                        File.Delete("config.xml");
                        Environment.Exit(1);

                    }


                }
                catch (Exception exc) {
                   MessageBox.Show(exc.ToString());
                   File.Delete("config.xml");
                
                }
                   
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(loginf.returnStatus().ToString());
        }


        private void loginToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            loginf.Show();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            if (loginf.returnStatus() == true)//Loggedin
            {
                toolStripLabel1.Text = "You are Logged In!";
                logoutToolStripMenuItem.Enabled = true;
                changePasswordToolStripMenuItem.Enabled = true;
                add_client.Enabled = true;
                loginToolStripMenuItem.Enabled = false;
                search_client.Enabled = true;
                list_users.Enabled = true;
                assign_plan.Enabled = true;
                showplancontent.Enabled = true;
                listplans.Enabled = true;
                modifydietplan.Enabled = true;
                searchplan.Enabled = true;
                addfood.Enabled = true;
                listfoods.Enabled = true;
                addworkout.Enabled = true;
                listworkout.Enabled = true;
                showworkout.Enabled = true;
                addexercise.Enabled = true;
                listexercise.Enabled = true;
                planner_today.Enabled = true;
            }
            else {
                toolStripLabel1.Text = "Please Log In!";//Logged Out
                search_client.Enabled = false;
                loginToolStripMenuItem.Enabled = true;
                logoutToolStripMenuItem.Enabled = false;
                changePasswordToolStripMenuItem.Enabled = false;
                add_client.Enabled = false;
                list_users.Enabled = false;
                assign_plan.Enabled = false;
                showplancontent.Enabled = false;
                listplans.Enabled = false;
                modifydietplan.Enabled = false;
                searchplan.Enabled = false;
                addfood.Enabled = false;
                listfoods.Enabled = false;
                addworkout.Enabled = false;
                listworkout.Enabled = false;
                showworkout.Enabled = false;
                addexercise.Enabled = false;
                listexercise.Enabled = false;
                planner_today.Enabled = false;
            }
            timer1.Start();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change_Password changepwd = new Change_Password();
            changepwd.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginf.logout();
        }

        private void add_client_Click(object sender, EventArgs e)
        {
            Create_Client_Form client_form = new Create_Client_Form();
            client_form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Search_Client sc = new Search_Client();
            sc.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form_List_Users lu = new Form_List_Users();
            lu.Show();
        }

        private void assign_plan_Click(object sender, EventArgs e)
        {
            Assign_Plan asp = new Assign_Plan();
            asp.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Search_Plan sp = new Search_Plan();
            sp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List_Plans lp = new List_Plans();
            lp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Show_Plan_Content showplanc = new Show_Plan_Content();
            showplanc.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Add_Diet_Plan ap = new Add_Diet_Plan();
            ap.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            FoodList fl = new FoodList();
            fl.Show();
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            Add_Food af = new Add_Food();
            af.Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            toolStripDropDownButton1.ShowDropDown();
            loginToolStripMenuItem.Select();
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            Add_Exercise addex = new Add_Exercise();
            addex.Show();
        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            Exercise_List exclist = new Exercise_List();
            exclist.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Workout_Add aw = new Workout_Add();
            aw.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Show_Workout_Content sc = new Show_Workout_Content();
            sc.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List_Workouts lw = new List_Workouts();
            lw.Show();
        }

        private void button1_Click_5(object sender, EventArgs e)
        {
            client_profile profile = new client_profile();
            profile.OpenMe(213);
        }

        private void button1_Click_6(object sender, EventArgs e)
        {
            //Client_Add_Progress tempadd = new Client_Add_Progress("205");
           // tempadd.Show();
            Client_Progress progress = new Client_Progress("205");
            progress.Show();
        }

        private void button1_Click_7(object sender, EventArgs e)
        {
            Client_Progress progress = new Client_Progress("205");
            progress.Show();
        }

        private void button1_Click_8(object sender, EventArgs e)
        {
            Client_Planner planner = new Client_Planner(206);
            planner.Show();
        }

        private void clearConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("config.xml"))
            {

                var confirmresult = MessageBox.Show("Delete all manager config"+Environment.NewLine+"Are you sure?", "Clear Config", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmresult == DialogResult.Yes)
                {
                    File.Delete("config.xml");
                    Environment.Exit(1);
                }
                else { 
                

                }
                
            }
            else {
                MessageBox.Show("Config Does Not Exist!");
            }
        }


        private void infoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Settings_Report report = new Settings_Report();
            report.Show();
        }

        private void button1_Click_9(object sender, EventArgs e)
        {
            Bookings_Today today = new Bookings_Today();
            today.Show();
        }

    }
}
