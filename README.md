# Auto_DependencyInjection

A lightweight library for **attribute-based automatic Dependency Injection** in .NET, eliminating boilerplate and centralizing DI configuration within the classes themselves.

---

## Main Goals

* Eliminate repetitive calls like `services.AddScoped<IService, Service>()`
* Centralize DI configuration within classes
* Fully compatible with the native .NET DI container
* Simple, explicit, and extensible

---

## Installation

Via NuGet:

```bash
dotnet add package Auto_DependencyInjection
```

Or via Package Manager Console:

```powershell
Install-Package Auto_DependencyInjection
```

---

## Main Concept

Just mark your classes with `[Inject]` or `[Scoped]` (or other lifetimes), and the `AutoInject()` method will automatically register the services in `IServiceCollection`.

### Example

```csharp
//Version I
[Inject(ServiceLifetime.Scoped)]
public class ClientService : IClientService
{
}

//Version II
[Scoped]
public class ClientService : IClientService
{
}
```

In `Program.cs`:

```csharp
//Version I
builder.Services.AutoInject(typeof(Program).Assembly);

//Version II
builder.Services.AutoInject();
```

This eliminates the need for:

```csharp
services.AddScoped<IClientService, ClientService>();
```

---

## The [Inject] Attribute

```csharp
[Inject(ServiceLifetime.Scoped)]
public class MyService : IMyService
{
}
```

### Parameters

| Property      | Description                                                       |
| ------------- | ----------------------------------------------------------------- |
| Lifetime      | Defines the service lifetime (`Scoped`, `Transient`, `Singleton`) |
| AllowMultiple | Allows multiple implementations of the same interface             |

---

## Registering Classes Without Interfaces

Classes without interfaces are registered as **concrete services**:

```csharp
[Inject(ServiceLifetime.Singleton)]
public class HealthCheckService
{
}
```

Usage:

```csharp
public class StatusController
{
    public StatusController(HealthCheckService service)
    {
    }
}
```

---

## Complete Program.cs Example

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Auto-register all services marked with [Inject]
builder.Services.AutoInject();

var app = builder.Build();

app.MapControllers();
app.Run();
```

**Important:** `AutoInject()` must be called **before** `builder.Build()`.

---

## Common Errors

* Registering after `Build()` throws the error: `The service collection cannot be modified because it is read-only.`

```csharp
var app = builder.Build();
builder.Services.AutoInject(); // ERROR
```

---

## License

MIT — free to use for personal and commercial projects.

---

## Conclusion

Auto_DependencyInjection reduces boilerplate, centralizes DI rules, and makes your `Program.cs` cleaner and more predictable. A simple, explicit, and extensible solution for Dependency Injection in .NET.
