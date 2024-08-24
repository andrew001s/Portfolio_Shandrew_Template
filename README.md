# SHANDREW PORTFOLIO
![Static Badge](https://img.shields.io/badge/-.NET%206.0-blueviolet)
[![Static Badge](https://img.shields.io/badge/-MongoDB-4DB33D?style=flat&logo=mongodb&logoCol)](https://img.shields.io/badge/-MongoDB-4DB33D?style=flat&logo=mongodb&logoCol)

Esta aplicación fue creada usando .NET MVC Y MongoDB para el almacenamiento de Imágenes/Servicios.
El proposito de esta App es la de crear un portafolio artístico, mostrando diferentes trabajos/Servicios y sus costos.

# Preview

<img src="https://i.imgur.com/XQ6pIEp.png" />

# Configuración
Dentro de la carpeta del Proyecto está el archivo appsettings-Example.json
```json
{
  "Email": {
    "Host": "smtp.gmail.com",
    "Port": "587",
    "Username": "youremail@gmail.com",
    "Password": "your app password"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },

  "AllowedHosts": "*",
  "ConnectionStrings": {
    "MongoDBConnection": "mongodb+srv://yourMongoDBDatabaseUrl",
    "DatabaseName": "YourDabaseName"
  }
}
```
Asegurate de configurar estos valores como:
## Servicio de Email
<ul>
  <li><strong>Host:</strong>  El host del servicio de email, por defecto Gmail.</li>
  <li><strong>Port:</strong>  Puerto para que el servicio de email funcione, por defecto 587 compatible con Gmail.</li>
  <li><strong>Username:</strong>  Aquí irá tu dirección de correo electrónico.</li>
  <li><strong>Password:</strong>  Aquí configura tu contraseña de aplicación, no siempre funciona con tu contraseña, por lo que es necesario generar una en tu proveedor de correos.</li>
</ul>

## Base de Datos
<ul>
  <li><strong>MongoDBConnection:</strong>  Aquí configura tu Uri de conexión a base de datos.</li>
  <li><strong>DatabaseName:</strong>  Aquí agrega el nombre de tu base de datos.</li>
</ul>
Esta configuración es usada para una base de datos NOSQL MongoDB
Para cambiar las colecciones es necesario visitar las clases en la carpeta Conections ejm:
HomeCon.cs:

```csharp
using MongoDB.Driver;
using ShandrewPage.Models;
namespace ShandrewPage.Conections
{
    public class HomeCOn
    {
        private readonly IMongoCollection<Home> home;
        public HomeCOn(IConfiguration configuration)
        {
            var mongo = new DBMongo(configuration);
            home = mongo.GetDatabase().GetCollection<Home>("Home");
        }
        public async Task<List<Home>> ObtenerCommAsync()
        {
            var projection = Builders<Home>.Projection
            .Include(p => p.Commissions)
            .Include(p=>p.Id);
            var query = await home.Find(_ => true).Project<Home>(projection).ToListAsync();

            return  query;
        }
    }
```
Cambiar el valor entre comillas en la linea 

```csharp
home = mongo.GetDatabase().GetCollection<Home>("Home");
```
Espero cambiar esto pronto.

## Web 

https://shandrewportfolio.tools.shandrew.tech/
    
