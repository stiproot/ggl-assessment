drop function if exists fn_insert_img;
create or replace function fn_insert_img(
    p_url varchar(500),
    p_thumbnail_url varchar(500),
    p_file_path varchar(500),
    p_usr_id bigint
)
returns bigint
language plpgsql
as $$
declare v_id bigint;
begin

    insert into tb_img
    (
        url, 
        thumbnail_url,
        file_path,
        usr_id
    ) 
    values 
    (
        p_url, 
        p_thumbnail_url, 
        p_file_path,
        p_usr_id
    ) 
    returning id into v_id;

    return v_id;

end;$$
