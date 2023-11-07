drop function if exists fn_get_lst;
CREATE FUNCTION fn_get_lst
(
    p_id bigint,
    p_user_id bigint,
    p_offset_id bigint,
    p_offset_boundry int,
    p_limit int,
    p_query_string varchar(50)
)
RETURNS TABLE
(
    Id bigint,
    Guid uuid,
    UserId bigint,
    CreationTimestampUtc timestamp,
    Name varchar(500), 
    ProductIds bigint[]
)
AS $$
BEGIN

    RETURN QUERY 
    SELECT
        t.id as Id,
        t.guid as Guid,
        t.user_id as UserId,
        t.creation_timestamp_utc as CreationTimestampUtc,
        t.name as Name,
        t.product_ids as ProductIds
    FROM tb_lst as t
    WHERE 
        (p_id > 0 AND t.id = p_id) OR
        (  
            (p_offset_id = -1) OR  
            (p_offset_boundry = 0 AND t.id > p_offset_id) OR  
            (p_offset_boundry = 1 AND t.id < p_offset_id)  
        )  
        AND  
        (  
            (p_query_string = '' OR p_query_string IS NULL) OR  
            LOWER(t.name) LIKE CONCAT('%', p_query_string, '%')
        )  
        ORDER BY t.id DESC  
        LIMIT CASE WHEN p_limit > 0 THEN p_limit END;
END;
$$ LANGUAGE plpgsql;
