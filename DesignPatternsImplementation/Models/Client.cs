using System;
using System.Collections.Generic;

namespace DesignPatternsImplementation.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? Age { get; set; }
}
