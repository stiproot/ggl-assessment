drop function if exists fn_update_img;
create or replace function fn_update_img(
  p_id bigint,
  p_usr_id,
  p_url varchar(50),
  p_thumbnail_url varchar(50)
)
returns bigint
language plpgsql
as $$
declare v_id bigint;
begin

    update tb_img
    set 
      url = p_url,
      thumbnail_url = p_thumbnail_url
    where id = p_id AND urs_id = p_usr_id
    returning id into v_id;

    return v_id;

end;$$
