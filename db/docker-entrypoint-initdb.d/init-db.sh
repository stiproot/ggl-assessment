#!/bin/bash

set -e
psql -v ON_ERROR_STOP=1 -U "$POSTGRES_USER" <<-EOSQL
    CREATE USER slst_usr WITH PASSWORD 'password';
    GRANT ALL PRIVILEGES ON DATABASE slst TO slst_usr;
    ALTER USER slst_usr WITH PASSWORD 'password';
EOSQL

echo "Attempting slst database creation..."

psql trxy < /db/init/extensions.sql -U "$POSTGRES_USER"
psql trxy < /db/init/tb.sql -U "$POSTGRES_USER"

psql trxy < /db/fn_delete_img.sql -U "$POSTGRES_USER"

# TODO: pipe all .sql files into psql...

echo "slst database creation finished..."

