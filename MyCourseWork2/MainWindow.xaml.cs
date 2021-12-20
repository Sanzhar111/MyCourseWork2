using System.Windows;
namespace MyCourseWork2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Registrator_Click(object sender, RoutedEventArgs e)
        {
            Hide();// прячется окно  MainWindow
            var con = new Registrator().GetCon();
            if (con.chekValid()) new Users(con).ShowDialog();
            Show();
        }
        private void Administrator_Click(object sender, RoutedEventArgs e)
        {
            Hide();// прячется окно  MainWindow
            var con = new Registrator().GetCon();
            if (con.chekValid()) new Administrator(con).ShowDialog();
            Show();
        }
    }

}
