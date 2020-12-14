DROP PROCEDURE GARVIZU.SP_GETINSCRIPCIONMATPARAM;

CREATE OR REPLACE PROCEDURE GARVIZU."SP_GETINSCRIPCIONMATPARAM"
(
    MAT varchar2,    
    PERCURSORINSCRIPMATPARAM OUT SYS_REFCURSOR
)
AS
BEGIN
    open PERCURSORINSCRIPMATPARAM for    
    select i.id_inscripcion, i.id_materia, m.sigla, m.nombre, e.id_estudiante, e.ci, (e.nombres ||' '||e.apellidos) nombre 
     from materia m, inscripcion i, estudiante e
    where ( UPPER (m.nombre) like '%' || upper(MAT) ||'%'
    or UPPER(m.sigla) like '%' || upper(MAT) ||'%')
    and m.id_materia = i.id_materia
    and i.id_estudiante = e.id_estudiante;    
   
 End;
/