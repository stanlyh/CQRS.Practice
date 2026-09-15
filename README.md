# CQRS.Practice

Proyecto de práctica en **.NET 8** que implementa el patrón **CQRS** (Command Query Responsibility Segregation) usando **MediatR** sobre una API REST simple de gestión de tareas (`TaskItem`).

## Tecnologías

- .NET 8 / ASP.NET Core Web API
- [MediatR](https://github.com/jbogard/MediatR) para el despacho de comandos y queries
- Entity Framework Core con proveedor **InMemory** (`TaskDb`)
- Autofac.Extensions.DependencyInjection
- Swagger / Swashbuckle para documentación interactiva de la API

## Estructura del proyecto

```
Controllers/            Controladores de la API (endpoints HTTP)
Application/
  DTOs/                 Objetos de transferencia de datos (TaskItemDto)
  Handlers/              Handlers que procesan los comandos y queries
Infraestructure/
  Commands/              Definición de comandos (Create, Update, Delete)
  Queries/               Definición de queries (GetAll, GetById)
Domain/                  Entidades de dominio (TaskItem)
Data/                    DbContext (EF Core InMemory)
Program.cs               Configuración y arranque de la aplicación
```

El flujo típico es: **Controller → Command/Query (MediatR) → Handler → DataContext (EF Core InMemory)**.

## Cómo ejecutar el proyecto

### Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Pasos

```bash
git clone <url-del-repositorio>
cd CQRS.Practice
dotnet restore
dotnet run
```

Al ejecutar en modo desarrollo, Swagger UI queda disponible para probar los endpoints (revisa la consola para la URL/puerto asignados, o usa el archivo `CQRS.Practice.http` incluido en el repo con `dotnet-http-client` / la extensión REST Client).

> **Nota:** el proyecto usa una base de datos en memoria, por lo que los datos se reinician cada vez que la aplicación se detiene.

## Endpoints de la API

Ruta base: `api/tasks`

| Método | Ruta              | Descripción                          | Cuerpo de la petición                                      |
|--------|-------------------|---------------------------------------|-------------------------------------------------------------|
| GET    | `/api/tasks`      | Obtiene todas las tareas               | -                                                             |
| GET    | `/api/tasks/{id}` | Obtiene una tarea por id                | -                                                             |
| POST   | `/api/tasks`      | Crea una nueva tarea                    | `{ "title": string, "description": string }`                |
| PUT    | `/api/tasks/{id}` | Actualiza una tarea existente           | `{ "id": int, "title": string, "description": string, "isCompleted": bool }` |
| DELETE | `/api/tasks/{id}` | Elimina una tarea por id                 | -                                                             |

## Modelo de datos (`TaskItem`)

| Campo         | Tipo    | Descripción                    |
|---------------|---------|---------------------------------|
| `Id`          | int     | Identificador único              |
| `Title`       | string  | Título de la tarea               |
| `Description` | string  | Descripción de la tarea          |
| `IsCompleted` | bool    | Indica si la tarea está completada |

## Licencia

Proyecto con fines educativos / de práctica.
