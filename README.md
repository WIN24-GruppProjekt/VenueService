# VenueService

VenueService is a .NET 8 Web API for managing **gym locations** and their **training rooms**.  
It provides CRUD operations for locations and rooms, enforces data validation, and exposes REST endpoints for easy integration with other systems.

---

## ✨ Features

- Manage **locations** (gym branches)
  - Store name, address, postal code, phone, email
  - Define opening & closing hours
  - Associate multiple training rooms with a location

- Manage **location rooms**
  - Create, update, and delete rooms
  - Enforce capacity limits
  - Fetch rooms by location

- REST API with Swagger documentation
- Data validation using `System.ComponentModel.DataAnnotations`
- Entity Framework Core with SQL Server
- Layered architecture:
  - **Persistence** (Entities, DbContext, Repositories)
  - **Application** (DTOs, Models, Services)
  - **Presentation** (Controllers / API endpoints)

---

## 📂 Project Structure

```
VenueService/
│── Application/
│ ├── DTOs/ # Request models (CreateLocationRequest, CreateLocationRoomRequest)
│ ├── Models/ # Domain models & result wrappers
│ └── Services/ # Interfaces for location & room services
│
│── Persistence/
│ ├── Contexts/ # DbContext
│ ├── Entities/ # EF Core entities (LocationEntity, LocationRoomEntity)
│ └── Repositories/ # Data access layer
│
│── Presentation/
│ └── Controllers/ # API controllers (LocationsController, LocationRoomsController)
│
│── Program.cs # Entry point & dependency injection
```
---

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (local or cloud)
- A connection string in `appsettings.json` such as:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=VenueDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```



