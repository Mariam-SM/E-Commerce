# 🛍️ E-Commerce Backend API Platform

> A scalable RESTful backend API for e-commerce operations built with ASP.NET Core and Clean Architecture — featuring Redis caching, Specification pattern, Generic Repository, and advanced middleware customization.

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-Web_API-512BD4?style=flat-square&logo=dotnet)
![EF Core](https://img.shields.io/badge/EF_Core-ORM-512BD4?style=flat-square)
![Redis](https://img.shields.io/badge/Redis-Cache-DC382D?style=flat-square&logo=redis)
![Clean Architecture](https://img.shields.io/badge/Architecture-Clean-brightgreen?style=flat-square)
![Status](https://img.shields.io/badge/Status-In_Progress-yellow?style=flat-square)

---

## 📌 Overview

**E-Commerce Backend API Platform** is a robust RESTful backend built with **ASP.NET Core** and **Clean Architecture**, designed for real-world e-commerce scenarios. It implements advanced backend patterns including the **Specification Pattern**, **Generic Repository & Unit of Work**, **Redis Caching**, and **custom middleware** for a production-ready experience.

---

## ✨ Features

- 🔐 **JWT Authentication** — Secure token-based authentication
- 🛒 **Basket Management** — Redis-backed basket operations
- 📄 **Pagination** — Efficient data retrieval with paginated responses
- 🔍 **Specification Pattern** — Flexible, reusable query specifications
- 🏗️ **Generic Repository & Unit of Work** — Abstracted, reusable data access layer
- ⚡ **Redis Caching** — High-performance response caching
- 🌱 **Data Seeding** — Automated database seeding via customized middleware
- 🔥 **Lazy Loading** — Optimized entity loading strategy
- 🛡️ **Global Exception Handling** — Centralized error management middleware

---

## 🏗️ Architecture

```
E-Commerce/
├── ECommerce.API/             # Controllers, Middleware, Extensions, Exception Handling
├── ECommerce.Application/     # Services, Specifications, DTOs
├── ECommerce.Core/            # Entities, Interfaces, Domain Models
├── ECommerce.Infrastructure/  # EF Core, Generic Repos, Redis, Data Seeding
└── ECommerce.sln
```

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core 8 |
| Language | C# |
| ORM | Entity Framework Core |
| Database | SQL Server |
| Caching | Redis |
| Authentication | JWT |
| Patterns | Specification, Generic Repository, Unit of Work |
| Architecture | Clean Architecture |
| Middleware | Custom Seeding + Global Exception Handler |

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Redis](https://redis.io/)

### Installation

```bash
# 1. Clone the repository
git clone https://github.com/Mariam-SM/E-Commerce.git
cd E-Commerce

# 2. Restore dependencies
dotnet restore

# 3. Configure appsettings.json
# - DefaultConnection (SQL Server)
# - Redis ConnectionString
# - JWT settings

# 4. Apply migrations (data seeding runs automatically on startup)
dotnet ef database update --project ECommerce.Infrastructure --startup-project ECommerce.API

# 5. Run
dotnet run --project ECommerce.API
```

> 💡 Data seeding is handled automatically via custom middleware on first run.

---

## 🗺️ Roadmap

- [x] Clean Architecture scaffold
- [x] JWT Authentication
- [x] Generic Repository & Unit of Work
- [x] Specification Pattern
- [x] Redis Caching
- [x] Basket management
- [x] Pagination
- [x] Lazy Loading
- [x] Custom Data Seeding Middleware
- [x] Global Exception Handling

---

## 👩‍💻 Author

**Mariam Sayed Mohammed** — Backend .NET Developer

[![LinkedIn](https://img.shields.io/badge/LinkedIn-mariam--sayedd-0077B5?style=flat-square&logo=linkedin)](https://linkedin.com/in/mariam-sayedd)
[![GitHub](https://img.shields.io/badge/GitHub-Mariam--SM-181717?style=flat-square&logo=github)](https://github.com/Mariam-SM)
[![Portfolio](https://img.shields.io/badge/Portfolio-mariam--sm.github.io-ff6b6b?style=flat-square)](https://mariam-sm.github.io/portfolio)

---

## 📄 License

This project is licensed under the MIT License.
