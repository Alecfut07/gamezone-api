FROM alpine:latest

RUN apk add dotnet7-sdk

RUN apk add aspnetcore7-runtime

WORKDIR /src

COPY . /src

EXPOSE 5248

CMD dotnet run