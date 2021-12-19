using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyCourseWork2
{
    class DB
    {
        // Connection String
      //  string connString = "Server=localhost;Database=database;port=3306;User Id=root;password=12345";
      MySqlConnection connection = new MySqlConnection("Server=localhost;port=3306;username=root;password=12345;Database=import3");
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }

    }
}
