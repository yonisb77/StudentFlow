using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SkolSystem.Models;

namespace SkolSystemApp
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            using var db = new SkolaDbContext();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("📚 === Skolsystem === 📚");
                Console.WriteLine("1️  Lista elever");
                Console.WriteLine("2️  Lista kurser");
                Console.WriteLine("3️  Registrera elev på kurs");
                Console.WriteLine("4️  Ge/uppdatera betyg");
                Console.WriteLine("5️  Ta bort elev");
                Console.WriteLine("6️  Antalet Elever per kurs");
                Console.WriteLine("7  Avsluta");
                Console.Write("👉 Val: ");

                string input = Console.ReadLine()?.Trim() ?? "";

                switch (input)
                {
                    case "1": ListaElever(db); break;
                    case "2": ListaKurser(db); break;
                    case "3": RegistreraElev(db); break;
                    case "4": UppdateraBetyg(db); break;
                    case "5": TaBortElev(db); break;
                    case "6": RapportEleverPerKurs(db); break;
                    case "0":
                        Console.WriteLine("👋 Hejdå!");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("❌ Fel val, försök igen!");
                        Vänta();
                        break;
                }
            }
        }

        // ======= Hjälpmetoder =======
        static int LäsHeltal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine()?.Trim(), out int value))
                    return value;
                Console.WriteLine("⚠️ Felaktig inmatning, ange ett heltal.");
            }
        }

        static string LäsBetyg(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string betyg = (Console.ReadLine()?.Trim().ToUpper()) ?? "";
                if (betyg == "IG" || betyg == "G")
                    return betyg;
                Console.WriteLine("⚠️ Ogiltigt betyg. Endast IG eller G är tillåtet.");
            }
        }

        static void Vänta()
        {
            Console.WriteLine("Tryck enter för att fortsätta...");
            Console.ReadLine();
        }

        // ======= Lista elever och kurser =======
        static void ListaElever(SkolaDbContext db)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("👩‍🎓 === Elever ===");
                var elever = db.Studenters.ToList();
                if (!elever.Any()) Console.WriteLine("⚠️ Inga elever registrerade.");
                foreach (var e in elever)
                    Console.WriteLine($"🆔 {e.StudentId}: {e.Förnamn} {e.Efternamn}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"💥 Fel vid lista elever: {ex.Message}");
            }
            Vänta();
        }

        static void ListaKurser(SkolaDbContext db)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("📖 === Kurser ===");
                var kurser = db.Kursers.Include(k => k.Klassrum).ToList();
                if (!kurser.Any()) Console.WriteLine("⚠️ Inga kurser registrerade.");
                foreach (var k in kurser)
                    Console.WriteLine($"🆔 {k.KursId}: {k.Kursnamn} - Klassrum: {k.Klassrum?.Namn ?? "Ej tilldelat"}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"💥 Fel vid lista kurser: {ex.Message}");
            }
            Vänta();
        }

        // ======= Registrera elev på kurs =======
        static void RegistreraElev(SkolaDbContext db)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("📝 Registrera elev på kurs");

                int elevId;
                while (true)
                {
                    elevId = LäsHeltal("ElevId: ");
                    if (db.Studenters.Any(e => e.StudentId == elevId)) break;
                    Console.WriteLine("⚠️ Ingen elev med det ID, försök igen.");
                }

                int kursId;
                while (true)
                {
                    kursId = LäsHeltal("KursId: ");
                    if (db.Kursers.Any(k => k.KursId == kursId)) break;
                    Console.WriteLine("⚠️ Ingen kurs med det ID, försök igen.");
                }

                if (db.Registreringars.Any(r => r.StudentId == elevId && r.KursId == kursId))
                {
                    Console.WriteLine("⚠️ Eleven är redan registrerad på kursen.");
                    Vänta();
                    return;
                }

                db.Registreringars.Add(new Registreringar { StudentId = elevId, KursId = kursId });
                db.SaveChanges();
                Console.WriteLine("✅ Elev registrerad på kursen!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"💥 Fel vid registrering: {ex.Message}");
            }
            Vänta();
        }

        // ======= Ge / uppdatera betyg =======
        static void UppdateraBetyg(SkolaDbContext db)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("✏️ Ge/uppdatera betyg");

                int elevId;
                while (true)
                {
                    elevId = LäsHeltal("ElevId: ");
                    if (db.Studenters.Any(e => e.StudentId == elevId)) break;
                    Console.WriteLine("⚠️ Ingen elev med det ID, försök igen.");
                }

                int kursId;
                while (true)
                {
                    kursId = LäsHeltal("KursId: ");
                    if (db.Kursers.Any(k => k.KursId == kursId)) break;
                    Console.WriteLine("⚠️ Ingen kurs med det ID, försök igen.");
                }

                var reg = db.Registreringars.FirstOrDefault(r => r.StudentId == elevId && r.KursId == kursId);
                if (reg == null)
                {
                    Console.WriteLine("⚠️ Eleven är inte registrerad på kursen.");
                    Vänta();
                    return;
                }

                reg.Betyg = LäsBetyg("Betyg (IG/G): ");
                db.SaveChanges();
                Console.WriteLine("✅ Betyg uppdaterat!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"💥 Fel vid uppdatera betyg: {ex.Message}");
            }
            Vänta();
        }

        // ======= Ta bort elev =======
        static void TaBortElev(SkolaDbContext db)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("🗑️ Ta bort elev");

                int elevId = LäsHeltal("ElevId som ska tas bort: ");
                var elev = db.Studenters.FirstOrDefault(s => s.StudentId == elevId);
                if (elev == null)
                {
                    Console.WriteLine("⚠️ Ingen elev med det ID.");
                    Vänta();
                    return;
                }

                var kopplingar = db.Registreringars.Where(r => r.StudentId == elevId).ToList();
                db.Registreringars.RemoveRange(kopplingar);
                db.Studenters.Remove(elev);
                db.SaveChanges();
                Console.WriteLine("✅ Elev borttagen!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"💥 Fel vid ta bort elev: {ex.Message}");
            }
            Vänta();
        }

        // ======= Rapport =======
        static void RapportEleverPerKurs(SkolaDbContext db)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("📊 Rapport: Elever per kurs");

                var resultat = db.Kursers
                    .Select(k => new
                    {
                        Kurs = k.Kursnamn,
                        Elever = k.Registreringars.Select(r => r.Student.Förnamn + " " + r.Student.Efternamn).ToList()
                    }).ToList();

                foreach (var k in resultat)
                {
                    Console.WriteLine($"\n📚 Kurs: {k.Kurs}");
                    if (!k.Elever.Any()) Console.WriteLine("  ⚠️ Inga registrerade elever.");
                    else foreach (var elev in k.Elever)
                            Console.WriteLine("  🧑‍🎓 " + elev);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"💥 Fel vid rapport: {ex.Message}");
            }
            Vänta();
        }
    }
}
