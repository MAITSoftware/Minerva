-- Base de datos Minerva
drop database if exists `Minerva`;
create database `Minerva`;
use `Minerva`;

-- Usuario minerva
DROP USER IF EXISTS 'minerva'@'localhost';
CREATE USER 'minerva'@'localhost' IDENTIFIED BY 'minerva';
GRANT ALL PRIVILEGES ON Minerva.* TO 'minerva'@'localhost' WITH GRANT OPTION;

-- PERSONA (CiPersona)
create table `Persona` (
  `CiPersona` INT(8) NOT NULL,
  PRIMARY KEY (`CiPersona`)
);

-- USUARIO (CiPersona, TipoUsuario, ContraseñaUsuario, AprobacionUsuario)
create table `Usuario` (
  `CiPersona` INT(8) NOT NULL,
  `TipoUsuario` VARCHAR(15) NOT NULL,
  `ContraseñaUsuario` VARCHAR(25) NOT NULL,
  `AprobacionUsuario` BOOLEAN NOT NULL,
  FOREIGN KEY (`CiPersona`) REFERENCES Persona(`CiPersona`),
  PRIMARY KEY (`CiPersona`)
);

-- PROFESOR (CiPersona, CargoProfesor, NombreProfesor, ApellidoProfesor)
create table `Profesor` (
  `CiPersona` INT(8) NOT NULL,
  `GradoProfesor` INT(2) NOT NULL,
  `NombreProfesor` VARCHAR(25) NOT NULL,
  `ApellidoProfesor` VARCHAR(25) NOT NULL,
  FOREIGN KEY (`CiPersona`) REFERENCES Persona(`CiPersona`),
  PRIMARY KEY (`CiPersona`)
);

-- SALON (IdSalon, ComentariosSalon, PlantaSalon)
create table `Salon` (
  `IDSalon` INTEGER NOT NULL,
  `PlantaSalon` VARCHAR(15) NOT NULL,
  `Comentarios` TEXT,
  PRIMARY KEY (`IDSalon`)
);

-- TURNO (IdTurno, NombreTurno, HoraInicio, DuracionHora)
create table `Turno` (
  `IDTurno` INTEGER NOT NULL,
  `NombreTurno` VARCHAR(25) NOT NULL,
  `HoraInicio` TIME NOT NULL,
  `DuracionHora` TIME NOT NULL,
  PRIMARY KEY (`IDTurno`)
);

-- CURSO (IdCurso, NombreCurso)
create table `Curso` (
  `IDCurso` INTEGER NOT NULL,
  `NombreCurso` VARCHAR(25) NOT NULL,
  PRIMARY KEY (`IDCurso`)
);
  
-- ORIENTACION (IdOrientacion, NombreOrientacion, IdCurso)
create table `Orientacion` (
  `IDOrientacion` INTEGER NOT NULL,
  `NombreOrientacion` VARCHAR(25) NOT NULL,
  `IDCurso` INTEGER NOT NULL,
  FOREIGN KEY (`IDCurso`) REFERENCES Curso(`IDCurso`),
  PRIMARY KEY (`IDOrientacion`)
);

-- AREA (IdArea, NombreArea, IdOrientacion)
create table `Area` (
  `IDArea` INTEGER NOT NULL,
  `NombreArea` VARCHAR(25) NOT NULL,
  `IDOrientacion` INTEGER NOT NULL,
  FOREIGN KEY (`IDOrientacion`) REFERENCES Orientacion(`IDOrientacion`),
  PRIMARY KEY (`IDArea`)
);

-- ASIGNATURA (IdAsignatura, NombreAsignatura, IdArea)
create table `Asignatura` (
  `IDAsignatura` INTEGER NOT NULL,
  `NombreAsignatura` VARCHAR(25) NOT NULL,
  `IDArea` INTEGER NOT NULL,
  FOREIGN KEY (`IDArea`) REFERENCES Area(`IDArea`),
  PRIMARY KEY (`IDAsignatura`, `IDArea`)
);

-- TRAYECTO (IdTrayecto, IdOrientacion)
create table `Trayecto` (
  `IDTrayecto` INTEGER NOT NULL,
  `IDOrientacion` INTEGER NOT NULL,
  FOREIGN KEY (`IDOrientacion`) REFERENCES Orientacion(`IDOrientacion`),
  PRIMARY KEY (`IDTrayecto`, `IDOrientacion`)
);

-- GRUPO (IdGrupo, Discapacitado, IdSalon, IdTrayecto, IdTurno)
create table `Grupo` (
  `IDGrupo` VARCHAR(10) NOT NULL,
  `Discapacitado` BOOLEAN NOT NULL,
  `IDSalon` INTEGER NOT NULL,
  `IDTrayecto` INTEGER NOT NULL,
  `IDTurno` INTEGER NOT NULL,

  `IDOrientacion` INTEGER NOT NULL, -- Error conocido: Buscar alguna forma de poder arrastrar Orientacion.IDOrientacion (en el mer)
  `IDCurso` INTEGER NOT NULL, -- Error conocido: Buscar alguna forma de poder arrastrar Orientacion, para poder sacar el id del curso desde la misma tabla

  FOREIGN KEY (`IDSalon`) REFERENCES Salon(`IDSalon`),
  FOREIGN KEY (`IDTrayecto`) REFERENCES Trayecto(`IDTrayecto`),
  FOREIGN KEY (`IDTurno`) REFERENCES Turno(`IDTurno`),
  FOREIGN KEY (`IDOrientacion`) REFERENCES Orientacion(`IDOrientacion`),
  FOREIGN KEY (`IDCurso`) REFERENCES Orientacion(`IDCurso`),
  PRIMARY KEY (`IDGrupo`, `IDSalon`, `IDTrayecto`, `IDTurno`)
);

-- ASIGNATURASTOMADAS (CiPersona, IdAsignatura, IdGrupo, cargaHoraria)
create table `AsignaturasTomadas` (
  `CiPersona` INT(8) NOT NULL,
  `IDAsignatura` INTEGER NOT NULL,
  `IDTrayecto` INTEGER NOT NULL,
  `IDGrupo` VARCHAR(10) NOT NULL,
  `cargaHoraria` INTEGER NOT NULL,
  `fechaAsignacion` DATE NOT NULL,
  FOREIGN KEY (`CiPersona`) REFERENCES Profesor(`CiPersona`),
  FOREIGN KEY (`IDAsignatura`) REFERENCES Asignatura(`IDAsignatura`),
  FOREIGN KEY (`IDTrayecto`) REFERENCES Grupo(`IDTrayecto`),
  FOREIGN KEY (`IDGrupo`) REFERENCES Grupo(`IDGrupo`),
  PRIMARY KEY (`CiPersona`, `IDAsignatura`, `IDTrayecto`, `IDGrupo`)
);
-- CALENDARIO (Horario, CiPersona, IdAsignatura, IdGrupo)
create table `Calendario` (
  `Horario` TIME NOT NULL,
  `CiPersona` INT(8) NOT NULL,
  `IDAsignatura` INTEGER NOT NULL,
  `IDGrupo` VARCHAR(10) NOT NULL,
  FOREIGN KEY (`CiPersona`) REFERENCES Profesor(`CiPersona`),
  FOREIGN KEY (`IDAsignatura`) REFERENCES Asignatura(`IDAsignatura`),
  FOREIGN KEY (`IDGrupo`) REFERENCES Grupo(`IDGrupo`),
  PRIMARY KEY (`Horario`, `CiPersona`, `IDAsignatura`, `IDGrupo`)
);

-- Datos pre-cargados --

-- Curso 1: EMT
-- Curso 2: CBT
INSERT INTO `Curso` VALUES (1, "EMT"), (2, "CBT"); 

-- Orientación 123 del Curso 1: Informática
-- Orientación 321 del Curso 1: Administración
-- Orientación 981 del Curso 2: Ciclo Básico
INSERT INTO `Orientacion` VALUES (123, "Informática", 1), (321, "Administración", 1), (981, "Ciclo Básico", 2);

-- Trayectos de prueba: Solo para que el programa funcione
INSERT INTO `Trayecto` VALUES (
1, 123), (2, 123), (3, 123), (4, 123), (
1, 321), (2, 321), (3, 321), (4, 321), (
1, 981), (2, 981), (3, 981), (4, 981);

-- Área 150 de la orientación 123: Pack 1
-- Área 151 de la orientación 123: Pack 2
-- Área 152 de la orientación 321: Pack 3
-- Área 153 de la orientación 981: Pack 4
INSERT INTO `Area` VALUES (150, "Pack 1", 123), (151, "Pack 2", 123), (152, "Pack 3", 321), (153, "Pack 4", 981);

-- Materia 1 de el área 150: Programación
-- Materia 2 de el área 150: Base de datos
-- Materia 3 de el área 151: Biología
-- Materia 4 de el área 152: Historia
-- Materia 5 de el área 153: Geografía
INSERT INTO `Asignatura` VALUES (1, "Programación", 150), (2, "Base de datos", 150), (3, "Biología", 151), (4, "Historia", 152), (5, "Geografía", 153);

-- Turno 1 al 5.
-- Todos inician a la misma hora, solo para probar.
INSERT INTO `Turno` VALUES (1, "Turno 1", "13:00", "00:45"), (2, "Turno 2", "13:00", "00:45"), (3, "Turno 3", "13:00", "00:45"), (4, "Turno 4", "13:00", "00:45"), (5, "Turno 5", "13:00", "00:45");

-- Salón negativo == Salón que indica que no tiene salón asignado
INSERT INTO `Salon` VALUES (-1, "", "");

