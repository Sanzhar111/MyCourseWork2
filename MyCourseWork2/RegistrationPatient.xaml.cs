using MySqlConnector;
using System;
using System.Data;
using System.Windows;

namespace MyCourseWork2
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPatient.xaml
    /// </summary>
    public partial class RegistrationPatient : Window
    {
        public RegistrationPatient()
        {
            InitializeComponent();
        }

        private void InsertInfo(object sender, RoutedEventArgs e)
        {
            String name = Name.Text;// получаю данные из текст бокса
            String surname = Surname.Text;
            String lastName = LastName.Text;
            String address = Address.Text;
            String diagnoz = Diagnoz.Text;
            String date = Date.Text;
            String doctor = Doctor.Text;
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT Address, Date_Of_Illnes, " +
                "(SELECT Name from illness where idillness=patients.Diagnosis)" +
                "as Diagnos FROM patients where idPatient=@uL;", db.getConnection());
            /*command.Parameters.Add("@", MySqlDbType.VarChar).Value = ;
            command.Parameters.Add("@", MySqlDbType.VarChar).Value = ;
            command.Parameters.Add("@", MySqlDbType.VarChar).Value = ;
            command.Parameters.Add("@", MySqlDbType.VarChar).Value = ;
            command.Parameters.Add("@", MySqlDbType.VarChar).Value = ;
            command.Parameters.Add("@", MySqlDbType.VarChar).Value = ;
            command.Parameters.Add("@", MySqlDbType.VarChar).Value = ;*/
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable data = new DataTable("patients");
            adapter.Fill(data);
            //Grid5.ItemsSource = data.DefaultView;
            adapter.Update(data);
        }
    }
}
