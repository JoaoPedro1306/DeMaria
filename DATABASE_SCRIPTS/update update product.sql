-- PROCEDURE: public.update_product(integer, character varying, numeric, integer, integer)

-- DROP PROCEDURE IF EXISTS public.update_product(integer, character varying, numeric, integer, integer);

CREATE OR REPLACE PROCEDURE public.update_product(
	IN p_prd_id integer,
	IN p_name character varying,
	IN p_price numeric,
	IN p_stock integer,
	IN p_id_user integer)
LANGUAGE 'plpgsql'
AS $BODY$

BEGIN
    UPDATE TBL_PRODUCT
       SET PRD_NAME = P_NAME,
           PRD_PRICE = P_PRICE,
           PRD_STOCK = P_STOCK,
           MODIFIED_DATE = CURRENT_TIMESTAMP,
           MODIFIED_BY = P_ID_USER
     WHERE PRD_ID = P_PRD_ID;

    EXCEPTION
        WHEN OTHERS THEN
            RAISE EXCEPTION 'Erro ao atualizar produto: %', SQLERRM;
END;
$BODY$;
ALTER PROCEDURE public.update_product(integer, character varying, numeric, integer, integer)
    OWNER TO postgres;
