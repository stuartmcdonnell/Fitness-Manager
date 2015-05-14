﻿using System;
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
    public partial class Form_Login : Form
    {
        public static bool login_status;
        DatabaseConnection c = new DatabaseConnection();

        string name;
        string password;


        public Form_Login()

        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e){
            Cursor.Current = Cursors.WaitCursor;
            if ((textbox_username.Text == this.returnName()) && (textbox_password.Text == this.returnPass()))
            {
                login_status = true;
                this.textbox_password.Clear();
                this.Hide();
                c.closeConnection();
            }
            else {
                MessageBox.Show("Invalid Username/Password!");
            }
            Cursor.Current = Cursors.Default;
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {

        }

        public string returnName()
        {
            c.connect();
            string stm = ("SELECT `username` FROM `login` WHERE 1;");
            MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
            string tempname = Convert.ToString(cmd.ExecuteScalar());
            this.name = tempname;

            c.closeConnection(); return name;
        }


        public string returnPass()
        {
            c.connect();
            string stm = ("SELECT `password` FROM `login` WHERE 1;");
            MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());
            string temppass = Convert.ToString(cmd.ExecuteScalar());
            this.password = temppass;

            c.closeConnection(); return password;
        }

        public void setStatus(bool statusin)
        {
            login_status = statusin;
        }

        public bool returnStatus()
        {
            return login_status;
        }

        public void logout() {
            if (login_status == true)
            {
                login_status = false;
                System.Windows.Forms.MessageBox.Show("You Have Been Logged Out!");
            }
            else {
                System.Windows.Forms.MessageBox.Show("You Are Not Logged In!");
            }

        }

        private void Form_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }


    }
}
