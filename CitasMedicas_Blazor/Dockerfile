FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CitasMedicas_Blazor/CitasMedicas_Blazor/CitasMedicas_Blazor.csproj", "CitasMedicas_Blazor/CitasMedicas_Blazor/"]
COPY ["CitasMedicas_Blazor/CitasMedicas_Blazor.Client/CitasMedicas_Blazor.Client.csproj", "CitasMedicas_Blazor/CitasMedicas_Blazor.Client/"]
RUN dotnet restore "CitasMedicas_Blazor/CitasMedicas_Blazor/CitasMedicas_Blazor.csproj"
COPY CitasMedicas_Blazor/ CitasMedicas_Blazor/
WORKDIR /src/CitasMedicas_Blazor/CitasMedicas_Blazor
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CitasMedicas_Blazor.dll"]
