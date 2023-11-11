drop function if exists fn_delete_ext_access_token;
create or replace function fn_delete_ext_access_token(
    p_id bigint,
    p_usr_id bigint
)
returns bigint
language plpgsql
as $$
declare v_id bigint;
begin

    delete from tb_ext_access_token t
    where t.id = p_id and t.usr_id = p_usr_id
    returning t.id into v_id;

    return v_id;

end;$$
