using System;
using System.Collections.Generic;

namespace Domain_Models;

public partial class Address
{
    public int Id { get; set; }

    public string? Street { get; set; }

    public string Sector { get; set; } = null!;

    public string City { get; set; } = null!;

    public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
}
