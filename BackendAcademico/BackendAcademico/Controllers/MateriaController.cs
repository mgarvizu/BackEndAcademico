using BackEnd.Core.Interfaces;
using BackEnd.Infraestructura.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Academico.Controllers
{
    // instalar viasfora
    // productivity power tools


    [Route("api/Materia")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
            readonly IMateriaRepository _materiaRepository;

            // esto es inyeccion por dependencias
            public MateriaController(IMateriaRepository materiaRepository)
            {
                _materiaRepository = materiaRepository;
            }

         [HttpGet]
        [Route("GetMaterias")]
        public IActionResult GetMaterias()
        {
            var res = _materiaRepository.GetMaterias();
            //var res = new MateriaRepository().GetMaterias();
            return Ok(res);
        }
    }
}
