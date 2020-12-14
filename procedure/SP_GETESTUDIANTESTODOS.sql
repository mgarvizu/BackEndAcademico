DROP PROCEDURE GARVIZU.SP_GETESTUDIANTESTODOS;

CREATE OR REPLACE PROCEDURE GARVIZU."SP_GETESTUDIANTESTODOS"
(PERCURSOR OUT SYS_REFCURSOR) 
AS
BEGIN
   Open PERCURSOR for
   select ID_ESTUDIANTE, nombres, apellidos, ci, 
           fecha_nacimiento
   from estudiante 
   order by apellidos asc;
END;
/