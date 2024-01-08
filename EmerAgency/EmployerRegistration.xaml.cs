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
    /// Логика взаимодействия для EmployerRegistration.xaml
    /// </summary>
    public partial class EmployerRegistration : Window
    {
        private static EmploymentAgencyContext ctx = new EmploymentAgencyContext();

        public EmployerRegistration()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Jobseeker j = new Jobseeker
            {
                LastName = surnameTextBox.Text,
                FirstName = nameTextBox.Text,
                Patronymic = patronymicTextBox.Text,
                Qualification = qualificationTextBox.Text,
                ActivityType = professionTextBox.Text,
                OtherData = otherDataTextBox.Text
            };
            ctx.Jobseekers.Add(j);
            ctx.SaveChanges();
            JobSeekerDashboard jobSeekerDashboard = new JobSeekerDashboard();
            this.Hide();
            jobSeekerDashboard.ShowDialog();
            this.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
