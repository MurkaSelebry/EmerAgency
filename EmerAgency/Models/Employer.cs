using System;
using System.Collections.Generic;

namespace EmerAgency.Models;

public partial class Employer
{
    public int EmployerId { get; set; }

    public string? Name { get; set; }

    public string? ActivityType { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Deal> Deals { get; } = new List<Deal>();

    public virtual ICollection<Vacancy> Vacancies { get; } = new List<Vacancy>();
}
