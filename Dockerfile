# syntax=docker/dockerfile:1

# Old .NET docker images: https://devblogs.microsoft.com/dotnet/net-core-2-1-container-images-will-be-deleted-from-docker-hub/
# 2.0 is not available so we are pointing to 2.1 to see if that works.
FROM mcr.microsoft.com/dotnet/sdk:2.1 as build-env
WORKDIR /src
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /publish
LABEL name="vulnerable-core-app"
EXPOSE 80
ENTRYPOINT ["dotnet", "run"]
