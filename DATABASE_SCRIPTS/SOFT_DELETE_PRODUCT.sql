-- PROCEDURE: public.soft_delete_product(integer, integer)

-- DROP PROCEDURE IF EXISTS public.soft_delete_product(integer, integer);

CREATE OR REPLACE PROCEDURE public.soft_delete_product(
	IN p_prd_id integer,
	IN p_id_user integer)
LANGUAGE 'plpgsql'
AS $BODY$

BEGIN
    UPDATE TBL_PRODUCT
       SET PRD_DELETE = "#",
           MODIFIED_DATE = CURRENT_TIMESTAMP,
           MODIFIED_BY = P_ID_USER
     WHERE PRD_ID = P_PRD_ID;

    EXCEPTION
        WHEN OTHERS THEN
            RAISE EXCEPTION 'Erro ao deletar produto: %', SQLERRM;
END;
$BODY$;
ALTER PROCEDURE public.soft_delete_product(integer, integer)
    OWNER TO postgres;
