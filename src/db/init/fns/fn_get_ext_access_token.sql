drop function if exists fn_get_ext_access_token;
CREATE FUNCTION fn_get_ext_access_token
(
    p_id bigint,
    p_usr_id bigint,
    p_offset_id bigint,
    p_offset_boundry int,
    p_limit int,
    p_query_string varchar(500)
)
RETURNS TABLE
(
    Id bigint,
    CreationTimestampUtc TIMESTAMP,
    UsrId bigint,
    Token varchar(500),
    RefreshToken varchar(500),
    Inactive boolean,
    ExpirationTimestampUtc TIMESTAMP
)
AS $$
BEGIN

    RETURN QUERY
    SELECT
        t.id AS Id,
        t.creation_timestamp_utc AS CreationTimestampUtc,
        t.usr_id AS UsrId,
        t.token AS Token,
        t.refresh_token AS RefreshToken,
        t.inactive AS Inactive,
        t.expiration_timestamp_utc AS ExpirationTimestampUtc
    FROM tb_ext_access_token AS t
    WHERE
        (
            (p_id <= 0) OR
            (p_id > 0 AND t.id = p_id)
        ) AND
        t.usr_id = p_usr_id AND
        t.inactive = FALSE;

END;
$$ LANGUAGE plpgsql;
