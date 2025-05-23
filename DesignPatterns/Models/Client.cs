﻿using System;
using System.Collections.Generic;

namespace DesignPatterns.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? Age { get; set; }
}
