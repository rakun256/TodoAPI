# Build a�amas�
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# ��z�m ve proje dosyalar�n� kopyala
COPY Todo.API/Todo.API.csproj ./Todo.API/
COPY Todo.API/Todo.API.sln ./
RUN dotnet restore "./Todo.API.sln"

# T�m kaynaklar� kopyala
COPY Todo.API/ ./Todo.API/
WORKDIR /src/Todo.API

# Yay�n i�in build et
RUN dotnet publish -c Release -o /app/publish

# Runtime a�amas�
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Todo.API.dll"]
