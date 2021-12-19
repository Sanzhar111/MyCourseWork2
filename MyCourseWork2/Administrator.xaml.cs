using System.Windows;

namespace MyCourseWork2
{
    /// <summary>
    /// Логика взаимодействия для Administrator.xaml
    /// </summary>
    public partial class Administrator : Window
    {
        public Administrator()
        {
            InitializeComponent();
        }

        private void InsertPatient(object sender, RoutedEventArgs e)
        {
            RegistrationPatient registerForm = new RegistrationPatient();
            registerForm.Show();
            
        }
    }
}
