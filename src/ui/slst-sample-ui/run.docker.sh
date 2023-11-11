#!/bin/sh

rm -r ./dist/
npm run build
cp .env ./dist/

docker build -f Dockerfile -t img-slst-sample-ui-$1 .

docker run --network slst --name slst-sample-ui-$1 -p 7080:80 -it --detach img-slst-sample-ui-$1

# docker exec -it slst-sample-ui-$1 sh
