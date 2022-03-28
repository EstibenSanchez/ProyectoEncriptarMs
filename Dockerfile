#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProyectoEncriptarMs/ProyectoEncriptarMs.csproj", "ProyectoEncriptarMs/"]
RUN dotnet restore "ProyectoEncriptarMs/ProyectoEncriptarMs.csproj"
COPY . .
WORKDIR "/src/ProyectoEncriptarMs"
RUN dotnet build "ProyectoEncriptarMs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProyectoEncriptarMs.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProyectoEncriptarMs.dll"]