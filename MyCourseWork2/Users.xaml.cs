using MySqlConnector;
using System;
using System.Data;
using System.Windows;

namespace MyCourseWork2
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        public Users()
        {
            InitializeComponent();
        }
        private void GetPatient_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT idPatient,Name,Surname,Lastname  FROM `patients`", db.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable data = new DataTable("patients");
            adapter.Fill(data);
            Grid.ItemsSource = data.DefaultView;
            Grid1.ItemsSource = data.DefaultView;
            adapter.Update(data);
        }

        private void ShowDoctorForPatient(object sender, RoutedEventArgs e)
        {
            String id_of_user = idOfUser.Text;// получаю данные из текст бокса
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT Address, Date_Of_Illnes, " +
                "(SELECT Name from illness where idillness=patients.Diagnosis)" +
                "as Diagnos FROM patients where idPatient=@uL;", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = id_of_user;
            MySqlDataAdapter adapter2 = new MySqlDataAdapter(command);
            DataTable data = new DataTable("patients");
            adapter2.Fill(data);
            Grid.ItemsSource = data.DefaultView;
            adapter2.Update(data);
        }

        private void ShowDoctors(object sender, RoutedEventArgs e)
        {

            String id_of_user2 = idOfUser2.Text;// получаю данные из текст бокса
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT Name, Surname, Lastname from doctors where " +
                "idDoctors = (select doctor FROM patients where idPatient = @uL)", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = id_of_user2;
            MySqlDataAdapter adapter3 = new MySqlDataAdapter(command); 
            DataTable data = new DataTable("doctors");
            adapter3.Fill(data);
            Grid1.ItemsSource = data.DefaultView;
            adapter3.Update(data);
        }

        private void GetDoctors_Click(object sender, RoutedEventArgs e)
        {
            
            DB db = new DB();
            MySqlCommand command2 = new MySqlCommand("SELECT idDoctors,Name,Surname,Lastname  FROM `doctors`", db.getConnection());

            MySqlDataAdapter adapter2 = new MySqlDataAdapter(command2);
            DataTable data2 = new DataTable("doctors");
            adapter2.Fill(data2);
            Grid2.ItemsSource = data2.DefaultView;
            Grid3.ItemsSource = data2.DefaultView;
            adapter2.Update(data2);
        }

        private void NumberAndDaysDoctors(object sender, RoutedEventArgs e)
        {
            String id_of_user3 = NumOfDoctor.Text;// получаю данные из текст бокса
            DB db = new DB();
            //MySqlCommand command = new MySqlCommand("SELECT Cabinet FROM doctors where idDoctors = @uL;", db.getConnection());
            MySqlCommand command = new MySqlCommand("SELECT Name,Surname,LastName,Cabinet,Start,End FROM " +
                "doctors RIGHT JOIN free_doctor_time ON" +
                " doctors.idDoctors = free_doctor_time.Doctor where " +
                "(doctors.idDoctors =@uL and  free_doctor_time.Doctor = @uL);", db.getConnection());


            //MySqlCommand command2 = new MySqlCommand("SELECT Start, End from free_doctor_time where Doctor = @uL;", db.getConnection());
            // SELECT Start, End from free_doctor_time where Doctor = 1;
            // SELECT Cabinet FROM doctors where idDoctors = @uL;
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = id_of_user3;

            //command2.Parameters.Add("@uL", MySqlDbType.VarChar).Value = id_of_user3;
            MySqlDataAdapter adapter4 = new MySqlDataAdapter(command);

            //MySqlDataAdapter adapter5 = new MySqlDataAdapter(command2);
            DataTable data3 = new DataTable("doctors");
            //DataTable data4 = new DataTable("free_doctor_time");
            adapter4.Fill(data3);
            
            //adapter5.Fill(data4);
            Grid2.ItemsSource = data3.DefaultView;
           // Grid3.ItemsSource = data4.DefaultView;
            adapter4.Update(data3);
            //adapter5.Update(data4);
        }

        private void ShowPatientsWithDoc(object sender, RoutedEventArgs e)
        {
            String id_of_user4 = NumOfDoctor4.Text;// получаю данные из текст бокса
            DB db = new DB();
            //
            MySqlCommand command = new MySqlCommand("SELECT name,surname,lastname FROM patients where Doctor = @uL;", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = id_of_user4;
            MySqlDataAdapter adapter5 = new MySqlDataAdapter(command);
            DataTable data4 = new DataTable("patients");
            adapter5.Fill(data4);
            Grid3.ItemsSource = data4.DefaultView;
            adapter5.Update(data4);
        }

        private void ShowSymptoms(object sender, RoutedEventArgs e)
        {

            String id_of_user5 = Illness_.Text;// получаю данные из текст бокса
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT (SELECT Symptoms_Of_Illness from symptoms where " +
                "id = simptom_ilness.Simptom) as Simptom,(SELECT Name from illness where " +
                "idIllness = simptom_ilness.Ilnes) as Illnes, Medications FROM " +
                "simptom_ilness, illness where (simptom_ilness.Ilnes = @uL and " +
                "illness.idIllness = @uL);", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = id_of_user5;
            MySqlDataAdapter adapter6 = new MySqlDataAdapter(command);
            DataTable data4 = new DataTable("patients");
            adapter6.Fill(data4);
            Grid4.ItemsSource = data4.DefaultView;
            adapter6.Update(data4);
        }

        private void GetIllness_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            MySqlCommand command3 = new MySqlCommand("SELECT idIllness, Name FROM `illness`", db.getConnection());
            MySqlDataAdapter adapter3 = new MySqlDataAdapter(command3);
            DataTable data3 = new DataTable("illness");
            adapter3.Fill(data3);
            Grid4.ItemsSource = data3.DefaultView;
            adapter3.Update(data3);
        }
    }
    

}
