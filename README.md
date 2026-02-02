# 🚀 Cached API – Optimized ASP.NET Core Web API

This project is a **beginner‑friendly yet production‑ready ASP.NET Core Web API** that demonstrates **modern API optimization techniques** such as **pagination, Redis caching, rate limiting, clean architecture, and system‑design best practices**.

The goal of this project is to **build a scalable, performant API** while keeping the implementation simple and easy to understand for learning and interview preparation.

---

## 📌 Tech Stack

* **ASP.NET Core Web API (.NET 7/8)**
* **Entity Framework Core** (Code‑First)
* **SQL Server**
* **Redis** (Distributed Caching)
* **RedisInsight** (Monitoring & Debugging)
* **Docker** (for Redis & RedisInsight)

---

## 🧱 Project Architecture

The project follows a **clean and maintainable layered architecture**:

```
Controllers
│
├── Interfaces (Abstractions)
│
├── Repositories (Data Access Layer)
│
├── DTOs (Request/Response Models)
│
├── Models (Database Entities)
│
└── Infrastructure (Caching, Rate Limiting, etc.)
```

✔ Separation of concerns
✔ Easy to test and extend
✔ Interview‑friendly structure

---

## ✨ Major Features

### 1️⃣ Pagination (Performance Optimization)

* API responses are **paginated** using `Skip` & `Take`
* Prevents large data loads
* Improves response time and memory usage

**Example:**

```
GET /api/todos?pageNumber=1&pageSize=10
```

Each response contains:

* Current page data
* Total record count
* Page size & page number

✔ Database‑level pagination using EF Core

---

### 2️⃣ Redis Caching (High‑Performance Reads)

* Integrated **Redis distributed cache**
* Paginated responses are cached
* Reduces database hits significantly

**Cache Strategy:**

* Cache key includes page number & page size
* Cache invalidation on:

  * Create
  * Update
  * Delete

✔ Improves scalability
✔ Faster repeated requests
✔ Suitable for distributed systems

---

### 3️⃣ Rate Limiting (API Protection)

Implemented using **ASP.NET Core built‑in Rate Limiting Middleware**.

**Algorithm Used:**

* **Fixed Window Rate Limiter**

**Configuration:**

* 100 requests per minute per IP
* No request queueing
* Returns **HTTP 429 – Too Many Requests**

✔ Prevents abuse
✔ Protects backend resources
✔ Beginner‑friendly configuration

---

### 4️⃣ Clean Repository Pattern

* Controllers do not directly talk to EF Core
* Database logic is isolated inside repositories

**Benefits:**

* Loose coupling
* Easier unit testing
* Cleaner controllers

---

### 5️⃣ DTO‑Based Responses

* Entities are never exposed directly
* Separate request and response models

✔ Better API security
✔ Versioning support
✔ Clean contract with frontend

---

### 6️⃣ EF Core Best Practices

* Async database calls
* Proper `OrderBy` before `Skip/Take`
* Optimized queries

✔ Predictable pagination
✔ Avoids EF Core warnings

---

### 7️⃣ RedisInsight Integration

* Redis monitored using **RedisInsight**
* Cache keys & values can be viewed visually
* Helps debug cache behavior

Run RedisInsight using Docker:

```
docker run -d --name redisinsight -p 8001:8001 redislabs/redisinsight:latest
```

---

## ⚡ Performance Optimizations Implemented

| Optimization       | Purpose              |
| ------------------ | -------------------- |
| Pagination         | Reduces payload size |
| Redis Caching      | Faster responses     |
| Rate Limiting      | Prevents abuse       |
| Async APIs         | Non‑blocking IO      |
| DTOs               | Smaller payloads     |
| Repository Pattern | Clean & testable     |

---

## 🧠 System Design Improvements (Beginner Level)

This project demonstrates **real‑world backend optimizations**:

* Stateless API design
* Distributed caching with Redis
* Horizontal scalability ready
* Safe API throttling
* Clean separation of layers

---

## 🔒 Security & Stability

* Rate‑limited endpoints
* Controlled payload sizes
* Centralized caching strategy
* Safe database access patterns

---

## 🎯 Who Is This Project For?

✔ Beginners learning Web API optimization
✔ Developers preparing for interviews
✔ Anyone learning Redis with .NET
✔ System‑design fundamentals learners

---

## 📈 Possible Future Enhancements

* Response compression (Gzip/Brotli)
* API versioning
* Background jobs (Hangfire)
* Logging & monitoring (Serilog)
* Authentication & authorization
* Cache‑aside vs write‑through strategies

---

## 🏁 Conclusion

This project focuses on **doing fewer things but doing them correctly**.
It demonstrates **how real‑world APIs are optimized** while remaining easy to understand for beginners.

If you understand this project well, you already have **strong backend fundamentals**.

---

### ⭐ If this project helped you, feel free to star the repository!
