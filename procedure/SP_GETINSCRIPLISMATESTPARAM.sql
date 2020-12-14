DROP PROCEDURE GARVIZU.SP_GETINSCRIPLISMATESTPARAM;

CREATE OR REPLACE PROCEDURE GARVIZU."SP_GETINSCRIPLISMATESTPARAM"
(
    ci varchar2,    
    PERCURSORINSCRIPLISMATESTPARAM OUT SYS_REFCURSOR
)
AS
BEGIN
    open PERCURSORINSCRIPLISMATESTPARAM for    
    select i.id_inscripcion, i.id_materia, m.sigla, m.nombre, e.id_estudiante, e.ci, (e.nombres ||' '||e.apellidos) nombre 
     from materia m, inscripcion i, estudiante e
    where e.CI = ci
    and i.id_estudiante = e.id_estudiante
    and i.id_materia = m.id_materia;        
   
 End;
/