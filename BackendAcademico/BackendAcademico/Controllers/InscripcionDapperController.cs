using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Core.Entities;
using BackEnd.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Academico.Controllers
{
    [Route("api/Inscripcion")]
    [ApiController]
    public class InscripcionDapperController : ControllerBase
    {
        readonly IInscripcionDapperRepository _inscripcionDapperRepository;
        readonly ILogger<InscripcionDapperController> _logger;
        public InscripcionDapperController(IInscripcionDapperRepository inscripcionDapperRepository,
            ILogger<InscripcionDapperController> logger)
        {
            _inscripcionDapperRepository = inscripcionDapperRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetInscripcionAll")]
        public async Task<IActionResult> GetInscripcionAll()
        {
            var ins = await _inscripcionDapperRepository.GetInscripcionAll();
            _logger.LogInformation("Iniciando GetInscripcionAll");
            return Ok(ins);
        }

        [HttpGet]
        [Route("GetEstInsEnMat/{materia}")]
        public async Task<IActionResult> GetEstInsEnMat(string materia)
        {
            var ins = await _inscripcionDapperRepository.GetEstInsEnMat(materia);
            _logger.LogInformation("Iniciando GetEstInsEnMat con materia {mat}", materia);
            return Ok(ins);
        }
        [HttpGet]
        [Route("GetListMatDeEst/{ci}")]
        public async Task<IActionResult> GetLisMatDeEst(string ci)
        {
            var ins = await _inscripcionDapperRepository.GetLisMatDeEst(ci);
            _logger.LogInformation("Iniciando GetPersonasDB con ci {ci_i}", ci);
            return Ok(ins);
        }
        [HttpPost]
        [Route("addInscripcion")]
        public async Task<IActionResult> addInscripcion(Inscripcion inscripcion) {
            var ins = await _inscripcionDapperRepository.AddInscripcionAsync(inscripcion);
            _logger.LogInformation("Iniciando addInscripcion");
            return Ok(ins);
        }

        [HttpPut]
        [Route("updateInscripcion")]
        public async Task<IActionResult> updateInscripcion(Inscripcion inscripcion)
        {
            var ins = await _inscripcionDapperRepository.UpdateInscripcionAsync(inscripcion);
            _logger.LogInformation("Iniciando updateInscripcion");
            return Ok(ins);
        }
        [HttpDelete]
        [Route("deleteInscripcion")]
        public async Task<IActionResult> deleteInscripcion(Inscripcion inscripcion)
        {
            var ins = await _inscripcionDapperRepository.DeleteInscripcionAsync(inscripcion);
            _logger.LogInformation("Iniciando deleteInscripcion");
            return Ok(ins);
        }
    }
}
