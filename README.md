# 🚀 TaskIna

Repositorio destinado al desarrollo y gestión de tareas, prácticas y proyectos relacionados con el aprendizaje y desarrollo de software.

## 📌 Proyecto Actual

### inaApp

Aplicación desarrollada con arquitectura por capas utilizando .NET y SQL Server.

### Tecnologías

- C#
- .NET
- ASP.NET Core Web API
- SQL Server
- Entity Framework Core
- Swagger
- Git & GitHub

## 🏗️ Arquitectura

El proyecto sigue una arquitectura por capas:

```text
Controller
    ↓
Service
    ↓
Repository
    ↓
Database
```

### Capas del proyecto

- **inaAPI** → Exposición de endpoints.
- **inaApp.Service** → Reglas de negocio.
- **inaApp.Repository** → Acceso a datos.
- **inaApp.Entities** → Entidades del dominio.
- **inaApp.Common** → Interfaces y componentes compartidos.

## 📂 Estructura

```text
TaskIna
│
└── inaApp
    ├── inaAPI
    ├── inaApp.Service
    ├── inaApp.Repository
    ├── inaApp.Entities
    └── inaApp.Common
```

## 🎯 Objetivos

- Aplicar principios SOLID.
- Implementar Inyección de Dependencias.
- Utilizar Repository Pattern.
- Trabajar con APIs REST.
- Aplicar buenas prácticas de desarrollo.
- Mantener una arquitectura escalable y mantenible.

## 👩‍💻 Autor

**Emily Selenia Rodríguez Mendoza**

Backend Developer | .NET | Java | SQL Server

GitHub:
https://github.com/EmilySelenia01
