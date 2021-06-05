#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["TodoApp.Endpoints.Api/TodoApp.Endpoints.Api.csproj", "TodoApp.Endpoints.Api/"]
COPY ["TodoApp.Core.Domain/TodoApp.Core.Domain.csproj", "TodoApp.Core.Domain/"]
COPY ["Framework.Core.Domain/Framework.Core.Domain.csproj", "Framework.Core.Domain/"]
COPY ["TodoApp.Infra.Data.SqlServer/TodoApp.Infra.Data.SqlServer.csproj", "TodoApp.Infra.Data.SqlServer/"]
COPY ["TodoApp.Core.ApplicationServices/TodoApp.Core.ApplicationServices.csproj", "TodoApp.Core.ApplicationServices/"]
COPY ["TodoApp.Infra.Data.SqlServer.Queries/TodoApp.Infra.Data.SqlServer.Queries.csproj", "TodoApp.Infra.Data.SqlServer.Queries/"]
RUN dotnet restore "TodoApp.Endpoints.Api/TodoApp.Endpoints.Api.csproj"
COPY . .
WORKDIR "/src/TodoApp.Endpoints.Api"
RUN dotnet build "TodoApp.Endpoints.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TodoApp.Endpoints.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoApp.Endpoints.Api.dll"]