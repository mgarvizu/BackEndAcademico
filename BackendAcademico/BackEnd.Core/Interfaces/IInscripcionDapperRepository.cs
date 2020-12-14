using BackEnd.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.Interfaces
{
   public interface IInscripcionDapperRepository
    {
        Task<object> GetInscripcionAll();
        Task<object> GetEstInsEnMat(string materia);
        Task<object> GetLisMatDeEst(string carnet);
        Task<bool> AddInscripcionAsync(Inscripcion inscripcion);
        Task<bool> UpdateInscripcionAsync(Inscripcion inscripcion);
        Task<bool> DeleteInscripcionAsync(Inscripcion inscripcion);
    }
}
