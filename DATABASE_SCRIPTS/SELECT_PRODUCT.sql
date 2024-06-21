CREATE OR REPLACE FUNCTION SELECT_PRODUCT (P_PRD_ID INT, P_OPTION INT)
RETURNS REFCURSOR AS $$
DECLARE 
    CURSOR_PRODUCT REFCURSOR;
BEGIN
    -- RETORNA TODOS REGISTROS
    IF (P_OPTION = 1) THEN
       OPEN CURSOR_PRODUCT FOR
     SELECT PDR.PRD_ID,
            PRD.PRD_NAME,
            PRD.PRD_PRICE,
            PRD.PRD_STOCK
       FROM TBL_PRODUCT PRD;
    
    -- RETORNA OS DADOS DE UM PRODUTO (FILTRA PELO ID)
    ELSIF (P_OPTION = 2) THEN
       OPEN CURSOR_PRODUCT FOR 
     SELECT PDR.PRD_ID,
            PRD.PRD_NAME,
            PRD.PRD_PRICE,
            PRD.PRD_STOCK
       FROM TBL_PRODUCT PRD
      WHERE PRD.PRD_ID = P_PRD_ID;
    END IF;
END;
$$ LANGUAGE PLPGSQL;