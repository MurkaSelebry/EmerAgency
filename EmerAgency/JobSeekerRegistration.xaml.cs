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
    /// Логика взаимодействия для JobSeekerRegistration.xaml
    /// </summary>
    public partial class JobSeekerRegistration : Window
    {
        private static EmploymentAgencyContext ctx = new EmploymentAgencyContext();

        public JobSeekerRegistration()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Employer j = new Employer()
            {
                Name = nameTextBox.Text,
                ActivityType = activityTextBox.Text,
                PhoneNumber = phoneTextBox.Text,
                Address = addressTextBox.Text
            };
            ctx.Employers.Add(j);
            ctx.SaveChanges();
            EmployerDashboard jobSeekerDashboard = new EmployerDashboard();
            this.Hide();
            jobSeekerDashboard.ShowDialog();
            this.Show();
        }
    }
}
