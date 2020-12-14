using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Core.Entities
{
    public class Inscripcion
    {
        public int ID_INSCRIPCION { get; set; }
        public int ID_MATERIA { get; set; }
        public int ID_ESTUDIANTE { get; set; }
        public string DESCRIPCION { get; set; }
    }
}
