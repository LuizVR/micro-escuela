using AutoMapper;
using EscuelaUnida.Modelo;
using EscuelaUnida.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EscuelaUnida.Aplicacion
{
    public class ConsultarFiltro
    {
        public class EstudianteUnico : IRequest<EstudianteDto>
        {
            public string EstudianteGuid { get; set; }
        }
        public class Manejador : IRequestHandler<EstudianteUnico, EstudianteDto>
        {
            private readonly ContextoEstudiante _contexto;
            private readonly IMapper _mapper;
            public Manejador(ContextoEstudiante contexto, IMapper mapper)
            {
                this._contexto = contexto;
                this._mapper = mapper;
            }
            public async Task<EstudianteDto> Handle(EstudianteUnico request, CancellationToken cancellationToken)
            {
                var estudiante = await _contexto.EstudianteEscuelas
                    .Where(p => p.EstudianteGuid == request.EstudianteGuid).FirstOrDefaultAsync();

                if (estudiante == null)
                {
                    throw new Exception("No se encontró el estudiante");
                }
                var estudianteDto = _mapper.Map<EstudianteEscuela, EstudianteDto>(estudiante);
                return estudianteDto;
            }
        }
    }
}
