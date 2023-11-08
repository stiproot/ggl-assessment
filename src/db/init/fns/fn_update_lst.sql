drop function if exists fn_update_lst;
create or replace function fn_update_lst(
    p_id bigint,
    p_name varchar(500),
    p_product_ids bigint[]
)
returns bigint
language plpgsql
as $$
declare v_id bigint;
begin

    update tb_lst
    set 
        name = p_name,
        product_ids = p_product_ids
    where id = p_id
    returning id into v_id;

    return v_id;

end;$$
