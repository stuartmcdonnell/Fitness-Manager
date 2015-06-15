using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitNess3
{
    class ListBookings
    {

        public DataSet getData()
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter a = new MySqlDataAdapter();
                DatabaseConnection c = new DatabaseConnection();
                string stm = ("SELECT * FROM `bookings`");
                MySqlCommand cmd = new MySqlCommand(stm, c.getConnection());

                a.SelectCommand = cmd;
                a.Fill(ds);
                a.Dispose();
                cmd.Dispose();
                c.closeConnection();

            }
            catch (Exception exc)
            {
                //MessageBox.Show(exc.ToString());
            }
            return ds;
        }



    }
}
