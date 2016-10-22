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

create table `Tiene_Ta` (
  `IdAsignatura` INT(4) NOT NULL,
  `Grado` INT(2) NOT NULL,
  `CargaHoraria` INT(2) NOT NULL,
  `IdOrientacion` INT(4) NOT NULL,
  FOREIGN KEY (`IdAsignatura`) REFERENCES Asignatura(`IdAsignatura`),
  FOREIGN KEY (`Grado`) REFERENCES Trayecto(`Grado`),
  FOREIGN KEY (`IdOrientacion`) REFERENCES Orientacion(`IdOrientacion`),
  PRIMARY KEY (`IdAsignatura`, `Grado`, `IdOrientacion`)
);

-- Views para que la profe sea feliz
create view AsignaturasTomadas AS select IdAsignatura, IdGrupo, Grado from Tiene_Ag;
create view Calendario AS select Asignatura.IdAsignatura as IdAsignatura, DATE_FORMAT(HoraInicio, '%H:%i') as HoraOrden, CONCAT(DATE_FORMAT(HoraInicio, '%H:%i'), " - ", DATE_FORMAT(HoraFin, '%H:%i')) as Hora, Dia, CONCAT(Grado, " ", IdGrupo) as Grupo, CONCAT(NombrePersona, ' ', ApellidoPersona) as NombreProfesor, Persona.CiPersona, NombreAsignatura as Materia from Genera, Asignatura, Persona where Genera.IdAsignatura=Asignatura.IdAsignatura and Genera.CiPersona=Persona.CiPersona;
create view AsignaturasOrientaciones as select IdOrientacion, Grado, Asignatura.IdAsignatura as IdAsignatura, CargaHoraria, NombreAsignatura from Tiene_Ta, Asignatura where Tiene_Ta.IdAsignatura=Asignatura.IdAsignatura;
create view Grupos AS select CONCAT(Grado, IdGrupo) as Grupo from Grupo;
create view ProfesorEnsenia as select HoraOrden, Dia, Calendario.CiPersona, CONCAT(NombrePersona, ' ', ApellidoPersona) as NombreProfesor from Calendario, Persona where Calendario.CiPersona=Persona.ciPersona;
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
 INSERT INTO `Turno` VALUES (1, "Matutino"), (2, "Vespertino"), (3, "Nocturno"), (4, "Turno 4"), (5, "Turno 5");
 INSERT INTO `Salon` VALUES (-1, "", "");
 INSERT INTO `Asignacion` 
VALUES
('13:00', '13:45', 'Lunes', 2), ('13:50', '14:35', 'Lunes', 2), ('14:40', '15:25', 'Lunes', 2), ('15:30', '16:15', 'Lunes', 2), ('16:20', '17:05', 'Lunes', 2), ('17:10', '17:55', 'Lunes', 2), ('18:00', '18:45', 'Lunes', 2), ('13:00', '13:45', 'Martes', 2), ('13:50', '14:35', 'Martes', 2), ('14:40', '15:25', 'Martes', 2), ('15:30', '16:15', 'Martes', 2), ('16:20', '17:05', 'Martes', 2), ('17:10', '17:55', 'Martes', 2), ('18:00', '18:45', 'Martes', 2),
('13:00', '13:45', 'Miércoles', 2), ('13:50', '14:35', 'Miércoles', 2), ('14:40', '15:25', 'Miércoles', 2), ('15:30', '16:15', 'Miércoles', 2), ('16:20', '17:05', 'Miércoles', 2), ('17:10', '17:55', 'Miércoles', 2), ('18:00', '18:45', 'Miércoles', 2),
('13:00', '13:45', 'Jueves', 2), ('13:50', '14:35', 'Jueves', 2), ('14:40', '15:25', 'Jueves', 2), ('15:30', '16:15', 'Jueves', 2), ('16:20', '17:05', 'Jueves', 2), ('17:10', '17:55', 'Jueves', 2), ('18:00', '18:45', 'Jueves', 2), 
('13:00', '13:45', 'Viernes', 2), ('13:50', '14:35', 'Viernes', 2), ('14:40', '15:25', 'Viernes', 2), ('15:30', '16:15', 'Viernes', 2), ('16:20', '17:05', 'Viernes', 2), ('17:10', '17:55', 'Viernes', 2), ('18:00', '18:45', 'Viernes', 2),
('13:00', '13:45', 'Sábado', 2), ('13:50', '14:35', 'Sábado', 2), ('14:40', '15:25', 'Sábado', 2), ('15:30', '16:15', 'Sábado', 2), ('16:20', '17:05', 'Sábado', 2), ('17:10', '17:55', 'Sábado', 2), ('18:00', '18:45', 'Sábado', 2)
;

INSERT INTO `Persona` VALUES (-1, "Sin", "profesor");
INSERT INTO `Profesor` VALUES (-1, "Sin", "profesor", 7);

-- Datos de prueba. 2do y 3ero BG.
INSERT INTO `Persona` VALUES (1, "ro", "ot");
INSERT INTO `Usuario` VALUES (1, "ro", "ot", "Administrador", "1", True);
INSERT INTO `Salon` VALUES (17, "", "Exterior"), (8, "", "Alta");
INSERT INTO `Area` VALUES 
(1, "Informática");

INSERT INTO `Asignatura` VALUES 
(-1, "Sin asignar", 1),
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
(11, "F. Empresarial", 1),
(14, "Economía", 1),
(15, "Química", 1),
(16, "APT", 1),
(17, "Web", 1),
(18, "Electrónica", 1),
(19, "Geometría", 1);


INSERT INTO `Tiene_Ta` VALUES
(1, 3, 3, 123),
(2, 3, 3, 123),
(3, 3, 3, 123),
(4, 3, 6, 123),
(5, 3, 3, 123),
(6, 3, 3, 123),
(7, 3, 3, 123),
(8, 3, 3, 123),
(9, 3, 4, 123),
(10, 3, 2, 123),
(11, 3, 3, 123),

(16, 2, 3, 123),
(5, 2, 3, 123),
(19, 2, 3, 123),
(9, 2, 4, 123),
(3, 2, 3, 123),
(4, 2, 3, 123),
(15, 2, 3, 123),
(2, 2, 3, 123),
(14, 2, 3, 123),
(18, 2, 3, 123),
(6, 2, 3, 123),
(17, 2, 2, 123)
;


INSERT INTO `Persona` VALUES (12345678, "Profesor", "defecto"),
(123, "John", "Smith");
INSERT INTO `Profesor` VALUES (12345678, "Profesor", "defecto", 7);
INSERT INTO `Profesor` VALUES (123, "John", "Smith", 6);
