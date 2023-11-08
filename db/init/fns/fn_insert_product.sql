drop function if exists fn_insert_product;
create or replace function fn_insert_product(
    p_description varchar(250),
    p_code varchar(25)
)
returns bigint
language plpgsql
as $$
declare v_id bigint;
begin

    insert into tb_product
    (
        description, 
        code
    ) 
    values 
    (
        p_description, 
        p_code
    ) 
    returning id into v_id;

    return v_id;

end;$$
