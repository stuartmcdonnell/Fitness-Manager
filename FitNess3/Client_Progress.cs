﻿using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    public partial class Client_Progress : Form
    {

        string clientid { get; set; }

        string[] images = { };
        string[] dates = { };


        public Client_Progress(string clientid)
        {
            this.clientid = clientid;
            InitializeComponent();
        }

        private void Client_Progress_Load(object sender, EventArgs e)
        {
            this.Text = "Client Progress Report";
            getClient();
        }





        private void button1_Click(object sender, EventArgs e)
        {
            
        }


        private void getClient()
        {

            DatabaseConnection c = new DatabaseConnection();

            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter a = new MySqlDataAdapter();

                string stm = ("SELECT * FROM `client_progress` WHERE  client_id = " + clientid);
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());

                a.SelectCommand = cmd;
                a.Fill(ds);
                a.Dispose();

                cmd.Dispose();
                c.closeConnection();

                listBox1.DataSource = ds.Tables[0];
                listBox1.ValueMember = "date";
                listBox1.DisplayMember = "date";

                listBox2.DataSource = ds.Tables[0];
                listBox2.ValueMember = "date";
                listBox2.DisplayMember = "weight";

                listBox4.DataSource = ds.Tables[0];
                listBox4.ValueMember = "date";
                listBox4.DisplayMember = "bodyfat";


                images = ds.Tables[0].AsEnumerable().Select(r => r.Field<string>("picture")).ToArray();
                dates = ds.Tables[0].AsEnumerable().Select(r => r.Field<string>("date")).ToArray();

                int length = images.Length;

                int bottom = 1337;
                if (length > 6)
                {
                    bottom = length - 6;
                }
                else if (length < 6)
                {
                    bottom = length - length;
                }


                int top = 1337;
                if (length > 6)
                {
                    top = bottom + 5;
                }
                else if (length < 6)
                {
                    top = length - 1;
                }

                ArrayList selectedimages = new ArrayList();
                ArrayList selecteddates = new ArrayList();

                MessageBox.Show("Bottom: " + bottom + Environment.NewLine + "Top: " + top);
                for (int i = bottom; i <= top; i++)
                {


                    string picture_directory = images[i];
                    string date = dates[i];

                    selecteddates.Add(date);
                    selectedimages.Add(picture_directory);

                }

                MessageBox.Show(selectedimages.Count.ToString());

                for (int inner = 0; inner < selectedimages.Count; inner++)
                {
                    switch (inner)
                    {
                        case 0: pictureBox1.Image = Image.FromFile(@"UserPictures\\" + selectedimages[0].ToString()); label1.Text=selecteddates[0].ToString(); break;
                        case 1: pictureBox2.Image = Image.FromFile(@"UserPictures\\" + selectedimages[1].ToString()); label2.Text = selecteddates[1].ToString(); break;
                        case 2: pictureBox3.Image = Image.FromFile(@"UserPictures\\" + selectedimages[2].ToString()); label3.Text = selecteddates[2].ToString(); break;
                        case 3: pictureBox4.Image = Image.FromFile(@"UserPictures\\" + selectedimages[3].ToString()); label4.Text = selecteddates[3].ToString(); break;
                        case 4: pictureBox5.Image = Image.FromFile(@"UserPictures\\" + selectedimages[4].ToString()); label5.Text = selecteddates[4].ToString(); break;
                        case 5: pictureBox6.Image = Image.FromFile(@"UserPictures\\" + selectedimages[5].ToString()); label6.Text = selecteddates[5].ToString(); break;
                    }
                }


            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
                c.closeConnection();
            }


        }

    }
}
