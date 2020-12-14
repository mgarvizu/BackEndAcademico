ALTER TABLE GARVIZU.MATERIA
 DROP PRIMARY KEY CASCADE;

DROP TABLE GARVIZU.MATERIA CASCADE CONSTRAINTS;

CREATE TABLE GARVIZU.MATERIA
(
  ID_MATERIA  NUMBER(10) GENERATED BY DEFAULT ON NULL AS IDENTITY ( START WITH 120 MAXVALUE 9999999999 MINVALUE 1 NOCYCLE CACHE 20 NOORDER NOKEEP) NOT NULL,
  SIGLA       VARCHAR2(12 BYTE),
  NOMBRE      VARCHAR2(50 BYTE)
)
TABLESPACE USERS
PCTUSED    0
PCTFREE    10
INITRANS   1
MAXTRANS   255
STORAGE    (
            INITIAL          64K
            NEXT             1M
            MINEXTENTS       1
            MAXEXTENTS       UNLIMITED
            PCTINCREASE      0
            BUFFER_POOL      DEFAULT
           )
LOGGING 
NOCOMPRESS 
NOCACHE
MONITORING;


CREATE UNIQUE INDEX GARVIZU.MATERIA_PK ON GARVIZU.MATERIA
(ID_MATERIA)
LOGGING
TABLESPACE USERS
PCTFREE    10
INITRANS   2
MAXTRANS   255
STORAGE    (
            INITIAL          64K
            NEXT             1M
            MINEXTENTS       1
            MAXEXTENTS       UNLIMITED
            PCTINCREASE      0
            BUFFER_POOL      DEFAULT
           );

ALTER TABLE GARVIZU.MATERIA ADD (
  CONSTRAINT MATERIA_PK
  PRIMARY KEY
  (ID_MATERIA)
  USING INDEX GARVIZU.MATERIA_PK
  ENABLE VALIDATE);