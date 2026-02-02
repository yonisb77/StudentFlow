using System;
using System.Linq;                 // behövs för ToList(), Where, GroupBy
using SkolSystem.Models;          // ditt scaffold-namespace
using Microsoft.EntityFrameworkCore; // behövs för Add(), Find(), SaveChanges() osv.



namespace SkolSystem.Models;

public partial class Studenter
{
    public int StudentId { get; set; }

    public string Förnamn { get; set; } = null!;

    public string Efternamn { get; set; } = null!;

    public DateTime SkapadDatum { get; set; }

    public virtual ICollection<Registreringar> Registreringars { get; set; } = new List<Registreringar>();
}
