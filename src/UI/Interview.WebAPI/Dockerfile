#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/UI/Interview.WebAPI/Interview.WebAPI.csproj", "src/UI/Interview.WebAPI/"]
COPY ["src/Infrastructure/Interview.Infrastructure.Persistence/Interview.Infrastructure.Persistence.csproj", "src/Infrastructure/Interview.Infrastructure.Persistence/"]
COPY ["src/Core/Interview.Domain/Interview.Domain.csproj", "src/Core/Interview.Domain/"]
RUN dotnet restore "src/UI/Interview.WebAPI/Interview.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/UI/Interview.WebAPI"
RUN dotnet build "Interview.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Interview.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Interview.WebAPI.dll"]
