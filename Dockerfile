FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /App

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HelpWanted.csproj", "./"]
RUN dotnet restore "HelpWanted.csproj"
COPY . .
RUN dotnet build "HelpWanted.csproj" -c Release -o /app/publish

FROM build AS publish
RUN dotnet publish "HelpWanted.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelpWanted.dll"]