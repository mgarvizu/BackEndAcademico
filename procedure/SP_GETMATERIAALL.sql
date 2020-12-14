DROP PROCEDURE GARVIZU.SP_GETMATERIAALL;

CREATE OR REPLACE PROCEDURE GARVIZU."SP_GETMATERIAALL"
(    
    PERCURSORMATALL OUT SYS_REFCURSOR
)
AS
BEGIN
    open PERCURSORMATALL for
     select i.id_inscripcion, m.id_materia, m.nombre nombre_Materia, e.id_estudiante, (e.apellidos || ' ' || e.nombres) nombre_Estudiante, i.descripcion 
        from estudiante e, materia m, inscripcion i
        where i.id_materia = m.id_materia
        and i.id_estudiante = e.id_estudiante;
 End;
/