using System;
using System.Collections.Generic;

namespace EmerAgency.Models;

public partial class Activitytype
{
    public int TypeId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Vacancy> Vacancies { get; } = new List<Vacancy>();
}
