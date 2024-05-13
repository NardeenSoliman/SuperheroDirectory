FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/SuperheroDirectory.API/SuperheroDirectory.API.csproj", "src/SuperheroDirectory.API/"]
COPY ["src/SuperheroDirectory.Infrastructure/SuperheroDirectory.Infrastructure.csproj", "src/SuperheroDirectory.Infrastructure/"]
COPY ["src/SuperheroDirectory.Application/SuperheroDirectory.Application.csproj", "src/SuperheroDirectory.Application/"]
COPY ["src/SuperheroDirectory.Domain/SuperheroDirectory.Domain.csproj", "src/SuperheroDirectory.Domain/"]
RUN dotnet restore "./src/SuperheroDirectory.API/./SuperheroDirectory.API.csproj"
COPY . .
WORKDIR "/src/src/SuperheroDirectory.API"
RUN dotnet build "./SuperheroDirectory.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SuperheroDirectory.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SuperheroDirectory.API.dll"]