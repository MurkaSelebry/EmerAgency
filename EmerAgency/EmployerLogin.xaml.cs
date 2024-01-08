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
    /// Логика взаимодействия для EmployerLogin.xaml
    /// </summary>
    public partial class EmployerLogin : Window
    {
        public EmployerLogin()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EmployerLoginButton_Click(object sender, RoutedEventArgs e)
        {
            EmployerDashboard employerDashboard = new EmployerDashboard(Convert.ToInt32(employerUsernameTextBox.Text));
            this.Hide();
            employerDashboard.ShowDialog();
            this.Show();
        }

        private void EmployerRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            JobSeekerRegistration employerRegistration = new JobSeekerRegistration();
            this.Hide();
            employerRegistration.ShowDialog();
            this.Show();
        }
    }
}
