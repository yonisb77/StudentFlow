using System;
using System.Collections.Generic;

namespace SkolSystem.Models;

public partial class VwRegistreringarRapport
{
    public string Förnamn { get; set; } = null!;

    public string Efternamn { get; set; } = null!;

    public string Kursnamn { get; set; } = null!;

    public string? Betyg { get; set; }

    public DateTime SkapadDatum { get; set; }
}
