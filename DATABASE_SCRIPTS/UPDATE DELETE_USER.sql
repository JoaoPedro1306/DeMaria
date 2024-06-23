-- PROCEDURE: public.delete_user(integer)

-- DROP PROCEDURE IF EXISTS public.delete_user(integer);

CREATE OR REPLACE PROCEDURE public.delete_user(
	IN p_usr_id integer)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
   DELETE 
	FROM TBL_USER 
    WHERE USR_ID = P_USR_ID;

	EXCEPTION 
		WHEN OTHERS THEN
			RAISE EXCEPTION 'Erro ao deletar usuário: %', SQLERRM;
END;
$BODY$;
ALTER PROCEDURE public.delete_user(integer)
    OWNER TO postgres;
