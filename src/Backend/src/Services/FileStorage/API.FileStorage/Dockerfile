#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/FileStorage/API.FileStorage/API.FileStorage.csproj", "src/Services/FileStorage/API.FileStorage/"]
COPY ["src/Services/Shared/API.Shared.Web/API.Shared.Web.csproj", "src/Services/Shared/API.Shared.Web/"]
COPY ["src/Services/Shared/API.Shared.Application/API.Shared.Application.csproj", "src/Services/Shared/API.Shared.Application/"]
COPY ["src/Services/Shared/API.Shared.Infrastructure/API.Shared.Infrastructure.csproj", "src/Services/Shared/API.Shared.Infrastructure/"]
COPY ["src/Services/Shared/API.Shared.Domain/API.Shared.Domain.csproj", "src/Services/Shared/API.Shared.Domain/"]
COPY ["src/Services/Shared/API.Shared.Common/API.Shared.Common.csproj", "src/Services/Shared/API.Shared.Common/"]
COPY ["src/Services/FileStorage/API.FileStorage.Application/API.FileStorage.Application.csproj", "src/Services/FileStorage/API.FileStorage.Application/"]
COPY ["src/Services/FileStorage/API.FileStorage.Infrastructure/API.FileStorage.Infrastructure.csproj", "src/Services/FileStorage/API.FileStorage.Infrastructure/"]
COPY ["src/Services/FileStorage/API.FileStorage.Domain/API.FileStorage.Domain.csproj", "src/Services/FileStorage/API.FileStorage.Domain/"]
COPY ["src/Services/FileStorage/API.FileStorage.Common/API.FileStorage.Common.csproj", "src/Services/FileStorage/API.FileStorage.Common/"]
RUN dotnet restore "./src/Services/FileStorage/API.FileStorage/API.FileStorage.csproj"
COPY . .
WORKDIR "/src/src/Services/FileStorage/API.FileStorage"
RUN dotnet build "./API.FileStorage.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.FileStorage.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.FileStorage.dll"]