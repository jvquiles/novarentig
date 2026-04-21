# 🚀 Novarenting API

## 📦 Overview

This project is a .NET 9 Web API for managing rentals.
It requires a MongoDB connection configured via environment variables or user secrets.

---

## 🧰 Prerequisites

Make sure you have installed:

* .NET 9 SDK
* Docker (optional, for containerized setup)
* MongoDB (local or via Docker)

---

## ▶️ Getting Started (Local Development)

### 1. Clone the repository

```bash
git clone <your-repo-url>
cd <your-repo-folder>
```

---

### 2. Configure User Secrets (Recommended for local development)

This project uses **User Secrets** to store sensitive configuration locally.

Run the following commands from the API project folder:

```bash
dotnet user-secrets init

dotnet user-secrets set "MongoDb:ConnectionString" "mongodb://mongo:mongo@localhost:27017/novarenting?authSource=admin"
dotnet user-secrets set "MongoDb:MongoDbDatabaseName" "novarenting"
```

You can verify the configuration with:

```bash
dotnet user-secrets list
```

---

### 3. Run the API

```bash
dotnet run
```

The API will start and be available at:

```
https://localhost:xxxx
```

---

## 🐳 Running with Docker (Optional)

### 1. Create a `.env` file

```env
MongoDb__ConnectionString=mongodb://mongo:mongo@mongo:27017/novarenting?authSource=admin
MongoDb__MongoDbDatabaseName=novarenting
```

---

### 2. Run with Docker Compose

```bash
docker-compose up --build
```

---

## ⚙️ Configuration

The application reads configuration in this order:

1. `appsettings.json`
2. `appsettings.Development.json`
3. User Secrets (local only)
4. Environment variables (Docker / CI)

---

## 🧪 Running Tests

```bash
dotnet test
```

---

## 📌 Notes

* Do NOT commit secrets to source control
* Use User Secrets for local development
* Use environment variables for Docker and production

---

## 🤝 Contributing

Feel free to open issues or submit pull requests.

---