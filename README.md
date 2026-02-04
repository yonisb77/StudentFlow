📚 SkolSystem Console App
SkolSystem är en robust konsolapplikation byggd i .NET som hanterar elever, kurser och betyg. Genom att använda Entity Framework Core (Database First) kommunicerar applikationen effektivt med en SQL-databas för att erbjuda en stabil och användarvänlig hantering av skoladministration.

🚀 Funktioner
📝 Grundläggande hantering (CRUD)
Hantera Elever: Lista, lägg till och ta bort elever. Vid borttagning rensas även tillhörande kursregistreringar automatiskt.

Kursadministration: Visa en översikt av alla tillgängliga kurser.

Registrering: Registrera elever på specifika kurser på ett smidigt sätt.

Betygsättning: Uppdatera betyg för elever (validerat enligt skalan: IG eller G).

📊 Rapportering (LINQ)
Elever per kurs: Se en detaljerad lista över vilka elever som läser vilken kurs.

Skalbarhet: Arkitekturen är förberedd för att enkelt kunna expandera med fler rapporter (t.ex. medelbetyg eller kurser per elev).

⚡ Stabilitet & UX
Datavalidering: Inbyggd kontroll för att förhindra tomma strängar, felaktiga datumformat eller ogiltiga heltal.

Felhantering: Använder try-catch block för att säkerställa att programmet inte kraschar vid oväntade databas- eller inmatningsfel.

Visuell upplevelse: Fullt stöd för UTF-8 vilket tillåter användning av emojis och tydlig formatering i konsolen.

🛠 Teknologi
Runtime: .NET 7 / C# 11

ORM: Entity Framework Core 7 (Database First)

Databas: SQL Server

Query-språk: LINQ för effektiv datautvinning
