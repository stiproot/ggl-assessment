drop function if exist fn_get_product;
CREATE FUNCTION fn_get_product
(
    p_offset_id bigint,
    p_offset_boundry int,
    p_limit int,
    p_query_string varchar(50)
)
RETURNS TABLE
(
    id bigint,
    description varchar(25), 
    code varchar(25) 
)
AS $$
BEGIN

    RETURN QUERY 
    SELECT
        t.id AS Id,
        t.description AS Description,
        t.code AS Code
    FROM tb_product t
    WHERE  
        (  
            (p_offset_id = -1) OR  
            (p_offset_boundry = 0 AND t.id > p_offset_id) OR  
            (p_offset_boundry = 1 AND t.id < p_offset_id)  
        )  
        AND  
        (  
            (p_query_string = '' OR p_query_string IS NULL) OR  
            (  
                LOWER(t.description) LIKE CONCAT('%', p_query_string, '%') OR
                LOWER(t.code) LIKE CONCAT('%', p_query_string, '%')
            )  
        )  
        ORDER BY t.id DESC  
        LIMIT CASE WHEN p_limit > 0 THEN p_limit END;
END;
$$ LANGUAGE plpgsql;
