using System;
using System.Collections.Generic;

namespace SkolSystem.Models;

public partial class VwStudenterPublic
{
    public int StudentId { get; set; }

    public string Förnamn { get; set; } = null!;

    public string Efternamn { get; set; } = null!;
}
