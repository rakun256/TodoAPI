# Stage 1: build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ./Todo.API/Todo.API.csproj ./Todo.API/
COPY ./Todo.Application/Todo.Application.csproj ./Todo.Application/
COPY ./Todo.Domain/Todo.Domain.csproj ./Todo.Domain/
COPY ./Todo.Infrastructure/Todo.Infrastructure.csproj ./Todo.Infrastructure/
RUN dotnet restore ./Todo.API/Todo.API.csproj

COPY . .
WORKDIR /src/Todo.API
RUN dotnet publish -c Release -o /app --no-restore

# Stage 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Todo.API.dll"]
