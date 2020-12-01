#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["samples/Configurator.Sample.AspNetCore/Configurator.Sample.AspNetCore.csproj", "samples/Configurator.Sample.AspNetCore/"]
COPY ["src/Containers/Configurator.AspNetCoreIntegration/Configurator.AspNetCoreIntegration.csproj", "src/Containers/Configurator.AspNetCoreIntegration/"]
COPY ["src/Configurator/Configurator.csproj", "src/Configurator/"]
RUN dotnet restore "samples/Configurator.Sample.AspNetCore/Configurator.Sample.AspNetCore.csproj"
COPY . .
WORKDIR "/src/samples/Configurator.Sample.AspNetCore"
RUN dotnet build "Configurator.Sample.AspNetCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Configurator.Sample.AspNetCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Configurator.Sample.AspNetCore.dll"]