DROP PROCEDURE GARVIZU.SP_DELETEINSCRIPCION;

CREATE OR REPLACE PROCEDURE GARVIZU."SP_DELETEINSCRIPCION"
(
    ID number,
    MAT NUMBER,
    EST NUMBER,
    DESCRIPCION VARCHAR2    
)
AS 
BEGIN
    DELETE inscripcion     
     WHERE
     ID_INSCRIPCION = ID;                
    DBMS_OUTPUT.put_line(1);
    return;
END;
/