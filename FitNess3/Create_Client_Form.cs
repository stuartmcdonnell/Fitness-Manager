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
    public partial class Create_Client_Form : Form
    {

        DatabaseConnection c = new DatabaseConnection();
        private string filepath { get; set; }
        private string filename { get; set; }

        public Create_Client_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{
            copyPicture();
            c.connect();
            string stm = ("INSERT INTO `clients` (`client_id`, `forename`, `surname`, `picture_directory`, `weight`, `height`, `bodyfat`, `shortgoals`, `longgoals`) VALUES (NULL, '"+forename_textbox.Text+"', '"+surname_textbox.Text+"', '"+filename+"', '"+textBox1.Text+"', '"+textBox2.Text+"', '"+textBox3.Text+"', '"+richTextBox1.Text+"', '"+richTextBox2.Text+"');");
            MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Client Added!", "Client Added");
            c.closeConnection();
            }
            catch(Exception exc){
                MessageBox.Show(exc.ToString());
            }

        }

        private void Create_Client_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void getPicturePath(){
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                this.filepath = openFileDialog1.FileName;
                this.filename = openFileDialog1.SafeFileName;
                button2.Text = openFileDialog1.SafeFileName;
            }
        }



        private void copyPicture() {
            try
            {

                DialogResult result = MessageBox.Show("This Will Overwrite Any Picture With The Same Name!" + Environment.NewLine + "Continue?", "Warngin!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    System.IO.File.Copy(this.filepath, "UserPictures/" + this.filename, true);
                }
            }
            catch (Exception exc) {
                MessageBox.Show(exc.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getPicturePath();
        }


    }
}
