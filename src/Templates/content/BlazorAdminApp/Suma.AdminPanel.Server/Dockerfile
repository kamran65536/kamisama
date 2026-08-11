# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Suma.AdminPanel.Abstractions/Suma.AdminPanel.Abstractions.csproj", "Suma.AdminPanel.Abstractions/"]
COPY ["Suma.AdminPanel.Client/Suma.AdminPanel.Client.csproj", "Suma.AdminPanel.Client/"]
COPY ["Suma.AdminPanel.Core/Suma.AdminPanel.Core.csproj", "Suma.AdminPanel.Core/"]
COPY ["Suma.AdminPanel.Server/Suma.AdminPanel.Server.csproj", "Suma.AdminPanel.Server/"]
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages\
	dotnet restore "./Suma.AdminPanel.Server/Suma.AdminPanel.Server.csproj"
COPY . .
WORKDIR "/src/Suma.AdminPanel.Server"
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages\
	dotnet build "./Suma.AdminPanel.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages\
	dotnet publish "./Suma.AdminPanel.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Suma.AdminPanel.Server.dll"]
