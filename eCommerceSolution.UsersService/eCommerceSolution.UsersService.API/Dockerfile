FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["eCommerceSolution.UsersService.API/eCommerceSolution.UsersService.API.csproj", "eCommerceSolution.UsersService.API/"]
RUN dotnet restore "eCommerceSolution.UsersService.API/eCommerceSolution.UsersService.API.csproj"
COPY . .
WORKDIR "/src/eCommerceSolution.UsersService.API"
RUN dotnet build "./eCommerceSolution.UsersService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./eCommerceSolution.UsersService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eCommerceSolution.UsersService.API.dll"]
