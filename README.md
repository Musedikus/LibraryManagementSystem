# Library Management System

A simple and secure ASP.NET Core Web API for managing books in a library. Built using Clean Architecture, JWT authentication, and full CRUD support for users and books.

---

##Feature..............................................................................

- ✅ User Registration & Login with JWT
- ✅ Secure password hashing using BCrypt
- ✅ JWT token versioning for invalidation on logout
- ✅ CRUD operations for books
- ✅ Search & pagination support for books
- ✅ Global exception handling middleware
- ✅ Consistent API responses using `ResultModel<T>`
- ✅ Swagger UI with JWT authorization support
- ✅ Seed data on startup (books + test user)

---

## 🧱 Architecture..........................................................................

Follows Clean Architecture with the following layers:

- `Domain`: Entity models
- `Application`: DTOs, interfaces, services
- `Infrastructure`: EF Core + repositories + Unit of Work
- `API`: Controllers, JWT logic, DI setup, middleware

### 🧩 Patterns Used..........................................................................

- Repository + Unit of Work
- DTO and Response Wrappers
- Global Error Handling Middleware
- Dependency Injection
- OpenAPI (Swagger) with JWT Auth

---

## 🛠 Tech Stack...........................................................................

- .NET 6 / ASP.NET Core
- Entity Framework Core
- SQL Server
- BCrypt.Net for hashing
- Swagger / OpenAPI

---

## 🚀 Getting Started......................................................................

### 1. **Clone the Project**
 ✅ git clone https://github.com/YourUsername/LibraryManagementSystem.git
### 2. **Navigate to API Folder**
cd LibraryManagementSystem/src/API

### 3. **Restore and Run**
 ✅ dotnet restore
 ✅ dotnet run

from the src/API folder, the following happens automatically:
✅ EF Core Migrations: Any pending migrations are applied to the database.
✅ Seed Data: A test user and 15 books are inserted if not already present.
✅ Swagger UI is launched (for testing the API).

### 4.  **How to Access Swagger**
✅ Once the app is running, the terminal will display output like this:

Now listening on: https://localhost:5163
Now listening on: http://localhost:5164
Application started. Press Ctrl+C to shut down.

✅Copy the HTTPS address shown (e.g., https://localhost:5163) and paste it into your browser.

Then append /swagger to it, like this:
https://localhost:5163/swagger

This will open the Swagger UI where you can explore and test all the API endpoints.
💡 If you're using Postman instead of Swagger, also use this same base URL for your API calls

#### 5.**Configuration**
appsettings.json (src/API/appsettings.Development.json)
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
✅ Change to match your local SQL Server setup if needed.

### 6.**Entity Framework**
✅ Migrations are automatically applied on startup.
✅ No need to run dotnet ef database update manually.

### 7.**Seeded Data**
✅ Includes test user + 15 law books for testing endpoints.
✅Test User (Seeded):
Email: testuser@example.com
Password: Password123

### 8 API ENDPOINTS 
Method	      Route                 	Description
-POST	    /api/auth/register      	Register a new user
-POST	    /api/auth/login	          Login and receive a JWT
-POST	    /api/auth/logout	        Logout and rotate token version
-GET	     /api/books	                Get all books (with search/paging)
-GET	     /api/books/{id}	          Get book by ID
-POST	    /api/books	              Add a new book (auth required)
-PUT	    /api/books/{id}	            Update book (auth required)
-DELETE	/api/books/{id}	            Delete book (auth required)


**NOTE NOTE NOTE NOTE **.........................................................................
✅ dotnet run must be run from the src/API directory.

✅ Swagger UI is enabled in development by default.

✅ All error responses are returned in a structured ResultModel<T>.









