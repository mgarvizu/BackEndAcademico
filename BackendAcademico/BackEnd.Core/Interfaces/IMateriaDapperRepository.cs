using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.Interfaces
{
    public interface IMateriaDapperRepository
    {
        Task<object> GetMateriasTodosAsync();
        Task<object> GetMateriasSiglaAsync(string sigla);
        Task<object> GetMateriasNombreMatAsync(string nombre);
    }
}
