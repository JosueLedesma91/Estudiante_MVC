 //ESTA FUNCION SE USA CUANDO VAMOS A EDITAR y CONSULTAR
    function cargarEnpantalla() {
        //1 Iniciar

        //2 Obtener id empleado
       
        //  meter consulta para ver si el idEstudiante esta en la base de las materias

        var requestOptions = {
            method: 'GET',
            redirect: 'follow'
        };

        fetch("https://localhost:5003/MateriasCursadas/" + idmateriasCdas, requestOptions)
            .then(response => response.json())
            .then(materiaCursada => {

                    accion2 = 3;
                    console.log(accion2);
                    
                    const idEstudianteMatCda = document.getElementById("idEstudianteMatCda");
                    const clave = document.getElementById("claveMatCda");
                    const materia = document.getElementById("materiaCda");
                    const caliPrimerPMCda = document.getElementById("caliPrimerPMCda");
                    const caliSegundoPMCda = document.getElementById("caliSegundoPMCda");
                    const caliTercerPMCda = document.getElementById("caliTercerPMCda");
                   
                    //3.3 - Pintar las propiedades en los elementos html
                    idEstudianteMatCda.value = estudiante.nombre;
                    clave.value = estudiante.apellidoPaterno;
                    materia.value = estudiante.apellidoMaterno;
                    caliPrimerPMCda.value = estudiante.sexo;
                    caliSegundoPMCda.value = estudiante.curp;
                    caliTercerPMCda.value = obtenerFecha(estudiante.fechaNacimiento);
                  



            })
            .catch(error => console.log('error', error));

        //3- Consumir el  servicio de obtener empleado por id

    }