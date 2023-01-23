FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Daka/Daka.csproj", "Daka/"]
RUN dotnet restore "Daka/Daka.csproj"
COPY . .
WORKDIR "/src/Daka"
RUN dotnet build "Daka.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Daka.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Daka.dll"]
