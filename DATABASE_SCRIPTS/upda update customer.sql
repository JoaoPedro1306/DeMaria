-- PROCEDURE: public.update_customer(integer, character varying, character varying, character varying, character varying, character varying, character varying, integer, character varying, character varying, character varying, integer)

-- DROP PROCEDURE IF EXISTS public.update_customer(integer, character varying, character varying, character varying, character varying, character varying, character varying, integer, character varying, character varying, character varying, integer);

CREATE OR REPLACE PROCEDURE public.update_customer(
	IN p_cst_id integer,
	IN p_name character varying,
	IN p_cpf character varying,
	IN p_email character varying,
	IN p_phone character varying,
	IN p_zip_code character varying,
	IN p_street character varying,
	IN p_number integer,
	IN p_complement character varying,
	IN p_city character varying,
	IN p_state character varying,
	IN p_id_user integer)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
    UPDATE TBL_CUSTOMER
       SET CST_NAME = P_NAME,
           CST_CPF = P_CPF,
           CST_EMAIL = P_EMAIL,
           CST_PHONE = P_PHONE,
           MODIFIED_DATE = CURRENT_TIMESTAMP,
           MODIFIED_BY = P_ID_USER
     WHERE CST_ID = P_CST_ID;

    UPDATE TBL_ADDRESS
       SET ADR_ZIP_CODE = P_ZIP_CODE,    
           ADR_STREET = P_STREET,  
           ADR_NUMBER = P_NUMBER,
           ADR_COMPLEMENT = P_COMPLEMENT,
           ADR_CITY = P_CITY,
           ADR_STATE = P_STATE,
           MODIFIED_DATE = CURRENT_TIMESTAMP,
           MODIFIED_BY = P_ID_USER
     WHERE CST_ID = P_CST_ID;

	EXCEPTION 
		WHEN OTHERS THEN
			RAISE EXCEPTION 'Erro ao atualizar cliente: %', SQLERRM;
END;
$BODY$;
ALTER PROCEDURE public.update_customer(integer, character varying, character varying, character varying, character varying, character varying, character varying, integer, character varying, character varying, character varying, integer)
    OWNER TO postgres;
