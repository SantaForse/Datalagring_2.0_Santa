using System;
using System.Collections.Generic;

namespace Final_Santa.Models.Entities;

public partial class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Errand> Errands { get; } = new List<Errand>();
}
