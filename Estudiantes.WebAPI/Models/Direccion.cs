using System;

namespace Estudiantes.WebAPI.Models
{

public class Direccion
    {
        public int idDireccion { get; set; }
        public string calle { get; set; }
        public string numeroExterior { get; set; }
        public string numeroInterior { get; set; }
        public string colonia { get; set; }
        public string municipio { get; set; }
        public string estado { get; set; }
        public string codigoPostal { get; set; }

    }
}