using System;
using System.Windows;
namespace MyCourseWork2
{
    public partial class Registrator : Window
    {
        public Registrator()
        {
             InitializeComponent();
        }
        public DB GetCon() { ShowDialog(); return db; }
        DB db = new DB();
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.openConnection(Login.Text, Password.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            if (db.connection.State!= System.Data.ConnectionState.Open) MessageBox.Show("Error: Connetcion not open");
            else Close();
        }
    }
}
