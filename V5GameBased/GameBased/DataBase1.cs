using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GameBased
{
    class DataBase1
    {    
        MySqlConnection connection= new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=game");
      

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
       public MySqlConnection GetConnection()
        {
            return connection;
        }
     

    }
}
