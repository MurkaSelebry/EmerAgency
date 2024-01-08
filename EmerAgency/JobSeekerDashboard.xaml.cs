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
    /// Логика взаимодействия для JobSeekerDashboard.xaml
    /// </summary>
    public partial class JobSeekerDashboard : Window
    {
        private static EmploymentAgencyContext ctx = new EmploymentAgencyContext();
        private Jobseeker j = new Jobseeker();
        public JobSeekerDashboard()
        {
            InitializeComponent();
            j = ctx.Jobseekers.ToList().Last();
            var query = from vacancy in ctx.Vacancies
                        join employer in ctx.Employers on vacancy.EmployerId equals employer.EmployerId
                        select $"Вакансия: {vacancy.Description}\nОжидаемая зп: от {vacancy.StartingSalary}\nРаботодатель: {employer.Name}";
            
            jobSeekerVacancyListBox.ItemsSource = query.ToList();
        }
        public JobSeekerDashboard(int id)
        {
            InitializeComponent();
            j = ctx.Jobseekers.First(x => x.JobSeekerId == id);
            var query = from vacancy in ctx.Vacancies
                        join employer in ctx.Employers on vacancy.EmployerId equals employer.EmployerId
                        join activityType in ctx.Activitytypes on vacancy.TypeId equals activityType.TypeId
                        where j.ActivityType == activityType.Name
                        select $"Вакансия: {vacancy.Description}\nОжидаемая зп: от {vacancy.StartingSalary}\nРаботодатель: {employer.Name}";


            jobSeekerVacancyListBox.ItemsSource = query.ToList();
        }
        
        
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedJobSeeker = jobSeekerVacancyListBox.SelectedItem as string;

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
