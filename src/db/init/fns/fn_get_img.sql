drop function if exists fn_get_img;
CREATE FUNCTION fn_get_img
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
    CreationTimestampUtc timestamp,
    Url varchar(500),
    ThumbnailUrl varchar(500)
)
AS $$
BEGIN

    RETURN QUERY
    SELECT
        t.id AS Id,
        t.creation_timestamp_utc AS CreationTimestampUtc,
        t.url AS Url,
        t.thumbnail_url AS ThumbnailUrl
    FROM tb_img AS t
    WHERE 
        (p_id <= 0 or t.id = p_id) and
        (
          (p_offset_id = -1) or
          (p_offset_boundry = 0 and t.id > p_offset_id) or
          (p_offset_boundry = 1 and t.id < p_offset_id)
        ) and
        (  
          (p_query_string = '' or p_query_string IS NULL) or  
          (  
              LOWER(t.url) LIKE CONCAT('%', p_query_string, '%')
          )  
        )
        ORDER BY t.id DESC  
        LIMIT CASE WHEN p_limit > 0 THEN p_limit END;

END;
$$ LANGUAGE plpgsql;
