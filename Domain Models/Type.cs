using System;
using System.Collections.Generic;

namespace Domain_Models;

public partial class Type
{
    public int Id { get; set; }

    public string Type1 { get; set; } = null!;

    public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
}
