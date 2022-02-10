using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using MVCDapper.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Web;
using Microsoft.AspNetCore.Http;
using Estudiantes.WebAPI.Models;

namespace Estudiantes.WebAPI.DataAccess
{


    public class EstudianteDA
    {
        private readonly IConfiguration configuration;

        public EstudianteDA(IConfiguration config)
        {
            this.configuration = config;


        }

        // METODOS DE ESTUDIANTES

        // METODO OBTENER Estudiantes
        public List<Estudiante> obtenerEstudiantes()
        {
            // Inicio
            //1 Creamos la lista donde guardaremos los datos
            List<Estudiante> estudiantesMostrar = new List<Estudiante>();


            //2 Creamos la cadena de conexion             
            string cadenaConexion = configuration.GetConnectionString("EstudianteConnection");
            //3 Hacemos la conexion a la base datos    
            using (IDbConnection db = new SqlConnection(cadenaConexion))
            {
                string query = " EXEC consultaEstudiantes";


                //4 se hace la consulta y la guardamos en la lista empleados
                var resultado = db.Query(query).ToList();
                foreach (var elementoE in resultado)
                {
                    Estudiante estudiante = new Estudiante();
                    estudiante.EstudianteSinLista(elementoE);
                    // Models.Empleado empleado = Models.Empleado.cargarDatos(elementoE);
                    estudiantesMostrar.Add(estudiante);
                }



            }
            return estudiantesMostrar;
        }


        // METODO Buscar por ID Estudiante
        public Estudiante encontrarEstudiante(int pIdEstudiante)
        {
            //1 Recibir id Empleado
            Estudiante estudiante = null;
            //2 Obtener la cadena de conexion 
            string cadenaConexion = configuration.GetConnectionString("EstudianteConnection");
            // 3 Crear la conexion 
            using (IDbConnection db = new SqlConnection(cadenaConexion))
            {
                //4 Hacer la consulta
                string queryEstudiante = " EXEC obtenerEstudiante @idEstudiante";
                string queryMateriasCursadas = " EXEC consultarMateriaCursada @idEstudiante";
                string queryMateriasCursando = " EXEC consultarMateriaCursando @idEstudiante";

                // 5 Ejecuta consulta
                var resultadoEstudiante = db.QueryFirstOrDefault(queryEstudiante, new { idEstudiante = pIdEstudiante });
                var resultadomateriasCas = db.Query<MateriaCursada>(queryMateriasCursadas, new { idEstudiante = pIdEstudiante }).ToList();
                var resultadomateriasCndo = db.Query<MateriaCursando>(queryMateriasCursando, new { idEstudiante = pIdEstudiante }).ToList();


                if (resultadomateriasCas.Count() == 0 && resultadomateriasCndo.Count() == 0)
                {
                    estudiante = new Estudiante();
                    estudiante.EstudianteSinLista(resultadoEstudiante);
                    //6 Si la consulta es null es que no existe en la base
                }
                else if (resultadomateriasCas.Count() > 0 && resultadomateriasCndo.Count() == 0)
                {
                     estudiante = new Estudiante();
                    //7 Si es existe devolver el empleado para que sea pintado en el front
                    estudiante.EstudianteConMateriasCursadas(resultadoEstudiante, resultadomateriasCas);
                }
                else if (resultadomateriasCas.Count() == 0 && resultadomateriasCndo.Count() > 0)
                {
                    estudiante = new Estudiante();
                    //7 Si es existe devolver el empleado para que sea pintado en el front
                    estudiante.EstudianteConMateriasCursando(resultadoEstudiante, resultadomateriasCndo);
                }
                else if (resultadomateriasCas.Count() > 0 && resultadomateriasCndo.Count() > 0)
                {
                    //7 Si es existe devolver el empleado para que sea pintado en el front
                    estudiante = new Estudiante(resultadoEstudiante, resultadomateriasCas, resultadomateriasCndo);
                }


            }
            return estudiante;

        }
        /////////


        //////METODO CREAR Estudiante

        public Estudiante Crear(Estudiante estudiante)
        {
            int idEstudiante = 0;
            // 1 Inicio
            // 2 Obtener la cadena de conexion
            string cadenaConexion = configuration.GetConnectionString("EstudianteConnection");
            // 3 Crear la conexion 
            using (IDbConnection db = new SqlConnection(cadenaConexion))
            {
                // 4 Crear el query para insertar

                string query = "EXEC crearEstudiante @IdPersona,@Nombre,@ApellidoPaterno,@apellidoMaterno,@sexo,@curp,@telefono,@correo," +
                "@fechaNacimiento,@nacionalidad,@idDireccion,@calle,@numeroExterior,@numeroInterior,@colonia,@municipio,@estado," +
                "@codigoPostal,@matricula,@carrera,@fechaIngreso,@semestre,@activo";

                object parametros = new
                {

                    idPersona = estudiante.idPersona,
                    nombre = estudiante.nombre,
                    apellidoPaterno = estudiante.apellidoPaterno,
                    apellidoMaterno = estudiante.apellidoMaterno,
                    sexo = estudiante.sexo,
                    curp = estudiante.curp,
                    telefono = estudiante.telefono,
                    correo = estudiante.correo,
                    fechaNacimiento = estudiante.fechaNacimiento,
                    nacionalidad = estudiante.nacionalidad,
                    idDireccion = estudiante.direccion.idDireccion,
                    calle = estudiante.direccion.calle,
                    numeroExterior = estudiante.direccion.numeroExterior,
                    numeroInterior = estudiante.direccion.numeroInterior,
                    colonia = estudiante.direccion.colonia,
                    municipio = estudiante.direccion.municipio,
                    estado = estudiante.direccion.estado,
                    codigoPostal = estudiante.direccion.codigoPostal,
                    matricula = estudiante.matricula,
                    carrera = estudiante.carrera,
                    fechaIngreso = estudiante.fechaIngreso,
                    semestre = estudiante.semestre,
                    activo = estudiante.activo

                };

                // 5 Ejecutar la consulta
                idEstudiante = db.QuerySingle<int>(query, parametros);
                estudiante.idEstudiante = idEstudiante;

            }

            // 8 Retornar empleado
            return estudiante;
        }


        //////////


        // METODO ACTUALIZAR Estudiante
        public Estudiante Actualizar(Estudiante estudiante)
        {
            // 1 Inicio
            // 2 Recibir empleado en los parametros actualizar del controlador PUT Actualizar()
            // 3 Obtener la cadena de conexion
            string cadenaConexion = configuration.GetConnectionString("EstudianteConnection");
            // 4 Crear el objeto conexion 
            using (IDbConnection db = new SqlConnection(cadenaConexion))
            {
                // 5 Crear el query



                string query = "EXEC actualizarEstudiante @idEstudiante,@idPersona,@nombre,@apellidoPaterno,@apellidoMaterno,@sexo," +
                "@curp,@telefono,@correo,@fechaNacimiento,@nacionalidad,@idDireccion,@calle,@numeroExterior,@numeroInterior,@colonia," +
                "@municipio,@estado,@codigoPostal,@matricula,@carrera,@fechaIngreso,@semestre,@activo";

                /*"UPDATE Empleado "+
                " SET idPersona= @idPersona, nombre= @nombre, apellidoPaterno= @apellidoPaterno, apellidoMaterno= @apellidoMaterno,"+
                "sexo= @sexo, curp= @curp, telefono= @telefono, correo= @correo, fechaNacimiento= @fechaNacimiento, nacionalidad= @nacionalidad,"+
                "idDireccion= @idDireccion, calle= @calle, numeroExterior= @numeroExterior, numeroInterior= @numeroInterior,colonia= @colonia,"+
                "municipio= @municipio, estado=@estado, codigoPostal= @codigoPostal, rfc= @rfc, puesto= @puesto, fechaIngreso= @fechaIngreso,"+
                "salarioDiario= @salarioDiario, nss= @nss, horario= @horario, totalFaltas= @totalFaltas, activo= @activo "+
                "WHERE idEmpleado = @idEmpleado";
                */
                //6 Obtener lsita de parametros
                var parametros = estudiante.obtenerParametros();

                // 7 Ejecutar el query
                int numRegistrosAfectados = db.Execute(query, parametros);


            }

            // 6 Ejecutar el query

            return estudiante;
        }


        //METODOS DE MATERIAS CURSADAS

        // METODO OBTENER MATERIAS CURSADAS
        public List<MateriaCursada> obtenerMateriasCursadas()
        {
            // Inicio
            //1 Creamos la lista donde guardaremos los datos
            List<MateriaCursada> materiasMostrar = new List<MateriaCursada>();
            //2 Creamos la cadena de conexion             
            string cadenaConexion = configuration.GetConnectionString("EstudianteConnection");
            //3 Hacemos la conexion a la base datos    
            using (IDbConnection db = new SqlConnection(cadenaConexion))
            {
                string queryMateriasCdas = "EXEC consultarMateriasCursadas ";

                //4 se hace la consulta y la guardamos en la lista empleados
                var resultadomateriasCas = db.Query<MateriaCursada>(queryMateriasCdas).ToList();

                resultadomateriasCas.ToList();
                foreach (var elementoE in resultadomateriasCas)
                {
                    MateriaCursada materia = new MateriaCursada(elementoE);
                    // Models.Empleado empleado = Models.Empleado.cargarDatos(elementoE);
                    materiasMostrar.Add(materia);
                }


            }
            return materiasMostrar;
        }

        //////

        // METODO OBTENER MATERIAS CURSADAS POR ID
        public MateriaCursada encontrarMateriaCursada(int pIdMateria)
        {
            //1 Recibir id Empleado
            MateriaCursada materiaCursada = null;
            //2 Obtener la cadena de conexion 
            string cadenaConexion = configuration.GetConnectionString("EstudianteConnection");
            // 3 Crear la conexion 
            using (IDbConnection db = new SqlConnection(cadenaConexion))
            {
                //4 Hacer la consulta
                string queryMateriaCursada = " EXEC consultarMateriaCursadaId @idMateriaCursada";


                // 5 Ejecuta consulta
                var resultadoMateriaCda = db.QueryFirstOrDefault(queryMateriaCursada, new { idMateriaCursada = pIdMateria });


                if (resultadoMateriaCda.Count() == 0)
                {
                    materiaCursada = null;
                    //6 Si la consulta es null es que no existe en la base
                }
                else
                {
                    //7 Si es existe devolver el empleado para que sea pintado en el front
                    materiaCursada = new MateriaCursada(resultadoMateriaCda);
                }
            }
            return materiaCursada;

        }
        /////////



        //////METODO CREAR MATERIA CURSADA

        public MateriaCursada crearMateriaCursada(MateriaCursada materiaCursada)
        {
            int idMateriaCursada = 0;
            // 1 Inicio
            // 2 Obtener la cadena de conexion
            string cadenaConexion = configuration.GetConnectionString("EstudianteConnection");
            // 3 Crear la conexion 
            using (IDbConnection db = new SqlConnection(cadenaConexion))
            {
                // 4 Crear el query para insertar
                string query = "EXEC insertarMateriaCursada @idEstudiante,@clave,@materia,@caliPrimerP,@caliSegundoP,@caliTercerP,@caliFinal,@activo";


                object parametros = new
                {

                    idEstudiante = materiaCursada.idEstudiante,
                    clave = materiaCursada.clave,
                    materia = materiaCursada.materia,
                    caliPrimerP = materiaCursada.caliPrimerP,
                    caliSegundoP = materiaCursada.caliSegundoP,
                    caliTercerP = materiaCursada.caliTercerP,
                    caliFinal = materiaCursada.caliFinal,
                    activo = materiaCursada.activo


                };

                // 5 Ejecutar la consulta
                idMateriaCursada = db.QueryFirstOrDefault<int>(query, parametros);
                materiaCursada.idMateriaCursada = idMateriaCursada;

            }

            // 8 Retornar empleado
            return materiaCursada;
        }


        //////////

        // METODO ACTUALIZAR MATERIACURSADA
        public MateriaCursada actualizarMateriaCursada(MateriaCursada materiaCursada)
        {

            // 1 Inicio
            // 2 Recibir empleado en los parametros actualizar del controlador PUT Actualizar()
            // 3 Obtener la cadena de conexion
            string cadenaConexion = configuration.GetConnectionString("EstudianteConnection");
            // 4 Crear el objeto conexion 
            using (IDbConnection db = new SqlConnection(cadenaConexion))
            {
                // 5 Crear el query

                string queryActualizar = "EXEC actualizarMateriaCursda @idMateriaCursada,@idEstudiante,@clave,@materia,@caliPrimerP,@caliSegundoP,@caliTercerP,0,@activo ";
            //    string queryMateriasCda = "EXEC consultarMateriaCursadaId @idMateriaCursada ";

                //6 Obtener lsita de parametros
                var parametros = materiaCursada.obtenerParametros();

                // 7 Ejecutar el query

                var resultadomateriasCasActual = db.Execute(queryActualizar, parametros);
              //  var resultadomateriasCas = db.QueryFirstOrDefault(queryMateriasCda, new { idMateriaCursada = materiaCursada.idMateriaCursada });

               // materiaCursada = new MateriaCursada(resultadomateriasCas);

            }

            // 6 Ejecutar el query

            return materiaCursada;
        }


//////////////METODOS MATERIAS CURSANDO


        // METODO OBTENER MATERIAS CURSADAS
        public List<MateriaCursando> obtenerMateriasCursando()
        {
            // Inicio
            //1 Creamos la lista donde guardaremos los datos
            List<MateriaCursando> materiasMostrar = new List<MateriaCursando>();
            //2 Creamos la cadena de conexion             
            string cadenaConexion = configuration.GetConnectionString("EstudianteConnection");
            //3 Hacemos la conexion a la base datos    
            using (IDbConnection db = new SqlConnection(cadenaConexion))
            {
                string queryMateriasCdas = "EXEC consultarMateriasCursando";

                //4 se hace la consulta y la guardamos en la lista empleados
                var resultadomateriasCando = db.Query<MateriaCursando>(queryMateriasCdas).ToList();

                resultadomateriasCando.ToList();
                foreach (var elementoE in resultadomateriasCando)
                {
                    MateriaCursando materia = new MateriaCursando(elementoE);
                    // Models.Empleado empleado = Models.Empleado.cargarDatos(elementoE);
                    materiasMostrar.Add(materia);
                }


            }
            return materiasMostrar;
        }

        //////

        // METODO OBTENER MATERIAS CURSADAS POR ID
        public MateriaCursando encontrarMateriaCursando(int pIdMateria)
        {
            //1 Recibir id Empleado
            MateriaCursando materiaCursando = null;
            //2 Obtener la cadena de conexion 
            string cadenaConexion = configuration.GetConnectionString("EstudianteConnection");
            // 3 Crear la conexion 
            using (IDbConnection db = new SqlConnection(cadenaConexion))
            {
                //4 Hacer la consulta
                string queryMateriaCursada = " EXEC consultarMateriaCursandoId @idMateriaCursando";


                // 5 Ejecuta consulta
                var resultadoMateriaCndo = db.QueryFirstOrDefault(queryMateriaCursada, new { idMateriaCursando = pIdMateria });


                if (resultadoMateriaCndo.Count() == 0)
                {
                    materiaCursando = null;
                    //6 Si la consulta es null es que no existe en la base
                }
                else
                {
                    //7 Si es existe devolver el empleado para que sea pintado en el front
                    materiaCursando = new MateriaCursando(resultadoMateriaCndo);
                }
            }
            return materiaCursando;

        }
        /////////



        //////METODO CREAR MATERIA CURSADA

        public MateriaCursando crearMateriaCursando(MateriaCursando materiaCursando)
        {
            int idMateriaCursando = 0;
            // 1 Inicio
            // 2 Obtener la cadena de conexion
            string cadenaConexion = configuration.GetConnectionString("EstudianteConnection");
            // 3 Crear la conexion 
            using (IDbConnection db = new SqlConnection(cadenaConexion))
            {
                // 4 Crear el query para insertar
                string query = "EXEC insertarMateriaCursando @idEstudiante,@clave,@materia,@horario,@caliPrimerP,@caliSegundoP,@caliTercerP,@activo";


                object parametros = new
                {

                    idEstudiante = materiaCursando.idEstudiante,
                    clave = materiaCursando.clave,
                    materia = materiaCursando.materia,
                    caliPrimerP = materiaCursando.caliPrimerP,
                    caliSegundoP = materiaCursando.caliSegundoP,
                    caliTercerP = materiaCursando.caliTercerP,
                    horario = materiaCursando.horario,
                    activo = materiaCursando.activo


                };

                // 5 Ejecutar la consulta
                idMateriaCursando = db.QueryFirstOrDefault<int>(query, parametros);
                materiaCursando.idMateriaCursando = idMateriaCursando;

            }

            // 8 Retornar empleado
            return materiaCursando;
        }


        //////////

        // METODO ACTUALIZAR MATERIA CURSANDO
        public MateriaCursando actualizarMateriaCursando(MateriaCursando materiaCursando)
        {

            // 1 Inicio
            // 2 Recibir empleado en los parametros actualizar del controlador PUT Actualizar()
            // 3 Obtener la cadena de conexion
            string cadenaConexion = configuration.GetConnectionString("EstudianteConnection");
            // 4 Crear el objeto conexion 
            using (IDbConnection db = new SqlConnection(cadenaConexion))
            {
                // 5 Crear el query

                string queryActualizar = "EXEC actualizarMateriaCursando @idMateriaCursando,@idEstudiante,@clave,@materia,@horario,@caliPrimerP,@caliSegundoP,@caliTercerP,@activo";
            //    string queryMateriasCda = "EXEC consultarMateriaCursadaId @idMateriaCursada ";

                //6 Obtener lsita de parametros
                var parametros = materiaCursando.obtenerParametros();

                // 7 Ejecutar el query

                var resultadomateriasCasActual = db.Execute(queryActualizar, parametros);
              //  var resultadomateriasCas = db.QueryFirstOrDefault(queryMateriasCda, new { idMateriaCursada = materiaCursada.idMateriaCursada });

               // materiaCursada = new MateriaCursada(resultadomateriasCas);

            }

            // 6 Ejecutar el query

            return materiaCursando;
        }
        

    }

}