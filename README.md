# EduHub Secure API 🚀

EduHub Secure API is a scalable backend application built using **ASP.NET Core Web API**. It is designed to manage school data with secure authentication, high performance, and modern backend architecture.

The project demonstrates enterprise-level backend development practices including **JWT authentication, Redis distributed caching, API rate limiting, pagination, DTO pattern, AutoMapper, and a clean layered architecture**.

---

# 🛠 Tech Stack

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Redis Distributed Cache
* JWT Authentication
* AutoMapper
* Docker (for Redis)
* REST API Architecture

---

# 📂 Project Architecture

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
│ │
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

RateLimiterTester
│
└── Console load testing application
```

The project follows a **layered architecture** separating responsibilities:

* **Controllers** → API endpoints
* **Services** → Business logic
* **Data** → Database context
* **Entities** → Models and DTOs
* **Helpers** → Utility classes

---

# 🔐 Authentication

Authentication is implemented using **JWT (JSON Web Tokens)**.

Endpoints:

```
POST /api/Auth/Register
POST /api/Auth/Login
```

After login, a **JWT token** is generated and must be included in request headers:

```
Authorization: Bearer <token>
```

---

# 🏫 School APIs

```
GET    /api/School/GetAllSchools
GET    /api/School/{id}
POST   /api/School/CreateSchool
PUT    /api/School/{id}
DELETE /api/School/{id}
```

---

# ⚡ Pagination

Pagination is implemented in the **GetAllSchools endpoint** to efficiently handle large datasets.

Example:

```
GET /api/School/GetAllSchools?pageNumber=1&pageSize=10
```

Benefits:

* Reduces server load
* Improves response time
* Efficient data retrieval

---

# 🚀 Redis Distributed Caching

To improve performance, **Redis caching** is implemented.

Frequently requested data such as school lists is cached to reduce database queries and improve response speed.

Benefits:

* Faster API response
* Reduced database load
* Better scalability

Redis runs inside a **Docker container**.

---

# 🛑 API Rate Limiting

Rate limiting is implemented using **ASP.NET Core Rate Limiting Middleware** with the **Token Bucket algorithm**.

This protects the API from excessive requests and abuse.

Example behavior:

```
Allowed Requests → 200 OK
Exceeded Limit → 429 Too Many Requests
```

Example configuration:

```csharp
opt.TokenLimit = 10;
opt.QueueLimit = 2;
opt.TokensPerPeriod = 1;
opt.ReplenishmentPeriod = TimeSpan.FromSeconds(1);
```

---

# 🧪 Load Testing

A separate console application **RateLimiterTester** is created to simulate concurrent requests and verify rate limiting behavior.

The tester sends multiple parallel requests to validate:

* API protection
* Request throttling
* Rate limiter performance

Example output:

```
200 OK
429 Too Many Requests
```

---

# 🔄 AutoMapper

AutoMapper is used to map:

```
DTOs ↔ Entity Models
```

Benefits:

* Protect database models
* Clean API responses
* Reduce manual mapping code

---

# 🗄 Database

The project uses **Entity Framework Core Code-First approach**.

Migration commands:

```
Add-Migration InitialMigration
Update-Database
```

---

# 🐳 Redis with Docker

Redis is run using Docker.

Start Redis container:

```
docker run -d -p 6379:6379 --name redis-server redis
```

Verify container:

```
docker ps
```

---

# ▶️ Running the Project

### 1️⃣ Clone the repository

```
git clone https://github.com/your-username/EduHub-Secure-API.git
```

### 2️⃣ Navigate to the project

```
cd EduHub-Secure-API
```

### 3️⃣ Update database connection

Update `appsettings.json` with your SQL Server connection string.

### 4️⃣ Run migrations

```
Update-Database
```

### 5️⃣ Start Redis (Docker)

```
docker run -d -p 6379:6379 redis
```

### 6️⃣ Run the application

```
dotnet run
```

---

# 📌 Features Implemented

✔ JWT Authentication
✔ Secure Login & Registration
✔ Redis Distributed Caching
✔ Pagination
✔ DTO Pattern
✔ AutoMapper Integration
✔ Service Layer Architecture
✔ Entity Framework Core Migrations
✔ API Rate Limiting (Token Bucket Algorithm)
✔ Concurrent Load Testing Tool
✔ Docker Redis Setup

---

# 📈 Future Improvements

* Role Based Authorization
* Refresh Tokens
* Logging with Serilog
* Unit Testing
* CI/CD Pipeline
* Kubernetes Deployment

---

# 👨‍💻 Author

**Tapan Ray**

Software Developer | .NET | Backend Engineering | Cloud
