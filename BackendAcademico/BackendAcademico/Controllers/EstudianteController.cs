using BackEnd.Core.Entities;
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
    // https:port/api/GetEstudiantes
    [Route("api/Estudiante")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        readonly IEstudianteRepository _estudianteRepository;

        // esto es inyeccion por dependencias
        public EstudianteController(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }

        [HttpGet]
        [Route("GetEstudiantes")]
        public IActionResult GetEstudiantes()
        {
            var res = _estudianteRepository.GetEstudiantes(); 
            // var res = new EstudianteRepository().GetEstudiantes();
            // BadRequest - estado 400
            // NoContent - 204
            // NoContent - 404
            return Ok(res);        
        }

        [HttpGet]
        [Route("GetEstudiantesBD1")]
        public IActionResult GetEstudiantesBD1()
        {
            var res = _estudianteRepository.GetEstudiantesBD1();
            // var res = new EstudianteRepository().GetEstudiantes();
            // BadRequest - estado 400
            // NoContent - 204
            // NoContent - 404
            return Ok(res);
        }

        [HttpGet]
        [Route("GetEstudiantesBD2")]
        public IActionResult GetEstudiantesBD2(int id)
        {
            var res = _estudianteRepository.GetEstudiantesBD2(id);
            // var res = new EstudianteRepository().GetEstudiantes();
            // BadRequest - estado 400
            // NoContent - 204
            // NoContent - 404
            return Ok(res);
        }

        [HttpGet]
        [Route("GetEstudiantesBD3")]
        public IActionResult GetEstudiantesBD3(int id)
        {
            var res = _estudianteRepository.GetEstudiantesBD3(id);
            // var res = new EstudianteRepository().GetEstudiantes();
            // BadRequest - estado 400
            // NoContent - 204
            // NoContent - 404
            return Ok(res);
        }

        // [HttpPut] // usualmnete para hacer un update
        [HttpPost] // sirve para hacer un registro
        [Route("AddEstudiante")]
        public IActionResult AddEstudiante(Estudiante estudiante) {
            var res = _estudianteRepository.AddEstudiante(estudiante);
            return Ok(res);
        }

        [HttpPut] // sirve para hacer un registro
        [Route("UpdateEstudiante")]
        public IActionResult UpdateEstudiante(Estudiante estudiante)
        {
            var res = _estudianteRepository.UpdateEstudiante(estudiante);
            return Ok(res);
        }

        [HttpDelete]
        [Route("DeleteEstudiante")]
        public IActionResult DeleteEstudiante(Estudiante estudiante)
        {
            var res = _estudianteRepository.DeleteEstudiante(estudiante);
            return Ok(res);
        }
    }
}
