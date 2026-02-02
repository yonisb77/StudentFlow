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
                Console.WriteLine("📚 === SkolSystem Meny === 📚");
                Console.WriteLine("1️⃣  Lista elever");
                Console.WriteLine("2️⃣  Lista kurser");
                Console.WriteLine("3️⃣  Registrera elev på kurs");
                Console.WriteLine("4️⃣  Uppdatera betyg");
                Console.WriteLine("5️⃣  Ta bort elev");
                Console.WriteLine("6️⃣  Rapport: Elever per kurs");
                Console.WriteLine("0️⃣  Avsluta");
                Console.Write("👉 Val: ");

                var input = Console.ReadLine()?.Trim() ?? "";

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
                        Console.ReadLine();
                        break;
                }
            }
        }

        // ====== Hjälpmetoder för validering ======
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

        // ====== Lista ======
        static void ListaElever(SkolaDbContext db)
        {
            Console.Clear();
            Console.WriteLine("👩‍🎓 === Elever ===");
            var elever = db.Studenters.ToList();
            if (!elever.Any()) Console.WriteLine("⚠️ Inga elever registrerade.");
            foreach (var e in elever)
                Console.WriteLine($"🆔 {e.StudentId}: {e.Förnamn} {e.Efternamn}");
            Console.WriteLine("Tryck enter för att återgå...");
            Console.ReadLine();
        }

        static void ListaKurser(SkolaDbContext db)
        {
            Console.Clear();
            Console.WriteLine("📖 === Kurser ===");
            var kurser = db.Kursers.Include(k => k.Klassrum).ToList();
            if (!kurser.Any()) Console.WriteLine("⚠️ Inga kurser registrerade.");
            foreach (var k in kurser)
                Console.WriteLine($"🆔 {k.KursId}: {k.Kursnamn} - Klassrum: {k.Klassrum?.Namn ?? "Ej tilldelat"}");
            Console.WriteLine("Tryck enter för att återgå...");
            Console.ReadLine();
        }

        // ====== Registrera relation ======
        static void RegistreraElev(SkolaDbContext db)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("📝 Registrera elev på kurs");
                int elevId = LäsHeltal("ElevId: ");
                int kursId = LäsHeltal("KursId: ");

                if (db.Registreringars.Any(r => r.StudentId == elevId && r.KursId == kursId))
                {
                    Console.WriteLine("⚠️ Eleven är redan registrerad på kursen.");
                    Console.ReadLine();
                    return;
                }

                db.Registreringars.Add(new Registreringar { StudentId = elevId, KursId = kursId });
                db.SaveChanges();
                Console.WriteLine("✅ Elev registrerad på kursen!");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"💥 Fel: {ex.Message}");
                Console.ReadLine();
            }
        }

        // ====== Uppdatera betyg ======
        static void UppdateraBetyg(SkolaDbContext db)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("✏️ Uppdatera betyg");
                int elevId = LäsHeltal("ElevId: ");
                int kursId = LäsHeltal("KursId: ");

                var reg = db.Registreringars.FirstOrDefault(r => r.StudentId == elevId && r.KursId == kursId);
                if (reg == null)
                {
                    Console.WriteLine("⚠️ Eleven är inte registrerad på kursen.");
                    Console.ReadLine();
                    return;
                }

                reg.Betyg = LäsBetyg("Betyg (IG/G): ");
                db.SaveChanges();
                Console.WriteLine("✅ Betyg uppdaterat!");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"💥 Fel: {ex.Message}");
                Console.ReadLine();
            }
        }

        // ====== Ta bort elev ======
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
                    Console.ReadLine();
                    return;
                }

                var kopplingar = db.Registreringars.Where(r => r.StudentId == elevId).ToList();
                db.Registreringars.RemoveRange(kopplingar);
                db.Studenters.Remove(elev);
                db.SaveChanges();
                Console.WriteLine("✅ Elev borttagen!");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"💥 Fel: {ex.Message}");
                Console.ReadLine();
            }
        }

        // ====== Rapport ======
        static void RapportEleverPerKurs(SkolaDbContext db)
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
            Console.WriteLine("\nTryck enter för att återgå...");
            Console.ReadLine();
        }
    }
}
