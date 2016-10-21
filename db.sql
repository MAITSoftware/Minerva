drop database if exists `Minerva`;
create database `Minerva`;
use `Minerva`;
 
 
create table `Persona` (
  `CiPersona` INT(8) NOT NULL,
  `NombrePersona` VARCHAR(25),
  `ApellidoPersona` VARCHAR(25),
  PRIMARY KEY (`CiPersona`)
);
 
create table `Usuario` (
  `CiPersona` INT(8) NOT NULL,
  `NombrePersona` VARCHAR(25),
  `ApellidoPersona` VARCHAR(25),
  `TipoUsuario` VARCHAR(13) NOT NULL,
  `ContraseñaUsuario` VARCHAR(25) NOT NULL,
  `AprobacionUsuario` BOOLEAN NOT NULL,
  FOREIGN KEY (`CiPersona`) REFERENCES Persona(`CiPersona`),
  PRIMARY KEY (`CiPersona`)
);
 
create table `Profesor` (
  `CiPersona` INT(8) NOT NULL,
  `NombrePersona` VARCHAR(25) NOT NULL,
  `ApellidoPersona` VARCHAR(25) NOT NULL,
  `GradoProfesor` INT(3) NOT NULL,
  FOREIGN KEY (`CiPersona`) REFERENCES Persona(`CiPersona`),
  PRIMARY KEY (`CiPersona`)
);
 
create table `Curso` (
  `IdCurso` INT(4) NOT NULL,
  `NombreCurso` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`IdCurso`)
);
 
create table `Orientacion` (
  `IdOrientacion` INT(4) NOT NULL,
  `NombreOrientacion` VARCHAR(30) NOT NULL,
  `IdCurso` INT(4) NOT NULL,
  FOREIGN KEY (`IdCurso`) REFERENCES Curso(`IdCurso`),
  PRIMARY KEY (`IdOrientacion`)
);
 
create table `Trayecto` (
  `Grado` INT(2) NOT NULL,
  `IdOrientacion` INT(4) NOT NULL,
  `Modulo` INT(2) NOT NULL,
  FOREIGN KEY (`IdOrientacion`) REFERENCES Orientacion(`IdOrientacion`),
  PRIMARY KEY (`Grado`, `IdOrientacion`)
);
 
create table `Salon` (
  `IdSalon` INT(2) NOT NULL,
  `ComentariosSalon` TEXT,
  `PlantaSalon` VARCHAR(15) NOT NULL,
  PRIMARY KEY (`IDSalon`)
);
 
create table `Turno` (
  `IdTurno` INT(2) NOT NULL,
  `NombreTurno` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`IdTurno`)
);
 
create table `Grupo` (
  `IdGrupo` VARCHAR(4) NOT NULL,
  `Discapacitado` BOOLEAN NOT NULL,
  `Grado` INT(2) NOT NULL,
  `IdOrientacion` INT(4) NOT NULL,
  `IdSalon` INT(2) NOT NULL,
  `IdTurno` INT(2) NOT NULL,
  FOREIGN KEY (`Grado`) REFERENCES Trayecto(`Grado`),
  FOREIGN KEY (`IdOrientacion`) REFERENCES Orientacion(`IdOrientacion`),
  FOREIGN KEY (`IdSalon`) REFERENCES Salon(`IdSalon`),
  FOREIGN KEY (`IdTurno`) REFERENCES Turno(`IdTurno`),
  PRIMARY KEY (`IdGrupo`, `Grado`, `IdOrientacion`)
);
 
create table `Area` (
  `IdArea` INT(4) NOT NULL,
  `NombreArea` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`IdArea`)
);
 
create table `Asignatura` (
  `IdAsignatura` INT(4) NOT NULL,
  `NombreAsignatura` VARCHAR(25) NOT NULL,
  `IdArea` INT(4) NOT NULL,
  FOREIGN KEY (`IdArea`) REFERENCES Area(`IdArea`),
  PRIMARY KEY (`IdAsignatura`)
);
 
create table `Asignacion` (
  `HoraInicio` TIME NOT NULL,
  `HoraFin` TIME NOT NULL,
  `Dia` VARCHAR(10) NOT NULL,
  `IdTurno` INT(2) NOT NULL,
  INDEX(`Dia`),
  INDEX(`HoraInicio`),
  INDEX( `HoraFin`),
  FOREIGN KEY (`IdTurno`) REFERENCES Turno(`IdTurno`),
  PRIMARY KEY (`HoraInicio`, `HoraFin`, `Dia`, `IdTurno`)
);
 
create table `Genera` (
  `HoraInicio` TIME NOT NULL,
  `HoraFin` TIME NOT NULL,
  `Dia` VARCHAR(10) NOT NULL,
  `Grado` INT(2) NOT NULL,
  `IdAsignatura` INT(4) NOT NULL,
  `IdGrupo` VARCHAR(4) NOT NULL,
  `IdOrientacion` INT(4) NOT NULL,
  `CiPersona` INT(8) NOT NULL,
  FOREIGN KEY (`HoraFin`) REFERENCES Asignacion(`HoraFin`),
  FOREIGN KEY (`HoraInicio`) REFERENCES Asignacion(`HoraInicio`),
  FOREIGN KEY (`Dia`) REFERENCES Asignacion(`Dia`),
  FOREIGN KEY (`Grado`) REFERENCES Trayecto(`Grado`),
  FOREIGN KEY (`IdAsignatura`) REFERENCES Asignatura(`IdAsignatura`),
  FOREIGN KEY (`IdGrupo`) REFERENCES Grupo(`IdGrupo`),
  FOREIGN KEY (`IdOrientacion`) REFERENCES Orientacion(`IdOrientacion`),
  FOREIGN KEY (`CiPersona`) REFERENCES Persona(`CiPersona`), -- Podría ser foranea a Profesor(CiPersona) e igual funcionaría.
  PRIMARY KEY (`HoraInicio`, `HoraFin`, `Dia`, `IdAsignatura`, `IdGrupo`, `IdOrientacion`, `CiPersona`, `Grado`)
);
 
create table `Tiene_Ag` (
  `IdAsignatura` INT(4) NOT NULL,
  `IdGrupo` VARCHAR(4) NOT NULL,
  `Grado` INT(2) NOT NULL,
  `IdOrientacion` INT(4) NOT NULL,
  `CiPersona` INT(8) NOT NULL,
  `FechaToma` DATE NOT NULL,
  `GradoAreaProfesor` INT(2) NOT NULL,
  FOREIGN KEY (`IdAsignatura`) REFERENCES Asignatura(`IdAsignatura`),
  FOREIGN KEY (`IdGrupo`) REFERENCES Grupo(`IdGrupo`),
  FOREIGN KEY (`Grado`) REFERENCES Trayecto(`Grado`),
  FOREIGN KEY (`IdOrientacion`) REFERENCES Orientacion(`IdOrientacion`),
  FOREIGN KEY (`CiPersona`) REFERENCES Persona(`CiPersona`), -- Podría ser foranea a Profesor(CiPersona) e igual funcionaría.
  PRIMARY KEY (`IdAsignatura`, `IdGrupo`, `Grado`, `IdOrientacion`, `CiPersona`)
);
 
 create view AsignaturasTomadas AS select IdAsignatura, IdGrupo, Grado from Tiene_Ag;
 
create table `Tiene_Ta` (
  `IdAsignatura` INT(4) NOT NULL,
  `Grado` INT(2) NOT NULL,
  `IdOrientacion` INT(4) NOT NULL,
  FOREIGN KEY (`IdAsignatura`) REFERENCES Asignatura(`IdAsignatura`),
  FOREIGN KEY (`Grado`) REFERENCES Trayecto(`Grado`),
  FOREIGN KEY (`IdOrientacion`) REFERENCES Orientacion(`IdOrientacion`),
  PRIMARY KEY (`IdAsignatura`, `Grado`, `IdOrientacion`)
);

-- Datos pre-cargados

INSERT INTO `Curso` VALUES (1, "EMT"), (2, "CBT"); 
INSERT INTO `Orientacion` VALUES
(123, "Informática", 1),
(321, "Administración", 1),
(981, "Ciclo Básico", 2);
INSERT INTO `Trayecto` VALUES (
 1, 123, 0), (2, 123, 0), (3, 123, 0), (4, 123, 0), (
 1, 321, 0), (2, 321, 0), (3, 321, 0), (4, 321, 0), (
 1, 981, 0), (2, 981, 0), (3, 981, 0), (4, 981, 0);
 INSERT INTO `Area` VALUES (150, "Pack 1"), (151, "Pack 2");
INSERT INTO `Asignatura` VALUES (
111, "Biología", 150), (232, "Coso", 150), (333, "BlaBla", 151);
 INSERT INTO `Turno` VALUES (1, "Turno 1"), (2, "Vespertino"), (3, "Turno 3"), (4, "Turno 4"), (5, "Turno 5");
 INSERT INTO `Salon` VALUES (-1, "", "");
 INSERT INTO `Asignacion` 
VALUES
('13:00', '13:45', 'Lunes', 2), ('13:50', '14:35', 'Lunes', 2), ('14:40', '15:25', 'Lunes', 2), ('15:30', '16:15', 'Lunes', 2), ('16:20', '17:05', 'Lunes', 2), ('17:10', '17:55', 'Lunes', 2), ('18:00', '18:45', 'Lunes', 2), ('13:00', '13:45', 'Martes', 2), ('13:50', '14:35', 'Martes', 2), ('14:40', '15:25', 'Martes', 2), ('15:30', '16:15', 'Martes', 2), ('16:20', '17:05', 'Martes', 2), ('17:10', '17:55', 'Martes', 2), ('18:00', '18:45', 'Martes', 2),
('13:00', '13:45', 'Miércoles', 2), ('13:50', '14:35', 'Miércoles', 2), ('14:40', '15:25', 'Miércoles', 2), ('15:30', '16:15', 'Miércoles', 2), ('16:20', '17:05', 'Miércoles', 2), ('17:10', '17:55', 'Miércoles', 2), ('18:00', '18:45', 'Miércoles', 2),
('13:00', '13:45', 'Jueves', 2), ('13:50', '14:35', 'Jueves', 2), ('14:40', '15:25', 'Jueves', 2), ('15:30', '16:15', 'Jueves', 2), ('16:20', '17:05', 'Jueves', 2), ('17:10', '17:55', 'Jueves', 2), ('18:00', '18:45', 'Jueves', 2), 
('13:00', '13:45', 'Viernes', 2), ('13:50', '14:35', 'Viernes', 2), ('14:40', '15:25', 'Viernes', 2), ('15:30', '16:15', 'Viernes', 2), ('16:20', '17:05', 'Viernes', 2), ('17:10', '17:55', 'Viernes', 2), ('18:00', '18:45', 'Viernes', 2),
('13:00', '13:45', 'Sábado', 2), ('13:50', '14:35', 'Sábado', 2), ('14:40', '15:25', 'Sábado', 2), ('15:30', '16:15', 'Sábado', 2), ('16:20', '17:05', 'Sábado', 2), ('17:10', '17:55', 'Sábado', 2), ('18:00', '18:45', 'Sábado', 2)
;


-- Datos de prueba. 3ero BG.
INSERT INTO `Persona` VALUES (1, "ro", "ot");
INSERT INTO `Usuario` VALUES (1, "ro", "ot", "Administrador", "1", True);
INSERT INTO `Salon` VALUES (17, "", "Exterior");
INSERT INTO `Grupo` VALUES ("BG", False, 3, 123, 17, 2);
INSERT INTO `Area` VALUES 
(1, "Informática");

INSERT INTO `Asignatura` VALUES 
(1, "ADA", 1),
(2, "Base de datos", 1),
(3, "Inglés", 1),
(4, "Matemática", 1),
(5, "Sistemas Operativos", 1),
(6, "Programación", 1),
(7, "Sociología", 1),
(8, "Filosofía", 1),
(9, "Taller", 1),
(10, "Proyecto", 1),
(11, "F. Empresarial", 1);

INSERT INTO `Persona` VALUES (12345678, "Profesor", "defecto");
INSERT INTO `Profesor` VALUES (12345678, "Profesor", "defecto", 7);
INSERT INTO `Tiene_Ag` VALUES
(1, "BG", 3, 123, 12345678, now(), 7),
(2, "BG", 3, 123, 12345678, now(), 7),
(3, "BG", 3, 123, 12345678, now(), 7),
(4, "BG", 3, 123, 12345678, now(), 7),
(5, "BG", 3, 123, 12345678, now(), 7),
(6, "BG", 3, 123, 12345678, now(), 7),
(7, "BG", 3, 123, 12345678, now(), 7),
(8, "BG", 3, 123, 12345678, now(), 7),
(9, "BG", 3, 123, 12345678, now(), 7),
(10, "BG", 3, 123, 12345678, now(), 7),
(11, "BG", 3, 123, 12345678, now(), 7);


