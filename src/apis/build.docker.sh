#!/bin/sh

docker build -f Dockerfile -t img-slst-api-$1 .

docker run -it --detach \
	-p 5079:80 \
	--name slst-api-$1 \
	-e ASPNETCORE_ENVIRONMENT=Development \
	img-slst-api-$1

# -e ASPNETCORE_URLS="https://+;http://+" \
# -e ASPNETCORE_HTTPS_PORT=8001 \
# -p 8000:80 \
# -p 8001:443 \
# --network slst \
# -e ASPNETCORE_Kestrel__Certificates__Default__Path=/root/.aspnet/https/aspnetcore-localhost-F49228DDFD1771875A1B6D9415EC27363D3DA105.pfx \
# -v ${HOME}/.aspnet/dev-certs/https/:/root/.aspnet/https/ \
