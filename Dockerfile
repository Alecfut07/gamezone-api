FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src

COPY gamezone-api/gamezone-api.csproj gamezone-api/

RUN dotnet restore ./gamezone-api/gamezone-api.csproj

# WORKDIR "/src/api"

COPY gamezone-api gamezone-api/

RUN dotnet publish gamezone-api/gamezone-api.csproj -c Release -o /release
#RUN dotnet build "gamezone-api.csproj" -c Release -o /app/build



FROM mcr.microsoft.com/dotnet/sdk:7.0 AS migration

WORKDIR /src

COPY gamezone-migration/gamezone-migration.csproj gamezone-migration/

RUN dotnet restore ./gamezone-migration/gamezone-migration.csproj

COPY gamezone-api gamezone-api/

COPY gamezone-migration gamezone-migration/

RUN dotnet publish gamezone-migration/gamezone-migration.csproj -c Release -o /release



FROM mcr.microsoft.com/dotnet/sdk:7.0

WORKDIR /app

COPY --from=migration /release .

COPY --from=build /release .

# RUN dotnet tool install --global dotnet-ef

# ENV PATH="$PATH:/root/.dotnet/tools"

COPY ["docker-entrypoint.sh", "/usr/bin/"]

RUN chmod +x  /usr/bin/docker-entrypoint.sh

ENTRYPOINT ["docker-entrypoint.sh"]

EXPOSE 5248

CMD dotnet gamezone-api.dll
