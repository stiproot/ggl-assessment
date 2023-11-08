drop function if exists fn_insert_lst;
create or replace function fn_insert_lst(
    p_name varchar(500),
    p_product_ids bigint[],
    p_usr_id bigint
)
returns bigint
language plpgsql
as $$
declare v_lst_id bigint;
begin

    insert into tb_lst 
    (
        name, 
        product_ids,
        usr_id
    ) 
    values 
    (
        p_name, 
        p_product_ids,
        p_usr_id
    ) 
    returning id into v_lst_id;

    return v_lst_id;

end;$$
