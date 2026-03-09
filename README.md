# EduHub Secure API 🚀

EduHub Secure API is a backend application built using **ASP.NET Core Web API**, designed to manage school data with secure authentication and high performance. The project demonstrates modern backend development practices including **JWT authentication, Redis caching, pagination, DTOs, AutoMapper, and clean service architecture**.

---

## 🛠 Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Redis Distributed Cache
- JWT Authentication
- AutoMapper
- REST API Architecture

---

## 📂 Project Architecture

```
Controllers
│
├── AuthController
├── SchoolController

Data
│
└── EduHubDbContext

Entities
│
├── Models
│ ├── School
│ └── User
│
└── Dtos
    ├── SchoolDtos
    └── UserDtos

Helper
│
└── JwtHelper

Mapping
│
├── SchoolMappingProfile
└── UserMappingProfile

Service
│
├── AuthService
└── SchoolService
```

The project follows a **layered architecture** separating:

- Controllers → API endpoints  
- Services → Business logic  
- Data → Database context  
- Entities → Models and DTOs  
- Helpers → Utility classes  

---

## 🔐 Authentication

Authentication is implemented using **JWT (JSON Web Tokens)**.

Endpoints:

```
POST /api/Auth/Register
POST /api/Auth/Login
```

After login, a **JWT token** is generated which must be included in request headers:

```
Authorization: Bearer <token>
```

---

## 🏫 School APIs

```
GET    /api/School/GetAllSchools
GET    /api/School/{id}
POST   /api/School/CreateSchool
PUT    /api/School/UpdateSchool
DELETE /api/School/DeleteSchool
```

---

## ⚡ Pagination

Pagination is implemented in the **GetAllSchools endpoint** to handle large datasets efficiently.

Example:

```
GET /api/School/GetAllSchools?pageNumber=1&pageSize=10
```

Benefits:

- Reduces server load
- Improves response time
- Efficient data retrieval

---

## 🚀 Redis Distributed Caching

To improve performance, **Redis caching** is implemented.

Frequently requested data (such as school lists) is cached to reduce database queries and improve response speed.

Benefits:

- Faster API response
- Reduced database load
- Better scalability

---

## 🔄 AutoMapper

AutoMapper is used to map:

```
DTOs ↔ Entity Models
```

This helps:

- Protect database models
- Clean API responses
- Reduce manual mapping code

---

## 🗄 Database

The project uses **Entity Framework Core Code-First approach**.

Migration commands:

```bash
Add-Migration InitialMigration
Update-Database
```

---

## ▶️ Running the Project

1. Clone the repository

```
git clone https://github.com/your-username/EduHub-Secure-API.git
```

2. Navigate to project folder

```
cd EduHub-Secure-API
```

3. Update connection string in `appsettings.json`

4. Run migrations

```
Update-Database
```

5. Run the application

```
dotnet run
```

---

## 📌 Features Implemented

✔ JWT Authentication  
✔ Secure Login & Registration  
✔ Redis Distributed Caching  
✔ Pagination  
✔ DTO Pattern  
✔ AutoMapper Integration  
✔ Service Layer Architecture  
✔ Entity Framework Core Migrations  

---

## 📈 Future Improvements

- Role Based Authorization
- Refresh Tokens
- API Rate Limiting
- Logging with Serilog
- Unit Testing
- Docker Deployment

---

## 👨‍💻 Author

**Tapan Ray**

Software Developer | .NET | Cloud | Backend Engineering
