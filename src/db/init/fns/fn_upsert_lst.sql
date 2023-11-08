drop function if exists fn_upsert_lst;
create or replace function fn_upsert_lst(
    p_id bigint,
    p_usr_id bigint,
    p_name varchar(50),
    p_product_ids bigint[]
)
returns bigint
language plpgsql
as $$
declare v_id bigint;
begin

    IF p_id > 0 THEN
        update tb_lst
        set 
            name = p_name,
            product_ids = p_product_ids
        where id = p_id and usr_id = p_usr_id
        returning id into v_id;
    ELSE
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
        returning id into v_id;
    END IF;

    return v_id;

end;$$
