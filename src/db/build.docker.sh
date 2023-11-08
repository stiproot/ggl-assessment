#!/bin/sh

docker build -f Dockerfile -t img-slst-db-$1 .

docker run -it --detach \
	-p 5432:5432 \
	--name slst-db-$1 \
	-e POSTGRES_USER=postgres \
	-e POSTGRES_PASSWORD=password \
	-e POSTGRES_DB=slst \
	img-slst-db-$1
