using System.Windows;
namespace MyCourseWork2
{
    public partial class Administrator : Window
    {
        DB db = null;
        public Administrator(DB db)
        {
            this.db = db;
            InitializeComponent();
        }
        private void InsertPatient(object sender, RoutedEventArgs e)
        {
            RegistrationPatient registerForm = new RegistrationPatient(db);
            registerForm.Show();
        }
    }
}
