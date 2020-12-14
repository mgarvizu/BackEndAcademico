using BackEnd.Core.Entities;
using BackEnd.Core.Exceptions;
using BackEnd.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Academico.Controllers
{
    [Route("api/Estudiante")]
    [ApiController]
    public class EstudianteDapperController : ControllerBase
    {
        readonly IEstudianteDapperRepository _estudianteDapperRepository;
        readonly ILogger<EstudianteDapperController> _logger;
        public EstudianteDapperController(IEstudianteDapperRepository estudianteDapperRepository,
            ILogger<EstudianteDapperController> logger)
        {
            _estudianteDapperRepository = estudianteDapperRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetEstudianteDBTodos")] // &
        public async Task<IActionResult> GetPersonasDBTodos()
        {
            var per = await _estudianteDapperRepository.GetEstudiantesBDTodosAsync();
            _logger.LogInformation("Iniciando Controlador");
            // simular un error en serlog
            try
            {
                for (int i = 0; i < 11; i++)
                {
                    if (1 == 11)
                    {
                        throw new Exception("Lnazar exception");
                    }
                    else {
                        _logger.LogInformation("El valor de i es {contador}", i);
                    }
                }
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Excepcion capturado");
                throw new BussinesException(err.Message);
            }
            return Ok(per);
        }

        [HttpGet]
        [Route ("GetEstudianteDB/{id}/{nombre}")] // &
        public async Task<IActionResult> GetPersonasDB(int id, string nombre)
        {
            var per = await _estudianteDapperRepository.GetEstudiantesBD3Async(id, nombre);
            _logger.LogInformation("Iniciando GetPersonasDB con id {id_e} y " +
                "nombre {nom}", id,nombre);
            return Ok(per);
        }
        [HttpPost]
        [Route ("AddEstudiante")]
        public async Task<IActionResult> AddEstudiante(Estudiante estudiante)
        {
            var per = await _estudianteDapperRepository.AddEstudianteAsync(estudiante);
            _logger.LogInformation("Iniciando AddEstudiante");
            return Ok(per);
        }

        [HttpPut]
        [Route("UpdateEstudiante")]
        public async Task<IActionResult> UpdateEstudiante(Estudiante estudiante)
        {
            var per = await _estudianteDapperRepository.UpdateEstudianteAsync(estudiante);
            _logger.LogInformation("Iniciando UpdateEstudiante");
            return Ok(per);
        }

        [HttpDelete]
        [Route("DeleteEstudiante")]
        public async Task<IActionResult> DeleteEstudiante(Estudiante estudiante)
        {
            var per = await _estudianteDapperRepository.DeleteEstudianteAsync(estudiante);
            _logger.LogInformation("Iniciando DeleteEstudiante");
            return Ok(per);
        }

        [HttpGet]
        [Route("AddEstudianteAutomatic")]
        public async Task<IActionResult> AddEstudianteAutomatic()
        {
            var per = await _estudianteDapperRepository.AddEstudianteAutomatic();
            _logger.LogInformation("Iniciando AddEstudianteAutomatic");
            return Ok(per);
        }
    }
}
