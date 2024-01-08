using EmerAgency.Models;
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
using System.Windows.Shapes;

namespace EmerAgency
{
    /// <summary>
    /// Логика взаимодействия для JobSeekerLogin.xaml
    /// </summary>
    public partial class JobSeekerLogin : Window
    {
        private static EmploymentAgencyContext ctx = new EmploymentAgencyContext();

        public JobSeekerLogin()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool AuthUser(int login, string password)
        {
            var query = from jobseeker in ctx.Jobseekers
                        where jobseeker.JobSeekerId == login && jobseeker.LastName == password
                        select jobseeker;
            var found = query.ToList().First();
            if (found != null)
                return true;
            return false;
        }
        private void JobSeekerLoginButton_Click(object sender, RoutedEventArgs e)
        {
            AuthUser(Convert.ToInt32(jobSeekerUsernameTextBox.Text), jobSeekerPasswordBox.Password);
            JobSeekerDashboard jobSeekerDashboard = new JobSeekerDashboard(Convert.ToInt32(jobSeekerUsernameTextBox.Text));
            this.Hide();
            jobSeekerDashboard.ShowDialog();
            this.Show();
        }

        private void JobSeekerRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            EmployerRegistration jobSeekerRegistration = new EmployerRegistration();
            this.Hide();
            jobSeekerRegistration.ShowDialog();
            this.Show();
        }
    }
}
