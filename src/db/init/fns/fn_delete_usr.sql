drop function if exists fn_delete_usr;
create or replace function fn_delete_usr(
    p_id bigint,
    p_usr_id bigint
)
returns bigint
language plpgsql
as $$
declare v_id bigint;
begin

    delete from tb_usr t
    where t.id = p_id
    returning t.id into v_id;

    return v_id;

end;$$
