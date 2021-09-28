#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CommanderGql.Api/CommanderGql.Api.csproj", "CommanderGql.Api/"]
COPY ["CommanderGql.Infraestructure/CommanderGql.Infraestructure.csproj", "CommanderGql.Infraestructure/"]
COPY ["CommanderGql.Application/CommanderGql.Application.csproj", "CommanderGql.Application/"]
COPY ["CommanderGql.Domain/CommanderGql.Domain.csproj", "CommanderGql.Domain/"]
RUN dotnet restore "CommanderGql.Api/CommanderGql.Api.csproj"
COPY . .
WORKDIR "/src/CommanderGql.Api"
RUN dotnet build "CommanderGql.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CommanderGql.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CommanderGql.Api.dll"]
