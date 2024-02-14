# .Net Rest API minimal: MyWebApi

## Ejecutar el proyecto

```bash
dotnet run
```

## Curl para probar la operación WeatherForecast

```bash
curl -X GET "http://localhost:5293/weatherforecast"
```

## Curl para probar la operación WeatherForecast ordenado

```bash
curl -X GET "http://localhost:5293/weatherforecast/sorted"
```

## Crear proyecto de test

```bash
dotnet new xunit -n MyWebApi.Tests
```

### Agregar referencia al proyecto principal

```bash
dotnet add MyWebApi.Tests/MyWebApi.Tests.csproj reference MyWebApi/MyWebApi.csproj
```

### Ejecutar los tests

```bash
dotnet test
```

## Containerizar aplicación

### Construir imagen

```bash
docker build -t mywebapi .
```

### Ejecutar contenedor

```bash
docker run -d -p 5293:80 --name mywebapi mywebapi
```

### Detener contenedor

```bash
docker stop mywebapi
```

### Eliminar contenedor

```bash
docker rm mywebapi
```

