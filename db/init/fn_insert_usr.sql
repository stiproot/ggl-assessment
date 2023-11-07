drop function if exists fn_insert_usr;
create or replace function fn_insert_usr(
    p_guid uuid,
    p_name varchar(50),
    p_surname varchar(50),
    p_usrname varchar(50),
    p_email varchar(50),
    p_password varchar(25),
    p_image_id bigint, 
    p_timezone_id smallint 
)
returns bigint
language plpgsql
as $$
declare v_id bigint;
begin

    insert into tb_usr
    (
        guid,
        name, 
        usr_id,
        surname,
        usrname,
        email,
        password,
        inactive
    ) 
    values 
    (
        p_guid,
        p_name, 
        cast(0 as bigint),
        p_surname, 
        p_usrname, 
        p_email, 
        p_password, 
        TRUE
    ) 
    returning id into v_id;

    return v_id;

end;$$
