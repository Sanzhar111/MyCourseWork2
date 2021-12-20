using System.Windows;
namespace MyCourseWork2
{
    public partial class Users : Window
    {
        DB db;
        public Users(DB db)
        {
            this.db = db;
            InitializeComponent();
        }
        private void GetPatient_Click(object sender, RoutedEventArgs e)
        {
            var data = db.GetTable("SELECT idPatient,Name,Surname,Lastname  FROM `patients`");
            Grid.ItemsSource = data;
            Grid1.ItemsSource = data;
        }
        private void ShowDoctorForPatient(object sender, RoutedEventArgs e) =>
            Grid.ItemsSource = db.GetTable("SELECT Address, Date_Of_Illnes, " +
                "(SELECT Name from illness where idillness=patients.Diagnosis)" +
                $"as Diagnos FROM patients where idPatient={idOfUser.Text}");
        private void ShowDoctors(object sender, RoutedEventArgs e) =>
            Grid1.ItemsSource = db.GetTable("SELECT Name, Surname, Lastname from doctors where " +
                $"idDoctors = (select doctor FROM patients where idPatient = {idOfUser2.Text})");
        private void GetDoctors_Click(object sender, RoutedEventArgs e)
        {
            var data = db.GetTable("SELECT idDoctors,Name,Surname,Lastname  FROM `doctors`");
            Grid2.ItemsSource = data;
            Grid3.ItemsSource = data;
        }
        private void NumberAndDaysDoctors(object sender, RoutedEventArgs e) =>
            Grid2.ItemsSource = db.GetTable("SELECT Name,Surname,LastName,Cabinet,Start,End FROM " +
                "doctors RIGHT JOIN free_doctor_time ON" +
                " doctors.idDoctors = free_doctor_time.Doctor where " +
                $"(doctors.idDoctors ={NumOfDoctor.Text} and  free_doctor_time.Doctor = {NumOfDoctor.Text})");
        private void ShowPatientsWithDoc(object sender, RoutedEventArgs e) =>
            Grid3.ItemsSource = db.GetTable($"SELECT name,surname,lastname FROM patients where Doctor = {NumOfDoctor4.Text}");
        private void ShowSymptoms(object sender, RoutedEventArgs e) =>
            Grid4.ItemsSource = db.GetTable("SELECT (SELECT Symptoms_Of_Illness from symptoms where " +
                "id = simptom_ilness.Simptom) as Simptom,(SELECT Name from illness where " +
                "idIllness = simptom_ilness.Ilnes) as Illnes, Medications FROM " +
                $"simptom_ilness, illness where (simptom_ilness.Ilnes = {Illness_.Text} and " +
                $"illness.idIllness ={Illness_.Text})");
        private void GetIllness_Click(object sender, RoutedEventArgs e) =>
            Grid4.ItemsSource = db.GetTable("SELECT idIllness, Name FROM `illness`");
    }
}
