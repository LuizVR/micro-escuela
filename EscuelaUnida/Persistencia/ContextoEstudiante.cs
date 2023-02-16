using EscuelaUnida.Modelo;
using Microsoft.EntityFrameworkCore;

namespace EscuelaUnida.Persistencia
{
    public class ContextoEstudiante : DbContext
    {
        public ContextoEstudiante(DbContextOptions<ContextoEstudiante> options): base(options)
        {

        }

        public DbSet<EstudianteEscuela> EstudianteEscuelas { get; set; }
    }
}
