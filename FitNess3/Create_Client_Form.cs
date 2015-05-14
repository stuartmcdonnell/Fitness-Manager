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
    public partial class Create_Client_Form : Form
    {

        DatabaseConnection c = new DatabaseConnection();

        public Create_Client_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{
            c.connect();
            string stm = ("INSERT INTO `clients`(`forename`, `surname`) VALUES ('"+forename_textbox.Text+"','"+surname_textbox.Text+"')");
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


    }
}
