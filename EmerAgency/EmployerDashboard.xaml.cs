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
    /// Логика взаимодействия для EmployerDashboard.xaml
    /// </summary>
    public partial class EmployerDashboard : Window
    {
        private static EmploymentAgencyContext ctx = new EmploymentAgencyContext();
        private Employer e = new Employer();
      
        public EmployerDashboard()
        {
            InitializeComponent();
            e = ctx.Employers.ToList().Last();
            var query = from jobSeeker in ctx.Jobseekers
                        join employer in ctx.Employers on jobSeeker.ActivityType equals employer.ActivityType
                        where employer.EmployerId == e.EmployerId
                        select $"{jobSeeker.LastName} {jobSeeker.FirstName} {jobSeeker.Patronymic}\nКвалификация: {jobSeeker.Qualification}\nДругие данные: {jobSeeker.OtherData}\nОжидаемая з/п: {jobSeeker.ExpectedSalary}";
            matchingJobSeekersListBox.ItemsSource = query.ToList();
        }
        public EmployerDashboard(int id)
        {
            InitializeComponent();
            e = ctx.Employers.First(x => x.EmployerId == id);
            var query = from jobSeeker in ctx.Jobseekers
                        join employer in ctx.Employers on jobSeeker.ActivityType equals employer.ActivityType
                        where employer.EmployerId == e.EmployerId
                        select $"{jobSeeker.LastName} {jobSeeker.FirstName} {jobSeeker.Patronymic}\nКвалификация: {jobSeeker.Qualification}\nДругие данные: {jobSeeker.OtherData}\nОжидаемая з/п: {jobSeeker.ExpectedSalary}";
            matchingJobSeekersListBox.ItemsSource = query.ToList();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       

        private void SignContractButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedJobSeeker = matchingJobSeekersListBox.SelectedItem as string;

            Deal d = new Deal
            {
                JobSeekerId = 1,
                EmployerId = 1,
                Position = "Специалист",
                Commission = 5000,
                ClosingDate = DateOnly.FromDateTime(DateTime.Now)
            };
            ctx.Deals.Add(d);
            ctx.SaveChanges();

            string dataToWrite = $"{selectedJobSeeker}, Комиссия: {d.Commission}, Дата закрытия: {d.ClosingDate}";

            string fileName = $"{selectedJobSeeker.Split(' ')[0]}_{DateTime.Now:yyyyMMdd}.txt";

            System.IO.File.WriteAllText(fileName, dataToWrite);

        }
    }
}
