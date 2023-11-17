FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 5000
 
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PortalPhotographer.sln", "."]
COPY ["Api/Api.csproj", "Api/"]
COPY ["Data/Data.csproj", "Data/"]
RUN dotnet restore "Api/Api.csproj"
RUN dotnet restore "Data/Data.csproj"
COPY . .
WORKDIR "/src/Api"
RUN dotnet build Api.csproj" -c Release -o /app/build
WORKDIR "/src/Data"
RUN dotnet build Data.csproj" -c Release -o /app/build
 
FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish
 
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]