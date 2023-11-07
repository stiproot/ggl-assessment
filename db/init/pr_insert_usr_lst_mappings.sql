drop procedure if exists pr_insert_usr_lst_mappings;
create procedure pr_insert_usr_lst_mappings(
    p_id bigint,
    p_usr_id bigint,
    p_lst_id int
)
language plpgsql
as $$
declare i int;
begin

    FOREACH i in ARRAY p_product_ids
    LOOP

        insert into tb_usr_lst_mapping
        (
            usr_id,
        ) 
        values 
        (
            i
        );

    END LOOP;

end;$$