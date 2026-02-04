# 🎓 StudentFlow – Management System

**StudentFlow** är en kraftfull och användarvänlig konsolapplikation utvecklad i **C# och .NET**, framtagen för att effektivisera och centralisera hanteringen av **elever, kurser och betyg**. Systemet använder **Entity Framework Core (Database First)** tillsammans med **SQL Server** för stabil, säker och skalbar datahantering.

---

## 🚀 Funktioner i korthet

* Fullständig **CRUD-hantering** av elever och kurser
* Säker **registrering av elever på kurser** med skydd mot dubbelregistrering
* **Automatisk rensning av beroenden** vid borttagning (Foreign Key-säkerhet)
* **Betygshantering** med strikt validering (endast `G` eller `IG`)
* **Rapportering** med LINQ för tydlig översikt av elever per kurs
* Stabil konsol-UX med **UTF-8-stöd och emojis**

---

## 🛠 Teknisk Stack

| Komponent       | Teknik                                 |
| --------------- | -------------------------------------- |
| Språk           | C# 11                                  |
| Ramverk         | .NET 7                                 |
| ORM             | Entity Framework Core (Database First) |
| Databas         | SQL Server                             |
| Datahantering   | LINQ                                   |
| Applikationstyp | Konsolapplikation                      |

---

## 📋 Administration (CRUD)

### 👩‍🎓 Elevregister

* Lista alla elever med **unika ID-nummer**
* Lägg till nya elever
* Ta bort befintliga elever

### 🧹 Smart radering

* Vid borttagning av en elev raderas **alla tillhörande kursregistreringar automatiskt**
* Förhindrar Foreign Key-konflikter och databaskrascher

### 📚 Kurshantering

* Visa alla kurser
* Se kopplade klassrum per kurs

### 🧩 Registreringsmotor

* Registrera elever på kurser
* Inbyggd logik som **förhindrar dubbelregistrering**

### 📝 Betygshantering

* Uppdatera betyg per elev och kurs
* Endast giltiga betyg tillåts: **G / IG**

---

## 📊 Rapportering

### 📈 Elever per kurs

* Genererar en tydlig rapport som listar:

  * Kursnamn
  * Tillhörande elever
* Bygger på **optimerade LINQ-projektioner** för prestanda och läsbarhet

---

## 🛡️ Stabilitet & Användarupplevelse

### ✅ Datavalidering

* Hjälpmetoder som:

  * `LäsHeltal()` – säker inmatning av numeriska värden
  * `LäsBetyg()` – säkerställer korrekt betygsformat
* Förhindrar felaktig input och programkrascher

### 🔐 Exception Handling

* Alla databasanrop är inkapslade i `try-catch`
* Ger tydliga felmeddelanden utan att applikationen avslutas oväntat

### 🎨 Konsol-UI

* Fullt **UTF-8-stöd**
* Emojis och tydliga menyer för modern känsla
* Enkel navigering direkt i terminalen

---

## 🏗 Arkitektur

* **Database First** – databasen är källan till sanningen
* Tydlig separation mellan:

  * Datamodeller
  * Logik
  * Användarinteraktion
* Skalbar struktur som enkelt kan byggas ut

---

## ▶️ Kom igång

1. Klona projektet
2. Säkerställ att SQL Server är installerat
3. Uppdatera connection string i `appsettings.json`
4. Kör applikationen via Visual Studio eller `dotnet run`

---

## 📌 Sammanfattning

**StudentFlow** är ett stabilt, pedagogiskt och välstrukturerat system som lämpar sig perfekt för:

* Skolprojekt
* Inlärning av EF Core & LINQ
* Demonstration av CRUD, relationer och dataintegritet

---

💡 *Utvecklat med fokus på kodkvalitet, stabilitet och tydlig användarupplevelse.*
