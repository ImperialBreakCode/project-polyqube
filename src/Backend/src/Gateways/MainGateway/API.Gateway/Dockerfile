#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Gateways/MainGateway/API.Gateway/API.Gateway.csproj", "src/Gateways/MainGateway/API.Gateway/"]
COPY ["src/Services/Shared/API.Shared.Web/API.Shared.Web.csproj", "src/Services/Shared/API.Shared.Web/"]
COPY ["src/Services/Shared/API.Shared.Application/API.Shared.Application.csproj", "src/Services/Shared/API.Shared.Application/"]
COPY ["src/Services/Shared/API.Shared.Infrastructure/API.Shared.Infrastructure.csproj", "src/Services/Shared/API.Shared.Infrastructure/"]
COPY ["src/Services/Shared/API.Shared.Domain/API.Shared.Domain.csproj", "src/Services/Shared/API.Shared.Domain/"]
COPY ["src/Services/Shared/API.Shared.Common/API.Shared.Common.csproj", "src/Services/Shared/API.Shared.Common/"]
RUN dotnet restore "./src/Gateways/MainGateway/API.Gateway/API.Gateway.csproj"
COPY . .
WORKDIR "/src/src/Gateways/MainGateway/API.Gateway"
RUN dotnet build "./API.Gateway.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.Gateway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.Gateway.dll"]