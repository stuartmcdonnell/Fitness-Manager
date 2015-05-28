using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FitNess3
{
    public class DatabaseConnection
    {

        MySqlConnection connection = new MySqlConnection(
       "Server=107.180.3.229;" +
       "Database=fitdb_publish;" +
       "Uid=fitdb_user;" +
       "password=123456;"
       );


        public void connect() {
            try
            {
                connection.Open();
                Console.Write("Connected!");
            }
            catch (Exception exc) {
                System.Windows.Forms.MessageBox.Show(exc.ToString());
            }
        }

        public void closeConnection() {
            connection.Close();
        }

        public MySqlConnection getConnection() {
            return connection;
        }

    }
}
