-- PROCEDURE: public.update_password(integer, character varying, integer)

-- DROP PROCEDURE IF EXISTS public.update_password(integer, character varying, integer);

CREATE OR REPLACE PROCEDURE public.update_password(
	IN p_usr_id integer,
	IN p_password character varying,
	IN p_id_user integer)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
	UPDATE TBL_USER
	   SET USR_PASSWORD = P_PASSWORD,
		   MODIFIED_DATE = CURRENT_TIMESTAMP,
		   MODIFIED_BY = P_ID_USER
	 WHERE USR_ID = P_USR_ID;

	EXCEPTION 
		WHEN OTHERS THEN
			RAISE EXCEPTION 'Erro ao alterar senha: %', SQLERRM;
END;
$BODY$;
ALTER PROCEDURE public.update_password(integer, character varying, integer)
    OWNER TO postgres;
