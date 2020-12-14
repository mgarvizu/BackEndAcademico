DROP PROCEDURE GARVIZU.SP_ADDINSCRIPCION;

CREATE OR REPLACE PROCEDURE GARVIZU."SP_ADDINSCRIPCION"
(
    MAT NUMBER,
    EST NUMBER,
    DESCRIPCION VARCHAR2
    
)
AS 
BEGIN
    insert into inscripcion (id_materia,id_estudiante,descripcion)
                values (MAT,EST,DESCRIPCION);
    DBMS_OUTPUT.put_line(1);
    return;
END;
/