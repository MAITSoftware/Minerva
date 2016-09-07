DROP DATABASE IF EXISTS `Minerva` ;
CREATE DATABASE `Minerva`;
USE `Minerva`;

CREATE TABLE `Usuario` (
	`IDUsuario` VARCHAR(25) PRIMARY KEY NOT NULL,
    `Contraseña` VARCHAR(25) NOT NULL,
    `Aprobado` BOOLEAN NOT NULL,
    `Tipo` VARCHAR(25) NOT NULL
);

-- Zona de abajo
CREATE TABLE `Curso` (
	`ID` INTEGER PRIMARY KEY NOT NULL,
    `Nombre` VARCHAR(25) NOT NULL
);

CREATE TABLE `Orientación` (
	`ID` INTEGER PRIMARY KEY NOT NULL,
    `Nombre` VARCHAR(25) NOT NULL,
	`IDCurso` INTEGER NOT NULL,
    FOREIGN KEY (`IDCurso`) REFERENCES Curso(`ID`)
);

CREATE TABLE `Área` (
	`ID` INTEGER PRIMARY KEY NOT NULL,
    `Nombre` VARCHAR(25) NOT NULL,
	`IDOrientación` INTEGER NOT NULL,
    FOREIGN KEY (`IDOrientación`) REFERENCES Orientación(`ID`)
);

CREATE TABLE `Turno` (
	`ID` INTEGER PRIMARY KEY NOT NULL,
    `HoraInicio` TIME NOT NULL,
    `DuraciónHora` TIME NOT NULL,
    `Nombre` VARCHAR(25) NOT NULL
);

-- Zona central

CREATE TABLE `Profesor` (
	`CI` VARCHAR(25) PRIMARY KEY NOT NULL,
    `Cargo` VARCHAR(25) NOT NULL,
    `Nombre` VARCHAR(25) NOT NULL,
    `Apellido` VARCHAR(25) NOT NULL
);

CREATE TABLE `Asignatura` (
	`ID` INTEGER PRIMARY KEY NOT NULL,
    `Nombre` VARCHAR(25) NOT NULL,
    `IDÁrea` INTEGER NOT NULL,
    FOREIGN KEY (`IDÁrea`) REFERENCES Área(`ID`)
);

CREATE TABLE `Salón` (
	`ID` VARCHAR(25) PRIMARY KEY NOT NULL,
    `Planta` VARCHAR(25) NOT NULL,
    `Comentarios` TEXT NOT NULL
);

CREATE TABLE `Grupo` (
	`ID` VARCHAR(25) NOT NULL,
    `Trayecto` INTEGER NOT NULL,
    `IDTurno` INTEGER NOT NULL,
    `IDCurso` INTEGER NOT NULL,
    `IDOrientación` INTEGER NOT NULL,
	`IDSalón` VARCHAR(25) DEFAULT "",
    FOREIGN KEY (`IDTurno`) REFERENCES Turno(`ID`),
    FOREIGN KEY (`IDCurso`) REFERENCES Curso(`ID`),
    FOREIGN KEY (`IDOrientación`) REFERENCES Orientación(`ID`),
    FOREIGN KEY (`IDSalón`) REFERENCES Salón(`ID`),
    PRIMARY KEY (`ID`, `IDTurno`, `Trayecto`)
);

-- AsignaturasTomadas, Calendario

CREATE TABLE `AsignaturasTomadas` (
	`cargaHoraria` INTEGER NOT NULL,
    `IDÁrea` INTEGER NOT NULL,
    `IDGrupo` VARCHAR(25) NOT NULL,
    `IDDocente` VARCHAR(25) NOT NULL,
    `IDAsignatura` INTEGER NOT NULL,
    FOREIGN KEY (`IDÁrea`) REFERENCES Área(`ID`),
    FOREIGN KEY (`IDDocente`) REFERENCES Profesor(`CI`),
    FOREIGN KEY (`IDAsignatura`) REFERENCES Asignatura(`ID`),
    PRIMARY KEY (`IDÁrea`, `IDGrupo`, `IDAsignatura`)
);

CREATE TABLE `Calendario` (
	`Horario` TIME NOT NULL,
    `IDGrupo` VARCHAR(25) NOT NULL,
    `IDAsignatura` INTEGER NOT NULL,
    `IDDocente` VARCHAR(25) NOT NULL,
    FOREIGN KEY (`IDGrupo`) REFERENCES Grupo(`ID`),
    FOREIGN KEY (`IDAsignatura`) REFERENCES Asignatura(`ID`),
    FOREIGN KEY (`IDDocente`) REFERENCES Profesor(`CI`),
    PRIMARY KEY (`IDGrupo`, `IDDocente`, `IDAsignatura`, `Horario`)
);
-- Curso Número 1: Emt
INSERT INTO `Curso` VALUES (1, "EMT"); 
INSERT INTO `Curso` VALUES (2, "CBT"); 

-- Orientación del Curso 1: Informática
INSERT INTO `Orientación` VALUES (1, "Informática", 1);
INSERT INTO `Orientación` VALUES (2, "Administración", 2);

-- Área 912 de la orientación 1: Pack 1
INSERT INTO `Área` VALUES (151, "Informática 1", 1); 
INSERT INTO `Área` VALUES (152, "Informática 2", 1);

-- Turno 2, inicia 13:00
INSERT INTO `Turno` VALUES (1, "13:00", "00:45", "Turno 1"); 
INSERT INTO `Turno` VALUES (2, "13:00", "00:45", "Turno 2"); 
INSERT INTO `Turno` VALUES (3, "13:00", "00:45", "Turno 3"); 
INSERT INTO `Turno` VALUES (4, "13:00", "00:45", "Turno 4"); 
INSERT INTO `Turno` VALUES (5, "13:00", "00:45", "Turno 5"); 

INSERT INTO `Salón` VALUES (17, "Alta", "");
INSERT INTO `Salón` VALUES (18, "Baja", "");

-- Materia ID: 123, del área 912
INSERT INTO `Asignatura` VALUES (1, "Programación", 151);
INSERT INTO `Asignatura` VALUES (2, "Base de datos", 152);

-- 3 horas de la asignatura 123 de él area 912, en el grupo BG, enseñadas por Carrasco
-- INSERT INTO `AsignaturasTomadas` VALUES (3, 912, "BG", "12345678", 123); 

-- La asignatura 123 enseñada al grupo BG por Carrasco, inicia a las 13:00
-- INSERT INTO `Calendario` VALUES ("13:00", "BG", 123, "12345678"); 