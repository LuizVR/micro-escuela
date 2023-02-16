using EscuelaUnida.Aplicacion;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EscuelaUnida.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EstudianteController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Nuevo(Agregar.Ejecuta data)
        {
            return await _mediator.Send(data);
        }
        [HttpGet]
        public async Task<ActionResult<List<EstudianteDto>>> GetEstudiantes()
        {
            return await _mediator.Send(new Consulta.ListaEstudiante());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EstudianteDto>> GetEstudianteEscuela(string id)
        {
            return await _mediator.Send(new ConsultarFiltro.EstudianteUnico { EstudianteGuid= id });
        }
    }
}
