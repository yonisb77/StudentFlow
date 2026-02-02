using System;
using System.Collections.Generic;

namespace SkolSystem.Models;

public partial class Klassrum
{
    public int KlassrumId { get; set; }

    public string Namn { get; set; } = null!;

    public int MaxAntal { get; set; }

    public DateTime SkapadDatum { get; set; }

    public virtual ICollection<Kurser> Kursers { get; set; } = new List<Kurser>();
}
