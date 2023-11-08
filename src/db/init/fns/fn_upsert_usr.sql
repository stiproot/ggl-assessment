drop function if exists fn_upsert_usr;
create or replace function fn_upsert_usr(
    p_id bigint,
    p_usr_id bigint,
    p_usrname varchar(50),
    p_name varchar(50),
    p_surname varchar(50), 
    p_email varchar(50),
    p_pwd varchar(25)
)
returns bigint
language plpgsql
as $$
declare v_id bigint;
begin

    IF p_id > 0 THEN
      update tb_usr
      set 
        usrname = p_usrname, 
        name = p_name,
        surname = p_surname, 
        email = p_email,
        pwd = p_password 
      where id = p_id
      returning id into v_id;
    ELSE
      insert into tb_usr
      (
          usrname,
          name, 
          surname,
          email,
          pwd
      ) 
      values 
      (
          p_usrname, 
          p_name, 
          p_surname, 
          p_email, 
          p_pwd
      ) 
      returning id into v_id;
    END IF;

    return v_id;

end;$$
