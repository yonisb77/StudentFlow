🎓 StudentFlow – Management System
StudentFlow är en kraftfull konsolapplikation utvecklad i C# och .NET. Systemet är byggt för att centralisera hanteringen av elever, kurser och betyg genom en robust integration med SQL Server via Entity Framework Core. Med ett fokus på stabilitet och användarvänlighet erbjuder StudentFlow en tydlig översikt av skolans administrativa flöden.

🛠 Teknisk Stack
Språk: C# 11

Ramverk: .NET 7

ORM: Entity Framework Core (Database First)

Databas: SQL Server

Datahantering: LINQ för avancerad filtrering och rapportgenerering

✨ Funktioner
📋 Administration (CRUD)
Elevregister: Lista alla elever med unika ID-nummer. Möjlighet att lägga till nya elever eller radera befintliga.

Smart Radering: Vid borttagning av en elev rensas automatiskt alla tillhörande kursregistreringar för att förhindra databasfel (Foreign Key integrity).

Kursöversikt: Se alla kurser och deras kopplade klassrum.

Registreringsmotor: Registrera elever på kurser med inbyggd kontroll som förhindrar dubbelregistreringar.

Betygshantering: Uppdatera betyg med strikt validering (endast G eller IG).

📊 Rapportering
Elever per kurs: Genererar en visuell rapport som listar varje kurs och tillhörande elever med hjälp av optimerade LINQ-projektioner.

🛡️ Stabilitet & UX
Datavalidering: Inbyggda hjälpmetoder (LäsHeltal, LäsBetyg) som säkerställer att användaren anger korrekt data utan att programmet kraschar.

Exception Handling: Global felhantering med try-catch för säkra databasanrop.

Visuellt UI: Fullt stöd för UTF-8 vilket ger en modern känsla med emojis och tydliga menyer direkt i terminalen.
