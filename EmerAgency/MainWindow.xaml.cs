using EmerAgency.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmerAgency
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //var ctx = new EmploymentAgencyContext();
            //var newJ = new Jobseeker
            //{
            //    LastName = "Fill"
            //};
            //ctx.Jobseekers.Add(newJ);
            //ctx.SaveChanges();
        }

        private void EmployerButton_Click(object sender, RoutedEventArgs e)
        {
            EmployerLogin employerLogin = new EmployerLogin();
            this.Hide();
            employerLogin.ShowDialog();
            this.Show();
        }

        private void JobSeekerButton_Click(object sender, RoutedEventArgs e)
        {
            JobSeekerLogin jobSeekerLogin = new JobSeekerLogin();
            this.Hide();
            jobSeekerLogin.ShowDialog();
            this.Show();
        }
    }
}