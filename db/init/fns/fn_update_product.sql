drop function if exists fn_update_product;
create or replace function fn_update_product(
  p_id bigint,
  p_description varchar(250),
  p_code varchar(25)
)
returns bigint
language plpgsql
as $$
declare v_id bigint;
begin

    update tb_product
    set 
      desc = p_description,
      code = p_code
    where id = p_id
    returning id into v_id;

    return v_id;

end;$$
