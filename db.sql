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
  `IdCurso` VARCHAR(4) NOT NULL,
  `NombreCurso` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`IdCurso`)
);
 
create table `Orientacion` (
  `IdOrientacion` VARCHAR(4) NOT NULL,
  `NombreOrientacion` VARCHAR(30) NOT NULL,
  `IdCurso` VARCHAR(4) NOT NULL,
  FOREIGN KEY (`IdCurso`) REFERENCES Curso(`IdCurso`),
  PRIMARY KEY (`IdOrientacion`)
);
 
create table `Trayecto` (
  `Grado` INT(2) NOT NULL,
  `IdOrientacion` VARCHAR(4) NOT NULL,
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
  `IdOrientacion` VARCHAR(4) NOT NULL,
  `IdSalon` INT(2) NOT NULL,
  `IdTurno` INT(2) NOT NULL,
  FOREIGN KEY (`Grado`) REFERENCES Trayecto(`Grado`),
  FOREIGN KEY (`IdOrientacion`) REFERENCES Orientacion(`IdOrientacion`),
  FOREIGN KEY (`IdSalon`) REFERENCES Salon(`IdSalon`),
  FOREIGN KEY (`IdTurno`) REFERENCES Turno(`IdTurno`),
  PRIMARY KEY (`IdGrupo`, `Grado`, `IdOrientacion`)
);
 
create table `Area` (
  `IdArea` VARCHAR(4) NOT NULL,
  `NombreArea` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`IdArea`)
);
 
create table `Asignatura` (
  `IdAsignatura` VARCHAR(4) NOT NULL,
  `NombreAsignatura` VARCHAR(50) NOT NULL,
  `IdArea` VARCHAR(4) NOT NULL,
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
  `IdAsignatura` VARCHAR(4) NOT NULL,
  `IdGrupo` VARCHAR(4) NOT NULL,
  `IdOrientacion` VARCHAR(4) NOT NULL,
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
  `IdAsignatura` VARCHAR(4) NOT NULL,
  `IdGrupo` VARCHAR(4) NOT NULL,
  `Grado` INT(2) NOT NULL,
  `IdOrientacion` VARCHAR(4) NOT NULL,
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
  `IdAsignatura` VARCHAR(4) NOT NULL,
  `Grado` INT(2) NOT NULL,
  `CargaHoraria` INT(2) NOT NULL,
  `IdOrientacion` VARCHAR(4) NOT NULL,
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

-- Datos necesarios
INSERT INTO `minerva`.`curso` (`IdCurso`, `NombreCurso`) VALUES ('001', 'CBT');
INSERT INTO `minerva`.`curso` (`IdCurso`, `NombreCurso`) VALUES ('048', 'EMP');
INSERT INTO `minerva`.`curso` (`IdCurso`, `NombreCurso`) VALUES ('049', 'EMT');
INSERT INTO `minerva`.`orientacion` (`IdOrientacion`, `NombreOrientacion`, `IdCurso`) VALUES ('125', 'CBT', '001');
INSERT INTO `minerva`.`orientacion` (`IdOrientacion`, `NombreOrientacion`, `IdCurso`) VALUES ('007', 'Administración', '048');
INSERT INTO `minerva`.`orientacion` (`IdOrientacion`, `NombreOrientacion`, `IdCurso`) VALUES ('107', 'Asistente de dirección', '048');
INSERT INTO `minerva`.`orientacion` (`IdOrientacion`, `NombreOrientacion`, `IdCurso`) VALUES ('344', 'Electrotecnia', '048');
INSERT INTO `minerva`.`orientacion` (`IdOrientacion`, `NombreOrientacion`, `IdCurso`) VALUES ('397', 'Gastronomía C/S/B', '048');
INSERT INTO `minerva`.`orientacion` (`IdOrientacion`, `NombreOrientacion`, `IdCurso`) VALUES ('401', 'Gastronomía Cocina', '048');
INSERT INTO `minerva`.`orientacion` (`IdOrientacion`, `NombreOrientacion`, `IdCurso`) VALUES ('008', 'Administración', '049');
INSERT INTO `minerva`.`orientacion` (`IdOrientacion`, `NombreOrientacion`, `IdCurso`) VALUES ('237', 'Construcción', '049');
INSERT INTO `minerva`.`orientacion` (`IdOrientacion`, `NombreOrientacion`, `IdCurso`) VALUES ('25A', 'Deporte y recreación', '049');
INSERT INTO `minerva`.`orientacion` (`IdOrientacion`, `NombreOrientacion`, `IdCurso`) VALUES ('331', 'Electromecánica automotriz', '049');
INSERT INTO `minerva`.`orientacion` (`IdOrientacion`, `NombreOrientacion`, `IdCurso`) VALUES ('335', 'Electro - Electromecánica', '049');
INSERT INTO `minerva`.`orientacion` (`IdOrientacion`, `NombreOrientacion`, `IdCurso`) VALUES ('336', 'Electromecánica', '049');
INSERT INTO `minerva`.`orientacion` (`IdOrientacion`, `NombreOrientacion`, `IdCurso`) VALUES ('480', 'Informática', '049');
INSERT INTO `minerva`.`orientacion` (`IdOrientacion`, `NombreOrientacion`, `IdCurso`) VALUES ('929', 'Turismo', '049');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('027', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('059', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('221', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('244', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('243', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('060', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('364', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('373', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('383', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('387', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('801', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('025', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('004', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('534', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('423', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('400', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('800', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('833', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('922', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('036', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('728', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('935', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('064', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('415', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('0591', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('459', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('0592', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('334', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('312', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('504', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('550', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('014', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('108', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('148', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('518', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('176', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('388', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('802', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('147', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('028', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('538', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('240', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('568', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('829', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('196', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('320', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('272', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('451', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('854', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('332', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('663', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('592', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('330', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('648', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('146', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('533', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('535', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('141', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('185', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('624', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('282', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('107', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('239', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('015', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('710', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('602', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('524', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('231', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('711', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('262', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('655', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('6161', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('276', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('269', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('270', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('188', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('438', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('808', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('475', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('492', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('936', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('341', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('925', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('786', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('381', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('915', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('055', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('343', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('617', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('964', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('855', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('349', '');
INSERT INTO `minerva`.`area` (`IdArea`, `NombreArea`) VALUES ('857', '');
INSERT INTO `minerva`.`turno` (`IdTurno`, `NombreTurno`) VALUES ('1', 'Matutino');
INSERT INTO `minerva`.`turno` (`IdTurno`, `NombreTurno`) VALUES ('2', 'Vespertino');
INSERT INTO `minerva`.`turno` (`IdTurno`, `NombreTurno`) VALUES ('3', 'Nocturno');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('1', '125', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('2', '125', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('3', '125', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('1', '007', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('1', '107', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('1', '344', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('1', '397', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('1', '401', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('1', '008', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('2', '008', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('3', '008', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('1', '237', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('2', '237', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('1', '25A', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('2', '25A', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('3', '25A', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('2', '331', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('3', '331', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('2', '335', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('3', '335', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('1', '336', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('2', '336', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('3', '336', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('1', '480', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('2', '480', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('3', '480', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('1', '929', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('2', '929', '0');
INSERT INTO `minerva`.`trayecto` (`Grado`, `IdOrientacion`, `Modulo`) VALUES ('3', '929', '0');
