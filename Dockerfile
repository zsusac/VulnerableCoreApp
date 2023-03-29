# syntax=docker/dockerfile:1

# Old .NET docker images: https://devblogs.microsoft.com/dotnet/net-core-2-1-container-images-will-be-deleted-from-docker-hub/
# 2.0 is not available so we are pointing to 2.1 to see if that works.
# Or try this: https://github.com/dotnet/dotnet-docker/issues/279#issuecomment-322671257
FROM mcr.microsoft.com/dotnet/sdk:2.1 as build-env
WORKDIR /src
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /publish

# FROM mcr.microsoft.com/dotnet/aspnet:2.1 as runtime
# WORKDIR /publish
# COPY --from=build-env /publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "run"]
