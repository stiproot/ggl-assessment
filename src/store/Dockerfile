FROM minio/minio:latest

ENV MINIO_ROOT_USER=minioadmin
ENV MINIO_ROOT_PASSWORD=minioadmin

EXPOSE 9000
EXPOSE 9001

WORKDIR /docker-entrypoint-initdb.d

COPY init.sh .

RUN chmod +x init.sh

CMD ["minio", "server", "/data", "--console-address", ":9001"]
