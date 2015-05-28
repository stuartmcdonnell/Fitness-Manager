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
    public partial class Add_Exercise : Form
    {
        public Add_Exercise()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && richTextBox1.Text != null) {
                addExercise();           
            }
        }


        private void addExercise() {

            try
            {
                DatabaseConnection c = new DatabaseConnection();
                c.connect();
                string stm = ("INSERT INTO `exercises` (`exercise_id`, `name`, `description`) VALUES (NULL, '" + textBox1.Text + "', '" + richTextBox1.Text + "');");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Exercise Added!");
                c.closeConnection();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        
        
        }


    }
}
