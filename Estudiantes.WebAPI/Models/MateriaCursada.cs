using System;

namespace Estudiantes.WebAPI.Models
{
    public class MateriaCursada{

        public int idMateriaCursada { get; set; }
        public int idEstudiante { get; set; }
        public string clave { get; set; }
        public string materia { get; set; }
        public decimal caliPrimerP { get; set; }
        public decimal caliSegundoP { get; set; }
        public decimal caliTercerP { get; set; }
        public decimal caliFinal { get; set; }
        public bool activo { get; set; }


public MateriaCursada(){

}

public  MateriaCursada (dynamic elementoE){

this.idMateriaCursada = elementoE.idMateriaCursada;
this.idEstudiante = elementoE.idEstudiante;
this.clave = elementoE.clave ;
this.materia = elementoE.materia ;
this.caliPrimerP =  elementoE.caliPrimerP ;
this.caliSegundoP =  elementoE.caliSegundoP ;
this.caliTercerP =  elementoE.caliTercerP ;
this.caliFinal =  elementoE.caliFinal ;
this.activo = elementoE.activo;

    }

    public object obtenerParametros(){

object parametros = new {

idMateriaCursada= this.idMateriaCursada,
idEstudiante = this.idEstudiante,
clave= this.clave,
materia= this.materia,
caliPrimerP= this.caliPrimerP,
caliSegundoP= this.caliSegundoP,
caliTercerP= this.caliTercerP,
caliFinal= this.caliFinal,
activo = this.activo

};

return parametros;

    }


    }
}