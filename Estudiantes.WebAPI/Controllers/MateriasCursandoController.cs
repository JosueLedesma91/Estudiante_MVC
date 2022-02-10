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
    public class MateriasCursandoController : ControllerBase
    {
       
        private readonly ILogger<MateriasCursandoController> _logger;

        private readonly IConfiguration configuration;
        private readonly EstudianteDA estudianteDA;
        public MateriasCursandoController(ILogger<MateriasCursandoController> logger,
        IConfiguration config)
        {
            _logger = logger;
            configuration = config;
            this.estudianteDA = new EstudianteDA(configuration);
        }

       ///METODO GET PARA OBTNER UNA LISTA LAS MATERIAS CURSADAS

         [HttpGet]
    public async Task<ActionResult<IEnumerable<MateriaCursando>>> ObtenerMateriasCursadas()
        {
            //1 Inicio 
            // 2 Creamos una lista de tipo estudiante 
            // y Buscamos alumnos activos en la base de datos
            List<MateriaCursando> listaMateriasActivos = estudianteDA.obtenerMateriasCursando();

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
        public async Task<ActionResult<MateriaCursando>> obtenerMateria(int idMateria)
        {
            
            MateriaCursando materiaEncontrada = estudianteDA.encontrarMateriaCursando(idMateria);

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
        public MateriaCursando Crear(MateriaCursando materiaCursando)
        {

            // 1 Inicio
            // 2 Recibimos el parametro     
            // 3 Activar el empleado 
            materiaCursando.activo = true;
            //Crear el empleado de la clase EmpleadoDA = empleadoDA

            estudianteDA.crearMateriaCursando(materiaCursando);

            // Insertar el empreado

            return materiaCursando;

        }

/////////////////
   
   /////////////////

    // CONTROLADOR DE ACTUALIZAR MATERIA CURSADA
        [HttpPut]
        // 2 Recibir el objeto empleado guardado en el front por el formulario (el parametro)
        public async Task<ActionResult<MateriaCursando>> Actualizar(MateriaCursando materiaCursando)
        {

            // 1 Inicio
            // 3 Se crea un objeto Empleado para guardar el empleado a modificar y se
            //Busca el empleado por id en la base de datos por medio del metodo en la clase Empleado DA
            MateriaCursando materiaModificar = estudianteDA.encontrarMateriaCursando(materiaCursando.idMateriaCursando);
            // 4 Si el empleado no existe,
            if (materiaModificar == null)
            {
                // 4.1 Regesar un NotFound (404)
                return NotFound();
            }
            else
            { // 5 Si esta en la base, asignar los valores del estudiante recibido en los parametros
              // al empleado que se creo "materiaModificar"
                materiaModificar.idMateriaCursando = materiaCursando.idMateriaCursando;
                materiaModificar.idEstudiante = materiaCursando.idEstudiante;
                materiaModificar.clave = materiaCursando.clave;
                materiaModificar.materia = materiaCursando.materia;
                materiaModificar.horario = materiaCursando.horario;
                materiaModificar.caliPrimerP = materiaCursando.caliPrimerP;
                materiaModificar.caliSegundoP = materiaCursando.caliSegundoP;
                materiaModificar.caliTercerP = materiaCursando.caliTercerP;
                materiaModificar.activo = materiaCursando.activo;
 

                // 6 Mandamos el empleadoModificar como parametro al metodo del empleadoDA 
                // para que haga el query y actulalice el registro 
                estudianteDA.actualizarMateriaCursando(materiaModificar);

            }

            return materiaModificar;


        }
//////////////////////////

          // eliminar
        [HttpDelete("{idMateriaCursando}")]
        public async Task<ActionResult<MateriaCursando>> eliminar(int idMateriaCursando)
        {

            // 1 Inicio
            // 2 Recibir parametros
            // 3 Buscar el empleado en la lista de empleados con el id enviado desde la peticion,
            // se buscara con el mismo metodoya usado antes par modificar
            MateriaCursando materiaCursandoEliminar = estudianteDA.encontrarMateriaCursando(idMateriaCursando);

            if (materiaCursandoEliminar == null)
            {
                // 4 si no se encuentra el id se regresa un NotFound = (404)
                return NotFound();
            }
            else
            {
                // 5 Si el empleado fue encontrado le asiganaremos su campo Activo a False
                materiaCursandoEliminar.activo = false;
                // 5.1 Actualizmos lista con el metodo actualizar que fue usado igual en modificar
                estudianteDA.actualizarMateriaCursando(materiaCursandoEliminar);
            }

            return materiaCursandoEliminar;

        }

    }
}
