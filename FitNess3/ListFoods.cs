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
    class ListFoods
    {

        public DataSet getFoods()
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter a = new MySqlDataAdapter();
                DatabaseConnection c = new DatabaseConnection();
                string stm = ("SELECT `food_id`, `name`, `calories`, `protein`, `carbs`, `fat` FROM `foods`");
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
