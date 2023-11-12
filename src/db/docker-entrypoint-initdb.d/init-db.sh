#!/bin/bash

set -e
psql -v ON_ERROR_STOP=1 -U "$POSTGRES_USER" <<-EOSQL
	    CREATE USER slst_usr WITH PASSWORD 'password';
	    GRANT ALL PRIVILEGES ON DATABASE slst TO slst_usr;
	    ALTER USER slst_usr WITH PASSWORD 'password';
EOSQL

echo "Attempting slst database creation..."

psql slst -U "$POSTGRES_USER" </db/init/extensions.sql
psql slst -U "$POSTGRES_USER" </db/init/tbs.sql

psql slst -U "$POSTGRES_USER" </db/init/fns/fn_upsert_lst.sql
psql slst -U "$POSTGRES_USER" </db/init/fns/fn_get_lst.sql
psql slst -U "$POSTGRES_USER" </db/init/fns/fn_delete_lst.sql
psql slst -U "$POSTGRES_USER" </db/init/fns/fn_upsert_usr.sql
psql slst -U "$POSTGRES_USER" </db/init/fns/fn_get_usr.sql
psql slst -U "$POSTGRES_USER" </db/init/fns/fn_delete_usr.sql
psql slst -U "$POSTGRES_USER" </db/init/fns/fn_upsert_img.sql
psql slst -U "$POSTGRES_USER" </db/init/fns/fn_get_img.sql
psql slst -U "$POSTGRES_USER" </db/init/fns/fn_delete_img.sql
psql slst -U "$POSTGRES_USER" </db/init/fns/fn_upsert_product.sql
psql slst -U "$POSTGRES_USER" </db/init/fns/fn_get_product.sql
psql slst -U "$POSTGRES_USER" </db/init/fns/fn_delete_product.sql
psql slst -U "$POSTGRES_USER" </db/init/fns/fn_get_product_img_mapping.sql
psql slst -U "$POSTGRES_USER" </db/init/fns/fn_insert_product_img_mapping.sql
psql slst -U "$POSTGRES_USER" </db/init/fns/fn_delete_product_img_mapping.sql
psql slst -U "$POSTGRES_USER" </db/init/fns/fn_upsert_ext_access_token.sql
psql slst -U "$POSTGRES_USER" </db/init/fns/fn_get_ext_access_token.sql
psql slst -U "$POSTGRES_USER" </db/init/fns/fn_delete_ext_access_token.sql

psql slst -U "$POSTGRES_USER" </db/init/seed/insert-tb_lst_status.sql
psql slst -U "$POSTGRES_USER" </db/init/seed/insert-tb_products.sql
psql slst -U "$POSTGRES_USER" </db/init/seed/insert-tb_usr-system.sql
psql slst -U "$POSTGRES_USER" </db/init/seed/insert-tb_img.sql

# TODO: fix this...
# FN_SCRIPTS_DIR="/db/init/fns"
# all_fn_scripts=""

# for script_file in "$FN_SCRIPTS_DIR"/*.sh; do
# 	if [ -f "$script_file" ]; then
# 		script_contents=$(<"$script_file")
# 		all_fn_scripts="${all_fn_scripts}${script_contents};"
# 	fi
# done

# echo "$all_fn_scripts" | psql "$DATABASE_NAME" -U "$POSTGRES_USER"

echo "slst database creation finished..."
