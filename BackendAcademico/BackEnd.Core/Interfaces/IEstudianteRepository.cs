using BackEnd.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Core.Interfaces
{
    public interface IEstudianteRepository
    {        
        IEnumerable<Estudiante> GetEstudiantes();
        IEnumerable<Estudiante> GetEstudiantesBD1();
        IEnumerable<Estudiante> GetEstudiantesBD2(int id);
        IEnumerable<Estudiante> GetEstudiantesBD3(int idPar);
        bool AddEstudiante(Estudiante estudiante);
        bool UpdateEstudiante(Estudiante estudiante);
        bool DeleteEstudiante(Estudiante estudiante);        
    }
}
