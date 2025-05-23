# Etapa 1: Construcción de la app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar todos los archivos de la solución
COPY . ./

# (Opcional) Listar archivos para confirmar que se copiaron bien
RUN ls -la

# Publicar el proyecto API específico
RUN find . -name "API_Inventario.csproj" -exec dotnet publish {} -c Release -o /app/out \;

# Si no se creó la carpeta /app/out, intenta publicar cualquier proyecto que contenga "api" en el nombre
RUN if [ ! -d /app/out ]; then \
    find . -name "*.csproj" | grep -i api | xargs -I {} dotnet publish {} -c Release -o /app/out; \
    fi

# Etapa 2: Imagen para correr la app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar los archivos publicados en la etapa build
COPY --from=build /app/out .

# Exponer puertos HTTP y HTTPS
EXPOSE 80
EXPOSE 443

# (Opcional) Mostrar los archivos DLL para debug
RUN find . -name "*.dll" | grep -i api

# Ejecutar la API buscando el DLL que contiene "API" en su nombre
ENTRYPOINT ["sh", "-c", "dotnet $(find . -name \"*API.dll\" | head -1)"]
