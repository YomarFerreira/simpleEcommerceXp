FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /app

COPY Api/*.csproj ./Api/
COPY Application/*.csproj ./Application/
COPY Domain/*.csproj ./Domain/
COPY Infrastructure/*.csproj ./Infrastructure/

WORKDIR /app/Api
RUN dotnet restore

WORKDIR /app/Application
RUN dotnet restore

WORKDIR /app/Domain
RUN dotnet restore

WORKDIR /app/Infrastructure
RUN dotnet restore

WORKDIR /app
COPY . .

RUN dotnet publish Api/Api.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime

WORKDIR /app

COPY --from=build /app/out .

ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "Api.dll"]