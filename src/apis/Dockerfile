FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine as restore-build-publish

WORKDIR /src

COPY ./Ggl.Slst.Api /src/Ggl.Slst.Api
COPY ./Ggl.Slst.Common /src/Ggl.Slst.Common
COPY ./Ggl.Slst.Db /src/Ggl.Slst.Db
COPY ./Ggl.Slst.Auth /src/Ggl.Slst.Auth

RUN dotnet restore /src/Ggl.Slst.Api/

RUN dotnet publish ./Ggl.Slst.Api/Ggl.Slst.Api.csproj  --no-restore --configuration Release --output /publish

from mcr.microsoft.com/dotnet/aspnet:7.0 as final

RUN mkdir /app

WORKDIR /app

COPY --from=restore-build-publish /publish /app

USER $APP_UID

ENTRYPOINT ["dotnet", "./Ggl.Slst.Api.dll"]
