drop function if exists fn_upsert_img;
create or replace function fn_upsert_img(
  p_id bigint,
  p_usr_id bigint,
  p_url varchar(50),
  p_thumbnail_url varchar(50)
)
returns bigint
language plpgsql
as $$
declare v_id bigint;
begin

  IF p_id > 0 THEN
    update tb_img
    set 
      url = p_url,
      thumbnail_url = p_thumbnail_url
    where id = p_id
    returning id into v_id;
  ELSE
    insert into tb_img
    (
      url, 
      thumbnail_url
    ) 
    values 
    (
        p_url, 
        p_thumbnail_url
    ) 
    returning id into v_id;

  END IF;

  return v_id;

end;$$
