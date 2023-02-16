using EscuelaUnida.Modelo;
using EscuelaUnida.Persistencia;
using FluentValidation;
using FluentValidation.Validators;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EscuelaUnida.Aplicacion
{
    public class Agregar
    {
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
            public string Matricula { get; set; }
            public string Municipio { get; set; }
            public DateTime? FechaNacimiento { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {

            public EjecutaValidacion()
            {
                RuleFor(p => p.Nombre).NotEmpty();
                RuleFor(p => p.Matricula).NotEmpty();
                RuleFor(p => p.Municipio).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly ContextoEstudiante _contexto;
            public Manejador(ContextoEstudiante contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken canellationToken)
            {
                var estudianteEscuela = new EstudianteEscuela
                {
                    Nombre = request.Nombre,
                    Matricula = request.Matricula,
                    Municipio = request.Municipio,
                    FechaNacimiento = request.FechaNacimiento,
                    EstudianteGuid = Convert.ToString(Guid.NewGuid())
                };
                _contexto.EstudianteEscuelas.Add(estudianteEscuela);
                var respuesta = await _contexto.SaveChangesAsync();
                if (respuesta > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar al estudiante");
            }
        }
    }
}
