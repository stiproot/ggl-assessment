drop function if exists fn_upsert_ext_access_token;
create or replace function fn_upsert_ext_access_token(
  p_id bigint,
  p_usr_id bigint,
  p_token varchar(500),
  p_refresh_token varchar(500),
  p_inactive boolean, 
  p_expiration_timestamp_utc TIMESTAMP
)
returns bigint
language plpgsql
as $$
declare v_id bigint;
begin

    IF p_id > 0 THEN
      update tb_ext_access_token
      set 
        usr_id = p_usr_id, 
        token = p_token,
        refresh_token = p_refresh_token, 
        inactive = p_inactive,
        expiration_timestamp_utc = p_expiration_timestamp_utc
      where id = p_id
      returning id into v_id;
    ELSE
      insert into tb_usr
      (
        usr_id,
        token,
        refresh_token,
        inactive,
        expiration_timestamp_utc
      ) 
      values 
      (
        p_usr_id,
        p_token,
        p_refresh_token,
        p_inactive,
        p_expiration_timestamp_utc
      ) 
      returning id into v_id;
    END IF;

    return v_id;

end;$$
