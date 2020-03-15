FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["./Stone.API/Stone.API.csproj", "./Stone.API/"]
COPY ["./Stone.Service/Stone.Service.csproj", "./Stone.Service/"]
COPY ["./Stone.Infrastructure/Stone.Infrastructure.csproj", "./Stone.Infrastructure/"]
COPY ["./Stone.Domain/Stone.Domain.csproj", "./Stone.Domain/"]
RUN dotnet restore "Stone.API/Stone.API.csproj"

COPY ["./Stone.API/Stone.API.csproj", "./Stone.API/"]
COPY ["./Stone.Service/Stone.Service.csproj", "./Stone.Service/"]
COPY ["./Stone.Infrastructure/Stone.Infrastructure.csproj", "./Stone.Infrastructure/"]
COPY ["./Stone.Domain/Stone.Domain.csproj", "./Stone.Domain/"]

WORKDIR "/src/Stone.API"
RUN dotnet build "Stone.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Stone.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Stone.API.dll"]