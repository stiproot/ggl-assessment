drop function if exists fn_delete_product_img_mapping;
create or replace function fn_delete_product_img_mapping(
    p_id bigint,
    p_usr_id bigint
)
returns bigint
language plpgsql
as $$
declare v_id bigint;
begin

    delete from tb_product_img_mapping t
    where t.id = p_id
    returning t.id into v_id;

    return v_id;

end;$$
