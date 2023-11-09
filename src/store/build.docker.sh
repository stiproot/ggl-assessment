#!/bin/sh

docker build -f Dockerfile -t img-slst-store-$1 .

docker run \
	-p 9000:9000 \
	-p 9001:9001 \
	--name slst-store-$1 \
	-e MINIO_ROOT_USER=minioadmin \
	-e MINIO_ROOT_PASSWORD=minioadmin \
	img-slst-store-$1
