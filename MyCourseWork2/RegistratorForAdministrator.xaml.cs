using MySqlConnector;
using System;
using System.Data;
using System.Windows;

namespace MyCourseWork2
{
    /// <summary>
    /// Логика взаимодействия для RegistratorForAdministrator.xaml
    /// </summary>
    public partial class RegistratorForAdministrator : Window
    {
        public RegistratorForAdministrator()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            String loginUser = Login.Text;// получаю данные из текст бокса
            String passUser = Password.Text;

            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `User` = @uL AND `Password` = @uP", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;//
            adapter.Fill(table);//обьект table добавляем 

            if (table.Rows.Count > 0)
            {
                Hide();// прячется окно  MainWindow
                Administrator registerForm = new Administrator();
                registerForm.Show();
                Close();
                //MessageBox.Show("OKey");
            }
            else
            {
                MessageBox.Show("Wrong password or name");
            }
        }
    }
}
