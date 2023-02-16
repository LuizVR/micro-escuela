using System;

namespace EscuelaUnida.Aplicacion
{
    public class EstudianteDto
    {
        public int EstudianteId { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public string Municipio { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string EstudianteGuid { get; set; }
    }
}
