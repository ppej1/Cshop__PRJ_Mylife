--------------------------------------------------------
--  파일이 생성됨 - 금요일-11월-13-2020   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table EXCHANGE_T
--------------------------------------------------------

  CREATE TABLE "ROOT2"."EXCHANGE_T" 
   (	"EXCHANGE_TYPE" NUMBER, 
	"EXCHANGE_NAME" VARCHAR2(50 CHAR), 
	"EXCHANGE_MONEY" NUMBER DEFAULT 0
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;

   COMMENT ON COLUMN "ROOT2"."EXCHANGE_T"."EXCHANGE_TYPE" IS 'exchange_type';
   COMMENT ON COLUMN "ROOT2"."EXCHANGE_T"."EXCHANGE_NAME" IS 'exchange_Name';
   COMMENT ON COLUMN "ROOT2"."EXCHANGE_T"."EXCHANGE_MONEY" IS 'exchange_money';
   COMMENT ON TABLE "ROOT2"."EXCHANGE_T"  IS 'Exchange_T';
--------------------------------------------------------
--  DDL for Table HOUSE_T
--------------------------------------------------------

  CREATE TABLE "ROOT2"."HOUSE_T" 
   (	"KE_NO" NUMBER, 
	"US_EMAIL" VARCHAR2(50 CHAR), 
	"IETYPE" NUMBER, 
	"KE_TYPE" NUMBER, 
	"KE_CONTENTS" VARCHAR2(1000 CHAR), 
	"PAY_TYPE_NO" NUMBER, 
	"EXCHANGE_TYPE" NUMBER, 
	"KE_PRICE" NUMBER, 
	"KE_PAY_DATE" DATE
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;

   COMMENT ON COLUMN "ROOT2"."HOUSE_T"."KE_NO" IS 'KE_NO';
   COMMENT ON COLUMN "ROOT2"."HOUSE_T"."US_EMAIL" IS 'US_EMAIL : 이메일';
   COMMENT ON COLUMN "ROOT2"."HOUSE_T"."IETYPE" IS 'ieType : 수입/지출
';
   COMMENT ON COLUMN "ROOT2"."HOUSE_T"."KE_TYPE" IS 'KE_TYPE';
   COMMENT ON COLUMN "ROOT2"."HOUSE_T"."KE_CONTENTS" IS 'KE_CONTENTS';
   COMMENT ON COLUMN "ROOT2"."HOUSE_T"."PAY_TYPE_NO" IS 'PAY_TYPE';
   COMMENT ON COLUMN "ROOT2"."HOUSE_T"."EXCHANGE_TYPE" IS 'exchange_type';
   COMMENT ON COLUMN "ROOT2"."HOUSE_T"."KE_PRICE" IS 'KE_PRICE';
   COMMENT ON COLUMN "ROOT2"."HOUSE_T"."KE_PAY_DATE" IS 'KE_PAY_DATE';
   COMMENT ON TABLE "ROOT2"."HOUSE_T"  IS 'HOUSE_T';
--------------------------------------------------------
--  DDL for Table K_TYPE_T
--------------------------------------------------------

  CREATE TABLE "ROOT2"."K_TYPE_T" 
   (	"KE_TYPE" NUMBER, 
	"KEEP_TYPE_NAME" VARCHAR2(50 CHAR)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;

   COMMENT ON COLUMN "ROOT2"."K_TYPE_T"."KE_TYPE" IS 'KE_TYPE';
   COMMENT ON COLUMN "ROOT2"."K_TYPE_T"."KEEP_TYPE_NAME" IS 'KE_TYPE_NAME';
   COMMENT ON TABLE "ROOT2"."K_TYPE_T"  IS 'K_TYPE_T';
--------------------------------------------------------
--  DDL for Table MEMO_T
--------------------------------------------------------

  CREATE TABLE "ROOT2"."MEMO_T" 
   (	"ME_NO" NUMBER, 
	"US_EMAIL" VARCHAR2(50 CHAR), 
	"ME_CONTENTS" VARCHAR2(500 CHAR), 
	"ME_REG_DATE" DATE
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;

   COMMENT ON COLUMN "ROOT2"."MEMO_T"."ME_NO" IS 'ME_NO';
   COMMENT ON COLUMN "ROOT2"."MEMO_T"."US_EMAIL" IS 'US_EMAIL : 이메일';
   COMMENT ON COLUMN "ROOT2"."MEMO_T"."ME_CONTENTS" IS 'ME_CONTENTS';
   COMMENT ON COLUMN "ROOT2"."MEMO_T"."ME_REG_DATE" IS 'ME_REG_DATE';
   COMMENT ON TABLE "ROOT2"."MEMO_T"  IS 'MEMO_T';
--------------------------------------------------------
--  DDL for Table PAY_T
--------------------------------------------------------

  CREATE TABLE "ROOT2"."PAY_T" 
   (	"PAY_TYPE_NO" NUMBER, 
	"PAY_NAME" VARCHAR2(100 CHAR), 
	"US_EMAIL" VARCHAR2(50 CHAR), 
	"PAY_TYPE" NUMBER
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;

   COMMENT ON COLUMN "ROOT2"."PAY_T"."PAY_TYPE_NO" IS 'PAY_TYPE';
   COMMENT ON COLUMN "ROOT2"."PAY_T"."PAY_NAME" IS 'PAY_NAME';
   COMMENT ON COLUMN "ROOT2"."PAY_T"."US_EMAIL" IS 'US_EMAIL : 이메일';
   COMMENT ON TABLE "ROOT2"."PAY_T"  IS 'PAY_T';
--------------------------------------------------------
--  DDL for Table PROD_T
--------------------------------------------------------

  CREATE TABLE "ROOT2"."PROD_T" 
   (	"PROD_TYPE" NUMBER, 
	"PROD_T_NAME" VARCHAR2(100 CHAR)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;

   COMMENT ON COLUMN "ROOT2"."PROD_T"."PROD_TYPE" IS 'PROD_TYPE';
   COMMENT ON COLUMN "ROOT2"."PROD_T"."PROD_T_NAME" IS 'PROD_T_NAME';
   COMMENT ON TABLE "ROOT2"."PROD_T"  IS 'PROD_T';
--------------------------------------------------------
--  DDL for Table SHOP_T
--------------------------------------------------------

  CREATE TABLE "ROOT2"."SHOP_T" 
   (	"SHOP_NO" NUMBER, 
	"US_EMAIL" VARCHAR2(50 CHAR), 
	"PROD_TYPE" NUMBER, 
	"SHOP_NAME" VARCHAR2(100 CHAR), 
	"EXCHANGE_TYPE" NUMBER, 
	"PRICE" NUMBER, 
	"SHOP_REGISTER" DATE, 
	"SHOP_URL" VARCHAR2(2000 CHAR), 
	"SHP_STATE" NUMBER DEFAULT 0, 
	"BUY_DATE" DATE
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;

   COMMENT ON COLUMN "ROOT2"."SHOP_T"."SHOP_NO" IS 'SHOP_NO';
   COMMENT ON COLUMN "ROOT2"."SHOP_T"."US_EMAIL" IS 'US_EMAIL : 이메일';
   COMMENT ON COLUMN "ROOT2"."SHOP_T"."PROD_TYPE" IS 'PROD_TYPE';
   COMMENT ON COLUMN "ROOT2"."SHOP_T"."SHOP_NAME" IS 'SHOP_NAME';
   COMMENT ON COLUMN "ROOT2"."SHOP_T"."EXCHANGE_TYPE" IS 'exchange_type';
   COMMENT ON COLUMN "ROOT2"."SHOP_T"."PRICE" IS 'PRICE';
   COMMENT ON COLUMN "ROOT2"."SHOP_T"."SHOP_REGISTER" IS 'SHOP_REGISTER';
   COMMENT ON COLUMN "ROOT2"."SHOP_T"."SHOP_URL" IS 'SHOP_URL';
   COMMENT ON COLUMN "ROOT2"."SHOP_T"."SHP_STATE" IS 'SHOP_STATE';
   COMMENT ON COLUMN "ROOT2"."SHOP_T"."BUY_DATE" IS 'Buy_Date';
   COMMENT ON TABLE "ROOT2"."SHOP_T"  IS 'SHOP_T';
--------------------------------------------------------
--  DDL for Table TODO_T
--------------------------------------------------------

  CREATE TABLE "ROOT2"."TODO_T" 
   (	"TOD_NO" NUMBER, 
	"US_EMAIL" VARCHAR2(50 CHAR), 
	"TOD_CONTENTS" VARCHAR2(3000 CHAR), 
	"TOD_START_DATE" DATE, 
	"TOD_END_DATE" DATE, 
	"TOD_DEADLINE_DATE" DATE, 
	"TOD_STATE" NUMBER DEFAULT 0, 
	"TOD_REGDATE" DATE
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;

   COMMENT ON COLUMN "ROOT2"."TODO_T"."TOD_NO" IS 'TOD_NO';
   COMMENT ON COLUMN "ROOT2"."TODO_T"."US_EMAIL" IS 'US_EMAIL : 이메일';
   COMMENT ON COLUMN "ROOT2"."TODO_T"."TOD_CONTENTS" IS 'TOD_CONTENTS';
   COMMENT ON COLUMN "ROOT2"."TODO_T"."TOD_START_DATE" IS 'TOD_START_DATE';
   COMMENT ON COLUMN "ROOT2"."TODO_T"."TOD_END_DATE" IS 'TOD_END_DATE';
   COMMENT ON COLUMN "ROOT2"."TODO_T"."TOD_DEADLINE_DATE" IS 'TOD_DEADLINE_DATE';
   COMMENT ON COLUMN "ROOT2"."TODO_T"."TOD_STATE" IS 'TOD_STATE';
   COMMENT ON TABLE "ROOT2"."TODO_T"  IS 'TODO_T';
--------------------------------------------------------
--  DDL for Table USER_T
--------------------------------------------------------

  CREATE TABLE "ROOT2"."USER_T" 
   (	"US_EMAIL" VARCHAR2(50 CHAR), 
	"US_PWD" VARCHAR2(40 CHAR), 
	"US_FIRSTNAME" VARCHAR2(10 CHAR), 
	"US_LASTNAME" VARCHAR2(20 CHAR), 
	"US_SEX" NUMBER, 
	"US_REGISTERDATE" DATE, 
	"US_LV" NUMBER DEFAULT 0, 
	"US_WITHDRAWAL" DATE, 
	"US_IMAGE" VARCHAR2(20 CHAR), 
	"US_PHONE" VARCHAR2(20 CHAR)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;

   COMMENT ON COLUMN "ROOT2"."USER_T"."US_EMAIL" IS 'US_EMAIL : 이메일';
   COMMENT ON COLUMN "ROOT2"."USER_T"."US_PWD" IS 'US_PWD';
   COMMENT ON COLUMN "ROOT2"."USER_T"."US_FIRSTNAME" IS 'US_FIRSTNAME';
   COMMENT ON COLUMN "ROOT2"."USER_T"."US_LASTNAME" IS 'US_LASTNAME';
   COMMENT ON COLUMN "ROOT2"."USER_T"."US_SEX" IS 'US_SEX';
   COMMENT ON COLUMN "ROOT2"."USER_T"."US_REGISTERDATE" IS 'US_REGISTERDATE';
   COMMENT ON COLUMN "ROOT2"."USER_T"."US_LV" IS 'US_LV';
   COMMENT ON COLUMN "ROOT2"."USER_T"."US_WITHDRAWAL" IS 'US_WITHDRAWAL';
   COMMENT ON COLUMN "ROOT2"."USER_T"."US_IMAGE" IS 'US_IMAGE : 아바타이미지';
   COMMENT ON COLUMN "ROOT2"."USER_T"."US_PHONE" IS 'US_PHONE';
   COMMENT ON TABLE "ROOT2"."USER_T"  IS '회원목록';
--------------------------------------------------------
--  DDL for Index SYS_C0011421
--------------------------------------------------------

  CREATE UNIQUE INDEX "ROOT2"."SYS_C0011421" ON "ROOT2"."EXCHANGE_T" ("EXCHANGE_TYPE") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index SYS_C0011430
--------------------------------------------------------

  CREATE UNIQUE INDEX "ROOT2"."SYS_C0011430" ON "ROOT2"."HOUSE_T" ("KE_NO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index SYS_C0011433
--------------------------------------------------------

  CREATE UNIQUE INDEX "ROOT2"."SYS_C0011433" ON "ROOT2"."K_TYPE_T" ("KE_TYPE") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index SYS_C0011437
--------------------------------------------------------

  CREATE UNIQUE INDEX "ROOT2"."SYS_C0011437" ON "ROOT2"."MEMO_T" ("ME_NO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index SYS_C0011441
--------------------------------------------------------

  CREATE UNIQUE INDEX "ROOT2"."SYS_C0011441" ON "ROOT2"."PAY_T" ("PAY_TYPE_NO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index SYS_C0011444
--------------------------------------------------------

  CREATE UNIQUE INDEX "ROOT2"."SYS_C0011444" ON "ROOT2"."PROD_T" ("PROD_TYPE") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index SYS_C0011451
--------------------------------------------------------

  CREATE UNIQUE INDEX "ROOT2"."SYS_C0011451" ON "ROOT2"."SHOP_T" ("SHOP_NO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index SYS_C0011455
--------------------------------------------------------

  CREATE UNIQUE INDEX "ROOT2"."SYS_C0011455" ON "ROOT2"."TODO_T" ("TOD_NO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index SYS_C0011463
--------------------------------------------------------

  CREATE UNIQUE INDEX "ROOT2"."SYS_C0011463" ON "ROOT2"."USER_T" ("US_EMAIL") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Trigger TRI_EXCHANGE_T_EXCHANGE_TYPE
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "ROOT2"."TRI_EXCHANGE_T_EXCHANGE_TYPE" BEFORE INSERT ON Exchange_T
FOR EACH ROW
BEGIN
	SELECT SEQ_Exchange_T_exchange_type.nextval
	INTO :new.exchange_type
	FROM dual;
END;


/
ALTER TRIGGER "ROOT2"."TRI_EXCHANGE_T_EXCHANGE_TYPE" ENABLE;
--------------------------------------------------------
--  DDL for Trigger TRI_HOUSE_T_KE_NO
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "ROOT2"."TRI_HOUSE_T_KE_NO" BEFORE INSERT ON HOUSE_T
FOR EACH ROW
BEGIN
	SELECT SEQ_HOUSE_T_KE_NO.nextval
	INTO :new.KE_NO
	FROM dual;
END;


/
ALTER TRIGGER "ROOT2"."TRI_HOUSE_T_KE_NO" ENABLE;
--------------------------------------------------------
--  DDL for Trigger TRI_K_TYPE_T_KE_TYPE
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "ROOT2"."TRI_K_TYPE_T_KE_TYPE" BEFORE INSERT ON K_TYPE_T
FOR EACH ROW
BEGIN
	SELECT SEQ_K_TYPE_T_KE_TYPE.nextval
	INTO :new.KE_TYPE
	FROM dual;
END;


/
ALTER TRIGGER "ROOT2"."TRI_K_TYPE_T_KE_TYPE" ENABLE;
--------------------------------------------------------
--  DDL for Trigger TRI_MEMO_T_ME_NO
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "ROOT2"."TRI_MEMO_T_ME_NO" BEFORE INSERT ON MEMO_T
FOR EACH ROW
BEGIN
	SELECT SEQ_MEMO_T_ME_NO.nextval
	INTO :new.ME_NO
	FROM dual;
END;


/
ALTER TRIGGER "ROOT2"."TRI_MEMO_T_ME_NO" ENABLE;
--------------------------------------------------------
--  DDL for Trigger TRI_PAY_T_PAY_TYPE_NO
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "ROOT2"."TRI_PAY_T_PAY_TYPE_NO" BEFORE INSERT ON PAY_T
FOR EACH ROW
BEGIN
	SELECT SEQ_PAY_T_PAY_TYPE_NO.nextval
	INTO :new.PAY_TYPE_NO
	FROM dual;
END;


/
ALTER TRIGGER "ROOT2"."TRI_PAY_T_PAY_TYPE_NO" ENABLE;
--------------------------------------------------------
--  DDL for Trigger TRI_PROD_T_PROD_TYPE
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "ROOT2"."TRI_PROD_T_PROD_TYPE" BEFORE INSERT ON PROD_T
FOR EACH ROW
BEGIN
	SELECT SEQ_PROD_T_PROD_TYPE.nextval
	INTO :new.PROD_TYPE
	FROM dual;
END;


/
ALTER TRIGGER "ROOT2"."TRI_PROD_T_PROD_TYPE" ENABLE;
--------------------------------------------------------
--  DDL for Trigger TRI_SHOP_T_SHOP_NO
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "ROOT2"."TRI_SHOP_T_SHOP_NO" BEFORE INSERT ON SHOP_T
FOR EACH ROW
BEGIN
	SELECT SEQ_SHOP_T_SHOP_NO.nextval
	INTO :new.SHOP_NO
	FROM dual;
END;


/
ALTER TRIGGER "ROOT2"."TRI_SHOP_T_SHOP_NO" ENABLE;
--------------------------------------------------------
--  DDL for Trigger TRI_TODO_T_TOD_NO
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "ROOT2"."TRI_TODO_T_TOD_NO" BEFORE INSERT ON TODO_T
FOR EACH ROW
BEGIN
	SELECT SEQ_TODO_T_TOD_NO.nextval
	INTO :new.TOD_NO
	FROM dual;
END;


/
ALTER TRIGGER "ROOT2"."TRI_TODO_T_TOD_NO" ENABLE;
--------------------------------------------------------
--  Constraints for Table EXCHANGE_T
--------------------------------------------------------

  ALTER TABLE "ROOT2"."EXCHANGE_T" ADD PRIMARY KEY ("EXCHANGE_TYPE")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "ROOT2"."EXCHANGE_T" MODIFY ("EXCHANGE_MONEY" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."EXCHANGE_T" MODIFY ("EXCHANGE_NAME" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."EXCHANGE_T" MODIFY ("EXCHANGE_TYPE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table HOUSE_T
--------------------------------------------------------

  ALTER TABLE "ROOT2"."HOUSE_T" ADD PRIMARY KEY ("KE_NO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "ROOT2"."HOUSE_T" MODIFY ("KE_PAY_DATE" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."HOUSE_T" MODIFY ("KE_PRICE" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."HOUSE_T" MODIFY ("EXCHANGE_TYPE" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."HOUSE_T" MODIFY ("PAY_TYPE_NO" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."HOUSE_T" MODIFY ("KE_TYPE" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."HOUSE_T" MODIFY ("IETYPE" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."HOUSE_T" MODIFY ("US_EMAIL" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."HOUSE_T" MODIFY ("KE_NO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table K_TYPE_T
--------------------------------------------------------

  ALTER TABLE "ROOT2"."K_TYPE_T" ADD PRIMARY KEY ("KE_TYPE")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "ROOT2"."K_TYPE_T" MODIFY ("KEEP_TYPE_NAME" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."K_TYPE_T" MODIFY ("KE_TYPE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table MEMO_T
--------------------------------------------------------

  ALTER TABLE "ROOT2"."MEMO_T" ADD PRIMARY KEY ("ME_NO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "ROOT2"."MEMO_T" MODIFY ("ME_REG_DATE" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."MEMO_T" MODIFY ("US_EMAIL" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."MEMO_T" MODIFY ("ME_NO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table PAY_T
--------------------------------------------------------

  ALTER TABLE "ROOT2"."PAY_T" MODIFY ("PAY_TYPE" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."PAY_T" ADD PRIMARY KEY ("PAY_TYPE_NO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "ROOT2"."PAY_T" MODIFY ("US_EMAIL" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."PAY_T" MODIFY ("PAY_NAME" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."PAY_T" MODIFY ("PAY_TYPE_NO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table PROD_T
--------------------------------------------------------

  ALTER TABLE "ROOT2"."PROD_T" ADD PRIMARY KEY ("PROD_TYPE")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "ROOT2"."PROD_T" MODIFY ("PROD_T_NAME" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."PROD_T" MODIFY ("PROD_TYPE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table SHOP_T
--------------------------------------------------------

  ALTER TABLE "ROOT2"."SHOP_T" ADD PRIMARY KEY ("SHOP_NO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "ROOT2"."SHOP_T" MODIFY ("SHP_STATE" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."SHOP_T" MODIFY ("SHOP_REGISTER" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."SHOP_T" MODIFY ("EXCHANGE_TYPE" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."SHOP_T" MODIFY ("PROD_TYPE" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."SHOP_T" MODIFY ("US_EMAIL" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."SHOP_T" MODIFY ("SHOP_NO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table TODO_T
--------------------------------------------------------

  ALTER TABLE "ROOT2"."TODO_T" MODIFY ("TOD_REGDATE" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."TODO_T" ADD PRIMARY KEY ("TOD_NO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "ROOT2"."TODO_T" MODIFY ("TOD_STATE" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."TODO_T" MODIFY ("US_EMAIL" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."TODO_T" MODIFY ("TOD_NO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table USER_T
--------------------------------------------------------

  ALTER TABLE "ROOT2"."USER_T" ADD PRIMARY KEY ("US_EMAIL")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "ROOT2"."USER_T" MODIFY ("US_LV" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."USER_T" MODIFY ("US_REGISTERDATE" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."USER_T" MODIFY ("US_SEX" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."USER_T" MODIFY ("US_LASTNAME" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."USER_T" MODIFY ("US_FIRSTNAME" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."USER_T" MODIFY ("US_PWD" NOT NULL ENABLE);
  ALTER TABLE "ROOT2"."USER_T" MODIFY ("US_EMAIL" NOT NULL ENABLE);
