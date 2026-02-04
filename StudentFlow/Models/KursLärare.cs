using System;
using System.Collections.Generic;

namespace SkolSystem.Models;

public partial class KursLärare
{
    public int KursLärareId { get; set; }

    public int KursId { get; set; }

    public int LärareId { get; set; }

    public virtual Kurser Kurs { get; set; } = null!;

    public virtual Lärare Lärare { get; set; } = null!;
}
