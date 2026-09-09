# Netwise Rekrutacja – Cat Facts Storage API

[![.NET 8](https://img.shields.io/badge/.NET-8.0-purple.svg)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/Language-C%23-blue.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Swagger](https://img.shields.io/badge/API_Docs-Swagger-brightgreen.svg)](https://swagger.io/)

Aplikacja Web API napisana w **.NET 8 (Minimal APIs)** przygotowana na potrzeby zadania rekrutacyjnego dla firmy **Netwise**. Aplikacja pobiera dane z zewnętrznego API (`catfact.ninja`), waliduje je i zapisuje na dysku za pomocą serwisu plikowego.

---

## 📌 O projekcie

Aplikacja udostępnia punkt końcowy, który w sposób asynchroniczny i bezpieczny pobiera dane o kotach i zapisuje je lokalnie.

### Główny endpoint:
* **`POST /saveToFile`** – Odpytuje zewnętrzne API `https://catfact.ninja/fact`, dokonuje walidacji odpowiedzi, a następnie zapisuje obiekt `CatFact` do pliku za pośrednictwem dedykowanego serwisu `IFileStorageService`.

### Kluczowe cechy rozwiązania:
- **Minimal APIs** – lekki i wydajny punkt końcowy w .NET 8.
- **Wzorzec Repository/Service** – wydzielona logika zapisu do interfejsu `IFileStorageService` i wstrzykiwanie zależności (Dependency Injection).
- **Bezpieczeństwo i Asynchroniczność** – wykorzystanie `IHttpClientFactory` oraz natywnej obsługi `CancellationToken`.
- **Obsługa błędów i walidacja:**
  - Walidacja pustych lub niepoprawnych danych (`406 Not Acceptable`).
  - Obsługa przekroczenia czasu żądania HTTP (`504 Gateway Timeout`).
  - Przechwytywanie wyjątków połączenia z logowaniem błędów (`502 Bad Gateway`).
- **Dokumentacja API** – zintegrowany Swagger UI w środowisku deweloperskim.

---

## 🛠 Technologie i biblioteki

- **Platforma:** .NET 8.0 (ASP.NET Core Web API)
- **Język:** C# 12
- **Dokumentacja:** Swashbuckle / Swagger UI (`Swashbuckle.AspNetCore`)
- **Klient HTTP:** `IHttpClientFactory` z `System.Net.Http.Json`

---

## ⚙️ Wymagania wstępne

* **.NET 8.0 SDK** ([Pobierz .NET 8](https://dotnet.microsoft.com/download/dotnet/8.0))
* Dowolne IDE wspierające .NET (Visual Studio 2022, JetBrains Rider, VS Code)

---

## 🚀 Uruchomienie projektu

### 1. Sklonuj repozytorium
```bash
git clone [https://github.com/SeBaK28/NetwiseRekrutacja.git](https://github.com/SeBaK28/NetwiseRekrutacja.git)
cd NetwiseRekrutacja
