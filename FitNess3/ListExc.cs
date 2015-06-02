using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitNess3
{
    class ListExc
    {

        public DataSet getExc()
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter a = new MySqlDataAdapter();
                DatabaseConnection c = new DatabaseConnection();
                string stm = ("SELECT * FROM `exercises`");
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
