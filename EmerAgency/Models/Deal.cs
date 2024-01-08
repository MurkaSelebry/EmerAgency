using System;
using System.Collections.Generic;

namespace EmerAgency.Models;

public partial class Deal
{
    public int DealId { get; set; }

    public int? JobSeekerId { get; set; }

    public int? EmployerId { get; set; }

    public string? Position { get; set; }

    public decimal? Commission { get; set; }

    public DateOnly? ClosingDate { get; set; }

    public virtual Employer? Employer { get; set; }

    public virtual Jobseeker? JobSeeker { get; set; }
}
