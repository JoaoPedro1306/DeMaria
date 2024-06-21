CREATE OR REPLACE PROCEDURE UPDATE_CUSTOMER(
	P_CST_ID INT,
    P_NAME VARCHAR,
    P_CPF VARCHAR,
    P_EMAIL VARCHAR,
    P_PHONE VARCHAR,
    P_ZIP_CODE VARCHAR,
    P_STREET VARCHAR,
    P_NUMBER INT,
    P_COMPLEMENT VARCHAR,
    P_CITY VARCHAR,
    P_STATE VARCHAR,
	P_ID_USER INT
	)
LANGUAGE PLPGSQL
AS $$
BEGIN
	UPDATE TBL_CUSTOMER CST
	   SET CST.CST_NAME = P_NAME,
		   CST.CST_CPF = P_CPF,
		   CST.CST_EMAIL = P_EMAIL,
		   CST.CST_PHONE = P_PHONE,
		   CST.MODIFIED_DATE = CURRENT_TIMESTAMP,
		   CST.MODIFIED_BY = P_ID_USER
	 WHERE CST.CST_ID = P_CST_ID;

	UPDATE TBL_ADDRESS ADR
	   SET ADR.ADR_ZIP_CODE = P_ZIP_CODE,	 
		   ADR.ADR_STREET = P_STREET,  
		   ADR.ADR_NUMBER = P_NUMBER,
		   ADR.ADR_COMPLEMENT = P_COMPLEMENT,
		   ADR.ADR_CITY = P_CITY,
		   ADR.ADR_STATE = P_STATE,
		   ADR.MODIFIED_DATE = CURRENT_TIMESTAMP,
		   ADR.MODIFIED_BY = P_ID_USER
	 WHERE ADR.CST_ID = P_CST_ID;

	EXCEPTION 
		WHEN OTHERS THEN
			RAISE EXCEPTION 'Erro ao atualizar cliente e endereço: %', SQLERRM;
END;
$$;