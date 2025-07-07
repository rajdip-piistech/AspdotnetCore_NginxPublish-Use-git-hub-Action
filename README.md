# MyApp: ASP.NET Core 9 + SQL Server + Docker + Nginx + GitHub Actions CI/CD

This project demonstrates how to set up a full-stack Dockerized application using:

* ASP.NET Core 9 API
* SQL Server (Dockerized)
* Nginx as a reverse proxy
* CI/CD using GitHub Actions

---

## 📁 Project Structure

```
MyApp/
├── docker-compose.yml           # Docker multi-container setup
├── .env                         # Sensitive env variables (e.g., DB password)
├── nginx/
│   └── default.conf             # Nginx reverse proxy config
├── .github/
│   └── workflows/
│       └── deploy.yml           # GitHub Actions CI/CD workflow
└── MyApp.Api/
    ├── Dockerfile               # ASP.NET Core 9 build
    ├── MyApp.Api.csproj         # Project definition
    ├── Program.cs               # API startup
    ├── appsettings.json         # App configuration
    └── Controllers/
        └── WeatherForecastController.cs  # Sample controller
```

---

## 🐳 Docker Setup

### Run Locally

```bash
docker-compose up -d --build
```

### Stop Services

```bash
docker-compose down
```

---

## 🔐 Environment File (.env)

Create a `.env` file at the root:

```env
SA_PASSWORD=YourStrong!Passw0rd
```

Used in `docker-compose.yml` to inject secure credentials into SQL Server and ASP.NET Core.

---

## 🔀 Reverse Proxy: Nginx

Nginx listens on port `80` and proxies requests to the ASP.NET API service named `api`:

```nginx
proxy_pass http://api:80;
```

You can customize `nginx/default.conf` to support SSL or rewrite rules.

---

## 🚀 Deployment (CI/CD)

### GitHub Secrets Needed:

| Name             | Description               |
| ---------------- | ------------------------- |
| SERVER\_HOST     | IP or domain of Linux VPS |
| SERVER\_USER     | SSH username (e.g. root)  |
| SERVER\_SSH\_KEY | Private key for SSH login |

### How It Works:

* On push to `main` branch:

  * GitHub checks out code
  * Uploads project via SCP
  * SSHs into server and runs Docker Compose

> See `.github/workflows/deploy.yml` for full pipeline config.

---

## 🧪 API Test

After deployment, visit:

```
http://yourdomain.com/WeatherForecast
```

To verify the API is running.

---

## 📦 Useful Commands

### View Logs

```bash
docker-compose logs -f api
```

### Rebuild with Cache Clear

```bash
docker-compose build --no-cache
```

---

## ✅ Technologies Used

* [.NET 9 SDK & ASP.NET Core](https://dotnet.microsoft.com/)
* [SQL Server 2022 (Docker)](https://hub.docker.com/_/microsoft-mssql-server)
* [Nginx](https://nginx.org/en/)
* [GitHub Actions](https://github.com/features/actions)

---

## 🔒 Security Notice

* Never commit real `.env` values
* Always rotate secrets regularly
* Add firewall protection or fail2ban for VPS

---

## 📞 Support

For help or suggestions, open an issue or contact the maintainer.

---

Happy coding! 🎉
