using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace MyCourseWork2
{
    /// <summary>
    /// Логика взаимодействия для Registrator.xaml
    /// </summary>
    public partial class Registrator : Window
    {
        public Registrator()
        {
             InitializeComponent();
        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Registrationn(object sender, RoutedEventArgs e)
        {
            String loginUser = Login.Text;// получаю данные из текст бокса
            String passUser = Password.Text;

            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `User` = @uL AND `Password` = @uP",db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;//
            adapter.Fill(table);//обьект table добавляем 

            if(table.Rows.Count>0)
            {
                Hide();// прячется окно  MainWindow
                Users registerForm = new Users();
                registerForm.Show();
                Close();
            } else
            {
                MessageBox.Show("Wrong password or name");
            }
        }
    }
}
