using System;
using System.Collections.Generic;

namespace MainApp.Models;

public partial class Learner
{
    public int LearnerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Country { get; set; }

    public string? CulturalBackground { get; set; }
}
