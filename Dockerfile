FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["qs-web-api.csproj", "./"]
RUN dotnet restore "qs-web-api.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "qs-web-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "qs-web-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "qs-web-api.dll"]
