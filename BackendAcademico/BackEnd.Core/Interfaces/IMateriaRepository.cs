using BackEnd.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Core.Interfaces
{
    public interface IMateriaRepository
    {
        IEnumerable<Materia> GetMaterias();
    }
}
