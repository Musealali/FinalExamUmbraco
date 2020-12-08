#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["web-platform/web-platform.csproj", "web-platform/"]
COPY ["web-platform.Data/web-platform.Data.csproj", "web-platform.Data/"]
COPY ["web-platform.Service/web-platform.Service.csproj", "web-platform.Service/"]
RUN dotnet restore "web-platform/web-platform.csproj"
COPY . .

WORKDIR "/src/."
RUN dotnet build "web-platform/web-platform.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "web-platform/web-platform.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "web-platform.dll"]