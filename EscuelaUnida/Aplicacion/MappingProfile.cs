using AutoMapper;
using EscuelaUnida.Modelo;

namespace EscuelaUnida.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EstudianteEscuela, EstudianteDto>();
        }
    }
}
