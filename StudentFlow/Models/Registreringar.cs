using System;
using System.Collections.Generic;

namespace SkolSystem.Models;

public partial class Registreringar
{
    public int RegistreringId { get; set; }

    public int StudentId { get; set; }

    public int KursId { get; set; }

    public string? Betyg { get; set; }

    public DateTime SkapadDatum { get; set; }

    public virtual Kurser Kurs { get; set; } = null!;

    public virtual Studenter Student { get; set; } = null!;
}
