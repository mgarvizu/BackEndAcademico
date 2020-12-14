using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackEnd.Core.Entities;
using BackEnd.Core.Interfaces;

namespace BackEnd.Infraestructura.Repositories
{
    public class MateriaRepository : IMateriaRepository
    {
        public IEnumerable<Materia> GetMaterias()    {

            var est = Enumerable.Range(1, 10).Select(x => new Materia
            {
                ID_MATERIA = x,                
                SIGLA = $"Sigla - {x}",
                NOMBRE = $"Nombre {x}"                
            });
            return est;
        }
    }
}
