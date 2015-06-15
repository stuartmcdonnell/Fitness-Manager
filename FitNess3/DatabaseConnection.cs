using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Xml;
using System.Windows;

namespace FitNess3
{
    public class DatabaseConnection
    {

        
        public string host {get;set;}
        public string database {get;set;}
        public string userid { get; set; }
        static MySqlConnection connection = new MySqlConnection();



        private void getHost() {

            try
            {

                XmlDocument doc = new XmlDocument();
                doc.Load("config.xml");
                this.host = doc.SelectSingleNode("config/host").InnerText;
                this.database = doc.SelectSingleNode("config/database").InnerText;
                this.userid = doc.SelectSingleNode("config/userid").InnerText;

                //System.Windows.Forms.MessageBox.Show(this.host+Environment.NewLine+this.database);


                connection.ConnectionString = (
                    "Server=" + this.host + ";" +
                    "Database=" + this.database + ";" +
                    "Uid=fitdb_user;" +
                    "password=123456;"
                    );

            }catch(Exception exc){
                System.Windows.Forms.MessageBox.Show(exc.ToString());
            }
        }



       // MySqlConnection connection = new MySqlConnection(
       //"Server=107.180.3.229;" +
       //"Database=fitdb_publish;" +
       //"Uid=fitdb_user;" +
       //"password=123456;"
       //);




        public MySqlConnection connect() {
            getHost();
            try
            {
                connection.Open();
                Console.WriteLine("Connected!");
            }
            catch (Exception exc) {
                //MessageBox.Show(exc.ToString());
            }
            return connection;
        }

        public void closeConnection() {
            connection.Close();
            Console.WriteLine("Connection Closed");
        }

        public MySqlConnection getConnection() {
            return connection;
        }

    }
}
