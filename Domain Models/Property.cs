using System;
using System.Collections.Generic;

namespace Domain_Models;

public partial class Property
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal Price { get; set; }

    public string Image { get; set; } = null!;

    public int Size { get; set; }

    public int Baths { get; set; }

    public int Rooms { get; set; }

    public string Address { get; set; } = null!;

    public int? ChoiseId { get; set; }

    public int? TypeId { get; set; }

    public int OwnerId { get; set; }

    public virtual Choise? Choise { get; set; }

    public virtual Owner Owner { get; set; } = null!;

    public virtual Type? Type { get; set; }
}
