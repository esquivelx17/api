# Etapa 1: Construcción de la app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar todos los archivos de la solución
COPY . ./

# (Opcional) Listar archivos para confirmar que se copiaron bien
RUN ls -la

# Publicar el proyecto API específico
RUN dotnet publish API_Inventario/API_Inventario.csproj -c Release -o /app/out

# Etapa 2: Imagen para correr la app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar los archivos publicados en la etapa build
COPY --from=build /app/out .

# Exponer puertos HTTP y HTTPS
EXPOSE 80
EXPOSE 443

# Ejecutar la API usando el nombre fijo del DLL
ENTRYPOINT ["dotnet", "API_Inventario.dll"]
