using MySqlConnector;
using System;
using System.Data;
using System.Windows;

namespace MyCourseWork2
{
    public class DB
    {
        public MySqlConnection connection { get; private set; }
        public void openConnection(string user="root", string pass="12345")
        {
            connection = new MySqlConnection($"Server=localhost;port=3306;username={user};password={pass};Database=hospital");
            connection.Open();
        }
        public MySqlDataReader REQ(string req, bool isReturn = true)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(req, connection);
                cmd.ExecuteNonQuery();
                if (!isReturn) return null;
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                return null;
            }
        }
        public DataView GetTable(string Req, string TableName = "table")
        {
            MySqlCommand command = new MySqlCommand(Req, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable data = new DataTable(TableName);
            adapter.Fill(data);
            return data.DefaultView;
        }
        public bool chekValid()
        {
            if (connection == null) return false;
            if (connection.State != ConnectionState.Open) return false;
            return true;
        }
    }
}
