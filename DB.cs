using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
public class Class1
{
	public Class1()
	{
		//MysqlConnection connection = new MysqlConnection("server=")

    public static MySqlConnection
          GetDBConnection(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);
             MySqlConnection.Open();
            if (MySqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("OK")
            } else
            {
                MessageBox.Show("UPS")
            }

            return conn;
        }
    }
}
