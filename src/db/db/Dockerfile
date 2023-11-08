FROM postgres:alpine

ENV POSTGRES_USER postgres
ENV POSTGRES_PASSWORD password
ENV POSTGRES_DB slst

EXPOSE 5432

COPY init/ /db/init/
COPY docker-entrypoint-initdb.d /docker-entrypoint-initdb.d
