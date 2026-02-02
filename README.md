# ✅ Todo API – Optimized ASP.NET Core Web API

An **ASP.NET Core Web API** project that implements a Todo management system while focusing on **performance optimization**, **scalability**, and **clean backend architecture** from a beginner’s system-design perspective.

This project goes beyond basic CRUD by adding **pagination, Redis caching, and rate limiting** to demonstrate how real-world APIs are optimized.

---

## 📌 Project Goals

- Build a clean and maintainable Web API
- Learn backend optimization techniques step by step
- Understand how pagination, caching, and rate limiting improve APIs
- Follow best practices used in production-ready systems

---

## 🛠️ Tech Stack

| Technology | Usage |
|----------|------|
| ASP.NET Core Web API | API framework |
| Entity Framework Core | ORM |
| SQL Server | Database |
| Redis | Distributed caching |
| Docker | Running Redis & RedisInsight |
| Swagger | API documentation |

---

## 📂 Project Structure

Cached_Api/
│
├── Controllers/ → API endpoints
├── Repositories/ → Data access + caching logic
├── Interfaces/ → Repository contracts
├── Models/ → Entity models
├── DTOs/ → Request/Response DTOs
├── Data/ → DbContext & migrations
├── Program.cs → App configuration


Architecture used:

Controller → Repository → Database
↓
Redis Cache


---

## 🚀 Features

### ✔️ CRUD Operations
- Create Todo
- Get Todo by ID
- Get all Todos
- Update Todo
- Delete Todo

All operations are implemented using **async/await** for non-blocking I/O.

---

## 📄 Pagination (Performance Optimization)

Pagination is implemented to prevent loading large datasets into memory.

### Request Example
GET /api/todo?pageNumber=1&pageSize=10


### Response Structure
```json
{
  "items": [ ... ],
  "totalCount": 60,
  "pageNumber": 1,
  "pageSize": 10,
  "totalPages": 6
}
✔️ Improves performance
✔️ Reduces database load
✔️ Scales well with large datasets

⚡ Redis Caching (Distributed Cache)
Redis is used to cache:

Paginated Todo lists

Individual Todo items

Why Redis?
Extremely fast (in-memory)

Reduces repeated database queries

Beginner-friendly entry into distributed systems

Cache Strategy
Read-through caching

Cache invalidation on Create / Update / Delete

Time-based expiration (TTL)

Example cache keys:

todos:page:1:size:10
todo:5
🔒 Rate Limiting (API Protection)
Rate limiting is implemented using ASP.NET Core Rate Limiter Middleware.

Strategy Used
Fixed Window Rate Limiting

Limit requests per IP address

Example:

100 requests per minute per IP

Returns 429 Too Many Requests when exceeded

Why This Matters
Protects API from abuse

Prevents accidental overload

Essential for public APIs

🧠 Optimization Techniques Used
Technique	Purpose
Pagination	Efficient data retrieval
Redis Caching	Faster responses
Cache Invalidation	Data consistency
Rate Limiting	API protection
AsNoTracking()	Read-only query optimization
Async/Await	Better scalability
Repository Pattern	Clean architecture
🧪 Swagger API Documentation
Swagger UI is enabled for easy testing and documentation.

Access it at:

/swagger
🐳 Redis & RedisInsight (Docker)
Redis and RedisInsight are run using Docker.

Example:

docker run -d --name redis -p 6379:6379 redis
docker run -d --name redisinsight -p 8001:8001 redislabs/redisinsight
RedisInsight helps visualize cached keys and TTLs.

📈 Beginner System-Design Learnings
This project helps understand:

Why pagination is mandatory in real APIs

How caching reduces DB pressure

Why rate limiting is important for security

How APIs scale beyond CRUD

How distributed systems start with Redis

🔮 Future Improvements
Authentication & Authorization (JWT)

Filtering & sorting

API versioning

Distributed rate limiting using Redis

Unit & integration tests

Background jobs (Hangfire)

🧾 Summary
This project demonstrates how a simple Todo API can be upgraded into a production-style optimized backend using industry-standard techniques — making it ideal for learning, interviews, and system-design discussions.

