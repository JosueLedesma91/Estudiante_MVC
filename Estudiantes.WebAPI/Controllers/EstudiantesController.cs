using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Estudiantes.WebAPI.Models;
using Estudiantes.WebAPI.DataAccess;
namespace Estudiantes.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstudiantesController : ControllerBase
    {
       
        private readonly ILogger<EstudiantesController> _logger;

        private readonly IConfiguration configuration;
        private readonly EstudianteDA estudianteDA;
        public EstudiantesController(ILogger<EstudiantesController> logger,
        IConfiguration config)
        {
            _logger = logger;
            configuration = config;
            this.estudianteDA = new EstudianteDA(configuration);
        }

// METODO OBTENE ESTUDIANTES
        [HttpGet]
    public async Task<ActionResult<IEnumerable<Estudiante>>> obtenerEstudiantes()
        {
            //1 Inicio 
            // 2 Creamos una lista de tipo estudiante 
            // y Buscamos alumnos activos en la base de datos

            List<Estudiante> listaEstudiantesActivos = estudianteDA.obtenerEstudiantes();

            /// 3. Si ne la lista dvuelta por la base esta vacia            
            if (listaEstudiantesActivos.Count == 0)
            {
                // 4 si no se encontro un registro regresar noTfound 404
                return NotFound();
            }
            else
            {
                // 5 si Se encontro regresar la lista de empleado activos 
                return listaEstudiantesActivos;

            }

        }

// Metodo Obtner 1 empleado por id
        [HttpGet("{idEstu}")]
        public async Task<ActionResult<Estudiante>> obtenerEstudiante(int idEstu)
        {
            
            Estudiante estudianteEncontrado = estudianteDA.encontrarEstudiante(idEstu);

            if (estudianteEncontrado == null)
            {
                return NotFound();
            }
            else
            {
                return estudianteEncontrado;
            }

        }
   

        // CREAR REGISTRO 
        [HttpPost]
        public Estudiante Crear(Estudiante estudiante)
        {

            // 1 Inicio
            // 2 Recibimos el parametro     
            // 3 Activar el empleado 
            estudiante.activo = true;
            //Crear el empleado de la clase EmpleadoDA = empleadoDA

            estudianteDA.Crear(estudiante);

            // Insertar el empreado

            return estudiante;

        }

/////////////////

    // CONTROLADOR DE ACTUALIZAR
        [HttpPut]
        // 2 Recibir el objeto empleado guardado en el front por el formulario (el parametro)
        public async Task<ActionResult<Estudiante>> Actualizar(Estudiante estudiante)
        {

            // 1 Inicio
            // 3 Se crea un objeto Empleado para guardar el empleado a modificar y se
            //Busca el empleado por id en la base de datos por medio del metodo en la clase Empleado DA
            Estudiante estudianteModificar = estudianteDA.encontrarEstudiante(estudiante.idEstudiante);
            // 4 Si el empleado no existe,
            if (estudianteModificar == null)
            {
                // 4.1 Regesar un NotFound (404)
                return NotFound();
            }
            else
            { // 5 Si esta en la base, asignar los valores del estudiante recibido en los parametros
              // al empleado que se creo "empleadoModificar"
                estudianteModificar.idEstudiante = estudiante.idEstudiante;
                estudianteModificar.matricula = estudiante.matricula;
                estudianteModificar.carrera = estudiante.carrera;
                estudianteModificar.fechaIngreso = estudiante.fechaIngreso;
                estudianteModificar.semestre = estudiante.semestre;
                estudianteModificar.activo = estudiante.activo;

                estudianteModificar.nombre = estudiante.nombre;
                estudianteModificar.apellidoPaterno = estudiante.apellidoPaterno;
                estudianteModificar.apellidoMaterno = estudiante.apellidoMaterno;
                estudianteModificar.sexo = estudiante.sexo;
                estudianteModificar.curp = estudiante.curp;
                estudianteModificar.telefono = estudiante.telefono;
                estudianteModificar.correo = estudiante.correo;
                estudianteModificar.fechaNacimiento = estudiante.fechaNacimiento;
                estudianteModificar.nacionalidad = estudiante.nacionalidad;

                estudianteModificar.direccion.idDireccion = estudiante.direccion.idDireccion;
                estudianteModificar.direccion.calle = estudiante.direccion.calle;
                estudianteModificar.direccion.numeroExterior = estudiante.direccion.numeroExterior;
                estudianteModificar.direccion.numeroInterior = estudiante.direccion.numeroInterior;
                estudianteModificar.direccion.colonia = estudiante.direccion.colonia;
                estudianteModificar.direccion.municipio = estudiante.direccion.municipio;
                estudianteModificar.direccion.estado = estudiante.direccion.estado;
                estudianteModificar.direccion.codigoPostal = estudiante.direccion.codigoPostal;

                // 6 Mandamos el empleadoModificar como parametro al metodo del empleadoDA 
                // para que haga el query y actulalice el registro 
                estudianteDA.Actualizar(estudianteModificar);

            }

            return estudianteModificar;


        }


          // eliminar
        [HttpDelete("{idEstudiante}")]
        public async Task<ActionResult<Estudiante>> eliminar(int idEstudiante)
        {

            // 1 Inicio
            // 2 Recibir parametros
            // 3 Buscar el empleado en la lista de empleados con el id enviado desde la peticion,
            // se buscara con el mismo metodoya usado antes par modificar
            Estudiante estudianteEliminar = estudianteDA.encontrarEstudiante(idEstudiante);

            if (estudianteEliminar == null)
            {
                // 4 si no se encuentra el id se regresa un NotFound = (404)
                return NotFound();
            }
            else
            {
                // 5 Si el empleado fue encontrado le asiganaremos su campo Activo a False
                estudianteEliminar.activo = false;
                // 5.1 Actualizmos lista con el metodo actualizar que fue usado igual en modificar
                estudianteDA.Actualizar(estudianteEliminar);
            }

            return estudianteEliminar;

        }
   
    }
}
