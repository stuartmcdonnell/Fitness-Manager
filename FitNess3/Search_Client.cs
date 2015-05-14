﻿using MySql.Data.MySqlClient;
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
    public partial class Search_Client : Form
    {

        public DataSet searchSet = new DataSet();


        DatabaseConnection c = new DatabaseConnection();
        MySqlDataAdapter a = new MySqlDataAdapter();
    

        public Search_Client()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchResult();
        }

        private void Search_Client_Load(object sender, EventArgs e)
        {

        }

        public DataSet searchResult() {

            try
            {
                Search_Results_Client sr = new Search_Results_Client();
                c.connect();
                string stm = ("SELECT clients.client_id, clients.forename,clients.surname,plans.plan_id,plans.plan_name FROM clients LEFT JOIN plans USING(plan_id) WHERE forename LIKE '"+forename_textbox.Text+"' AND surname LIKE '"+surname_textbox.Text+"'");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());


                a.SelectCommand = cmd;
                a.Fill(searchSet);
                a.Dispose();

                sr.displayResults(searchSet);

                forename_textbox.Clear();
                surname_textbox.Clear();
                c.closeConnection();
                
            }
            catch (Exception exc)
            {
                MessageBox.Show("Search Returned No Results!", "Error");
                c.closeConnection();
            }

            return searchSet;
        }

        private void Search_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

    }
}
