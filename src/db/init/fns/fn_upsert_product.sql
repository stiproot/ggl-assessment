drop function if exists fn_upsert_product;
create or replace function fn_upsert_product(
  p_id bigint,
  p_usr_id bigint,
  p_description varchar(250),
  p_code varchar(25)
)
returns bigint
language plpgsql
as $$
declare v_id bigint;
begin

    RAISE NOTICE 'p_id: %', p_id;
    RAISE NOTICE 'p_usr_id: %', p_usr_id;
    RAISE NOTICE 'p_description: %', p_description;
    RAISE NOTICE 'p_code: %', p_code;

    IF p_id > 0 THEN

      update tb_product
      set 
        description = p_description,
        code = p_code
      where id = p_id
      returning id into v_id;

    ELSE

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

    END IF;

    return v_id;

end;$$
