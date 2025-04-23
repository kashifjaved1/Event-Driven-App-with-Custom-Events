# Event-Driven CRUD Application

This project is an **Event-Driven CRUD application** built using **.NET 6** (or later). It uses **event-driven architecture** where operations like **Create**, **Update**, and **Delete** are handled using events. The application supports a simple in-memory repository, and events are managed using a custom `IEventBus`.

## Features

- **CRUD Operations**: Create, Update, Delete, and Get products.
- **Event-Driven Architecture**: Actions (e.g., create, update, delete) trigger events.
- **In-Memory Repository**: A simple in-memory storage for products.
- **Swagger Integration**: API documentation and testing UI.
- **ASP.NET Core MVC**: Web API with controllers.

## Project Structure

Here’s a breakdown of the project structure:
![image](https://github.com/user-attachments/assets/437727d6-a3b6-4525-9d90-cf7d34992dd9)

## Setup Instructions

### Prerequisites

Ensure that you have the following installed:

- **.NET 6 SDK** or later: [Install .NET](https://dotnet.microsoft.com/download/dotnet)
- **Visual Studio** or any code editor (VSCode, JetBrains Rider, etc.)
- **Postman** (optional, for testing the API)

### Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/EventDrivenCrudApp.git
   cd EventDrivenCrudApp

   dotnet restore

   dotnet run
   ```
   The application will be hosted at https://localhost:5001 (or similar).

2. Testing the API

    Open Swagger UI:
    If you're in development mode, go to https://localhost:5001/swagger in your browser to interact with the API.

    Test the CRUD Operations:

    - POST /api/product: Create a new product.
    
    - GET /api/product/{id}: Get a product by ID.
    
    - GET /api/product: Get all products.
    
    - PUT /api/product/{id}: Update a product.
    
    - DELETE /api/product/{id}: Delete a product.

### Event Flow

- Product Created: When a product is created via the API, a ProductCreatedEvent is triggered.

- Product Updated: When a product is updated, the ProductUpdatedEvent is fired.

- Product Deleted: When a product is deleted, a ProductDeletedEvent is raised.

These events are handled by their respective handlers (ProductCreatedHandler, ProductUpdatedHandler, ProductDeletedHandler), which interact with the repository to persist the changes.  
