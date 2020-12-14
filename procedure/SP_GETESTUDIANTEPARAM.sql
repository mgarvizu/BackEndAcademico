DROP PROCEDURE GARVIZU.SP_GETESTUDIANTEPARAM;

CREATE OR REPLACE PROCEDURE GARVIZU."SP_GETESTUDIANTEPARAM"
(
    ID_ESTU NUMBER,
    NOMBRE VARCHAR2,
    PERCURSORESTPARAM OUT SYS_REFCURSOR
)
AS
BEGIN
    open PERCURSORESTPARAM for
    select ID_ESTUDIANTE, nombres, apellidos, ci,
           fecha_nacimiento
    from estudiante 
    where ID_ESTUDIANTE=ID_ESTU 
           and upper(nombres) like '%' || upper(NOMBRE) ||'%';
 End;
/