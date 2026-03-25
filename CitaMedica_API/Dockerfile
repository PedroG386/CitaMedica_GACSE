FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CitaMedica_API/CitaMedica_API.csproj", "CitaMedica_API/"]
RUN dotnet restore "CitaMedica_API/CitaMedica_API.csproj"
COPY CitaMedica_API/ CitaMedica_API/
WORKDIR /src/CitaMedica_API
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CitaMedica_API.dll"]
