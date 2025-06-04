My project is a clean-architecture based .NET application designed to interact with and manage data from an iTunes-like database.

## Project Overview

The project is structured to showcase best practices in building a maintainable, scalable, and testable application. It separates concerns into distinct layers:

* **Core:** Foundation elements like generic repository interfaces, base entities, and custom result-handling mechanisms
* **DataAccess:** Using Entity Framework Core for interaction with a local SQL Server database. It implements a generic repository pattern for CRUD operations.
* **Business:** Implements the business logic using managers that depend on abstractions from the DataAccess layer. It handles the orchestration of data operations and applies business rules.
* **Entities:** Defines the domain models that represent the database entities.
* **Web API:** Web API using Autofac

## Features

* **Layered Architecture:** Clear separation of concerns.
* **Generic Repository Pattern:** CRUD operations for couple of entities
* **Dependency Inversion Principle (DIP):** Business logic depends on abstractions, enhancing flexibility and testability
* **Result:** Handling of operation outcomes (success/failure, messages, data).
* **Entity Framework Core:** EF Core for object-relational mapping with a SQL Server database.
* **CRUD Operations:** Supports basic Create, Read, Update, and Delete operations for Albums, Artists, and Tracks.
* **Specific Queries:** Includes examples of filtered queries.

## Technologies Used

* **C#** Main programming language.
* **.NET 8**
* **Entity Framework**
* **Autofac**
* **SQL Server (LocalDB)**

## Areas for Future Improvement

* **Asynchronous Operations**
* **Input Validation**.
* **Logging**
* **Unit and Integration Tests**
* **Dependency Injection Container**
* **Cross-Cutting Concerns**
