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
    public class MateriasCursadasController : ControllerBase
    {
       
        private readonly ILogger<MateriasCursadasController> _logger;

        private readonly IConfiguration configuration;
        private readonly EstudianteDA estudianteDA;
        public MateriasCursadasController(ILogger<MateriasCursadasController> logger,
        IConfiguration config)
        {
            _logger = logger;
            configuration = config;
            this.estudianteDA = new EstudianteDA(configuration);
        }

       ///METODO GET PARA OBTNER UNA LISTA LAS MATERIAS CURSADAS

         [HttpGet]
    public async Task<ActionResult<IEnumerable<MateriaCursada>>> ObtenerMateriasCursadas()
        {
            //1 Inicio 
            // 2 Creamos una lista de tipo estudiante 
            // y Buscamos alumnos activos en la base de datos
            List<MateriaCursada> listaMateriasActivos = estudianteDA.obtenerMateriasCursadas();

            /// 3. Si ne la lista dvuelta por la base esta vacia            
            if (listaMateriasActivos.Count == 0)
            {
                // 4 si no se encontro un registro regresar noTfound 404
                return NotFound();
            }
            else
            {
                // 5 si Se encontro regresar la lista de empleado activos 
                return listaMateriasActivos;

            }

        }
///////////


// Metodo Obtner 1 empleado por id
        [HttpGet("{idMateria}")]
        public async Task<ActionResult<MateriaCursada>> obtenerMateria(int idMateria)
        {
            
            MateriaCursada materiaEncontrada = estudianteDA.encontrarMateriaCursada(idMateria);

            if (materiaEncontrada == null)
            {
                return NotFound();
            }
            else
            {
                return materiaEncontrada;
            }

        }

        ///////////////

        
        // CREAR REGISTRO de MATERIA CURSADA
        [HttpPost]
        public MateriaCursada Crear(MateriaCursada materiaCursada)
        {

            // 1 Inicio
            // 2 Recibimos el parametro     
            // 3 Activar el empleado 
            materiaCursada.activo = true;
            //Crear el empleado de la clase EmpleadoDA = empleadoDA

            estudianteDA.crearMateriaCursada(materiaCursada);

            // Insertar el empreado

            return materiaCursada;

        }

/////////////////
   
   /////////////////

    // CONTROLADOR DE ACTUALIZAR MATERIA CURSADA
        [HttpPut]
        // 2 Recibir el objeto empleado guardado en el front por el formulario (el parametro)
        public async Task<ActionResult<MateriaCursada>> Actualizar(MateriaCursada materiaCursada)
        {

            // 1 Inicio
            // 3 Se crea un objeto Empleado para guardar el empleado a modificar y se
            //Busca el empleado por id en la base de datos por medio del metodo en la clase Empleado DA
            MateriaCursada materiaModificar = estudianteDA.encontrarMateriaCursada(materiaCursada.idMateriaCursada);
            // 4 Si el empleado no existe,
            if (materiaModificar == null)
            {
                // 4.1 Regesar un NotFound (404)
                return NotFound();
            }
            else
            { // 5 Si esta en la base, asignar los valores del estudiante recibido en los parametros
              // al empleado que se creo "materiaModificar"
                materiaModificar.idMateriaCursada = materiaCursada.idMateriaCursada;
                materiaModificar.idEstudiante = materiaCursada.idEstudiante;
                materiaModificar.clave = materiaCursada.clave;
                materiaModificar.materia = materiaCursada.materia;
                materiaModificar.caliPrimerP = materiaCursada.caliPrimerP;
                materiaModificar.caliSegundoP = materiaCursada.caliSegundoP;
                materiaModificar.caliTercerP = materiaCursada.caliTercerP;
                materiaModificar.caliFinal = (materiaCursada.caliPrimerP+ materiaCursada.caliSegundoP+materiaCursada.caliTercerP)/3;
                materiaModificar.activo = materiaCursada.activo;
 

                // 6 Mandamos el empleadoModificar como parametro al metodo del empleadoDA 
                // para que haga el query y actulalice el registro 
                estudianteDA.actualizarMateriaCursada(materiaModificar);

            }

            return materiaModificar;


        }
//////////////////////////

          // eliminar
        [HttpDelete("{idMateriaCursada}")]
        public async Task<ActionResult<MateriaCursada>> eliminar(int idMateriaCursada)
        {

            // 1 Inicio
            // 2 Recibir parametros
            // 3 Buscar el empleado en la lista de empleados con el id enviado desde la peticion,
            // se buscara con el mismo metodoya usado antes par modificar
            MateriaCursada materiaCursadaEliminar = estudianteDA.encontrarMateriaCursada(idMateriaCursada);

            if (materiaCursadaEliminar == null)
            {
                // 4 si no se encuentra el id se regresa un NotFound = (404)
                return NotFound();
            }
            else
            {
                // 5 Si el empleado fue encontrado le asiganaremos su campo Activo a False
                materiaCursadaEliminar.activo = false;
                // 5.1 Actualizmos lista con el metodo actualizar que fue usado igual en modificar
                estudianteDA.actualizarMateriaCursada(materiaCursadaEliminar);
            }

            return materiaCursadaEliminar;

        }

    }
}
