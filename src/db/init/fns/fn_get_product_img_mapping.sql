drop function if exists fn_get_product_img_mapping;
CREATE FUNCTION fn_get_product_img_mapping
(
    p_id bigint,
    p_usr_id bigint,
    p_product_id bigint,
    p_offset_id bigint,
    p_offset_boundry int,
    p_limit int,
    p_query_string varchar(50)
)
RETURNS TABLE
(
    Id bigint,
    ImgId bigint,
    Url varchar(500), 
    ThumbnailUrl varchar(500)
)
AS $$
BEGIN

    RETURN QUERY 
    SELECT
        t.id AS Id,
        img.id AS ImgId,
        img.url AS Url,
        img.thumbnail_url AS ThumbnailUrl
    FROM tb_product_img_mapping t
        INNER JOIN tb_img AS img
            ON t.img_id = img.id
    WHERE  
        (  
            (p_offset_id = -1) OR  
            (p_offset_boundry = 0 AND t.id > p_offset_id) OR  
            (p_offset_boundry = 1 AND t.id < p_offset_id)  
        )  
        AND t.product_id = p_product_id
        ORDER BY t.id DESC  
        LIMIT CASE WHEN p_limit > 0 THEN p_limit END;
END;
$$ LANGUAGE plpgsql;
