FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7286

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./services/ANCASE.API/ANCASE.API.csproj", "services/ANCASE.API/"]
COPY ["./building-blocks/ANCASE.Core/ANCASE.Core.csproj", "building-blocks/ANCASE.Core/"]
COPY ["./building-blocks/ANCASE.MessageBus/ANCASE.MessageBus.csproj", "building-blocks/ANCASE.MessageBus/"]

RUN dotnet restore "services/ANCASE.API/ANCASE.API.csproj"
COPY . .
WORKDIR "services/ANCASE.API"
RUN dotnet build "ANCASE.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ANCASE.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ANCASE.API.dll"]