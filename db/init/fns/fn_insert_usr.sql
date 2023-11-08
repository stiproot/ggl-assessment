drop function if exists fn_insert_usr;
create or replace function fn_insert_usr(
    p_name varchar(50),
    p_surname varchar(50),
    p_usrname varchar(50),
    p_email varchar(50),
    p_password varchar(25)
)
returns bigint
language plpgsql
as $$
declare v_id bigint;
begin

    insert into tb_usr
    (
        usr_id,
        name, 
        surname,
        usrname,
        email,
        pwd,
        inactive
    ) 
    values 
    (
        cast(0 as bigint),
        p_name, 
        p_surname, 
        p_usrname, 
        p_email, 
        p_password, 
        FALSE
    ) 
    returning id into v_id;

    return v_id;

end;$$
