using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearningAPI;

public partial class Datum
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public string? Gender { get; set; }
}
