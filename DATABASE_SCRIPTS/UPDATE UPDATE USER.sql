-- PROCEDURE: public.update_user(integer, character varying, character varying, integer)

-- DROP PROCEDURE IF EXISTS public.update_user(integer, character varying, character varying, integer);

CREATE OR REPLACE PROCEDURE public.update_user(
	IN p_usr_id integer,
	IN p_name character varying,
	IN p_email character varying,
	IN p_id_user integer)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
	UPDATE TBL_USER
	   SET USR_NAME = P_NAME,
		   USR_EMAIL = P_EMAIL,
		   MODIFIED_DATE = CURRENT_TIMESTAMP,
		   MODIFIED_BY = P_ID_USER
	 WHERE USR_ID = P_USR_ID;

	EXCEPTION 
		WHEN OTHERS THEN
			RAISE EXCEPTION 'Erro ao atualizar usuário: %', SQLERRM;
END;
$BODY$;
ALTER PROCEDURE public.update_user(integer, character varying, character varying, integer)
    OWNER TO postgres;
