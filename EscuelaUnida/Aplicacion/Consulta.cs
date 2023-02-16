using AutoMapper;
using EscuelaUnida.Modelo;
using EscuelaUnida.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EscuelaUnida.Aplicacion
{
    public class Consulta
    {
        public class ListaEstudiante : IRequest<List<EstudianteDto>>
        {

        }

        public class Manejador : IRequestHandler<ListaEstudiante, List<EstudianteDto>>
        {
            private readonly ContextoEstudiante _contexto;
            private readonly IMapper _mapper;
            public Manejador(ContextoEstudiante contexto, IMapper mapper)
            {
                this._contexto = contexto;
                this._mapper = mapper;
            }
            public async Task<List<EstudianteDto>> Handle(ListaEstudiante request, CancellationToken cancellationToken)
            {
                var estudiantes = await _contexto.EstudianteEscuelas.ToListAsync();
                var estudiantesDto = _mapper.Map<List<EstudianteEscuela>, List<EstudianteDto>>(estudiantes);
                return estudiantesDto;
            }
        }
    }
}
