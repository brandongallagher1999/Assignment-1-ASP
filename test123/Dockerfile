#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["test123/test123.csproj", "test123/"]
RUN dotnet restore "test123/test123.csproj"
COPY . .
WORKDIR "/src/test123"
RUN dotnet build "test123.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "test123.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "test123.dll"]