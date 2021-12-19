using System.Windows;
namespace MyCourseWork2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Registrator_Click(object sender, RoutedEventArgs e)
        {
            Hide();// прячется окно  MainWindow
            Registrator registerForm = new Registrator();
            registerForm.Show();
            Close();
        }

        private void Administrator_Click(object sender, RoutedEventArgs e)
        {
            Hide();// прячется окно  MainWindow
            RegistratorForAdministrator registerForm = new RegistratorForAdministrator();
            registerForm.Show();
            Close();
        }
    }

}
