
/*Tabla MateriasCursado*/

drop table MateriaCursando
select * from MateriaCursando
drop Procedure insertarMateriaCursando

BEGIN TRANSACTION
GO
CREATE TABLE MateriaCursando
	(
	idMateriaCursando int NOT NULL IDENTITY (1, 1),
	idEstudiante int NOT NULL,
	clave varchar(50) NOT NULL,
	materia varchar(50) NOT NULL,
	horario varchar(50) NOT NULL,
	caliPrimerP decimal(18, 2) NOT NULL,
	caliSegundoP decimal(18, 2) NOT NULL,
	caliTercerP decimal(18, 2) NOT NULL,
	activo bit NOT NULL
	CONSTRAINT fk_idEstudiante2 FOREIGN KEY (idEstudiante) REFERENCES Estudiante (idEstudiante)
	)  ON [PRIMARY]
GO
ALTER TABLE MateriaCursando ADD CONSTRAINT
	PK_MateriaCursando PRIMARY KEY CLUSTERED 
	(
	idMateriaCursando
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE MateriaCursando SET (LOCK_ESCALATION = TABLE)

GO
COMMIT

/*PROCEDIMIENTO PARA CONSULTAR MATERIAS CURSANDO*/
drop Procedure consultarMateriasCursando

EXEC obtenerEstudiante 1

EXEC consultarMateriasCursando 

GO
CREATE PROC consultarMateriasCursando
AS
BEGIN
SELECT idMateriaCursando 
       ,idEstudiante 
       ,clave 
       ,materia 
	   ,horario
      ,caliPrimerP 
      ,caliSegundoP 
      ,caliTercerP 
      ,activo 
  FROM  MateriaCursando   WHERE activo = 1 

  END
GO


/*PROCEDIMIENTO PARA INSERTAR MATERIA CURSANDO*/
EXEC insertarMateriaCursando 1,'500','Contabilidad','8-10',9,10,10,1
EXEC insertarMateriaCursando 1,'501','Estructura de Datos','10-12',8,9,9,1
EXEC insertarMateriaCursando 2,'578','Contabilidad','10-12',10,9,9,1
EXEC insertarMateriaCursando 10,'578','Contabilidad',10,9,9,1
drop Procedure insertarMateriaCursada

GO
CREATE PROC insertarMateriaCursando

@idEstudiante int,
@clave varchar(50),
@materia varchar(50),
@horario varchar(50),
@caliPrimerP decimal(18, 2),
@caliSegundoP decimal(18, 2),
@caliTercerP decimal(18, 2),
@activo bit
AS
begin
INSERT INTO  MateriaCursando (idEstudiante,clave,materia,horario,caliPrimerP,caliSegundoP,caliTercerP,activo )
     VALUES(@idEstudiante,@clave,@materia,@horario,@caliPrimerP,@caliSegundoP,@caliTercerP,@activo)
	 
END
GO

/*PROCEDIMIENTO DE CONSUTLTAR MATERIAS CURSANDO POR ID De Estudiante*/

drop Procedure consultarMateriaCursando

EXEC obtenerEstudiante 2

EXEC consultarMateriaCursando 2 

GO
CREATE PROC consultarMateriaCursando
@idEstudiante int
AS
BEGIN
SELECT m.idMateriaCursando 
      ,m.idEstudiante 
      ,m.clave 
      ,m.materia 
	  ,m.horario
      ,m.caliPrimerP 
      ,m.caliSegundoP 
      ,m.caliTercerP 
      ,m.activo  
  FROM  MateriaCursando m  INNER JOIN Estudiante e
  ON m.idEstudiante =  e.idEstudiante 
  WHERE m.activo = 1 and m.idEstudiante = @idEstudiante
  END
GO


/*PROCEDIMIENTO PARA ACTUALIZAR MATERIA CURSANDO*/
EXEC actualizarMateriaCursando 2,1,'504','Estructura de Datos','8-10',8,10,10,0
EXEC consultarMateriasCursando 
DROP PROCEDURE actualizarMateriaCursando
GO
CREATE PROC actualizarMateriaCursando
    @idMateriaCursando int ,
	@idEstudiante int ,
	@clave varchar(50) ,
	@materia varchar(50) ,
	@horario varchar(50),
	@caliPrimerP decimal(18, 2) ,
	@caliSegundoP decimal(18, 2) ,
	@caliTercerP decimal(18, 2) ,
	@activo bit 
AS
BEGIN
UPDATE MateriaCursando SET idEstudiante= @idEstudiante, clave= @clave, materia= @materia, caliPrimerP= @caliPrimerP,
caliSegundoP= @caliSegundoP, caliTercerP= @caliTercerP, activo= @activo
WHERE idMateriaCursando = @idMateriaCursando

 END
GO



/*PROCEDIMIENTO PARA CONSULTAR MATERIA CURSANDO POR ID DE MATERIA*/
drop Procedure consultarMateriaCursandoId

EXEC consultarMateriaCursandoId 3 
select * from MateriaCursada

GO
CREATE PROC consultarMateriaCursandoId
@idMateriaCursando int
AS
BEGIN
SELECT idMateriaCursando
      ,idEstudiante 
      ,clave 
      ,materia 
	  ,horario
      ,caliPrimerP 
      ,caliSegundoP 
      ,caliTercerP 
      ,activo 
  FROM  MateriaCursando 
  WHERE activo = 1 and idMateriaCursando = @idMateriaCursando
  END
GO