--
-- PostgreSQL database dump
--

-- Dumped from database version 16.3
-- Dumped by pg_dump version 16.3

-- Started on 2024-06-24 07:48:15

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 225 (class 1255 OID 16963)
-- Name: delete_customer(integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.delete_customer(IN p_cst_id integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
   UPDATE TBL_CUSTOMER
	  SET CST_DELETE = '*'
    WHERE CST_ID = P_CST_ID;

	EXCEPTION 
		WHEN OTHERS THEN
			RAISE EXCEPTION 'Erro ao deletar cliente: %', SQLERRM;
END;
$$;


ALTER PROCEDURE public.delete_customer(IN p_cst_id integer) OWNER TO postgres;

--
-- TOC entry 226 (class 1255 OID 16994)
-- Name: delete_customer(integer, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.delete_customer(IN p_cst_id integer, IN p_id_user integer)
    LANGUAGE plpgsql
    AS $$
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
$$;


ALTER PROCEDURE public.delete_customer(IN p_cst_id integer, IN p_id_user integer) OWNER TO postgres;

--
-- TOC entry 227 (class 1255 OID 16964)
-- Name: delete_user(integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.delete_user(IN p_usr_id integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE TBL_USER
       SET USR_DELETE = '*',
           MODIFIED_DATE = CURRENT_TIMESTAMP,
           MODIFIED_BY = P_USR_ID
     WHERE USR_ID = P_USR_ID;
	EXCEPTION 
		WHEN OTHERS THEN
			RAISE EXCEPTION 'Erro ao deletar usuário: %', SQLERRM;
END;
$$;


ALTER PROCEDURE public.delete_user(IN p_usr_id integer) OWNER TO postgres;

--
-- TOC entry 248 (class 1255 OID 16961)
-- Name: insert_customer(character varying, character varying, character varying, character varying, character varying, character varying, integer, character varying, character varying, character varying, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.insert_customer(IN p_name character varying, IN p_cpf character varying, IN p_email character varying, IN p_phone character varying, IN p_zip_code character varying, IN p_street character varying, IN p_number integer, IN p_complement character varying, IN p_city character varying, IN p_state character varying, IN p_id_user integer)
    LANGUAGE plpgsql
    AS $$
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
$$;


ALTER PROCEDURE public.insert_customer(IN p_name character varying, IN p_cpf character varying, IN p_email character varying, IN p_phone character varying, IN p_zip_code character varying, IN p_street character varying, IN p_number integer, IN p_complement character varying, IN p_city character varying, IN p_state character varying, IN p_id_user integer) OWNER TO postgres;

--
-- TOC entry 243 (class 1255 OID 16969)
-- Name: insert_product(character varying, numeric, integer, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.insert_product(IN p_name character varying, IN p_price numeric, IN p_stock integer, IN p_id_user integer)
    LANGUAGE plpgsql
    AS $$

BEGIN
    INSERT INTO TBL_PRODUCT (PRD_NAME, PRD_PRICE, PRD_STOCK, CREATION_DATE, CREATED_BY) 
    VALUES (P_NAME, P_PRICE, P_STOCK, CURRENT_TIMESTAMP, P_ID_USER);    

    EXCEPTION
        WHEN OTHERS THEN
            RAISE EXCEPTION 'Erro ao inserir produto: %', SQLERRM;
END;
$$;


ALTER PROCEDURE public.insert_product(IN p_name character varying, IN p_price numeric, IN p_stock integer, IN p_id_user integer) OWNER TO postgres;

--
-- TOC entry 244 (class 1255 OID 16997)
-- Name: insert_product_sale(integer, integer, integer, numeric, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.insert_product_sale(IN p_sale_id integer, IN p_product_id integer, IN p_quantity integer, IN p_price numeric, IN p_id_user integer)
    LANGUAGE plpgsql
    AS $$
DECLARE
    V_STOCK INT;
BEGIN
    INSERT INTO TBL_PRODUCT_SALE (SLS_ID, PRD_ID, PRS_QUANTITY, PRD_PRICE) 
    VALUES (P_SALE_ID, P_PRODUCT_ID, P_QUANTITY, P_PRICE);    

    SELECT PRD_STOCK INTO V_STOCK FROM TBL_PRODUCT WHERE PRD_ID = P_PRODUCT_ID;

    UPDATE TBL_PRODUCT
       SET PRD_STOCK = V_STOCK-P_QUANTITY,
           MODIFIED_BY = P_ID_USER,
           MODIFIED_DATE = CURRENT_TIMESTAMP
     WHERE PRD_ID = P_PRODUCT_ID;

    EXCEPTION
        WHEN OTHERS THEN
            RAISE EXCEPTION 'Erro ao inserir venda: %', SQLERRM;
END;
$$;


ALTER PROCEDURE public.insert_product_sale(IN p_sale_id integer, IN p_product_id integer, IN p_quantity integer, IN p_price numeric, IN p_id_user integer) OWNER TO postgres;

--
-- TOC entry 245 (class 1255 OID 16998)
-- Name: insert_sale(integer, numeric, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.insert_sale(p_cst_id integer, p_total_price numeric, p_id_user integer) RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    V_SLS_ID INT;
BEGIN
    INSERT INTO TBL_SALES (CST_ID, SLS_TOTAL_PRICE, CREATED_BY) 
    VALUES (P_CST_ID, P_TOTAL_PRICE, P_ID_USER) 
    RETURNING SLS_ID INTO V_SLS_ID;

    RETURN V_SLS_ID;
EXCEPTION
    WHEN OTHERS THEN
        RAISE EXCEPTION 'Erro ao inserir venda: %', SQLERRM;
END;
$$;


ALTER FUNCTION public.insert_sale(p_cst_id integer, p_total_price numeric, p_id_user integer) OWNER TO postgres;

--
-- TOC entry 228 (class 1255 OID 16966)
-- Name: insert_user(character varying, character varying, character varying, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.insert_user(IN p_name character varying, IN p_email character varying, IN p_password character varying, IN p_id_user integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO TBL_USER (USR_NAME, USR_EMAIL, USR_PASSWORD, CREATION_DATE, CREATED_BY) 
    VALUES (P_NAME, P_EMAIL, P_PASSWORD, CURRENT_TIMESTAMP, P_ID_USER);    

    EXCEPTION
        WHEN OTHERS THEN
            RAISE EXCEPTION 'Erro ao inserir usuário: %', SQLERRM;
END;
$$;


ALTER PROCEDURE public.insert_user(IN p_name character varying, IN p_email character varying, IN p_password character varying, IN p_id_user integer) OWNER TO postgres;

--
-- TOC entry 246 (class 1255 OID 16985)
-- Name: soft_delete_product(integer, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.soft_delete_product(IN p_prd_id integer, IN p_id_user integer)
    LANGUAGE plpgsql
    AS $$

BEGIN
    UPDATE TBL_PRODUCT
       SET PRD_DELETE = '*',
           MODIFIED_DATE = CURRENT_TIMESTAMP,
           MODIFIED_BY = P_ID_USER
     WHERE PRD_ID = P_PRD_ID;

    EXCEPTION
        WHEN OTHERS THEN
            RAISE EXCEPTION 'Erro ao deletar produto: %', SQLERRM;
END;
$$;


ALTER PROCEDURE public.soft_delete_product(IN p_prd_id integer, IN p_id_user integer) OWNER TO postgres;

--
-- TOC entry 247 (class 1255 OID 16962)
-- Name: update_customer(integer, character varying, character varying, character varying, character varying, character varying, character varying, integer, character varying, character varying, character varying, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.update_customer(IN p_cst_id integer, IN p_name character varying, IN p_cpf character varying, IN p_email character varying, IN p_phone character varying, IN p_zip_code character varying, IN p_street character varying, IN p_number integer, IN p_complement character varying, IN p_city character varying, IN p_state character varying, IN p_id_user integer)
    LANGUAGE plpgsql
    AS $$
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
     WHERE ADR_ID = P_CST_ID;

	EXCEPTION 
		WHEN OTHERS THEN
			RAISE EXCEPTION 'Erro ao atualizar cliente: %', SQLERRM;
END;
$$;


ALTER PROCEDURE public.update_customer(IN p_cst_id integer, IN p_name character varying, IN p_cpf character varying, IN p_email character varying, IN p_phone character varying, IN p_zip_code character varying, IN p_street character varying, IN p_number integer, IN p_complement character varying, IN p_city character varying, IN p_state character varying, IN p_id_user integer) OWNER TO postgres;

--
-- TOC entry 230 (class 1255 OID 16968)
-- Name: update_password(integer, character varying, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.update_password(IN p_usr_id integer, IN p_password character varying, IN p_id_user integer)
    LANGUAGE plpgsql
    AS $$
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
$$;


ALTER PROCEDURE public.update_password(IN p_usr_id integer, IN p_password character varying, IN p_id_user integer) OWNER TO postgres;

--
-- TOC entry 242 (class 1255 OID 16970)
-- Name: update_product(integer, character varying, numeric, integer, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.update_product(IN p_prd_id integer, IN p_name character varying, IN p_price numeric, IN p_stock integer, IN p_id_user integer)
    LANGUAGE plpgsql
    AS $$

BEGIN
    UPDATE TBL_PRODUCT
       SET PRD_NAME = P_NAME,
           PRD_PRICE = P_PRICE,
           PRD_STOCK = P_STOCK,
           MODIFIED_DATE = CURRENT_TIMESTAMP,
           MODIFIED_BY = P_ID_USER
     WHERE PRD_ID = P_PRD_ID;

    EXCEPTION
        WHEN OTHERS THEN
            RAISE EXCEPTION 'Erro ao atualizar produto: %', SQLERRM;
END;
$$;


ALTER PROCEDURE public.update_product(IN p_prd_id integer, IN p_name character varying, IN p_price numeric, IN p_stock integer, IN p_id_user integer) OWNER TO postgres;

--
-- TOC entry 229 (class 1255 OID 16967)
-- Name: update_user(integer, character varying, character varying, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.update_user(IN p_usr_id integer, IN p_name character varying, IN p_email character varying, IN p_id_user integer)
    LANGUAGE plpgsql
    AS $$
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
$$;


ALTER PROCEDURE public.update_user(IN p_usr_id integer, IN p_name character varying, IN p_email character varying, IN p_id_user integer) OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 219 (class 1259 OID 16882)
-- Name: tbl_address; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tbl_address (
    adr_id integer NOT NULL,
    adr_zip_code character varying(8) NOT NULL,
    adr_street character varying(100) NOT NULL,
    adr_number integer NOT NULL,
    adr_complement character varying(100),
    adr_city character varying(100) NOT NULL,
    adr_state character varying(100) NOT NULL,
    creation_date timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    created_by integer NOT NULL,
    modified_date timestamp without time zone,
    modified_by integer
);


ALTER TABLE public.tbl_address OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 16863)
-- Name: tbl_customer; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tbl_customer (
    cst_id integer NOT NULL,
    cst_name character varying(100) NOT NULL,
    cst_cpf character varying(11) NOT NULL,
    cst_email character varying(100) NOT NULL,
    cst_phone character varying(11) NOT NULL,
    creation_date timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    created_by integer NOT NULL,
    modified_date timestamp without time zone,
    modified_by integer,
    cst_delete "char"
);


ALTER TABLE public.tbl_customer OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16862)
-- Name: tbl_customer_cst_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tbl_customer_cst_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.tbl_customer_cst_id_seq OWNER TO postgres;

--
-- TOC entry 4921 (class 0 OID 0)
-- Dependencies: 217
-- Name: tbl_customer_cst_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tbl_customer_cst_id_seq OWNED BY public.tbl_customer.cst_id;


--
-- TOC entry 221 (class 1259 OID 16904)
-- Name: tbl_product; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tbl_product (
    prd_id integer NOT NULL,
    prd_name character varying(100) NOT NULL,
    prd_price numeric(10,2) NOT NULL,
    prd_stock integer NOT NULL,
    creation_date timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    created_by integer NOT NULL,
    modified_date timestamp without time zone,
    modified_by integer,
    prd_delete character varying(4)
);


ALTER TABLE public.tbl_product OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 16903)
-- Name: tbl_product_prd_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tbl_product_prd_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.tbl_product_prd_id_seq OWNER TO postgres;

--
-- TOC entry 4922 (class 0 OID 0)
-- Dependencies: 220
-- Name: tbl_product_prd_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tbl_product_prd_id_seq OWNED BY public.tbl_product.prd_id;


--
-- TOC entry 224 (class 1259 OID 16944)
-- Name: tbl_product_sale; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tbl_product_sale (
    sls_id integer NOT NULL,
    prd_id integer NOT NULL,
    prs_quantity integer NOT NULL,
    prd_price numeric(10,2) NOT NULL
);


ALTER TABLE public.tbl_product_sale OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 16922)
-- Name: tbl_sales; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tbl_sales (
    sls_id integer NOT NULL,
    cst_id integer NOT NULL,
    sls_total_price numeric(10,2) NOT NULL,
    creation_date timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    created_by integer NOT NULL,
    modified_date timestamp without time zone,
    modified_by integer
);


ALTER TABLE public.tbl_sales OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 16921)
-- Name: tbl_sales_sls_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tbl_sales_sls_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.tbl_sales_sls_id_seq OWNER TO postgres;

--
-- TOC entry 4923 (class 0 OID 0)
-- Dependencies: 222
-- Name: tbl_sales_sls_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tbl_sales_sls_id_seq OWNED BY public.tbl_sales.sls_id;


--
-- TOC entry 216 (class 1259 OID 16843)
-- Name: tbl_user; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tbl_user (
    usr_id integer NOT NULL,
    usr_name character varying(100) NOT NULL,
    usr_email character varying(100) NOT NULL,
    usr_password character varying(255),
    creation_date timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    created_by integer NOT NULL,
    modified_date timestamp without time zone,
    modified_by integer,
    usr_delete "char"
);


ALTER TABLE public.tbl_user OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 16842)
-- Name: tbl_user_usr_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tbl_user_usr_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.tbl_user_usr_id_seq OWNER TO postgres;

--
-- TOC entry 4924 (class 0 OID 0)
-- Dependencies: 215
-- Name: tbl_user_usr_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tbl_user_usr_id_seq OWNED BY public.tbl_user.usr_id;


--
-- TOC entry 4726 (class 2604 OID 16866)
-- Name: tbl_customer cst_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_customer ALTER COLUMN cst_id SET DEFAULT nextval('public.tbl_customer_cst_id_seq'::regclass);


--
-- TOC entry 4729 (class 2604 OID 16907)
-- Name: tbl_product prd_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_product ALTER COLUMN prd_id SET DEFAULT nextval('public.tbl_product_prd_id_seq'::regclass);


--
-- TOC entry 4731 (class 2604 OID 16925)
-- Name: tbl_sales sls_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_sales ALTER COLUMN sls_id SET DEFAULT nextval('public.tbl_sales_sls_id_seq'::regclass);


--
-- TOC entry 4724 (class 2604 OID 16846)
-- Name: tbl_user usr_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_user ALTER COLUMN usr_id SET DEFAULT nextval('public.tbl_user_usr_id_seq'::regclass);


--
-- TOC entry 4910 (class 0 OID 16882)
-- Dependencies: 219
-- Data for Name: tbl_address; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tbl_address (adr_id, adr_zip_code, adr_street, adr_number, adr_complement, adr_city, adr_state, creation_date, created_by, modified_date, modified_by) FROM stdin;
5	12234510	Rua Zilda Pinotti Martins	173	Casa	São José dos Campos	SP	2024-06-23 02:05:47.624813	11	\N	\N
2	12240480	Rua Durvalina Simões	259	Casa Amarela (Fundos)	São José dos Campos	SP	2024-06-23 01:49:29.694194	11	2024-06-23 02:06:40.094848	11
\.


--
-- TOC entry 4909 (class 0 OID 16863)
-- Dependencies: 218
-- Data for Name: tbl_customer; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tbl_customer (cst_id, cst_name, cst_cpf, cst_email, cst_phone, creation_date, created_by, modified_date, modified_by, cst_delete) FROM stdin;
5	Teste exclusao	44444444444	teste@gmail.com	11111111111	2024-06-23 02:05:47.624813	11	2024-06-23 02:05:58.640655	11	*
2	Giovana Luanna	12345678910	giovana@gmail.com	12992328947	2024-06-23 01:49:29.694194	11	2024-06-23 02:06:40.094848	11	\N
\.


--
-- TOC entry 4912 (class 0 OID 16904)
-- Dependencies: 221
-- Data for Name: tbl_product; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tbl_product (prd_id, prd_name, prd_price, prd_stock, creation_date, created_by, modified_date, modified_by, prd_delete) FROM stdin;
3	Teste pra exclusão	12.00	12	2024-06-22 19:23:32.000243	4	2024-06-22 19:35:19.438218	4	*
1	Arroz Tipo 1 5Kg	30.29	19	2024-06-22 17:51:23.948728	4	2024-06-22 20:01:11.637654	11	\N
2	Feijão Carioca 1Kg	4.99	24	2024-06-22 19:20:32.498001	4	2024-06-24 07:33:28.306759	11	\N
4	Açucar 1Kg	4.35	38	2024-06-22 19:42:09.390416	4	2024-06-24 07:33:28.306759	11	\N
5	Óleo de Soja 900ml	6.59	23	2024-06-22 19:43:30.485052	4	2024-06-24 07:33:28.306759	11	\N
6	Macarrão 1Kg	2.99	18	2024-06-22 20:01:50.856565	11	2024-06-24 07:33:28.306759	11	\N
\.


--
-- TOC entry 4915 (class 0 OID 16944)
-- Dependencies: 224
-- Data for Name: tbl_product_sale; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tbl_product_sale (sls_id, prd_id, prs_quantity, prd_price) FROM stdin;
1	2	1	4.99
1	4	2	4.35
1	5	2	6.59
1	6	2	2.99
\.


--
-- TOC entry 4914 (class 0 OID 16922)
-- Dependencies: 223
-- Data for Name: tbl_sales; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tbl_sales (sls_id, cst_id, sls_total_price, creation_date, created_by, modified_date, modified_by) FROM stdin;
1	2	32.85	2024-06-24 07:33:28.306759	11	\N	\N
\.


--
-- TOC entry 4907 (class 0 OID 16843)
-- Dependencies: 216
-- Data for Name: tbl_user; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tbl_user (usr_id, usr_name, usr_email, usr_password, creation_date, created_by, modified_date, modified_by, usr_delete) FROM stdin;
4	USER_DB	admin@admin.com	a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3	2024-06-21 00:22:53.76704	4	2024-06-22 03:25:55.88145	4	\N
5	Teste 1	teste@gmail.com	teste	2024-06-21 00:42:25.208702	4	2024-06-22 19:54:50.694369	5	*
7	teste2	teste2@gmail.com	102030	2024-06-21 23:51:37.738166	4	2024-06-22 19:54:52.890081	7	*
11	João Pedro	joao@gmail.com	03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4	2024-06-22 19:55:37.274009	4	2024-06-22 20:00:17.199297	11	\N
\.


--
-- TOC entry 4925 (class 0 OID 0)
-- Dependencies: 217
-- Name: tbl_customer_cst_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tbl_customer_cst_id_seq', 5, true);


--
-- TOC entry 4926 (class 0 OID 0)
-- Dependencies: 220
-- Name: tbl_product_prd_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tbl_product_prd_id_seq', 6, true);


--
-- TOC entry 4927 (class 0 OID 0)
-- Dependencies: 222
-- Name: tbl_sales_sls_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tbl_sales_sls_id_seq', 1, true);


--
-- TOC entry 4928 (class 0 OID 0)
-- Dependencies: 215
-- Name: tbl_user_usr_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tbl_user_usr_id_seq', 11, true);


--
-- TOC entry 4742 (class 2606 OID 16887)
-- Name: tbl_address tbl_address_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_address
    ADD CONSTRAINT tbl_address_pkey PRIMARY KEY (adr_id);


--
-- TOC entry 4738 (class 2606 OID 16871)
-- Name: tbl_customer tbl_customer_cst_cpf_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_customer
    ADD CONSTRAINT tbl_customer_cst_cpf_key UNIQUE (cst_cpf);


--
-- TOC entry 4740 (class 2606 OID 16869)
-- Name: tbl_customer tbl_customer_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_customer
    ADD CONSTRAINT tbl_customer_pkey PRIMARY KEY (cst_id);


--
-- TOC entry 4744 (class 2606 OID 16910)
-- Name: tbl_product tbl_product_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_product
    ADD CONSTRAINT tbl_product_pkey PRIMARY KEY (prd_id);


--
-- TOC entry 4748 (class 2606 OID 16948)
-- Name: tbl_product_sale tbl_product_sale_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_product_sale
    ADD CONSTRAINT tbl_product_sale_pkey PRIMARY KEY (sls_id, prd_id);


--
-- TOC entry 4746 (class 2606 OID 16928)
-- Name: tbl_sales tbl_sales_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_sales
    ADD CONSTRAINT tbl_sales_pkey PRIMARY KEY (sls_id);


--
-- TOC entry 4734 (class 2606 OID 16849)
-- Name: tbl_user tbl_user_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_user
    ADD CONSTRAINT tbl_user_pkey PRIMARY KEY (usr_id);


--
-- TOC entry 4736 (class 2606 OID 16851)
-- Name: tbl_user tbl_user_usr_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_user
    ADD CONSTRAINT tbl_user_usr_email_key UNIQUE (usr_email);


--
-- TOC entry 4753 (class 2606 OID 16893)
-- Name: tbl_address tbl_address_created_by_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_address
    ADD CONSTRAINT tbl_address_created_by_fkey FOREIGN KEY (created_by) REFERENCES public.tbl_user(usr_id);


--
-- TOC entry 4754 (class 2606 OID 16888)
-- Name: tbl_address tbl_address_cst_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_address
    ADD CONSTRAINT tbl_address_cst_id_fkey FOREIGN KEY (adr_id) REFERENCES public.tbl_customer(cst_id);


--
-- TOC entry 4755 (class 2606 OID 16898)
-- Name: tbl_address tbl_address_modified_by_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_address
    ADD CONSTRAINT tbl_address_modified_by_fkey FOREIGN KEY (modified_by) REFERENCES public.tbl_user(usr_id);


--
-- TOC entry 4751 (class 2606 OID 16872)
-- Name: tbl_customer tbl_customer_created_by_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_customer
    ADD CONSTRAINT tbl_customer_created_by_fkey FOREIGN KEY (created_by) REFERENCES public.tbl_user(usr_id);


--
-- TOC entry 4752 (class 2606 OID 16877)
-- Name: tbl_customer tbl_customer_modified_by_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_customer
    ADD CONSTRAINT tbl_customer_modified_by_fkey FOREIGN KEY (modified_by) REFERENCES public.tbl_user(usr_id);


--
-- TOC entry 4756 (class 2606 OID 16911)
-- Name: tbl_product tbl_product_created_by_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_product
    ADD CONSTRAINT tbl_product_created_by_fkey FOREIGN KEY (created_by) REFERENCES public.tbl_user(usr_id);


--
-- TOC entry 4757 (class 2606 OID 16916)
-- Name: tbl_product tbl_product_modified_by_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_product
    ADD CONSTRAINT tbl_product_modified_by_fkey FOREIGN KEY (modified_by) REFERENCES public.tbl_user(usr_id);


--
-- TOC entry 4761 (class 2606 OID 16954)
-- Name: tbl_product_sale tbl_product_sale_prd_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_product_sale
    ADD CONSTRAINT tbl_product_sale_prd_id_fkey FOREIGN KEY (prd_id) REFERENCES public.tbl_product(prd_id);


--
-- TOC entry 4762 (class 2606 OID 16949)
-- Name: tbl_product_sale tbl_product_sale_sls_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_product_sale
    ADD CONSTRAINT tbl_product_sale_sls_id_fkey FOREIGN KEY (sls_id) REFERENCES public.tbl_sales(sls_id);


--
-- TOC entry 4758 (class 2606 OID 16934)
-- Name: tbl_sales tbl_sales_created_by_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_sales
    ADD CONSTRAINT tbl_sales_created_by_fkey FOREIGN KEY (created_by) REFERENCES public.tbl_user(usr_id);


--
-- TOC entry 4759 (class 2606 OID 16929)
-- Name: tbl_sales tbl_sales_cst_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_sales
    ADD CONSTRAINT tbl_sales_cst_id_fkey FOREIGN KEY (cst_id) REFERENCES public.tbl_customer(cst_id);


--
-- TOC entry 4760 (class 2606 OID 16939)
-- Name: tbl_sales tbl_sales_modified_by_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_sales
    ADD CONSTRAINT tbl_sales_modified_by_fkey FOREIGN KEY (modified_by) REFERENCES public.tbl_user(usr_id);


--
-- TOC entry 4749 (class 2606 OID 16852)
-- Name: tbl_user tbl_user_created_by_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_user
    ADD CONSTRAINT tbl_user_created_by_fkey FOREIGN KEY (created_by) REFERENCES public.tbl_user(usr_id);


--
-- TOC entry 4750 (class 2606 OID 16857)
-- Name: tbl_user tbl_user_modified_by_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_user
    ADD CONSTRAINT tbl_user_modified_by_fkey FOREIGN KEY (modified_by) REFERENCES public.tbl_user(usr_id);


-- Completed on 2024-06-24 07:48:15

--
-- PostgreSQL database dump complete
--

