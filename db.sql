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
  `IdOrientacion` INT(2) NOT NULL,
  `Modulo` INT(2) NOT NULL,
  FOREIGN KEY (`IdOrientacion`) REFERENCES Orientacion(`IdOrientacion`),
  PRIMARY KEY (`Grado`, `IdOrientacion`)
);

create table `Salon` (
  `IDSalon` INT(2) NOT NULL,
  `ComentariosSalon` TEXT,
  `PlantaSalon` VARCHAR(15) NOT NULL,
  PRIMARY KEY (`IDSalon`)
);

create table `Turno` (
  `IDTurno` INT(2) NOT NULL,
  `NombreTurno` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`IDTurno`)
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
  INDEX(`IdAsignatura`),
  FOREIGN KEY (`IdArea`) REFERENCES Area(`IdArea`)
);

create table `Asignacion` (
  `HoraInicio` TIME NOT NULL,
  `HoraFin` TIME NOT NULL,
  `Dia` VARCHAR(10) NOT NULL,
  INDEX(`Dia`),
  INDEX(`HoraInicio`),
  INDEX( `HoraFin`),
  PRIMARY KEY (`HoraInicio`, `HoraFin`, `Dia`)
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
  FOREIGN KEY (`CiPersona`) REFERENCES Profesor(`CiPersona`),
  PRIMARY KEY (`HoraInicio`, `HoraFin`, `Dia`, `IdAsignatura`, `IdGrupo`, `IdOrientacion`, `CiPersona`, `Grado`)
);

create table `Tiene_Ag` (
  `IdAsignatura` INT(4) NOT NULL,
  `IdGrupo` VARCHAR(4) NOT NULL,
  `Grado` INT(2) NOT NULL,
  `IdOrientacion` INT(4) NOT NULL,
  `CiPersona` INT(8) NOT NULL,
  `FechaToma` DATETIME NOT NULL,
  FOREIGN KEY (`IdAsignatura`) REFERENCES Asignatura(`IdAsignatura`),
  FOREIGN KEY (`IdGrupo`) REFERENCES Grupo(`IdGrupo`),
  FOREIGN KEY (`Grado`) REFERENCES Trayecto(`Grado`),
  FOREIGN KEY (`IdOrientacion`) REFERENCES Orientacion(`IdOrientacion`),
  FOREIGN KEY (`CiPersona`) REFERENCES Profesor(`CiPersona`),
  PRIMARY KEY (`IdAsignatura`, `IdGrupo`, `Grado`, `IdOrientacion`, `CiPersona`)
);

create table `Tiene_Ta` (
  `IdAsignatura` INT(4) NOT NULL,
  `Grado` INT(2) NOT NULL,
  `IdOrientacion` INT(4) NOT NULL,
  FOREIGN KEY (`IdAsignatura`) REFERENCES Asignatura(`IdAsignatura`),
  FOREIGN KEY (`Grado`) REFERENCES Trayecto(`Grado`),
  FOREIGN KEY (`IdOrientacion`) REFERENCES Orientacion(`IdOrientacion`),
  PRIMARY KEY (`IdAsignatura`, `Grado`, `IdOrientacion`)
);
