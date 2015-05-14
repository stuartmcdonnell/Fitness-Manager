using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FitNess3
{
    public partial class Change_Password : Form
    {

        Form_Login l = new Form_Login();
        DatabaseConnection c = new DatabaseConnection();

        public Change_Password()
        {
            InitializeComponent();



        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (l.returnPass() == textBox1.Text)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    try
                    {
                        c.connect();

                        string stm = ("UPDATE login SET PASSWORD =  '" + textBox3.Text + "'");
                        MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Password Changed!");

                        this.Close();

                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.ToString());
                    }
                }
                else { MessageBox.Show("New Passwords Do Not Match!"); }
            }
            else { MessageBox.Show("Current Password Incorrect!"); }


        }

        private void Change_Password_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel=true;
        }
    }
}
