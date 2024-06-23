-- PROCEDURE: public.insert_product(character varying, numeric, integer, integer)

-- DROP PROCEDURE IF EXISTS public.insert_product(character varying, numeric, integer, integer);

CREATE OR REPLACE PROCEDURE public.insert_product(
	IN p_name character varying,
	IN p_price numeric(10,2),
	IN p_stock integer,
	IN p_id_user integer)
LANGUAGE 'plpgsql'
AS $BODY$

BEGIN
    INSERT INTO TBL_PRODUCT (PRD_NAME, PRD_PRICE, PRD_STOCK, CREATION_DATE, CREATED_BY) 
    VALUES (P_NAME, P_PRICE, P_STOCK, CURRENT_TIMESTAMP, P_ID_USER);    

    EXCEPTION
        WHEN OTHERS THEN
            RAISE EXCEPTION 'Erro ao inserir produto: %', SQLERRM;
END;
$BODY$;
ALTER PROCEDURE public.insert_product(character varying, numeric, integer, integer)
    OWNER TO postgres;
