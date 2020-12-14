using BackEnd.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.Interfaces
{
   public interface IEstudianteDapperRepository
    {
        Task<object> GetEstudiantesBD3Async(int idPar, string nombre);
        Task<bool> AddEstudianteAsync(Estudiante estudiante);
        Task<bool> UpdateEstudianteAsync(Estudiante estudiante);
        Task<bool> DeleteEstudianteAsync(Estudiante estudiante);
        Task<object> GetEstudiantesBDTodosAsync();
        Task<bool> AddEstudianteAutomatic();
        Task<object> GetEstudiantesBDExist(Estudiante estudiante);
    }
}
