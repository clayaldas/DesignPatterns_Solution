using System;
using System.Collections.Generic;

namespace DesignPatterns.Models.Data;

public partial class Category
{
    public Guid CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
