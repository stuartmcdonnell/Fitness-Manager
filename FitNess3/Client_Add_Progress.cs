using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitNess3
{
    public partial class Client_Add_Progress : Form
    {


        string clientid { get; set; }
        string fullname { get; set; }
        string picture_directory { get; set; }
        string weight { get; set; }
        string height { get; set; }
        string bodyfat { get; set; }

        string filename;
        string filepath;
        bool newimage = false;

        public Client_Add_Progress(string clientid)
        {
            this.clientid = clientid;
            InitializeComponent();
        }


        private void Client_Add_Progress_Load(object sender, EventArgs e)
        {
            label5.Text = DateTime.Today.Date.ToShortDateString();
            getClient();
            this.Text = this.fullname;
        }


        private void getPicturePath()
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.filepath = openFileDialog1.FileName;
                this.filename = openFileDialog1.SafeFileName;
                button1.Text = openFileDialog1.SafeFileName;
                copyPicture();
            }
        }



        private void copyPicture()
        {
            try
            {

                DialogResult result = MessageBox.Show("This Will Overwrite Any Picture With The Same Name!" + Environment.NewLine + "Continue?", "Warngin!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    newimage = true;
                    System.IO.File.Copy(this.filepath, "UserPictures/" + this.filename, true);
                }
            }
            catch (Exception exc)
            {
                //MessageBox.Show(exc.ToString());
                //MessageBox.Show("File Copy Error"+Environment.NewLine+"This Error is Usually Nothing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void getClient()
        {

            DatabaseConnection c = new DatabaseConnection();
            try
            {
                Search_Results_Client sr = new Search_Results_Client();
                c.connect();
                string stm = ("SELECT * FROM clients WHERE clients.client_id =" + clientid);
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    this.fullname = dr["forename"].ToString() + " " + dr["surname"].ToString();
                    this.weight = dr["weight"].ToString();
                    this.bodyfat = dr["bodyfat"].ToString();
                    this.picture_directory = dr["picture_directory"].ToString();
                }

                textBox1.Text = this.weight;
                textBox3.Text = this.bodyfat;
                setPicture();
                dr.Dispose();
                c.closeConnection();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }


        private void setPicture()
        {
            if (picture_directory != "")
            {
                if (File.Exists(@"UserPictures\\" + picture_directory))
                {
                    pictureBox1.Image = Image.FromFile(@"UserPictures\\" + picture_directory);
                }
                else
                {
                    MessageBox.Show("File Doesn't Exist Using Default!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getPicturePath();
        }

        private void addProgress() {


        }



        private void addCurrent() {

            try
            {
                DatabaseConnection c = new DatabaseConnection();
                c.connect();
                string stm = ("INSERT INTO `client_progress` (`progress_id`, `client_id`, `date`, `picture`, `weight`, `bodyfat`) VALUES (NULL, '"+this.clientid+"', '"+DateTime.Today.Date.ToShortDateString()+"', '"+this.picture_directory+"', '"+this.weight+"', '"+this.bodyfat+"');");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                cmd.ExecuteNonQuery();

                c.closeConnection();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void updateCurrent() {

            DialogResult result = MessageBox.Show("Do you wish to Add Client Progress Point?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                DatabaseConnection c = new DatabaseConnection();
                try
                {
                    c.connect();
                    string stm="";
                    if (newimage)
                    {
                        stm = ("UPDATE `clients` SET `picture_directory` = '" + this.filename + "', `weight` = '" + this.textBox1.Text + "', `bodyfat` = '" + textBox3.Text + "' WHERE `clients`.`client_id` = " + this.clientid + ";");
                    }
                    else {
                        stm = ("UPDATE `clients` SET `weight` = '" + this.textBox1.Text + "', `bodyfat` = '" + textBox3.Text + "' WHERE `clients`.`client_id` = " + this.clientid + ";");
                    }

                   
                    MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                    cmd.ExecuteNonQuery();
                    c.closeConnection();
                    MessageBox.Show("Client Progress Added!", "Progress Added");
                    getClient();
                    setPicture();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addCurrent();
            updateCurrent();
            this.Dispose();
            client_profile profile = new client_profile();
            profile.OpenMe(Convert.ToInt32(clientid));
        }


    }
}
