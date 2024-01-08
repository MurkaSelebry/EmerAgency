using System;
using System.Collections.Generic;

namespace EmerAgency.Models;

public partial class Jobseeker
{
    public int JobSeekerId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Patronymic { get; set; }

    public string? Qualification { get; set; }

    public string? ActivityType { get; set; }

    public string? OtherData { get; set; }

    public decimal? ExpectedSalary { get; set; }

    public virtual ICollection<Deal> Deals { get; } = new List<Deal>();
}
