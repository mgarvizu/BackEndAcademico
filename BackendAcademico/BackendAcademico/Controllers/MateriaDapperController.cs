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
    [Route("api/Materia")]
    [ApiController]
    public class MateriaDapperController : ControllerBase
    {
        readonly IMateriaDapperRepository _materiaDapperRepository;
        readonly ILogger<MateriaDapperController> _logger;
        public MateriaDapperController(IMateriaDapperRepository materiaDapperRepository,
            ILogger<MateriaDapperController> logger)
        {
            _materiaDapperRepository = materiaDapperRepository;
            _logger = logger;
            
        }

        [HttpGet]
        [Route("GetMateriasTodosAsync")]
        public async Task<IActionResult> GetMateriasTodosAsync()
        {
            var mat = await _materiaDapperRepository.GetMateriasTodosAsync();
            _logger.LogInformation("Iniciando GetMateriasTodosAsync");
            return Ok(mat);
        }
        [HttpGet]
        [Route("GetMateriasSiglaAsync/{sigla}")]
        public async Task<IActionResult> GetMateriasSiglaAsync(string sigla)
        {
            var mat = await _materiaDapperRepository.GetMateriasSiglaAsync(sigla);
            _logger.LogInformation("Iniciando GetMateriasSiglaAsync con dato {mat}", sigla);
            return Ok(mat);
        }

        [HttpGet]
        [Route("GetMateriasNombreMatAsync/{nombre}")]
        public async Task<IActionResult> GetMateriasNombreMatAsync(string nombre)
        {
            var mat = await _materiaDapperRepository.GetMateriasNombreMatAsync(nombre);
            _logger.LogInformation("Iniciando GetMateriasNombreMatAsync con dato {mat}", nombre);
            return Ok(mat);
        }
    }
}
