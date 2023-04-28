#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Order.WebApi/Order.WebApi.csproj", "Order.WebApi/"]
COPY ["Order.Infraestructure/Order.Infraestructure.csproj", "Order.Infraestructure/"]
COPY ["Order.Domain/Order.Domain.csproj", "Order.Domain/"]
RUN dotnet restore "Order.WebApi/Order.WebApi.csproj"
COPY . .
WORKDIR "/src/Order.WebApi"
RUN dotnet build "Order.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Order.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Order.WebApi.dll"]