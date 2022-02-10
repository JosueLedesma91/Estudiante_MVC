/*Tabla estudiantes*/

BEGIN TRANSACTION
GO
CREATE TABLE Estudiante
	(
	idEstudiante int NOT NULL IDENTITY (1, 1),
	idPersona int NOT NULL,
	nombre varchar(50) NOT NULL,
	apellidoPaterno varchar(50) NOT NULL,
	apellidoMaterno varchar(50) NOT NULL,
	sexo char(1) NOT NULL,
	curp varchar(50) NOT NULL,
	telefono varchar(50) NOT NULL,
	correo varchar(50) NOT NULL,
	fechaNacimiento datetime NOT NULL,
	nacionalidad varchar(50) NOT NULL,
	idDireccion int NOT NULL,
	calle varchar(50) NOT NULL,
	numeroExterior varchar(50) NOT NULL,
	numeroInterior varchar(50) NOT NULL,
	colonia varchar(50) NOT NULL,
	municipio varchar(50) NOT NULL,
	estado varchar(50) NOT NULL,
	codigoPostal varchar(50) NOT NULL,
	matricula varchar(50) NOT NULL,
	carrera varchar(50) NOT NULL,
	fechaIngreso datetime NOT NULL,
	semestre varchar(50) NOT NULL,
	activo bit NOT NULL
	)  ON [PRIMARY]
GO


ALTER TABLE Estudiante ADD CONSTRAINT
	PK_Estudiante PRIMARY KEY CLUSTERED 
	(
	idEstudiante
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE Estudiante SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

INSERT INTO Estudiante ( idPersona ,nombre ,apellidoPaterno ,apellidoMaterno,sexo,curp,telefono 
           ,correo,fechaNacimiento,nacionalidad,idDireccion,calle,numeroExterior,numeroInterior
		   ,colonia,municipio,estado,codigoPostal,matricula,carrera,fechaIngreso,semestre 
           ,activo)
   VALUES ( 1,'Josue','Sanchez','Ledesma','M','LESESDFs','5741411',
           'j@hotmail.com','1991-06-28','mexicano',1,'Tanger','5','6',   
           'Valle de Aragon','Gustavo a Madero','Ciudad de Mexico','57494',
		   '201711571','Informatica','2017-06-28','9no',1)

 drop procedure crearEstudiante
EXEC crearEstudiante 4,'Angel','Carmona','Chavez','F','FERCES','5741411','j@hotmail.com','1991-06-28','mexicano',1,'Calle 12','5','6','Rio de Luz','Gustavo a Madero','Ciudad de Mexico','57494','201411571','Gestion','2017-06-28','8no',1
GO
CREATE PROC crearEstudiante
    @idPersona int  ,
	@nombre varchar(50)  ,
	@apellidoPaterno varchar(50)  ,
	@apellidoMaterno varchar(50)  ,
	/*@sexo char(1)  ,*/
	@sexo varchar(50)  ,
	@curp varchar(50)  ,
	@telefono varchar(50)  ,
	@correo varchar(50)  ,
	@fechaNacimiento datetime  ,
	@nacionalidad varchar(50)  ,
	@idDireccion int  ,
	@calle varchar(50)  ,
	@numeroExterior varchar(50)  ,
	@numeroInterior varchar(50)  ,
	@colonia varchar(50)  ,
	@municipio varchar(50)  ,
	@estado varchar(50)  ,
	@codigoPostal varchar(50)  ,
	@matricula varchar(50)  ,
	@carrera varchar(50)  ,
	@fechaIngreso datetime  ,
	@semestre varchar(50)  ,
	@activo bit 
AS
BEGIN
INSERT INTO Estudiante ( idPersona ,nombre ,apellidoPaterno ,apellidoMaterno,sexo,curp,telefono 
           ,correo,fechaNacimiento,nacionalidad,idDireccion,calle,numeroExterior,numeroInterior
		   ,colonia,municipio,estado,codigoPostal,matricula,carrera,fechaIngreso,semestre 
           ,activo)
   VALUES ( @idPersona,@nombre,@apellidoPaterno,@apellidoMaterno,@sexo,@curp,@telefono,
           @correo,@fechaNacimiento,@nacionalidad,@idDireccion,@calle,@numeroExterior,@numeroInterior,   
           @colonia,@municipio,@estado,@codigoPostal,
		   @matricula,@carrera,@fechaIngreso,@semestre,@activo)

		   SELECT  CAST(SCOPE_IDENTITY() as int) AS idEstudiante

END

GO

EXEC consultaEstudiantes

GO

CREATE Procedure consultaEstudiantes
AS
BEGIN
SELECT  idEstudiante,idPersona , nombre, apellidoPaterno,apellidoMaterno , sexo , curp
      ,telefono,correo,fechaNacimiento,nacionalidad,idDireccion , calle , numeroExterior
      ,numeroInterior,colonia, municipio,estado,codigoPostal,matricula,carrera 
      ,fechaIngreso,semestre, activo  FROM  Estudiante  WHERE activo = 1
END
GO

select * from MateriaCursada

drop Procedure obtenerEstudiante
EXEC obtenerEstudiante 1

GO
CREATE PROC obtenerEstudiante
@idEstudiante int
AS
BEGIN
SELECT  idEstudiante,idPersona , nombre, apellidoPaterno,apellidoMaterno , sexo , curp 
      ,telefono,correo,fechaNacimiento,nacionalidad,idDireccion , calle , numeroExterior 
      ,numeroInterior,colonia, municipio,estado,codigoPostal,matricula,carrera 
      ,fechaIngreso,semestre, activo  FROM  Estudiante  WHERE idEstudiante = @idEstudiante

	 
 END
GO

select * from Estudiante

EXEC actualizarEstudiante

GO
CREATE PROC actualizarEstudiante
    @idEstudiante int,
    @idPersona int  ,
	@nombre varchar(50)  ,
	@apellidoPaterno varchar(50)  ,
	@apellidoMaterno varchar(50)  ,
	/*@sexo char(1)  ,*/
	@sexo varchar(50)  ,
	@curp varchar(50)  ,
	@telefono varchar(50)  ,
	@correo varchar(50)  ,
	@fechaNacimiento datetime  ,
	@nacionalidad varchar(50)  ,
	@idDireccion int  ,
	@calle varchar(50)  ,
	@numeroExterior varchar(50)  ,
	@numeroInterior varchar(50)  ,
	@colonia varchar(50)  ,
	@municipio varchar(50)  ,
	@estado varchar(50)  ,
	@codigoPostal varchar(50)  ,
	@matricula varchar(50)  ,
	@carrera varchar(50)  ,
	@fechaIngreso datetime  ,
	@semestre varchar(50)  ,
	@activo bit 
AS
BEGIN
UPDATE Estudiante SET idPersona= @idPersona, nombre= @nombre, apellidoPaterno= @apellidoPaterno, apellidoMaterno= @apellidoMaterno,
sexo= @sexo, curp= @curp, telefono= @telefono, correo= @correo, fechaNacimiento= @fechaNacimiento, nacionalidad= @nacionalidad,
idDireccion= @idDireccion, calle= @calle, numeroExterior= @numeroExterior, numeroInterior= @numeroInterior,colonia= @colonia,
municipio= @municipio, estado=@estado, codigoPostal= @codigoPostal, matricula= @matricula, carrera= @carrera, fechaIngreso= @fechaIngreso,
semestre= @semestre, activo= @activo 
WHERE idEstudiante = @idEstudiante
 END
GO


/*Tabla MateriaCursada*/
drop table MateriaCursada
select * from MateriaCursada


BEGIN TRANSACTION
GO
CREATE TABLE MateriaCursada
	(
	idMateriaCursada int NOT NULL IDENTITY (1, 1),
	idEstudiante int NOT NULL,
	clave varchar(50) NOT NULL,
	materia varchar(50) NOT NULL,
	caliPrimerP decimal(18, 2) NOT NULL,
	caliSegundoP decimal(18, 2) NOT NULL,
	caliTercerP decimal(18, 2) NOT NULL,
	caliFinal decimal(18, 2),
	activo bit NOT NULL,
    CONSTRAINT fk_idEstudiante2 FOREIGN KEY (idEstudiante) REFERENCES Estudiante (idEstudiante)

	)  ON [PRIMARY]
GO
ALTER TABLE MateriaCursada ADD CONSTRAINT
	PK_MateriaCursada PRIMARY KEY CLUSTERED 
	(
	idMateriaCursada
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE MateriaCursada SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

select * from MateriaCursada

/*PROCEDIMIENTO PARA INSERTAR MATERIA CURSADA*/
EXEC insertarMateriaCursada 1,'481','Programacion',9,10,10,0,1
EXEC insertarMateriaCursada 1,'487','Bases de Datos',8,9,9,0,1
EXEC insertarMateriaCursada 2,'578','Contabilidad',10,9,9,0,1
EXEC insertarMateriaCursada 2,'127','Calculo Dif',10,9,9,0,1
EXEC insertarMateriaCursada 3,'578','Contabilidad',10,9,9,0,1
drop Procedure insertarMateriaCursada

GO
CREATE PROC insertarMateriaCursada

@idEstudiante int,
@clave varchar(50),
@materia varchar(50),
@caliPrimerP decimal(18, 2),
@caliSegundoP decimal(18, 2),
@caliTercerP decimal(18, 2),
@caliFinal decimal(18, 2),
@activo bit
AS
begin
SET @caliFinal=(@caliPrimerP+@caliSegundoP+@caliTercerP)/3
INSERT INTO  MateriaCursada (idEstudiante,clave,materia,caliPrimerP,caliSegundoP,caliTercerP,caliFinal,activo )
     VALUES(@idEstudiante,@clave,@materia,@caliPrimerP,@caliSegundoP,@caliTercerP,@caliFinal,@activo)
	
	 SELECT  CAST(SCOPE_IDENTITY() as int) AS idMateriaCursada

END
GO

/*PROCEDIMIENTO PARA CONSULTAR MATERIA POR ID DE MATERIA*/
drop Procedure consultarMateriaCursadaId

EXEC consultarMateriaCursadaId 3 
select * from MateriaCursada

GO
CREATE PROC consultarMateriaCursadaId
@idMateriaCursada int
AS
BEGIN
SELECT idMateriaCursada 
      ,idEstudiante 
      ,clave 
      ,materia 
      ,caliPrimerP 
      ,caliSegundoP 
      ,caliTercerP 
      ,caliFinal 
      ,activo 
  FROM  MateriaCursada 
  WHERE activo = 1 and idMateriaCursada = @idMateriaCursada 
  END
GO

/*PROCEDIMIENTO PARA CONSULTAR MATERIA POR ID de ESTUDIANTE*/
drop Procedure consultarMateriaCursada

EXEC obtenerEstudiante 1

EXEC consultarMateriaCursada 1 

GO
CREATE PROC consultarMateriaCursada
@idEstudiante int
AS
BEGIN
SELECT m.idMateriaCursada 
      ,m.idEstudiante 
      ,m.clave 
      ,m.materia 
      ,m.caliPrimerP 
      ,m.caliSegundoP 
      ,m.caliTercerP 
      ,m.caliFinal 
      ,m.activo 
  FROM  MateriaCursada m  INNER JOIN Estudiante e
  ON m.idEstudiante =  e.idEstudiante 
  WHERE m.activo = 1 and m.idEstudiante = @idEstudiante
  END
GO

/*PROCEDIMIENTO PARA CONSULTAR MATERIAS CURSADAS*/
drop Procedure consultarMateriasCursadas

EXEC obtenerEstudiante 1

EXEC consultarMateriasCursadas 

GO
CREATE PROC consultarMateriasCursadas
AS
BEGIN
SELECT idMateriaCursada 
       ,idEstudiante 
       ,clave 
       ,materia 
      ,caliPrimerP 
      ,caliSegundoP 
      ,caliTercerP 
      ,caliFinal 
      ,activo 
  FROM  MateriaCursada   WHERE activo = 1 

  END
GO

/*PROCEDIMIENTO PARA ACTUALIZAR MATERIA CURSADA*/
EXEC actualizarMateriaCursda 5,3,'205','Algebra Lineal',8,8,8,0,1

EXEC consultarMateriasCursadas 
DROP PROCEDURE actualizarMateriaCursda
GO
CREATE PROC actualizarMateriaCursda
    @idMateriaCursada int ,
	@idEstudiante int ,
	@clave varchar(50) ,
	@materia varchar(50) ,
	@caliPrimerP decimal(18, 2) ,
	@caliSegundoP decimal(18, 2) ,
	@caliTercerP decimal(18, 2) ,
	@caliFinal decimal(18, 2),
	@activo bit 
AS
BEGIN
SET @caliFinal=(@caliPrimerP+@caliSegundoP+@caliTercerP)/3
UPDATE MateriaCursada SET idEstudiante= @idEstudiante, clave= @clave, materia= @materia, caliPrimerP= @caliPrimerP,
caliSegundoP= @caliSegundoP, caliTercerP= @caliTercerP, caliFinal= @caliFinal, activo= @activo
WHERE idMateriaCursada = @idMateriaCursada

 END
GO


   
