using System;
using System.Collections.Generic;

namespace SkolSystem.Models;

public partial class Lärare
{
    public int LärareId { get; set; }

    public string Förnamn { get; set; } = null!;

    public string Efternamn { get; set; } = null!;

    public DateTime SkapadDatum { get; set; }

    public virtual ICollection<KursLärare> KursLärares { get; set; } = new List<KursLärare>();
}
