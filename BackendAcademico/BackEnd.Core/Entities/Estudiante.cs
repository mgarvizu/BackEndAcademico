using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Core.Entities
{
    public class Estudiante
    {
        public int ID_ESTUDIANTE { get; set; }
        public string CI { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public DateTime FECHA_NACIMIENTO { get; set; }
    }
}
