FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
USER app
WORKDIR /app
EXPOSE 55822
EXPOSE 8081
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["rabbitmq_queue_utlisation_dashboard.csproj", "."]
RUN dotnet restore "rabbitmq_queue_utlisation_dashboard.csproj"
COPY . .
RUN dotnet build "rabbitmq_queue_utlisation_dashboard.csproj" -c $BUILD_CONFIGURATION -o /app

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "rabbitmq_queue_utlisation_dashboard.csproj" -c $BUILD_CONFIGURATION -o /app /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "rabbitmq_queue_utlisation_dashboard.dll"]
