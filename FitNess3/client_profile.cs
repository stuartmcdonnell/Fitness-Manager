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
using System.IO;

namespace FitNess3
{
    public partial class client_profile : Form
    {

        int clientid { get; set; }
        string fullname { get; set; }
        string planname { get; set; }
        string workoutname { get; set; }
        string picture_directory { get; set; }

        public client_profile()
        {
            InitializeComponent();
        }

        private void client_profile_Load(object sender, EventArgs e)
        {

        }


        public void OpenMe(int clientid_in) {
            this.Show();
            this.clientid = clientid_in;
            getClient();
            setPicture();
            getDislikes();
        }

        private void setPicture() {
            if (picture_directory != "") {
                if (File.Exists(@"UserPictures\\" + picture_directory))
                {
                    pictureBox1.Image = Image.FromFile(@"UserPictures\\" + picture_directory);
                }
                else {
                    MessageBox.Show("File Doesn't Exist Using Default!");
                }
            }
        }

        private void getClient() {

            DatabaseConnection c = new DatabaseConnection();

            try
            {
                Search_Results_Client sr = new Search_Results_Client();
                c.connect();
                string stm = ("SELECT clients.client_id, clients.forename,clients.surname,clients.picture_directory, plans.plan_name ,workouts.name FROM clients LEFT JOIN plans ON clients.plan_id=plans.plan_id  LEFT JOIN workouts ON clients.workout_id=workouts.workout_id WHERE clients.client_id =" + clientid);
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    this.planname = dr["plan_name"].ToString();
                    label4.Text = planname;
                    this.fullname = dr["forename"].ToString() + " " + dr["surname"].ToString();
                    label2.Text = fullname;
                    this.Text = fullname;
                    this.workoutname = dr["name"].ToString();
                    label6.Text = workoutname;
                    this.picture_directory = dr["picture_directory"].ToString();
                }

                dr.Dispose();
                c.closeConnection();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
                c.closeConnection();
            }


        }


        private void getDislikes() {

            DataSet ds = new DataSet();
            MySqlDataAdapter a = new MySqlDataAdapter();
            DatabaseConnection c = new DatabaseConnection();

            string stm = ("SELECT clients.client_id,client_dislikes_id,client_dislikes.food_id,foods.name FROM client_dislikes LEFT JOIN clients ON clients.client_id=client_dislikes.client_id LEFT JOIN foods ON foods.food_id=client_dislikes.food_id WHERE clients.client_id="+clientid);
            MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());

            a.SelectCommand = cmd;
            a.Fill(ds);
            a.Dispose();

            cmd.Dispose();
            c.closeConnection();

            listBox1.DataSource = ds.Tables[0];
            listBox1.ValueMember = "client_dislikes_id";
            listBox1.DisplayMember = "name";


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client_Edit editclient = new Client_Edit();
            editclient.openMe(clientid.ToString());
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Client_Add_Progress addprogress = new Client_Add_Progress(clientid.ToString());
            addprogress.Show();
        }



    }//BASE
}
