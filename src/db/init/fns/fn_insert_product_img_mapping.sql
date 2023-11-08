drop function if exists fn_insert_product_img_mapping;
create or replace function fn_insert_product_img_mapping(
    p_product_id bigint, 
    p_img_id bigint
)
returns bigint
language plpgsql
as $$
declare v_id bigint;
begin

    insert into tb_product_img_mapping
    (
        product_id,
        img_id
    ) 
    values 
    (
        p_product_id,
        p_img_id
    ) 
    returning id into v_id;

    return v_id;

end;$$
