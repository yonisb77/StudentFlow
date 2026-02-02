using System;
using System.Collections.Generic;

namespace SkolSystem.Models;

public partial class Kurser
{
    public int KursId { get; set; }

    public string Kursnamn { get; set; } = null!;

    public DateTime SkapadDatum { get; set; }

    public int? KlassrumId { get; set; }

    public virtual Klassrum? Klassrum { get; set; }

    public virtual ICollection<KursLärare> KursLärares { get; set; } = new List<KursLärare>();

    public virtual ICollection<Registreringar> Registreringars { get; set; } = new List<Registreringar>();
}
