drop function if exists fn_update_usr;
create or replace function fn_update_usr(
    p_id bigint,
    p_name varchar(50),
    p_surname varchar(50), 
    p_usrname varchar(50),
    p_password varchar(25),
    p_email varchar(50),
)
returns bigint
language plpgsql
as $$
declare v_id bigint;
begin

    update tb_usr
    set 
      name = p_name,
      surname = p_surname, 
      usrname = p_usrname, 
      pwd = p_password, 
      email = p_email
    where id = p_id
    returning id into v_id;

    return v_id;

end;$$
