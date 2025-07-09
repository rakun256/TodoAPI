# Build aþamasý
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Çözüm ve proje dosyalarýný kopyala
COPY Todo.API/Todo.API.csproj ./Todo.API/
COPY Todo.API/Todo.API.sln ./
RUN dotnet restore "./Todo.API.sln"

# Tüm kaynaklarý kopyala
COPY Todo.API/ ./Todo.API/
WORKDIR /src/Todo.API

# Yayýn için build et
RUN dotnet publish -c Release -o /app/publish

# Runtime aþamasý
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Todo.API.dll"]
