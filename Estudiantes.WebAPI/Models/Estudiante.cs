using System;
using System.Collections.Generic;
using Estudiantes.WebAPI.Models;

namespace Estudiantes.WebAPI.Models
{
    public class Estudiante : Persona
    {
        public int idEstudiante { get; set; }
        public string matricula { get; set; }
        public string carrera { get; set; }
        public DateTime fechaIngreso { get; set; }
        public string semestre { get; set; }
        public bool activo { get; set; }
        public List<MateriaCursando> materiascursando { get; set; }
        public List<MateriaCursada> materiascursadas { get; set; }

       //     List<MateriaCursando> materiascursando1 ;
        //    List<MateriaCursada> materiascursadas1 ;

        public Estudiante()
        {
           
        }

        public Estudiante(dynamic elementoE, dynamic elementoMateriasCas, dynamic elementoMateriasCndo)
        {

            this.idPersona = elementoE.idPersona;
            this.nombre = elementoE.nombre;
            this.apellidoPaterno = elementoE.apellidoPaterno;
            this.apellidoMaterno = elementoE.apellidoMaterno;
            this.sexo = char.Parse(elementoE.sexo.ToString());
            this.curp = elementoE.curp;
            this.telefono = elementoE.telefono;
            this.correo = elementoE.correo;
            this.fechaNacimiento = elementoE.fechaNacimiento;
            this.nacionalidad = elementoE.nacionalidad;
            // Datos direccion
            this.direccion = new Direccion();
            this.direccion.idDireccion = elementoE.idDireccion;
            this.direccion.calle = elementoE.calle;
            this.direccion.numeroExterior = elementoE.numeroExterior;
            this.direccion.numeroInterior = elementoE.numeroInterior;
            this.direccion.colonia = elementoE.colonia;
            this.direccion.municipio = elementoE.municipio;
            this.direccion.estado = elementoE.estado;
            this.direccion.codigoPostal = elementoE.codigoPostal;
            //Datos de alumno
            this.idEstudiante = elementoE.idEstudiante;
            this.matricula = elementoE.matricula;
            this.carrera = elementoE.carrera;
            this.semestre = elementoE.semestre;
            this.fechaIngreso = elementoE.fechaIngreso;
            this.activo = elementoE.activo;

            this.materiascursadas = new List<MateriaCursada>();

            //Iterar elementoMateriasCas para llenar materiasCursadas 
            foreach (var materia1 in elementoMateriasCas)
            {
                MateriaCursada materiaCursada = new MateriaCursada(materia1);
                this.materiascursadas.Add(materiaCursada);
            }

            this.materiascursando = new List<MateriaCursando>();

            //Iterar elementoMateriasCas para llenar elementoMateriasCndo 
            foreach (var materia2 in elementoMateriasCndo)
            {
                MateriaCursando materiaCursando = new MateriaCursando(materia2);
                this.materiascursando.Add(materiaCursando);
            }

        }

        public void EstudianteSinLista(dynamic elementoE)
        {

            this.idPersona = elementoE.idPersona;
            this.nombre = elementoE.nombre;
            this.apellidoPaterno = elementoE.apellidoPaterno;
            this.apellidoMaterno = elementoE.apellidoMaterno;
            this.sexo = char.Parse(elementoE.sexo.ToString());
            this.curp = elementoE.curp;
            this.telefono = elementoE.telefono;
            this.correo = elementoE.correo;
            this.fechaNacimiento = elementoE.fechaNacimiento;
            this.nacionalidad = elementoE.nacionalidad;
            // Datos direccion
            this.direccion = new Direccion();
            this.direccion.idDireccion = elementoE.idDireccion;
            this.direccion.calle = elementoE.calle;
            this.direccion.numeroExterior = elementoE.numeroExterior;
            this.direccion.numeroInterior = elementoE.numeroInterior;
            this.direccion.colonia = elementoE.colonia;
            this.direccion.municipio = elementoE.municipio;
            this.direccion.estado = elementoE.estado;
            this.direccion.codigoPostal = elementoE.codigoPostal;
            //Datos de alumno
            this.idEstudiante = elementoE.idEstudiante;
            this.matricula = elementoE.matricula;
            this.carrera = elementoE.carrera;
            this.semestre = elementoE.semestre;
            this.fechaIngreso = elementoE.fechaIngreso;
            this.activo = elementoE.activo;
          //  this.materiascursando = new List<MateriaCursando>();

            //this.materiascursadas = new List<MateriaCursada>();
        //    elementoE.materiascursadas = this.materiascursadas1;
         //  elementoE.materiascursando = this.materiascursando1;

        }

   public void EstudianteConMateriasCursadas(dynamic elementoE , dynamic elementoMateriasCas)
        {

            this.idPersona = elementoE.idPersona;
            this.nombre = elementoE.nombre;
            this.apellidoPaterno = elementoE.apellidoPaterno;
            this.apellidoMaterno = elementoE.apellidoMaterno;
            this.sexo = char.Parse(elementoE.sexo.ToString());
            this.curp = elementoE.curp;
            this.telefono = elementoE.telefono;
            this.correo = elementoE.correo;
            this.fechaNacimiento = elementoE.fechaNacimiento;
            this.nacionalidad = elementoE.nacionalidad;
            // Datos direccion
            this.direccion = new Direccion();
            this.direccion.idDireccion = elementoE.idDireccion;
            this.direccion.calle = elementoE.calle;
            this.direccion.numeroExterior = elementoE.numeroExterior;
            this.direccion.numeroInterior = elementoE.numeroInterior;
            this.direccion.colonia = elementoE.colonia;
            this.direccion.municipio = elementoE.municipio;
            this.direccion.estado = elementoE.estado;
            this.direccion.codigoPostal = elementoE.codigoPostal;
            //Datos de alumno
            this.idEstudiante = elementoE.idEstudiante;
            this.matricula = elementoE.matricula;
            this.carrera = elementoE.carrera;
            this.semestre = elementoE.semestre;
            this.fechaIngreso = elementoE.fechaIngreso;
            this.activo = elementoE.activo;
        
        //Lista Materias Cursadas
            this.materiascursadas = new List<MateriaCursada>();

            //Iterar elementoMateriasCas para llenar materiasCursadas 
            foreach (var materia1 in elementoMateriasCas)
            {
                MateriaCursada materiaCursada = new MateriaCursada(materia1);
                this.materiascursadas.Add(materiaCursada);
            }


        }

         public void EstudianteConMateriasCursando(dynamic elementoE, dynamic elementoMateriasCndo)
        {

            this.idPersona = elementoE.idPersona;
            this.nombre = elementoE.nombre;
            this.apellidoPaterno = elementoE.apellidoPaterno;
            this.apellidoMaterno = elementoE.apellidoMaterno;
            this.sexo = char.Parse(elementoE.sexo.ToString());
            this.curp = elementoE.curp;
            this.telefono = elementoE.telefono;
            this.correo = elementoE.correo;
            this.fechaNacimiento = elementoE.fechaNacimiento;
            this.nacionalidad = elementoE.nacionalidad;
            // Datos direccion
            this.direccion = new Direccion();
            this.direccion.idDireccion = elementoE.idDireccion;
            this.direccion.calle = elementoE.calle;
            this.direccion.numeroExterior = elementoE.numeroExterior;
            this.direccion.numeroInterior = elementoE.numeroInterior;
            this.direccion.colonia = elementoE.colonia;
            this.direccion.municipio = elementoE.municipio;
            this.direccion.estado = elementoE.estado;
            this.direccion.codigoPostal = elementoE.codigoPostal;
            //Datos de alumno
            this.idEstudiante = elementoE.idEstudiante;
            this.matricula = elementoE.matricula;
            this.carrera = elementoE.carrera;
            this.semestre = elementoE.semestre;
            this.fechaIngreso = elementoE.fechaIngreso;
            this.activo = elementoE.activo;
        
            //Lista Materias Cursando

            this.materiascursando = new List<MateriaCursando>();

            //Iterar elementoMateriasCas para llenar elementoMateriasCndo 
            foreach (var materia2 in elementoMateriasCndo)
            {
                MateriaCursando materiaCursando = new MateriaCursando(materia2);
                this.materiascursando.Add(materiaCursando);
            }

        }

        public object obtenerParametros()
        {

            object parametros = new
            {

                idPersona = this.idPersona,
                nombre = this.nombre,
                apellidoPaterno = this.apellidoPaterno,
                apellidoMaterno = this.apellidoMaterno,
                sexo = this.sexo,
                curp = this.curp,
                telefono = this.telefono,
                correo = this.correo,
                fechaNacimiento = this.fechaNacimiento,
                nacionalidad = this.nacionalidad,

                idDireccion = this.direccion.idDireccion,
                calle = this.direccion.calle,
                numeroExterior = this.direccion.numeroExterior,
                numeroInterior = this.direccion.numeroInterior,
                colonia = this.direccion.colonia,
                municipio = this.direccion.municipio,
                estado = this.direccion.estado,
                codigoPostal = this.direccion.codigoPostal,

                idEstudiante = this.idEstudiante,
                matricula = this.matricula,
                carrera = this.carrera,
                fechaIngreso = this.fechaIngreso,
                semestre = this.semestre,
                activo = this.activo

        //   materiascursando = this.materiascursando,
         //   materiascursadas = this.materiascursadas

            };

            return parametros;

        }

    }

}