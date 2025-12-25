FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081



FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProductService.API/ProductService.API.csproj", "ProductService.API/"]
RUN dotnet restore "ProductService.API/ProductService.API.csproj"
COPY . .
WORKDIR "/src/ProductService.API"
RUN dotnet build "ProductService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release