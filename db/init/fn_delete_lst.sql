drop function if exists fn_delete_lst;
create or replace function fn_delete_lst(
    p_id bigint
)
returns bigint
language plpgsql
as $$
declare v_id bigint;
begin

    delete from tb_lst t
    where t.id = p_id
    returning t.id into v_id;

    return v_id;

end;$$
