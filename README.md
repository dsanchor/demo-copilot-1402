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

## Deploy to AKS

### Environment variables for RG and CLUSTER

```bash
export RESOURCE_GROUP=aks-demo-alb-rg
export CLUSTER_NAME=demo
export NAMESPACE=demo
```

## Get credentials

```bash
az aks get-credentials -g $RESOURCE_GROUP -n $CLUSTER_NAME
```

## Create a namespace

```bash
kubectl create namespace $NAMESPACE
```

## Deploy the application

```bash
kubectl apply -f k8s/application.yml -n $NAMESPACE
```

## Get service IP

```bash
export SVCIP=`kubectl get service webapi-service -n $NAMESPACE -o jsonpath='{.status.loadBalancer.ingress[0].ip}'`
```

## Test the application

```bash
curl http://$SVCIP/weatherforecast
```
