drop function if exists fn_upsert_usr;
create or replace function fn_upsert_usr(
    p_id bigint,
    p_usr_id bigint,
    p_name varchar(50),
    p_surname varchar(50),
    p_email varchar(50)
)
returns bigint
language plpgsql
as $$
declare v_id bigint;
begin

    IF p_id > 0 THEN
      update tb_usr
      set 
        name = p_name,
        surname = p_surname, 
        email = p_email
      where id = p_id
      returning id into v_id;
    ELSE
      insert into tb_usr
      (
          name, 
          surname,
          email
      ) 
      values 
      (
          p_name, 
          p_surname, 
          p_email
      ) 
      returning id into v_id;
    END IF;

    return v_id;

end;$$
