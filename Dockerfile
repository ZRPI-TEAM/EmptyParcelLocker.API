#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EmptyParcelLocker.API.csproj", "."]
RUN dotnet restore "./EmptyParcelLocker.API.csproj"
COPY . .
WORKDIR "/src/."

RUN dotnet dev-certs https --trust
RUN dotnet build "EmptyParcelLocker.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmptyParcelLocker.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY . .
RUN chmod +x prepare_db.sh
ENTRYPOINT ./prepare_db.sh
