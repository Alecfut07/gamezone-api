FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src

# COPY gamezone-api.csproj .
COPY ["gamezone-api/gamezone-api.csproj", "api/"]

RUN dotnet restore "api/gamezone-api.csproj"

COPY . .

# WORKDIR "/src/api"

# RUN dotnet publish gamezone-api.csproj -c Release -o /release
RUN dotnet build "gamezone-api.csproj" -c Release -o /app/build



#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS migration

#WORKDIR /src

#COPY gamezone-migration/ .
# /Users/alecfut07/Projects/gamezone-api/gamezone-migration/gamezone-migration.csproj
# COPY ["../gamezone-migration/gamezone-migration.csproj", "migration/"]

# COPY ["../gamezone-migration/" "."]

# RUN dotnet restore "gamezone-migration/gamezone-migration.csproj"

#COPY . .

#WORKDIR "/src/gamezone-migration"

#RUN dotnet build "gamezone-migration.csproj" -c Release -o /app/migration



#FROM mcr.microsoft.com/dotnet/sdk:7.0

#WORKDIR /migration

#COPY --from=migration /app/migration .

#WORKDIR /app

#COPY --from=build /app/build .

#EXPOSE 5248

#ENTRYPOINT [ "dotnet", "gamezone-api.dll" ]

# RUN dotnet tool install --global dotnet-ef

# ENV PATH="$PATH:/root/.dotnet/tools"

# COPY --from=build /release .

# COPY ["docker-entrypoint.sh", "/usr/bin/"]

# RUN chmod +x /usr/bin/docker-entrypoint.sh

# ENTRYPOINT ["docker-entrypoint.sh"]

# EXPOSE 5248

# CMD dotnet gamezone-api.dll

CMD sleep 10000
