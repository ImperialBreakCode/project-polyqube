# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
# Install ICU for full globalization support
RUN apk add --no-cache icu-libs
# Tell .NET to use ICU instead of invariant mode
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=0
USER $APP_UID
WORKDIR /app
EXPOSE 8050
EXPOSE 8051


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Chats/API.Chats/API.Chats.csproj", "src/Services/Chats/API.Chats/"]
COPY ["src/Services/Shared/API.Shared.Web/API.Shared.Web.csproj", "src/Services/Shared/API.Shared.Web/"]
COPY ["src/Services/Shared/API.Shared.Application/API.Shared.Application.csproj", "src/Services/Shared/API.Shared.Application/"]
COPY ["src/Services/Shared/API.Shared.Infrastructure/API.Shared.Infrastructure.csproj", "src/Services/Shared/API.Shared.Infrastructure/"]
COPY ["src/Services/Shared/API.Shared.Domain/API.Shared.Domain.csproj", "src/Services/Shared/API.Shared.Domain/"]
COPY ["src/Services/Shared/API.Shared.Common/API.Shared.Common.csproj", "src/Services/Shared/API.Shared.Common/"]
COPY ["src/Services/Chats/API.Chats.Application/API.Chats.Application.csproj", "src/Services/Chats/API.Chats.Application/"]
COPY ["src/Services/Chats/API.Chats.Infrastructure/API.Chats.Infrastructure.csproj", "src/Services/Chats/API.Chats.Infrastructure/"]
COPY ["src/Services/Chats/API.Chats.Domain/API.Chats.Domain.csproj", "src/Services/Chats/API.Chats.Domain/"]
COPY ["src/Services/Chats/API.Chats.Common/API.Chats.Common.csproj", "src/Services/Chats/API.Chats.Common/"]
RUN dotnet restore "./src/Services/Chats/API.Chats/API.Chats.csproj"
COPY . .
WORKDIR "/src/src/Services/Chats/API.Chats"
RUN dotnet build "./API.Chats.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.Chats.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.Chats.dll"]