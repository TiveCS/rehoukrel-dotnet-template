FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RehoukrelTemplate.Hello.Api/RehoukrelTemplate.Hello.Api.csproj", "RehoukrelTemplate.Hello.Api/"]
RUN dotnet restore "RehoukrelTemplate.Hello.Api/RehoukrelTemplate.Hello.Api.csproj"
COPY . .
WORKDIR "/src/RehoukrelTemplate.Hello.Api"
RUN dotnet build "./RehoukrelTemplate.Hello.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RehoukrelTemplate.Hello.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RehoukrelTemplate.Hello.Api.dll"]
