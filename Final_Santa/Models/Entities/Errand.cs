using System;
using System.Collections.Generic;

namespace Final_Santa.Models.Entities;

public partial class Errand
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string ErrandDescription { get; set; } = null!;

    public DateTime ErrandDate { get; set; }

    public int ErrandStatus { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
