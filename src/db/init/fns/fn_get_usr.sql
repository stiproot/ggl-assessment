drop function if exists fn_get_usr;
CREATE FUNCTION fn_get_usr
(
    p_id bigint,
    p_usr_id bigint,
    p_offset_id bigint,
    p_offset_boundry int,
    p_limit int,
    p_query_string varchar(50)
)
RETURNS TABLE
(
    Id bigint,
    CreationTimestampUtc timestamp,
    Inactive boolean,
    Name varchar(50),
    Surname varchar(50),
    Email varchar(50)
)
AS $$
BEGIN

    RETURN QUERY
    SELECT
        u.id AS Id,
        u.creation_timestamp_utc AS CreationTimestampUtc,
        u.inactive AS Inactive,
        u.name AS Name,
        u.surname AS Surname,
        u.email AS Email
    FROM tb_usr AS u
    WHERE 
        (p_id <= 0 or u.id = p_id) and
        (
          (p_offset_id = -1) or
          (p_offset_boundry = 0 and u.id > p_offset_id) or
          (p_offset_boundry = 1 and u.id < p_offset_id)
        ) and
        (  
          (p_query_string = '' or p_query_string IS NULL) or  
          (  
              LOWER(u.email) LIKE CONCAT('%', p_query_string, '%') or 
              LOWER(u.surname) LIKE CONCAT('%', p_query_string, '%') or 
              LOWER(u.name) LIKE CONCAT('%', p_query_string, '%')
          )  
        )
        ORDER BY u.id DESC  
        LIMIT CASE WHEN p_limit > 0 THEN p_limit END;

END;
$$ LANGUAGE plpgsql;
