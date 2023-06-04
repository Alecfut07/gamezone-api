FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src

COPY gamezone-api.csproj .

RUN dotnet restore gamezone-api.csproj

COPY . .

RUN dotnet publish gamezone-api.csproj -c Release -o /release



FROM mcr.microsoft.com/dotnet/sdk:7.0 AS final

WORKDIR /app

COPY --from=build /release .

EXPOSE 5248

CMD dotnet gamezone-api.dll