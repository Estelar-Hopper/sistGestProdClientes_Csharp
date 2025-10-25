# Customer and Order Management System

This project is a **RESTful API** built with **.NET 8**.  
It follows the **Domain-Driven Design (DDD)** architecture pattern to keep the code clean, organized, and easy to maintain.  
The system allows managing **customers**, **orders**, **order details**, and **products** in a structured way.

---

## Architecture Overview

The project is divided into **four layers**, each one with a clear responsibility:

### 1. API Layer
This layer contains the **controllers** and **endpoints**.  
Each entity (Customer, Order, OrderDetail, Product) has its own controller and endpoint for CRUD operations.  
The controllers receive HTTP requests, call the Application layer, and return HTTP responses.

### 2. Application Layer
This layer contains the **services**.  
It includes all **business logic**, data validation, and communication between the API and the Domain layer.

### 3. Domain Layer
This layer defines the **core entities** and the **domain models** used in the system:
- **Customer** – basic client information  
- **Order** – general order data  
- **OrderDetail** – details about each product in an order  
- **Product** – information about items that can be sold  

The Domain layer is independent of other layers.

### 4. Infrastructure Layer
This layer manages the **database connection** and **data persistence**.  
It uses **Entity Framework Core** with **MySQL**.  
Here you can find the **DbContext** class and the **repositories** that handle CRUD operations.

---

## Technologies Used
- .NET 8  
- Entity Framework Core  
- MySQL  
- C#  
- Clean Architecture / DDD pattern

---

## Installation

Before running the project, install the necessary **NuGet packages** for Entity Framework Core and MySQL.

### Install in the Infrastructure Project
```bash
dotnet add ApiRestFul.Infrastructure package Microsoft.EntityFrameworkCore
dotnet add ApiRestFul.Infrastructure package Microsoft.EntityFrameworkCore.Design
dotnet add ApiRestFul.Infrastructure package Pomelo.EntityFrameworkCore.MySql
```

### Install in the API Project
```bash
dotnet add ApiRestFul.Api package Microsoft.EntityFrameworkCore.Tools
```

These packages enable database connections, migrations, and EF Core tools support.

---

## How to Run the Project

### 1. Clone the Repository
```bash
git clone https://github.com/Estelar-Hopper/sistGestProdClientes_Csharp.git
cd sistGestProdClientes_Csharp
```

### 2. Restore Dependencies
```bash
dotnet restore
```

### 3. Create the First Migration
```bash
dotnet ef migrations add InitialCreate   --project ApiRestFul.Infrastructure   --startup-project ApiRestFul.Api
```

### 4. Create the Database in MySQL
```bash
dotnet ef database update   --project ApiRestFul.Infrastructure   --startup-project ApiRestFul.Api
```

### 5. Run the API
```bash
dotnet run --project ApiRestFul.Api
```

The API will start at a local address such as:
```
https://localhost:5001
```

---

## API Endpoints

Each entity has its own route inside the API layer.  
All endpoints follow RESTful conventions and support basic CRUD operations.

| Entity | Base Route | Operations |
|---------|-------------|-------------|
| **Customer** | `/api/customer` | GET, POST, PUT, DELETE |
| **Order** | `/api/order` | GET, POST, PUT, DELETE |
| **OrderDetail** | `/api/orderdetail` | GET, POST, PUT, DELETE |
| **Product** | `/api/product` | GET, POST, PUT, DELETE |

You can test these routes using **Postman** or any other API client.

---

## Database Configuration (MySQL)

The connection string is defined inside the **`appsettings.json`** file of the API project.  
You must update it according to your local MySQL configuration.

### Example:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=CustomerOrderDB;User=youruser;Password=yourpassword;"
  }
}
```

Make sure MySQL is running and the credentials are correct before running the migration or updating the database.  
If you are using a different port or user, change the values as needed.

---

## Testing the API

1. Run the project:  
   ```bash
   dotnet run --project ApiRestFul.Api
   ```
2. Open **Postman** or another tool.  
3. Send requests to the routes like:  
   - `GET https://localhost:5001/api/product`  
   - `POST https://localhost:5001/api/customer`  

You should receive JSON responses from the API.

---

## Project Purpose

This project was designed as a **DDD practice exercise** to understand how to structure a clean .NET application.  
It helps developers learn how to separate responsibilities into different layers and work with **Entity Framework Core** and **MySQL** in a real-world scenario.
