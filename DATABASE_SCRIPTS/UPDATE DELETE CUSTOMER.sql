-- PROCEDURE: public.delete_customer(integer)

-- DROP PROCEDURE IF EXISTS public.delete_customer(integer);

CREATE OR REPLACE PROCEDURE public.delete_customer(
	IN p_cst_id integer,
	IN P_ID_USER integer)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
   UPDATE TBL_CUSTOMER
	
	  SET CST_DELETE = '*',
          MODIFIED_DATE = CURRENT_TIMESTAMP,
          MODIFIED_BY = P_ID_USER
    WHERE CST_ID = P_CST_ID;

	EXCEPTION 
		WHEN OTHERS THEN
			RAISE EXCEPTION 'Erro ao deletar cliente: %', SQLERRM;
END;
$BODY$;
ALTER PROCEDURE public.delete_customer(integer)
    OWNER TO postgres;
