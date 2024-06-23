-- PROCEDURE: public.insert_customer(character varying, character varying, character varying, character varying, character varying, character varying, integer, character varying, character varying, character varying, integer)

-- DROP PROCEDURE IF EXISTS public.insert_customer(character varying, character varying, character varying, character varying, character varying, character varying, integer, character varying, character varying, character varying, integer);

CREATE OR REPLACE PROCEDURE public.insert_customer(
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
DECLARE
    V_CST_ID INTEGER;
BEGIN
    INSERT INTO TBL_CUSTOMER (CST_NAME, CST_CPF, CST_EMAIL, CST_PHONE, CREATION_DATE, CREATED_BY) 
    VALUES (P_NAME, P_CPF, P_EMAIL, P_PHONE, CURRENT_TIMESTAMP, P_ID_USER)
    RETURNING CST_ID INTO V_CST_ID;

    INSERT INTO TBL_ADDRESS (ADR_ID, ADR_ZIP_CODE, ADR_STREET, ADR_NUMBER, ADR_COMPLEMENT, ADR_CITY, ADR_STATE, CREATION_DATE, CREATED_BY) 
    VALUES (V_CST_ID, P_ZIP_CODE, P_STREET, P_NUMBER, P_COMPLEMENT, P_CITY, P_STATE, CURRENT_TIMESTAMP, P_ID_USER);

    EXCEPTION
        WHEN OTHERS THEN
            RAISE EXCEPTION 'Erro ao inserir cliente e endereço: %', SQLERRM;
END;
$BODY$;
ALTER PROCEDURE public.insert_customer(character varying, character varying, character varying, character varying, character varying, character varying, integer, character varying, character varying, character varying, integer)
    OWNER TO postgres;
