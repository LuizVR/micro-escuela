using MediatR;
using System;

namespace EscuelaUnida.Modelo
{
    public class EstudianteEscuela
    {
        public int EstudianteEscuelaId { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public string Municipio { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string EstudianteGuid { get; set; }
    }
}
//Migracion:   Add-Migration AddTable_v1    update-database