# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar toda la solución
COPY . ./

# (Opcional) Listar archivos para ver qué se copió
RUN ls -la

# Intentar construir solo el proyecto API específico
RUN find . -name "Inventarios_API.csproj" -exec dotnet publish {} -c Release -o /app/out \;

# Si no se creó la carpeta /app/out, intenta publicar cualquier proyecto que contenga "inventarios_api" en el nombre
RUN if [ ! -d /app/out ]; then \
    find . -name "*.csproj" | grep -i inventarios_api | xargs -I {} dotnet publish {} -c Release -o /app/out; \
    fi

# Etapa final: imagen para correr la app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar archivos publicados desde la etapa de construcción
COPY --from=build /app/out .

# Exponer puertos HTTP y HTTPS
EXPOSE 80
EXPOSE 443

# (Opcional) Mostrar los archivos DLL para depuración
RUN find . -name "*.dll" | grep -i api

# Ejecutar la API buscando el DLL que contenga "API" en el nombre
ENTRYPOINT ["sh", "-c", "dotnet $(find . -name \"*API.dll\" | head -1)"]