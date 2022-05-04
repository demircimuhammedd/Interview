FROM  mcr.microsoft.com/dotnet/runtime:latest AS base
    
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Projections/Interview.Projections.JobService/Interview.Projections.JobService.csproj", "src/Projections/Interview.Projections.JobService/"]
RUN dotnet restore "src/Projections/Interview.Projections.JobService/Interview.Projections.JobService.csproj"
COPY . .
WORKDIR "/src/src/Projections/Interview.Projections.JobService"
RUN dotnet build "Interview.Projections.JobService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Interview.Projections.JobService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Interview.Projections.JobService.dll"]
