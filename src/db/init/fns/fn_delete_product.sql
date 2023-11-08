drop function if exists fn_delete_product;
create or replace function fn_delete_product(
    p_id bigint
)
returns bigint
language plpgsql
as $$
declare v_id bigint;
begin

    delete from tb_product t
    where t.id = p_id
    returning t.id into v_id;

    return v_id;

end;$$
