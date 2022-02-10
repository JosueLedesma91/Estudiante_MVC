using System;

namespace Estudiantes.WebAPI.Models
{
    public class MateriaCursando{

        public int idMateriaCursando { get; set; }
        public int idEstudiante { get; set; }

        public string clave { get; set; }
        public string materia { get; set; }
        public string horario { get; set; }
        public decimal caliPrimerP { get; set; }
        public decimal caliSegundoP { get; set; }
        public decimal caliTercerP { get; set; }
        public bool activo { get; set; }


public MateriaCursando(){

}

public  MateriaCursando (dynamic elementoE){

this.idMateriaCursando = elementoE.idMateriaCursando ;
this.idEstudiante = elementoE.idEstudiante;
this.clave = elementoE.clave ;
this.materia = elementoE.materia ;
this.horario = elementoE.horario;
this.caliPrimerP =  elementoE.caliPrimerP ;
this.caliSegundoP =  elementoE.caliSegundoP ;
this.caliTercerP =  elementoE.caliTercerP ;
this.activo = elementoE.activo;

    }

    public object obtenerParametros(){

object parametros = new {

idMateriaCursando= this.idMateriaCursando,
idEstudiante=this.idEstudiante,
clave= this.clave,
materia= this.materia,
horario = this.horario,
caliPrimerP= this.caliPrimerP,
caliSegundoP= this.caliSegundoP,
caliTercerP= this.caliTercerP,
activo = this.activo

};

return parametros;

    }



    }
}