-- USER (USR)
CREATE TABLE TBL_USER(
	USR_ID SERIAL,
	USR_NAME VARCHAR(100) NOT NULL,
	USR_EMAIL VARCHAR(100) NOT NULL,
	USR_PASSWORD VARCHAR(255),
	CREATION_DATE TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	CREATED_BY INT NOT NULL,
	MODIFIED_DATE TIMESTAMP,
	MODIFIED_BY INT,
	PRIMARY KEY (USR_ID),
	FOREIGN KEY (CREATED_BY) REFERENCES TBL_USER (USR_ID),
	FOREIGN KEY (MODIFIED_BY) REFERENCES TBL_USER (USR_ID)
);

-- ADDRESS (ADR)
CREATE TABLE TBL_ADDRESS(
	ADR_ID SERIAL,
	ADR_ZIP_CODE VARCHAR(7) NOT NULL,
	ADR_STREET VARCHAR(100) NOT NULL,
	ADR_NUMBER INT NOT NULL,
	ADR_COMPLEMENT VARCHAR(100),
	ADR_CITY VARCHAR(100) NOT NULL,
	ADR_STATE VARCHAR(100) NOT NULL,
	CREATION_DATE TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	CREATED_BY INT NOT NULL,
	MODIFIED_DATE TIMESTAMP,
	MODIFIED_BY INT,
	PRIMARY KEY (ADR_ID),
	FOREIGN KEY (CREATED_BY) REFERENCES TBL_USER (USR_ID),
	FOREIGN KEY (MODIFIED_BY) REFERENCES TBL_USER (USR_ID)
);

-- CUSTOMER (CST)
CREATE TABLE TBL_CUSTOMER(
	CST_ID SERIAL,
	CST_NAME VARCHAR(100) NOT NULL,
	CST_CPF VARCHAR(11) NOT NULL,
	CST_EMAIL VARCHAR(100) NOT NULL,
	ADR_ID INT NOT NULL,
	CREATION_DATE TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	CREATED_BY INT NOT NULL,
	MODIFIED_DATE TIMESTAMP,
	MODIFIED_BY INT,
	PRIMARY KEY (CST_ID),
	FOREIGN KEY (ADR_ID) REFERENCES TBL_ADDRESS (ADR_ID),
	FOREIGN KEY (CREATED_BY) REFERENCES TBL_USER (USR_ID),
	FOREIGN KEY (MODIFIED_BY) REFERENCES TBL_USER (USR_ID)
);

-- CONTACT (CTC)
CREATE TABLE TBL_CONTACT(
	CTC_ID SERIAL,
	CST_ID INT NOT NULL,
	CTC_PHONE VARCHAR(11) NOT NULL,
	CTC_DESCRIPTION VARCHAR(100) NOT NULL,
	CREATION_DATE TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	CREATED_BY INT NOT NULL,
	MODIFIED_DATE TIMESTAMP,
	MODIFIED_BY INT,
	PRIMARY KEY (CTC_ID, CST_ID),
	FOREIGN KEY (CST_ID) REFERENCES TBL_CUSTOMER (CST_ID),
	FOREIGN KEY (CREATED_BY) REFERENCES TBL_USER (USR_ID),
	FOREIGN KEY (MODIFIED_BY) REFERENCES TBL_USER (USR_ID)
);

-- PRODUCT (PRD)
CREATE TABLE TBL_PRODUCT (
	PRD_ID SERIAL,
	PRD_NAME VARCHAR(100) NOT NULL,
	PRD_DESCRIPTION VARCHAR(255) NOT NULL,
	PRD_PRICE DECIMAL(10, 2) NOT NULL,
	PRD_STOCK INT NOT NULL,
	CREATION_DATE TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	CREATED_BY INT NOT NULL,
	MODIFIED_DATE TIMESTAMP,
	MODIFIED_BY INT,
	PRIMARY KEY (PRD_ID),
	FOREIGN KEY (CREATED_BY) REFERENCES TBL_USER (USR_ID),
	FOREIGN KEY (MODIFIED_BY) REFERENCES TBL_USER (USR_ID)
);


-- SALES (SLS)
CREATE TABLE TBL_SALES (
	SLS_ID SERIAL,
	CST_ID INT NOT NULL,
	SLS_DATE TIMESTAMP DEFAULT CURRENT_TIMESTAMP, 
	CREATION_DATE TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	CREATED_BY INT NOT NULL,
	MODIFIED_DATE TIMESTAMP,
	MODIFIED_BY INT,
	PRIMARY KEY (SLS_ID),
	FOREIGN KEY (CST_ID) REFERENCES TBL_CUSTOMER (CST_ID),
	FOREIGN KEY (CREATED_BY) REFERENCES TBL_USER (USR_ID),
	FOREIGN KEY (MODIFIED_BY) REFERENCES TBL_USER (USR_ID)
);

-- PRODUCT_SALE
CREATE TABLE TBL_PRODUCT_SALE (
	SLS_ID INT NOT NULL,
	PRD_ID INT NOT NULL,
	PRS_QUANTITY INT NOT NULL,
	PRIMARY KEY (SLS_ID, PRD_ID),
	FOREIGN KEY (SLS_ID) REFERENCES TBL_SALES (SLS_ID),
	FOREIGN KEY (PRD_ID) REFERENCES TBL_PRODUCT (PRD_ID)
);