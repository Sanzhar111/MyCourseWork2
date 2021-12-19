using System.Windows;
using System.Linq;
namespace MyCourseWork2
{
    public partial class RegistrationPatient : Window
    {
        DB db;
        public RegistrationPatient(DB db)
        {
            this.db = db;
            InitializeComponent();
            var reader = db.REQ("select Name from illness");
            if (reader != null) while (reader.Read()) Diagnoz.Items.Add(reader[0]);
            reader.Close();
            reader = db.REQ("select Name, Surname, LastName from doctors");
            if (reader != null) while (reader.Read()) Doctor.Items.Add($"{reader[0]} {reader[1]} {reader[2]}");
            reader.Close();
        }
        private void InsertInfo(object sender, RoutedEventArgs e)
        {
            
            var arr = (Doctor.SelectedItem as string).Split();
            var reader = db.REQ($"select idDoctors from doctors where Name='{arr[0]}' AND Surname='{arr[1]}' AND LastName='{arr[2]}'");
            if (reader == null) { Close(); return; }
            reader.Read();
            string doctor = reader[0].ToString();
            reader.Close();
            reader = db.REQ($"select idIllness from illness where Name='{Diagnoz.SelectedItem}'");
            if (reader == null) { Close(); return; }
            reader.Read();
            string Diagnosis = reader[0].ToString();
            reader.Close();
            db.REQ($"INSERT INTO patients (Name, Surname, LastName, Address, Diagnosis, Date_Of_Illnes, Doctor) VALUES('{Name.Text}','{Surname.Text}','{LastName.Text}','{Address.Text}',{Diagnosis},CAST('{Date.Text}' as datetime),{doctor})", false);
            Close();
        }
    }
}
