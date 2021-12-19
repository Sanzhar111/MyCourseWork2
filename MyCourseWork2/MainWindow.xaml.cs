using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
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
