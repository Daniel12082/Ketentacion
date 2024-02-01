# Ketentacion

Ketentación es un emprendimiento dedicado a la excelencia gastronómica. Ofrecemos una variedad exquisita de productos artesanales, desde tablas de quesos hasta pasteles innovadores, cafés artesanales y delicias para todos los gustos.

## Generalidades

- **Versión de .NET Core**: 7.0.0
- **Tecnologías principales**:
  - ASP.NET Core
  - Entity Framework Core
  - Angular
  - MySQL
  - MongoDB
  - OpenAPI

## Estructura del Proyecto

Explicación breve de la estructura del proyecto, destacando las capas.


```
 |-- KetentacionBack/Api # Capa de Presentación (ASP.NET Core MVC, API, etc.)
 |-- KetentacionBack.Application/ # Capa de Aplicación (Lógica de Negocio)
 |-- KetentacionBack.Infrastructure/ # Capa de Persistencia (Acceso a Datos, Configuracion Relacional, etc.)
 |-- KetentacionBack.Domain/ # Capa de Dominio (Entidades y Interfaces)
 |-- KetentacionBack.tests/ # Proyectos de pruebas
```



## Configuración

- **appsettings.json**: Archivo de configuración principal de despliegue.
- **appsettingsDevelopment.json**: Archivo de configuración principal para desarrollo (configuracion MySQL y mongoDB).

## Base de Datos

- **Tipo de Base de Datos**: [SQL, MongoDB]
- **ORM utilizado (si aplica)**: Entity Framework Core.
- **Scripts de Compilacion**: dotnet build.
- **Scripts de creacion Migración**: dotnet ef migrations add update --project ./Persistence/ --startup-project ./API/ --output-dir ./Data/Migrations
- **Scripts de ejecucion Migración**: dotnet ef database update --project .\Persistence\ --startup-project ./API/

## Instrucciones de Ejecución

- Configurar la base de datos de la manera correspondiete
- **Comando de ejecucion BackEnd**: Dotnet run --project API/ 