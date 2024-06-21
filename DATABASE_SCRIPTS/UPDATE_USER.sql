CREATE OR REPLACE PROCEDURE UPDATE_USER (
	P_USR_ID INT,
	P_NAME VARCHAR,
	P_EMAIL VARCHAR,
	P_ID_USER INT
) LANGUAGE PLPGSQL AS $$
BEGIN
	UPDATE TBL_USER USR
	   SET USR.USR_NAME = P_NAME,
		   USR.USR_EMAIL = P_EMAIL,
		   USR.MODIFIED_DATE = CURRENT_TIMESTAMP,
		   USR.MODIFIED_BY = P_ID_USER
	 WHERE USR.USR_ID = P_USR_ID;

	EXCEPTION 
		WHEN OTHERS THEN
			RAISE EXCEPTION 'Erro ao atualizar usuário: %', SQLERRM;
END;
$$;