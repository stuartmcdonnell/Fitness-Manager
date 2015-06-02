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

        
        string host {get;set;}
        string database {get;set;}
        static MySqlConnection connection = new MySqlConnection();



        private void getHost() {
            XmlDocument doc = new XmlDocument();
            doc.Load("http://stuartmcdonnell.co.uk/fitnessmanager/config.xml");
            this.host=doc.SelectSingleNode("connection/host").InnerText;
            this.database = doc.SelectSingleNode("connection/database").InnerText;

            //System.Windows.Forms.MessageBox.Show(this.host+Environment.NewLine+this.database);


            connection.ConnectionString = (
                "Server="+this.host+";" +
                "Database="+this.database+";" +
                "Uid=fitdb_user;" +
                "password=123456;"
                );
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
                Console.Write("Connected!");
            }
            catch (Exception exc) {
                //MessageBox.Show(exc.ToString());
            }
            return connection;
        }

        public void closeConnection() {
            connection.Close();
        }

        public MySqlConnection getConnection() {
            return connection;
        }

    }
}
