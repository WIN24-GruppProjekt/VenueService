# VenueService

VenueService is a .NET 9 Web API for managing **gym locations** and their **training rooms**.  
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
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- SQL Server (local or cloud)
- A connection string in an `appsettings.json` file such as:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=VenueDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

## 📌 API Endpoints

### Locations

| Method | Endpoint              | Description         |
| ------ | --------------------- | ------------------- |
| GET    | `/api/locations`      | Get all locations   |
| GET    | `/api/locations/{id}` | Get location by ID  |
| POST   | `/api/locations`      | Create new location |
| PUT    | `/api/locations/{id}` | Update location     |
| DELETE | `/api/locations/{id}` | Delete location     |


### Location Rooms

| Method | Endpoint                                | Description                  |
| ------ | --------------------------------------- | ---------------------------- |
| GET    | `/api/locationrooms`                    | Get all rooms                |
| GET    | `/api/locationrooms/{id}`               | Get room by ID               |
| GET    | `/api/locationrooms/{locationId}/rooms` | Get all rooms for a location |
| POST   | `/api/locationrooms`                    | Create new room              |
| PUT    | `/api/locationrooms/{id}`               | Update room                  |
| DELETE | `/api/locationrooms/{id}`               | Delete room                  |


## 🧪 Example Requests

### Create Location
```json
POST /api/locations
Content-Type: application/json

{
  "name": "Downtown Gym",
  "address": "123 Main St",
  "postalCode": "12345",
  "telephone": "+1-555-123-4567",
  "email": "contact@downtowngym.com",
  "opensAt": "06:00:00",
  "closesAt": "22:00:00"
}
```

### Create Room
```json
POST /api/locationrooms
Content-Type: application/json

{
  "roomName": "Yoga Studio",
  "roomCapacity": 30,
  "locationId": "location-guid-here"
}
```

## 🛠️ Tech Stack

- .NET 9
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI
- Dependency Injection


