using System;
using System.Collections.Generic;

namespace EmerAgency.Models;

public partial class Vacancy
{
    public int VacancyId { get; set; }

    public int? EmployerId { get; set; }

    public string? Description { get; set; }

    public int? TypeId { get; set; }

    public decimal? StartingSalary { get; set; }

    public virtual Employer? Employer { get; set; }

    public virtual Activitytype? Type { get; set; }
}
