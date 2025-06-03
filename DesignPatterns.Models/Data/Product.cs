using System;
using System.Collections.Generic;

namespace DesignPatterns.Models.Data;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public short UnitsInStock { get; set; }

    public decimal UnitPrice { get; set; }
}
