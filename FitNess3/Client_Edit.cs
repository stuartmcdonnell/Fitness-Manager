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
    public partial class Client_Edit : Form
    {

        private string clientid { get; set; }
        private string forename { get; set; }
        private string surname { get; set; }
        private string filepath { get; set; }
        private string filename { get; set; }
        private string picture_directory { get; set; }

        public Client_Edit()
        {
            InitializeComponent();
        }

        private void Client_Edit_Load(object sender, EventArgs e)
        {
            getFoods();
            getClient();
            setPicture();
            getDislikes();
        }

        private void getFoods()
        {
            ListFoods lf = new ListFoods();
            DataSet foods = new DataSet();
            foods = lf.getFoods();

            comboBox1.DataSource = foods.Tables[0];
            comboBox1.ValueMember = "food_id";
            comboBox1.DisplayMember = "name";

        }


        private void getDislikes() {

            DatabaseConnection c = new DatabaseConnection();
            MySqlDataAdapter a = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            string stm = "SELECT clients.client_id,client_dislikes_id,client_dislikes.food_id,foods.name FROM client_dislikes LEFT JOIN clients ON clients.client_id=client_dislikes.client_id LEFT JOIN foods ON foods.food_id=client_dislikes.food_id WHERE clients.client_id=" + clientid;
            MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
            a.SelectCommand=cmd;
            a.Fill(ds);
            a.Dispose();

            listBox1.DataSource = ds.Tables[0];
            listBox1.ValueMember = "client_dislikes_id";
            listBox1.DisplayMember = "name";


        }

        private void setPicture()
        {
            if (picture_directory != "")
            {
                pictureBox1.Image = Image.FromFile(@"UserPictures\\" + picture_directory);
            }
        }

        public void openMe(string clientidin) {
            this.clientid = clientidin;
            this.Show();
        }

        private void getClient()
        {

            DatabaseConnection c = new DatabaseConnection();

            try
            {
                Search_Results_Client sr = new Search_Results_Client();
                c.connect();
                string stm = ("SELECT * FROM  `clients` WHERE client_id="+clientid);
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string name = dr["forename"].ToString() +" "+ dr["surname"].ToString();
                    this.Text = name;
                    this.forename = dr["forename"].ToString();
                    this.surname = dr["surname"].ToString();
                    this.picture_directory = dr["picture_directory"].ToString();

                    textBox1.Text = forename;
                    textBox2.Text = surname;

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getPicturePath();
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
                    System.IO.File.Copy(this.filepath, "UserPictures/" + this.filename, true);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getPicturePath();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you wish to save Client Changes?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result==System.Windows.Forms.DialogResult.Yes) {
                confirmEdit();
            }

        }


        private void confirmEdit() {

            DatabaseConnection c = new DatabaseConnection();
            try
            {
                c.connect();
                string stm = ("UPDATE `fitdb`.`clients` SET `forename` = '" + textBox1.Text + "', `surname` = '" + textBox2.Text + "', `picture_directory` = '" + filename + "' WHERE `clients`.`client_id` =" + clientid);
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Client Edited!", "Client Edited");
                c.closeConnection();
                getClient();
                setPicture();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }

        }

        private void addDislike() {

            DatabaseConnection c = new DatabaseConnection();
            try
            {
                c.connect();
                string stm = ("INSERT INTO `fitdb`.`client_dislikes` (`client_dislikes_id`, `food_id`, `client_id`) VALUES (NULL, '"+comboBox1.SelectedValue.ToString()+"', '"+clientid+"');");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                cmd.ExecuteNonQuery();
                c.closeConnection();
                getDislikes();
            }
            catch(Exception exc) {
                MessageBox.Show(exc.ToString());
            }
        
        
        }


        private void removeDislike() {
            DatabaseConnection c = new DatabaseConnection();
            try
            {
                c.connect();
                string stm = ("DELETE FROM `fitdb`.`client_dislikes` WHERE `client_dislikes`.`client_dislikes_id` = "+listBox1.SelectedValue.ToString());
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                cmd.ExecuteNonQuery();
                c.closeConnection();
                getDislikes();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addDislike();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            removeDislike();
        }


    }//BASE
}
