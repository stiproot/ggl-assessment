#!/bin/bash

set -e
psql -v ON_ERROR_STOP=1 -U "$POSTGRES_USER" <<-EOSQL
    CREATE USER slst_usr WITH PASSWORD 'password';
    GRANT ALL PRIVILEGES ON DATABASE slst TO slst_usr;
    ALTER USER slst_usr WITH PASSWORD 'password';
EOSQL

echo "Attempting slst database creation..."

psql slst < /db/init/extensions.sql -U "$POSTGRES_USER"
psql slst < /db/init/tbs.sql -U "$POSTGRES_USER"

FN_SCRIPTS_DIR="/db/init/fns"
all_fn_scripts=""

for script_file in "$FN_SCRIPTS_DIR"/*.sh; do
    if [ -f "$script_file" ]; then
        script_contents=$(<"$script_file")
        all_fn_scripts="${all_fn_scripts}${script_contents};"
    fi
done

echo "$all_fn_scripts" | psql "$DATABASE_NAME" -U "$POSTGRES_USER"

echo "slst database creation finished..."

