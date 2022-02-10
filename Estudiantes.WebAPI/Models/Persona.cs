using System;

namespace Estudiantes.WebAPI.Models
{
    public class Persona
    {
        public int idPersona { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public char sexo { get; set; }
        public string curp { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string nacionalidad { get; set; }
        public Direccion direccion { get; set; }
    }
}
