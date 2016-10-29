-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: minerva
-- ------------------------------------------------------
-- Server version	5.7.16-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `area`
--

DROP TABLE IF EXISTS `area`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `area` (
  `IdArea` varchar(4) NOT NULL,
  `NombreArea` varchar(50) NOT NULL,
  PRIMARY KEY (`IdArea`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `area`
--

LOCK TABLES `area` WRITE;
/*!40000 ALTER TABLE `area` DISABLE KEYS */;
INSERT INTO `area` VALUES ('014','Análisis y producción de textos'),('015','Administración y gestion de obras'),('027','Biología (1er. ciclo)'),('028','Biología'),('055','Ciencias experimentales turismo'),('059','Ciencias físico-químicas (1er. C)'),('0591','Física'),('0592','Química'),('060','Ciencias geográficas'),('064','Ciencias Sociales'),('107','Comunicaciones'),('108','Comunicaciones'),('141','Contabilidad e informática aplicada'),('146','Administración y gestion empresaria'),('147','Teoria y práctica administrativa'),('148','Contabilidad general'),('176','Derecho'),('185','Derecho y leg. en la empres'),('188','Dibujo tecnico 1'),('196','Dibujo técnico 3'),('221','Educación visual y plástica)'),('231','Diseño y tecnol. de construccion BT'),('239','Economia y finanzas'),('240','Nociones de economía y finanzas'),('243','Educación de la sexualidad'),('244','Educación física'),('262','Educación física - deporte'),('269','Electromec.automot.y labor. (mec.aut'),('270','Electromec.automot.y labor. (ele.aut'),('272','Electrónica 1'),('276','Electronica 2'),('282','Elementos de marketing'),('312','Filosofía'),('320','Física'),('330','Gastronomía'),('332','Francés'),('341','Gestion en mantenimiento industrial'),('343','Geografía turística'),('349','Gestion turismo sostenible'),('364','Historia'),('373','Idioma Español (1er. Ciclo)'),('381','Informática - Diseño gráfico y web'),('383','Informática (Ciclo básico)'),('387','Inglés (Ciclo básico)'),('388','Inglés'),('400','Instalaciones electricas'),('415','Instrucción cívica (Ciclo básico)'),('438','Lab. de electronica y electrotecnia'),('451','Laboratorio y medidas electricas'),('459','Lengua y literatura'),('475','Magnitudes electromecánicas'),('492','Materiales'),('518','Mecanografía informatizada'),('533','Nutricion EMP'),('535','Nutricion'),('538','OP.M E INT a la informática'),('550','Orientacion vocacional CBT'),('568','Portugues'),('592','Pract.Prof. de sala y bar'),('602','Procesos constructivos'),('6161','Psicología del deporte'),('617','Psico-sociología del turismo'),('624','Química'),('648','Relaciones humanas y públicas'),('655','Primeros auxilios'),('663','Seguridad e higiene alimentarias'),('710','Taller de C.A.D'),('711','Informática C.A.D especializada'),('786','Taller de mantenimiento informático'),('801','Matemáticas nivel 1'),('802','Matemática Nivel 2'),('808','Taller de mec. mantenimiento'),('829','Taller de oficina'),('854','Tall. Rep. Maq. Elec. y BOB.'),('855','Taller recreación y cultura lúdica'),('857','Planificación act. turísticas'),('915','Técnicas informáticas nivel 2'),('925','Técnicas informáticas'),('935','Tecnología'),('936','Tecnología de mecánica 2'),('964','Teoría del turismo'),('TOC','T.O.C (en general)');
/*!40000 ALTER TABLE `area` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `asignacion`
--

DROP TABLE IF EXISTS `asignacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `asignacion` (
  `HoraInicio` time NOT NULL,
  `HoraFin` time NOT NULL,
  `Dia` varchar(10) NOT NULL,
  `IdTurno` int(2) NOT NULL,
  PRIMARY KEY (`HoraInicio`,`HoraFin`,`Dia`,`IdTurno`),
  KEY `Dia` (`Dia`),
  KEY `HoraInicio` (`HoraInicio`),
  KEY `HoraFin` (`HoraFin`),
  KEY `IdTurno` (`IdTurno`),
  CONSTRAINT `asignacion_ibfk_1` FOREIGN KEY (`IdTurno`) REFERENCES `turno` (`IdTurno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asignacion`
--

LOCK TABLES `asignacion` WRITE;
/*!40000 ALTER TABLE `asignacion` DISABLE KEYS */;
INSERT INTO `asignacion` VALUES ('07:00:00','07:40:00','Jueves',1),('07:00:00','07:40:00','Lunes',1),('07:00:00','07:40:00','Martes',1),('07:00:00','07:40:00','Miércoles',1),('07:00:00','07:40:00','Sábado',1),('07:00:00','07:40:00','Viernes',1),('07:45:00','08:30:00','Jueves',1),('07:45:00','08:30:00','Lunes',1),('07:45:00','08:30:00','Martes',1),('07:45:00','08:30:00','Miércoles',1),('07:45:00','08:30:00','Sábado',1),('07:45:00','08:30:00','Viernes',1),('08:35:00','09:20:00','Jueves',1),('08:35:00','09:20:00','Lunes',1),('08:35:00','09:20:00','Martes',1),('08:35:00','09:20:00','Miércoles',1),('08:35:00','09:20:00','Sábado',1),('08:35:00','09:20:00','Viernes',1),('09:25:00','10:10:00','Jueves',1),('09:25:00','10:10:00','Lunes',1),('09:25:00','10:10:00','Martes',1),('09:25:00','10:10:00','Miércoles',1),('09:25:00','10:10:00','Sábado',1),('09:25:00','10:10:00','Viernes',1),('10:20:00','11:05:00','Jueves',1),('10:20:00','11:05:00','Lunes',1),('10:20:00','11:05:00','Martes',1),('10:20:00','11:05:00','Miércoles',1),('10:20:00','11:05:00','Sábado',1),('10:20:00','11:05:00','Viernes',1),('11:10:00','11:55:00','Jueves',1),('11:10:00','11:55:00','Lunes',1),('11:10:00','11:55:00','Martes',1),('11:10:00','11:55:00','Miércoles',1),('11:10:00','11:55:00','Sábado',1),('11:10:00','11:55:00','Viernes',1),('12:00:00','12:45:00','Jueves',1),('12:00:00','12:45:00','Lunes',1),('12:00:00','12:45:00','Martes',1),('12:00:00','12:45:00','Miércoles',1),('12:00:00','12:45:00','Sábado',1),('12:00:00','12:45:00','Viernes',1),('13:00:00','13:45:00','Jueves',2),('13:00:00','13:45:00','Lunes',2),('13:00:00','13:45:00','Martes',2),('13:00:00','13:45:00','Miércoles',2),('13:00:00','13:45:00','Sábado',2),('13:00:00','13:45:00','Viernes',2),('13:50:00','14:35:00','Jueves',2),('13:50:00','14:35:00','Lunes',2),('13:50:00','14:35:00','Martes',2),('13:50:00','14:35:00','Miércoles',2),('13:50:00','14:35:00','Sábado',2),('13:50:00','14:35:00','Viernes',2),('14:40:00','15:25:00','Jueves',2),('14:40:00','15:25:00','Lunes',2),('14:40:00','15:25:00','Martes',2),('14:40:00','15:25:00','Miércoles',2),('14:40:00','15:25:00','Sábado',2),('14:40:00','15:25:00','Viernes',2),('15:30:00','16:15:00','Jueves',2),('15:30:00','16:15:00','Lunes',2),('15:30:00','16:15:00','Martes',2),('15:30:00','16:15:00','Miércoles',2),('15:30:00','16:15:00','Sábado',2),('15:30:00','16:15:00','Viernes',2),('16:20:00','17:05:00','Jueves',2),('16:20:00','17:05:00','Lunes',2),('16:20:00','17:05:00','Martes',2),('16:20:00','17:05:00','Miércoles',2),('16:20:00','17:05:00','Sábado',2),('16:20:00','17:05:00','Viernes',2),('17:10:00','17:55:00','Jueves',2),('17:10:00','17:55:00','Lunes',2),('17:10:00','17:55:00','Martes',2),('17:10:00','17:55:00','Miércoles',2),('17:10:00','17:55:00','Sábado',2),('17:10:00','17:55:00','Viernes',2),('18:00:00','18:45:00','Jueves',2),('18:00:00','18:45:00','Lunes',2),('18:00:00','18:45:00','Martes',2),('18:00:00','18:45:00','Miércoles',2),('18:00:00','18:45:00','Sábado',2),('18:00:00','18:45:00','Viernes',2),('19:15:00','19:55:00','Jueves',3),('19:15:00','19:55:00','Lunes',3),('19:15:00','19:55:00','Martes',3),('19:15:00','19:55:00','Miércoles',3),('19:15:00','19:55:00','Sábado',3),('19:15:00','19:55:00','Viernes',3),('20:00:00','20:40:00','Jueves',3),('20:00:00','20:40:00','Lunes',3),('20:00:00','20:40:00','Martes',3),('20:00:00','20:40:00','Miércoles',3),('20:00:00','20:40:00','Sábado',3),('20:00:00','20:40:00','Viernes',3),('20:45:00','21:25:00','Jueves',3),('20:45:00','21:25:00','Lunes',3),('20:45:00','21:25:00','Martes',3),('20:45:00','21:25:00','Miércoles',3),('20:45:00','21:25:00','Sábado',3),('20:45:00','21:25:00','Viernes',3),('21:30:00','22:10:00','Jueves',3),('21:30:00','22:10:00','Lunes',3),('21:30:00','22:10:00','Martes',3),('21:30:00','22:10:00','Miércoles',3),('21:30:00','22:10:00','Sábado',3),('21:30:00','22:10:00','Viernes',3),('22:15:00','22:55:00','Jueves',3),('22:15:00','22:55:00','Lunes',3),('22:15:00','22:55:00','Martes',3),('22:15:00','22:55:00','Miércoles',3),('22:15:00','22:55:00','Sábado',3),('22:15:00','22:55:00','Viernes',3),('23:00:00','23:40:00','Jueves',3),('23:00:00','23:40:00','Lunes',3),('23:00:00','23:40:00','Martes',3),('23:00:00','23:40:00','Miércoles',3),('23:00:00','23:40:00','Sábado',3),('23:00:00','23:40:00','Viernes',3);
/*!40000 ALTER TABLE `asignacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `asignatura`
--

DROP TABLE IF EXISTS `asignatura`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `asignatura` (
  `IdAsignatura` varchar(5) NOT NULL,
  `NombreAsignatura` varchar(50) NOT NULL,
  `IdArea` varchar(4) NOT NULL,
  PRIMARY KEY (`IdAsignatura`,`IdArea`),
  KEY `IdArea` (`IdArea`),
  CONSTRAINT `asignatura_ibfk_1` FOREIGN KEY (`IdArea`) REFERENCES `area` (`IdArea`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asignatura`
--

LOCK TABLES `asignatura` WRITE;
/*!40000 ALTER TABLE `asignatura` DISABLE KEYS */;
INSERT INTO `asignatura` VALUES ('-1','Sin asignar','015'),('-1','Sin asignar','027'),('-1','Sin asignar','028'),('-1','Sin asignar','055'),('-1','Sin asignar','059'),('-1','Sin asignar','0591'),('-1','Sin asignar','0592'),('-1','Sin asignar','060'),('-1','Sin asignar','064'),('-1','Sin asignar','107'),('-1','Sin asignar','108'),('-1','Sin asignar','141'),('-1','Sin asignar','146'),('-1','Sin asignar','147'),('-1','Sin asignar','148'),('-1','Sin asignar','176'),('-1','Sin asignar','185'),('-1','Sin asignar','188'),('-1','Sin asignar','196'),('-1','Sin asignar','221'),('-1','Sin asignar','231'),('-1','Sin asignar','239'),('-1','Sin asignar','240'),('-1','Sin asignar','243'),('-1','Sin asignar','244'),('-1','Sin asignar','262'),('-1','Sin asignar','269'),('-1','Sin asignar','270'),('-1','Sin asignar','272'),('-1','Sin asignar','276'),('-1','Sin asignar','282'),('-1','Sin asignar','312'),('-1','Sin asignar','320'),('-1','Sin asignar','330'),('-1','Sin asignar','332'),('-1','Sin asignar','341'),('-1','Sin asignar','343'),('-1','Sin asignar','349'),('-1','Sin asignar','364'),('-1','Sin asignar','373'),('-1','Sin asignar','381'),('-1','Sin asignar','383'),('-1','Sin asignar','387'),('-1','Sin asignar','388'),('-1','Sin asignar','400'),('-1','Sin asignar','415'),('-1','Sin asignar','438'),('-1','Sin asignar','451'),('-1','Sin asignar','459'),('-1','Sin asignar','475'),('-1','Sin asignar','492'),('-1','Sin asignar','518'),('-1','Sin asignar','533'),('-1','Sin asignar','535'),('-1','Sin asignar','538'),('-1','Sin asignar','550'),('-1','Sin asignar','568'),('-1','Sin asignar','592'),('-1','Sin asignar','602'),('-1','Sin asignar','6161'),('-1','Sin asignar','617'),('-1','Sin asignar','624'),('-1','Sin asignar','648'),('-1','Sin asignar','655'),('-1','Sin asignar','663'),('-1','Sin asignar','710'),('-1','Sin asignar','711'),('-1','Sin asignar','786'),('-1','Sin asignar','801'),('-1','Sin asignar','802'),('-1','Sin asignar','808'),('-1','Sin asignar','829'),('-1','Sin asignar','854'),('-1','Sin asignar','855'),('-1','Sin asignar','857'),('-1','Sin asignar','915'),('-1','Sin asignar','925'),('-1','Sin asignar','935'),('-1','Sin asignar','936'),('-1','Sin asignar','964'),('-1','Sin asignar','TOC'),('0028','Adm. y gestión de obras 2','015'),('0029','Administración y gestión de obras 1','015'),('0044','Administracion y costos','146'),('0051','Administración organización taller','146'),('0057','Administración y contabilidad inf.','141'),('0195','Análisis y montaje sistemas electr.','400'),('0213','Análisis y diseño de aplicaciones','915'),('0214','Análisis y producción de textos','014'),('0219','Análisis y producción de textos','014'),('0458','Bases documentarias','146'),('0487','Biología','027'),('0495','Biología CTS','028'),('0504','Biología y anatomía humana','028'),('0507','Biomecánica','320'),('0581','Ciencias de la naturaleza','055'),('0585','Ciencias sociales (Economía)','364'),('0586','Ciencias sociales (Historia)','364'),('0587','Ciencias sociales (Sociología)','064'),('0593','Ciencias Físicas','059'),('0641','Comercialización','282'),('0660','Comunicaciones','108'),('0664','Comunicaciones','276'),('0668','A. P. T comunicaciones','107'),('0770','Contabilidad','141'),('0771','Contabilidad','141'),('0773','Contabilidad','141'),('0779','Contabilidad superior','141'),('0782','Contabilidad general','148'),('0898','Dactilografía informatizada','518'),('0900','Derecho','176'),('0942','Dibujo','221'),('1142','Dispositivos mecánicos de control','936'),('1143','Diseño de páginas web','381'),('1149','Diseño y repesentación técnica','196'),('1167','Ecología y medio ambiente','055'),('1178','Tecnología','330'),('1210','Economía y finanzas','239'),('1244','Educación física','244'),('1257','Educación de la sexualidad','243'),('1303','Electromecánica y lab. 3 Elect.','451'),('1304','Electromecánica y lab. 3 Mec.','808'),('1308','Electromecánica y lab. 1 elect.','438'),('1309','Electromecánica y lab. 1 mec.','808'),('1320','Electricidad','438'),('1324','Electromecánica y lab. 2 elect.','451'),('1325','Electromecánica y lab. 2 mec.','808'),('1330','Electrónica','276'),('1332','Electrónica básica','276'),('1338','Electrónica 2','276'),('1339','Electrónica 3','276'),('1348','Electromm automotriz 2 (m.a.)','269'),('1349','Electromm automotriz 2 (e.a.)','270'),('1388','Electrónica analógica digital','276'),('1470','Estadística','802'),('1487','Estadística','802'),('1540','Filosofía','312'),('1568','Física','0591'),('1580','Física aplicada','320'),('1595','Física cts','320'),('1613','Física informática','320'),('1627','Física','320'),('1635','Física técnica 1','320'),('1636','Física técnica 2','320'),('1637','Física técnica 3','320'),('1638','Física técnica 1','320'),('1651','Física','320'),('1652','Formación empresarial','146'),('1656','Formación ciudadana','415'),('1660','Francés','332'),('1725','Geografía','060'),('1747','Geografía turística 1','343'),('1748','Geografía turística 2','343'),('1749','Geografía turística 3','343'),('1761','Geometría','802'),('1764','Geometría','802'),('1769','Gestión del mantenimiento industrial','341'),('1770','Gestión empresarial','146'),('1795','Gestión empresarial turística','146'),('1819','Gestión y proyectos','146'),('1860','Seguridad e higiene','663'),('1875','Historia','364'),('1890','Historia de la cultura 1','364'),('1891','Historia de la cultura 2','364'),('1892','Historia de la cultura 3','364'),('1959','Idioma Español','373'),('1980','Informática aplicada','538'),('1990','Inglés','388'),('1992','Inglés','388'),('1993','Informática','383'),('1997','Informática aplicada cad 1','710'),('1998','Informática aplicada cad 2','711'),('2003','Inglés','387'),('2117','Introducción a la computación 2','925'),('2125','Introducción a la administración','146'),('2136','Int. a la didactiva y met. deporte','262'),('2198','Informática','538'),('2381','Lab. electrotécnia-electrónica','272'),('2383','Lab. electrónica-electrotécnia','451'),('2415','Legislación en la empresa','185'),('2426','Legislación aplicada gastronomía','176'),('2435','Lengua y literatura','459'),('2452','Legislacion turística aplicada','185'),('2457','Lógica para computación','925'),('2469','Magnitudes electromecánicas','475'),('2615','Matemática','802'),('2616','Matemática','801'),('2620','Matemática','802'),('2622','Matemática','802'),('2625','Matemática','802'),('2626','Matemática','802'),('2629','Matemática','802'),('2631','Matemática','802'),('2632','matemática','802'),('2641','Matemática A','802'),('2643','Matemática B','802'),('2700','Matemática financiera','802'),('2767','Matemática','802'),('2768','Matemática','802'),('2864','Mediciones electronicas electrot.','451'),('2866','Mediciones electronicas electronica','276'),('3040','Nociones de economía y finanzas','240'),('3051','Nutrición','533'),('3100','Organización administrativa','147'),('3125','Organización institucional','146'),('3174','Planeam. Actividades turísticas','857'),('3177','Portugués','568'),('3212','Prac. prof. sala y bar','592'),('3227','Practica profesional gastronomía','330'),('3340','Prácticas administrativas','147'),('3384','Primeros auxilios','655'),('3405','Práctica de oficina','829'),('3425','Procesos constructivos 1','602'),('3426','Procesos constructivos 2','602'),('3501','Programación 1','925'),('3502','Programación 2','915'),('3507','Programación 3','915'),('3508','Potencia y control electrotecnia','451'),('3512','Potencia y control electrónica','276'),('3555','Proyecto','915'),('3596','Psicología social','617'),('3605','Psicología del deporte','6161'),('3616','Química 3','0592'),('3643','Química de los proc. constructivos 1','624'),('3644','Química de proc. constructivos 2','624'),('3646','Química para gastronomía','535'),('3647','Química cts','624'),('3665','Química de los materiales y proc. 1','624'),('3666','Química de materiales y proc. 2','624'),('3695','Fisiología func. y del ejercicio','028'),('3702','Química','624'),('3729','Práctica profesional gastronomía 2','330'),('3740','Relaciones humanas','648'),('3776','Representación técnica','188'),('3777','Rep. tec. asistida por computadora','188'),('3893','Sistemas de bases de datos 1','915'),('3894','Sistemas de bases de datos 2','915'),('3921','Sistemas Operativos 1','925'),('3922','Sistemas operativos 2','915'),('3927','Sistemas operativos 3','915'),('3971','Soldadura y tratamientos térmicos','492'),('4709','Taller de Rec. y cultura lúdica 1','855'),('4711','Taller de rec. y cultura lúdica 2','855'),('49121','Taller de deporte y recreación','262'),('5071','Taller electrotecnia i.e','400'),('5075','Taller de electrotenia m.e','854'),('5557','Taller de mantenimiento 1','786'),('5558','Taller de mantenimiento 2','786'),('5559','Taller de mantenimiento 3','786'),('6902','Tecnología','935'),('7175','Tec. diseño de la construcción 1','231'),('7176','Tec. y diseño de la construcción 2','231'),('7565','Teoría del turismo','964'),('7568','Teoría del turismo 2 G.T.S','349'),('8077','Orientación vocacional','550'),('TOC','T. O. C','TOC');
/*!40000 ALTER TABLE `asignatura` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `asignaturasgrupo`
--

DROP TABLE IF EXISTS `asignaturasgrupo`;
/*!50001 DROP VIEW IF EXISTS `asignaturasgrupo`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `asignaturasgrupo` AS SELECT 
 1 AS `NombreAsignatura`,
 1 AS `NombreProfesor`,
 1 AS `Grado`,
 1 AS `IdGrupo`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `asignaturasorientaciones`
--

DROP TABLE IF EXISTS `asignaturasorientaciones`;
/*!50001 DROP VIEW IF EXISTS `asignaturasorientaciones`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `asignaturasorientaciones` AS SELECT 
 1 AS `IdOrientacion`,
 1 AS `Grado`,
 1 AS `IdAsignatura`,
 1 AS `CargaHoraria`,
 1 AS `NombreAsignatura`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `asignaturastomadas`
--

DROP TABLE IF EXISTS `asignaturastomadas`;
/*!50001 DROP VIEW IF EXISTS `asignaturastomadas`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `asignaturastomadas` AS SELECT 
 1 AS `IdAsignatura`,
 1 AS `IdGrupo`,
 1 AS `Grado`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `calendario`
--

DROP TABLE IF EXISTS `calendario`;
/*!50001 DROP VIEW IF EXISTS `calendario`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `calendario` AS SELECT 
 1 AS `IdAsignatura`,
 1 AS `HoraInicio`,
 1 AS `HoraOrden`,
 1 AS `Hora`,
 1 AS `Dia`,
 1 AS `Grupo`,
 1 AS `NombreProfesor`,
 1 AS `CiPersona`,
 1 AS `Materia`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `curso`
--

DROP TABLE IF EXISTS `curso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `curso` (
  `IdCurso` varchar(4) NOT NULL,
  `NombreCurso` varchar(30) NOT NULL,
  PRIMARY KEY (`IdCurso`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `curso`
--

LOCK TABLES `curso` WRITE;
/*!40000 ALTER TABLE `curso` DISABLE KEYS */;
INSERT INTO `curso` VALUES ('001','CBT'),('048','EMP'),('049','EMT');
/*!40000 ALTER TABLE `curso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `datosgrupos`
--

DROP TABLE IF EXISTS `datosgrupos`;
/*!50001 DROP VIEW IF EXISTS `datosgrupos`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `datosgrupos` AS SELECT 
 1 AS `Salon`,
 1 AS `IdOrientacion`,
 1 AS `Orientacion`,
 1 AS `Curso`,
 1 AS `Grado`,
 1 AS `IdGrupo`,
 1 AS `NombreTurno`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `genera`
--

DROP TABLE IF EXISTS `genera`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `genera` (
  `HoraInicio` time NOT NULL,
  `HoraFin` time NOT NULL,
  `Dia` varchar(10) NOT NULL,
  `Grado` int(2) NOT NULL,
  `IdAsignatura` varchar(5) NOT NULL,
  `IdGrupo` varchar(4) NOT NULL,
  `IdOrientacion` varchar(4) NOT NULL,
  `CiPersona` varchar(8) NOT NULL,
  PRIMARY KEY (`HoraInicio`,`HoraFin`,`Dia`,`IdAsignatura`,`Grado`,`IdGrupo`,`IdOrientacion`),
  KEY `HoraFin` (`HoraFin`),
  KEY `Dia` (`Dia`),
  KEY `Grado` (`Grado`),
  KEY `IdAsignatura` (`IdAsignatura`),
  KEY `IdGrupo` (`IdGrupo`),
  KEY `IdOrientacion` (`IdOrientacion`),
  KEY `CiPersona` (`CiPersona`),
  CONSTRAINT `genera_ibfk_1` FOREIGN KEY (`HoraFin`) REFERENCES `asignacion` (`HoraFin`),
  CONSTRAINT `genera_ibfk_2` FOREIGN KEY (`HoraInicio`) REFERENCES `asignacion` (`HoraInicio`),
  CONSTRAINT `genera_ibfk_3` FOREIGN KEY (`Dia`) REFERENCES `asignacion` (`Dia`),
  CONSTRAINT `genera_ibfk_4` FOREIGN KEY (`Grado`) REFERENCES `trayecto` (`Grado`),
  CONSTRAINT `genera_ibfk_5` FOREIGN KEY (`IdAsignatura`) REFERENCES `asignatura` (`IdAsignatura`),
  CONSTRAINT `genera_ibfk_6` FOREIGN KEY (`IdGrupo`) REFERENCES `grupo` (`IdGrupo`),
  CONSTRAINT `genera_ibfk_7` FOREIGN KEY (`IdOrientacion`) REFERENCES `orientacion` (`IdOrientacion`),
  CONSTRAINT `genera_ibfk_8` FOREIGN KEY (`CiPersona`) REFERENCES `persona` (`CiPersona`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genera`
--

LOCK TABLES `genera` WRITE;
/*!40000 ALTER TABLE `genera` DISABLE KEYS */;
INSERT INTO `genera` VALUES ('13:00:00','13:45:00','Martes',3,'-1','BG','480','-1'),('18:00:00','18:45:00','Jueves',2,'-1','2','480','-1'),('18:00:00','18:45:00','Jueves',3,'-1','BG','480','-1'),('18:00:00','18:45:00','Lunes',2,'-1','2','480','-1'),('18:00:00','18:45:00','Lunes',3,'-1','BG','480','-1'),('18:00:00','18:45:00','Martes',2,'-1','2','480','-1'),('18:00:00','18:45:00','Miércoles',2,'-1','2','480','-1'),('18:00:00','18:45:00','Miércoles',3,'-1','BG','480','-1'),('18:00:00','18:45:00','Sábado',2,'-1','2','480','-1'),('18:00:00','18:45:00','Sábado',3,'-1','BG','480','-1'),('18:00:00','18:45:00','Viernes',2,'-1','2','480','-1'),('18:00:00','18:45:00','Viernes',3,'-1','BG','480','-1'),('19:15:00','19:55:00','Jueves',2,'-1','2','480','-1'),('19:15:00','19:55:00','Lunes',2,'-1','2','480','-1'),('19:15:00','19:55:00','Martes',2,'-1','2','480','-1'),('19:15:00','19:55:00','Miércoles',2,'-1','2','480','-1'),('19:15:00','19:55:00','Sábado',2,'-1','2','480','-1'),('19:15:00','19:55:00','Viernes',2,'-1','2','480','-1'),('20:00:00','20:40:00','Jueves',2,'-1','2','480','-1'),('20:00:00','20:40:00','Martes',2,'0585','2','480','-1'),('20:00:00','20:40:00','Miércoles',2,'-1','2','480','-1'),('20:00:00','20:40:00','Sábado',2,'-1','2','480','-1'),('20:00:00','20:40:00','Viernes',2,'-1','2','480','-1'),('20:45:00','21:25:00','Jueves',2,'1330','2','480','-1'),('20:45:00','21:25:00','Martes',2,'0585','2','480','-1'),('20:45:00','21:25:00','Miércoles',2,'-1','2','480','-1'),('20:45:00','21:25:00','Sábado',2,'-1','2','480','-1'),('20:45:00','21:25:00','Viernes',2,'-1','2','480','-1'),('21:30:00','22:10:00','Jueves',2,'-1','2','480','-1'),('21:30:00','22:10:00','Martes',2,'-1','2','480','-1'),('21:30:00','22:10:00','Miércoles',2,'0585','2','480','-1'),('21:30:00','22:10:00','Sábado',2,'-1','2','480','-1'),('22:15:00','22:55:00','Jueves',2,'-1','2','480','-1'),('22:15:00','22:55:00','Lunes',2,'-1','2','480','-1'),('22:15:00','22:55:00','Martes',2,'1143','2','480','-1'),('22:15:00','22:55:00','Miércoles',2,'-1','2','480','-1'),('22:15:00','22:55:00','Sábado',2,'-1','2','480','-1'),('22:15:00','22:55:00','Viernes',2,'-1','2','480','-1'),('23:00:00','23:40:00','Jueves',2,'-1','2','480','-1'),('23:00:00','23:40:00','Lunes',2,'-1','2','480','-1'),('23:00:00','23:40:00','Martes',2,'-1','2','480','-1'),('23:00:00','23:40:00','Miércoles',2,'-1','2','480','-1'),('23:00:00','23:40:00','Sábado',2,'-1','2','480','-1'),('23:00:00','23:40:00','Viernes',2,'-1','2','480','-1'),('13:00:00','13:45:00','Jueves',3,'5559','BG','480','1'),('13:00:00','13:45:00','Lunes',3,'0213','BG','480','1'),('13:50:00','14:35:00','Jueves',3,'5559','BG','480','1'),('13:50:00','14:35:00','Lunes',3,'0213','BG','480','1'),('14:40:00','15:25:00','Jueves',3,'5559','BG','480','1'),('14:40:00','15:25:00','Lunes',3,'0213','BG','480','1'),('15:30:00','16:15:00','Jueves',3,'5559','BG','480','1'),('15:30:00','16:15:00','Lunes',3,'3894','BG','480','2'),('16:20:00','17:05:00','Lunes',3,'3894','BG','480','2'),('17:10:00','17:55:00','Lunes',3,'3894','BG','480','2'),('13:00:00','13:45:00','Viernes',3,'2631','BG','480','3'),('13:50:00','14:35:00','Sábado',3,'2631','BG','480','3'),('13:50:00','14:35:00','Viernes',3,'2631','BG','480','3'),('14:40:00','15:25:00','Martes',3,'2631','BG','480','3'),('14:40:00','15:25:00','Sábado',3,'2631','BG','480','3'),('15:30:00','16:15:00','Martes',3,'2631','BG','480','3'),('21:30:00','22:10:00','Viernes',2,'1764','2','480','3'),('13:50:00','14:35:00','Martes',3,'1990','BG','480','4'),('16:20:00','17:05:00','Jueves',3,'1990','BG','480','4'),('17:10:00','17:55:00','Jueves',3,'1990','BG','480','4'),('16:20:00','17:05:00','Martes',3,'3927','BG','480','5'),('17:10:00','17:55:00','Martes',3,'3927','BG','480','5'),('18:00:00','18:45:00','Martes',3,'3927','BG','480','5'),('20:00:00','20:40:00','Lunes',2,'0219','2','480','5'),('20:45:00','21:25:00','Lunes',2,'0219','2','480','5'),('21:30:00','22:10:00','Lunes',2,'0219','2','480','5'),('13:00:00','13:45:00','Miércoles',3,'3507','BG','480','6'),('13:50:00','14:35:00','Miércoles',3,'3507','BG','480','6'),('14:40:00','15:25:00','Miércoles',3,'3507','BG','480','6'),('14:40:00','15:25:00','Viernes',3,'3555','BG','480','6'),('15:30:00','16:15:00','Viernes',3,'3555','BG','480','6'),('13:00:00','13:45:00','Sábado',3,'0587','BG','480','7'),('15:30:00','16:15:00','Miércoles',3,'0587','BG','480','7'),('16:20:00','17:05:00','Miércoles',3,'0587','BG','480','7'),('16:20:00','17:05:00','Viernes',3,'1540','BG','480','8'),('17:10:00','17:55:00','Miércoles',3,'1540','BG','480','8'),('17:10:00','17:55:00','Viernes',3,'1540','BG','480','8'),('15:30:00','16:15:00','Sábado',3,'1652','BG','480','9'),('16:20:00','17:05:00','Sábado',3,'1652','BG','480','9'),('17:10:00','17:55:00','Sábado',3,'1652','BG','480','9');
/*!40000 ALTER TABLE `genera` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grupo`
--

DROP TABLE IF EXISTS `grupo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grupo` (
  `IdGrupo` varchar(4) NOT NULL,
  `Discapacitado` tinyint(1) NOT NULL,
  `Grado` int(2) NOT NULL,
  `IdOrientacion` varchar(4) NOT NULL,
  `IdSalon` int(2) NOT NULL,
  `IdTurno` int(2) NOT NULL,
  PRIMARY KEY (`IdGrupo`,`Grado`,`IdOrientacion`),
  KEY `Grado` (`Grado`),
  KEY `IdOrientacion` (`IdOrientacion`),
  KEY `IdSalon` (`IdSalon`),
  KEY `IdTurno` (`IdTurno`),
  CONSTRAINT `grupo_ibfk_1` FOREIGN KEY (`Grado`) REFERENCES `trayecto` (`Grado`),
  CONSTRAINT `grupo_ibfk_2` FOREIGN KEY (`IdOrientacion`) REFERENCES `orientacion` (`IdOrientacion`),
  CONSTRAINT `grupo_ibfk_3` FOREIGN KEY (`IdSalon`) REFERENCES `salon` (`IdSalon`),
  CONSTRAINT `grupo_ibfk_4` FOREIGN KEY (`IdTurno`) REFERENCES `turno` (`IdTurno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grupo`
--

LOCK TABLES `grupo` WRITE;
/*!40000 ALTER TABLE `grupo` DISABLE KEYS */;
INSERT INTO `grupo` VALUES ('2',0,2,'480',-1,3),('BG',0,3,'480',-1,2);
/*!40000 ALTER TABLE `grupo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `grupos`
--

DROP TABLE IF EXISTS `grupos`;
/*!50001 DROP VIEW IF EXISTS `grupos`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `grupos` AS SELECT 
 1 AS `IdGrupo`,
 1 AS `Grupo`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `orientacion`
--

DROP TABLE IF EXISTS `orientacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orientacion` (
  `IdOrientacion` varchar(4) NOT NULL,
  `NombreOrientacion` varchar(30) NOT NULL,
  `IdCurso` varchar(4) NOT NULL,
  PRIMARY KEY (`IdOrientacion`),
  KEY `IdCurso` (`IdCurso`),
  CONSTRAINT `orientacion_ibfk_1` FOREIGN KEY (`IdCurso`) REFERENCES `curso` (`IdCurso`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orientacion`
--

LOCK TABLES `orientacion` WRITE;
/*!40000 ALTER TABLE `orientacion` DISABLE KEYS */;
INSERT INTO `orientacion` VALUES ('007','Administración','048'),('008','Administración','049'),('107','Asistente de dirección','048'),('125','CBT','001'),('237','Construcción','049'),('25A','Deporte y recreación','049'),('331','Electromecánica automotriz','049'),('335','Electro - Electromecánica','049'),('336','Electromecánica','049'),('344','Electrotecnia','048'),('397','Gastronomía C/S/B','048'),('401','Gastronomía Cocina','048'),('480','Informática','049'),('929','Turismo','049');
/*!40000 ALTER TABLE `orientacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `persona`
--

DROP TABLE IF EXISTS `persona`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `persona` (
  `CiPersona` varchar(8) NOT NULL,
  `NombrePersona` varchar(25) DEFAULT NULL,
  `ApellidoPersona` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`CiPersona`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `persona`
--

LOCK TABLES `persona` WRITE;
/*!40000 ALTER TABLE `persona` DISABLE KEYS */;
INSERT INTO `persona` VALUES ('-1','Sin','profesor'),('00000000','Victoria','Bolsi'),('1','Daniel','Carrasco'),('12345678','Ignacio','Rodríguez'),('2','Victoria','Bolsi'),('3','Santiago','Vigo'),('4','Patricia','LaDeIngles'),('5','Gustavo','Caraballo'),('6','Ignacio','Olveira'),('7','Estela','Lamarque'),('8','Dianela','Pérez'),('9','Lorena','Suarez');
/*!40000 ALTER TABLE `persona` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `profesor`
--

DROP TABLE IF EXISTS `profesor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `profesor` (
  `CiPersona` varchar(8) NOT NULL,
  `NombrePersona` varchar(25) NOT NULL,
  `ApellidoPersona` varchar(25) NOT NULL,
  `GradoProfesor` int(3) NOT NULL,
  PRIMARY KEY (`CiPersona`),
  CONSTRAINT `profesor_ibfk_1` FOREIGN KEY (`CiPersona`) REFERENCES `persona` (`CiPersona`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `profesor`
--

LOCK TABLES `profesor` WRITE;
/*!40000 ALTER TABLE `profesor` DISABLE KEYS */;
INSERT INTO `profesor` VALUES ('-1','Sin','profesor',7),('1','Daniel','Carrasco',1),('2','Victoria','Bolsi',1),('3','Santiago','Vigo',1),('4','Patricia','LaDeIngles',1),('5','Gustavo','Caraballo',1),('6','Ignacio','Olveira',1),('7','Estela','Lamarque',1),('8','Dianela','Pérez',1),('9','Lorena','Suarez',1);
/*!40000 ALTER TABLE `profesor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `profesorensenia`
--

DROP TABLE IF EXISTS `profesorensenia`;
/*!50001 DROP VIEW IF EXISTS `profesorensenia`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `profesorensenia` AS SELECT 
 1 AS `HoraOrden`,
 1 AS `Dia`,
 1 AS `CiPersona`,
 1 AS `NombreProfesor`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `salon`
--

DROP TABLE IF EXISTS `salon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `salon` (
  `IdSalon` int(2) NOT NULL,
  `ComentariosSalon` text,
  `PlantaSalon` varchar(15) NOT NULL,
  PRIMARY KEY (`IdSalon`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salon`
--

LOCK TABLES `salon` WRITE;
/*!40000 ALTER TABLE `salon` DISABLE KEYS */;
INSERT INTO `salon` VALUES (-1,'',''),(16,'','Exterior'),(17,'','Exterior'),(18,'','Exterior');
/*!40000 ALTER TABLE `salon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tiene_ag`
--

DROP TABLE IF EXISTS `tiene_ag`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tiene_ag` (
  `IdAsignatura` varchar(5) NOT NULL,
  `IdGrupo` varchar(4) NOT NULL,
  `Grado` int(2) NOT NULL,
  `IdOrientacion` varchar(4) NOT NULL,
  `CiPersona` varchar(8) NOT NULL,
  `FechaToma` date NOT NULL,
  `GradoAreaProfesor` int(2) NOT NULL,
  PRIMARY KEY (`IdAsignatura`,`IdGrupo`,`Grado`,`IdOrientacion`,`CiPersona`),
  KEY `IdGrupo` (`IdGrupo`),
  KEY `Grado` (`Grado`),
  KEY `IdOrientacion` (`IdOrientacion`),
  KEY `CiPersona` (`CiPersona`),
  CONSTRAINT `tiene_ag_ibfk_1` FOREIGN KEY (`IdAsignatura`) REFERENCES `asignatura` (`IdAsignatura`),
  CONSTRAINT `tiene_ag_ibfk_2` FOREIGN KEY (`IdGrupo`) REFERENCES `grupo` (`IdGrupo`),
  CONSTRAINT `tiene_ag_ibfk_3` FOREIGN KEY (`Grado`) REFERENCES `trayecto` (`Grado`),
  CONSTRAINT `tiene_ag_ibfk_4` FOREIGN KEY (`IdOrientacion`) REFERENCES `orientacion` (`IdOrientacion`),
  CONSTRAINT `tiene_ag_ibfk_5` FOREIGN KEY (`CiPersona`) REFERENCES `persona` (`CiPersona`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tiene_ag`
--

LOCK TABLES `tiene_ag` WRITE;
/*!40000 ALTER TABLE `tiene_ag` DISABLE KEYS */;
INSERT INTO `tiene_ag` VALUES ('0213','BG',3,'480','1','2016-10-26',1),('0219','2',2,'480','5','2016-10-26',1),('0587','BG',3,'480','7','2016-10-26',1),('1540','BG',3,'480','8','2016-10-26',1),('1652','BG',3,'480','9','2016-10-26',1),('1764','2',2,'480','3','2016-10-26',1),('1990','BG',3,'480','4','2016-10-26',1),('1992','2',2,'480','4','2016-10-26',1),('2626','2',2,'480','3','2016-10-26',1),('2631','BG',3,'480','3','2016-10-26',1),('3502','2',2,'480','1','2016-10-26',1),('3507','BG',3,'480','6','2016-10-26',1),('3555','BG',3,'480','6','2016-10-26',1),('3893','2',2,'480','2','2016-10-26',1),('3894','BG',3,'480','2','2016-10-26',1),('3922','2',2,'480','1','2016-10-26',1),('3927','BG',3,'480','5','2016-10-26',1),('5559','BG',3,'480','1','2016-10-26',1);
/*!40000 ALTER TABLE `tiene_ag` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tiene_ta`
--

DROP TABLE IF EXISTS `tiene_ta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tiene_ta` (
  `IdAsignatura` varchar(5) NOT NULL,
  `Grado` int(2) NOT NULL,
  `CargaHoraria` int(2) NOT NULL,
  `IdOrientacion` varchar(4) NOT NULL,
  PRIMARY KEY (`IdAsignatura`,`Grado`,`IdOrientacion`),
  KEY `Grado` (`Grado`),
  KEY `IdOrientacion` (`IdOrientacion`),
  CONSTRAINT `tiene_ta_ibfk_1` FOREIGN KEY (`IdAsignatura`) REFERENCES `asignatura` (`IdAsignatura`),
  CONSTRAINT `tiene_ta_ibfk_2` FOREIGN KEY (`Grado`) REFERENCES `trayecto` (`Grado`),
  CONSTRAINT `tiene_ta_ibfk_3` FOREIGN KEY (`IdOrientacion`) REFERENCES `orientacion` (`IdOrientacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tiene_ta`
--

LOCK TABLES `tiene_ta` WRITE;
/*!40000 ALTER TABLE `tiene_ta` DISABLE KEYS */;
INSERT INTO `tiene_ta` VALUES ('0028',2,3,'237'),('0029',1,2,'237'),('0044',1,3,'401'),('0051',3,2,'331'),('0057',3,3,'008'),('0195',3,4,'336'),('0213',3,3,'480'),('0214',1,3,'007'),('0214',1,3,'008'),('0214',1,3,'237'),('0214',1,3,'25A'),('0214',1,3,'336'),('0214',1,3,'344'),('0214',1,3,'397'),('0214',1,3,'480'),('0214',1,3,'929'),('0219',2,3,'008'),('0219',2,3,'237'),('0219',2,3,'25A'),('0219',2,3,'331'),('0219',2,0,'335'),('0219',2,3,'336'),('0219',2,3,'480'),('0219',2,3,'929'),('0458',1,3,'008'),('0487',1,3,'125'),('0487',2,3,'125'),('0487',3,3,'125'),('0495',1,0,'107'),('0495',1,3,'401'),('0495',1,3,'480'),('0495',2,3,'007'),('0495',3,3,'008'),('0504',1,4,'25A'),('0507',3,2,'25A'),('0581',1,3,'929'),('0585',2,3,'008'),('0585',2,3,'237'),('0585',2,3,'25A'),('0585',2,3,'331'),('0585',2,0,'335'),('0585',2,3,'336'),('0585',2,3,'480'),('0585',2,3,'929'),('0586',1,3,'008'),('0586',1,0,'107'),('0586',1,3,'237'),('0586',1,3,'25A'),('0586',1,3,'336'),('0586',1,3,'401'),('0586',1,3,'480'),('0586',1,3,'929'),('0586',2,3,'007'),('0587',3,3,'008'),('0587',3,3,'25A'),('0587',3,3,'331'),('0587',3,3,'335'),('0587',3,0,'336'),('0587',3,3,'480'),('0587',3,3,'929'),('0593',1,2,'125'),('0593',2,2,'125'),('0641',3,3,'008'),('0660',1,3,'007'),('0660',1,0,'107'),('0660',2,3,'007'),('0664',3,4,'335'),('0668',3,3,'008'),('0770',3,3,'929'),('0771',1,6,'008'),('0773',2,6,'008'),('0779',3,3,'008'),('0782',1,4,'007'),('0782',1,0,'107'),('0782',2,4,'007'),('0898',1,4,'007'),('0900',1,2,'007'),('0900',1,4,'008'),('0900',1,0,'107'),('0900',2,2,'007'),('0942',1,2,'125'),('0942',2,2,'125'),('0942',3,2,'125'),('1142',3,3,'336'),('1143',2,2,'480'),('1149',1,2,'344'),('1167',2,3,'929'),('1178',1,2,'401'),('1210',3,3,'008'),('1244',1,0,'125'),('1244',2,0,'125'),('1244',3,0,'125'),('1257',1,0,'125'),('1257',2,0,'125'),('1303',3,10,'336'),('1304',3,10,'336'),('1308',1,10,'336'),('1309',1,10,'336'),('1320',1,3,'480'),('1324',2,10,'336'),('1325',2,10,'336'),('1330',2,3,'480'),('1332',2,2,'331'),('1338',2,7,'335'),('1339',3,10,'335'),('1348',2,10,'331'),('1348',3,10,'331'),('1349',2,10,'331'),('1349',3,10,'331'),('1388',3,6,'331'),('1470',2,4,'008'),('1487',3,2,'25A'),('1540',3,3,'008'),('1540',3,3,'25A'),('1540',3,3,'331'),('1540',3,3,'335'),('1540',3,3,'336'),('1540',3,3,'480'),('1540',3,3,'929'),('1568',3,3,'125'),('1580',1,2,'344'),('1595',1,3,'008'),('1595',1,2,'929'),('1613',1,3,'480'),('1627',1,3,'237'),('1635',2,3,'237'),('1636',2,3,'331'),('1636',2,3,'335'),('1636',2,3,'336'),('1637',3,3,'331'),('1637',3,3,'335'),('1637',3,3,'336'),('1638',1,3,'336'),('1651',3,3,'25A'),('1652',3,3,'480'),('1656',3,2,'125'),('1660',1,3,'397'),('1725',1,2,'125'),('1725',2,3,'125'),('1725',3,2,'125'),('1747',1,5,'929'),('1748',2,3,'929'),('1749',3,3,'929'),('1761',1,3,'237'),('1761',1,3,'336'),('1761',1,3,'480'),('1764',2,3,'237'),('1764',2,3,'331'),('1764',2,3,'335'),('1764',2,3,'336'),('1764',2,3,'480'),('1769',3,2,'336'),('1770',2,3,'008'),('1795',3,3,'929'),('1819',1,2,'25A'),('1819',2,2,'25A'),('1819',3,2,'25A'),('1860',1,2,'397'),('1875',1,3,'125'),('1875',2,2,'125'),('1875',3,3,'125'),('1890',1,5,'929'),('1891',2,4,'929'),('1892',3,5,'929'),('1959',1,5,'125'),('1959',2,5,'125'),('1980',1,0,'107'),('1980',2,3,'007'),('1990',1,4,'007'),('1990',1,3,'008'),('1990',1,0,'107'),('1990',1,3,'237'),('1990',1,3,'25A'),('1990',1,3,'336'),('1990',1,3,'480'),('1990',1,3,'929'),('1990',2,3,'007'),('1990',3,3,'008'),('1990',3,3,'25A'),('1990',3,3,'331'),('1990',3,3,'335'),('1990',3,3,'336'),('1990',3,3,'480'),('1990',3,3,'929'),('1992',2,3,'008'),('1992',2,3,'237'),('1992',2,3,'25A'),('1992',2,3,'331'),('1992',2,0,'335'),('1992',2,3,'336'),('1992',2,3,'480'),('1992',2,3,'929'),('1993',1,2,'125'),('1993',2,2,'125'),('1997',1,4,'237'),('1998',2,2,'237'),('2003',1,4,'125'),('2003',2,4,'125'),('2003',3,3,'125'),('2117',1,2,'480'),('2125',1,3,'008'),('2125',2,2,'929'),('2136',2,2,'25A'),('2198',1,2,'25A'),('2198',2,2,'25A'),('2381',1,8,'344'),('2383',1,8,'344'),('2415',2,4,'008'),('2426',1,2,'397'),('2435',3,5,'125'),('2452',3,3,'929'),('2457',1,2,'480'),('2469',1,2,'336'),('2469',2,3,'336'),('2615',1,3,'007'),('2615',1,3,'344'),('2615',1,3,'397'),('2616',1,5,'125'),('2616',2,5,'125'),('2616',3,5,'125'),('2620',1,4,'008'),('2620',1,4,'929'),('2622',2,4,'008'),('2625',1,3,'237'),('2625',1,3,'336'),('2625',1,3,'480'),('2626',2,3,'237'),('2626',2,4,'25A'),('2626',2,3,'331'),('2626',2,3,'335'),('2626',2,3,'336'),('2626',2,3,'480'),('2629',2,4,'929'),('2631',3,6,'331'),('2631',3,6,'335'),('2631',3,6,'336'),('2631',3,6,'480'),('2632',3,4,'929'),('2641',3,5,'008'),('2643',3,4,'008'),('2700',1,4,'008'),('2700',1,0,'107'),('2700',2,3,'007'),('2767',1,4,'25A'),('2768',3,4,'25A'),('2864',2,5,'335'),('2866',2,5,'335'),('3040',1,0,'107'),('3040',2,3,'007'),('3051',1,2,'401'),('3100',1,3,'007'),('3100',2,3,'007'),('3125',2,3,'008'),('3174',3,3,'929'),('3177',1,3,'107'),('3177',1,3,'929'),('3177',2,3,'929'),('3212',1,5,'397'),('3227',1,10,'397'),('3340',1,4,'007'),('3340',2,2,'007'),('3384',2,2,'25A'),('3384',3,2,'25A'),('3405',1,3,'107'),('3425',1,5,'237'),('3426',2,6,'237'),('3501',1,2,'480'),('3502',2,3,'480'),('3507',3,3,'480'),('3508',3,5,'335'),('3512',3,5,'335'),('3555',3,2,'480'),('3596',1,2,'929'),('3605',3,2,'25A'),('3616',3,3,'125'),('3643',1,3,'237'),('3644',2,3,'237'),('3646',1,2,'401'),('3647',2,3,'008'),('3647',2,3,'480'),('3647',2,2,'929'),('3665',1,3,'336'),('3666',2,3,'331'),('3666',2,0,'335'),('3666',2,3,'336'),('3695',2,2,'25A'),('3702',2,3,'25A'),('3729',1,15,'401'),('3740',1,2,'397'),('3776',1,3,'336'),('3777',2,3,'331'),('3777',2,3,'335'),('3893',2,3,'480'),('3894',3,3,'480'),('3921',1,2,'480'),('3922',2,3,'480'),('3927',3,3,'480'),('3971',2,2,'336'),('4709',2,3,'929'),('4711',3,3,'929'),('49121',1,16,'25A'),('49121',2,12,'25A'),('49121',3,12,'25A'),('5071',1,12,'344'),('5075',1,12,'344'),('5557',1,4,'480'),('5558',2,4,'480'),('5559',3,4,'480'),('6902',1,5,'125'),('6902',2,5,'125'),('6902',3,4,'125'),('7175',1,4,'237'),('7176',2,4,'237'),('7565',1,3,'929'),('7568',2,3,'929'),('8077',3,0,'125'),('TOC',1,3,'125'),('TOC',2,3,'125'),('TOC',3,3,'125');
/*!40000 ALTER TABLE `tiene_ta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trayecto`
--

DROP TABLE IF EXISTS `trayecto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trayecto` (
  `Grado` int(2) NOT NULL,
  `IdOrientacion` varchar(4) NOT NULL,
  `Modulo` int(2) NOT NULL,
  PRIMARY KEY (`Grado`,`IdOrientacion`),
  KEY `IdOrientacion` (`IdOrientacion`),
  CONSTRAINT `trayecto_ibfk_1` FOREIGN KEY (`IdOrientacion`) REFERENCES `orientacion` (`IdOrientacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trayecto`
--

LOCK TABLES `trayecto` WRITE;
/*!40000 ALTER TABLE `trayecto` DISABLE KEYS */;
INSERT INTO `trayecto` VALUES (1,'007',0),(1,'008',0),(1,'107',0),(1,'125',0),(1,'237',0),(1,'25A',0),(1,'336',0),(1,'344',0),(1,'397',0),(1,'401',0),(1,'480',0),(1,'929',0),(2,'008',0),(2,'125',0),(2,'237',0),(2,'25A',0),(2,'331',0),(2,'335',0),(2,'336',0),(2,'480',0),(2,'929',0),(3,'008',0),(3,'125',0),(3,'25A',0),(3,'331',0),(3,'335',0),(3,'336',0),(3,'480',0),(3,'929',0);
/*!40000 ALTER TABLE `trayecto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `turno`
--

DROP TABLE IF EXISTS `turno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `turno` (
  `IdTurno` int(2) NOT NULL,
  `NombreTurno` varchar(30) NOT NULL,
  PRIMARY KEY (`IdTurno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `turno`
--

LOCK TABLES `turno` WRITE;
/*!40000 ALTER TABLE `turno` DISABLE KEYS */;
INSERT INTO `turno` VALUES (1,'Matutino'),(2,'Vespertino'),(3,'Nocturno');
/*!40000 ALTER TABLE `turno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuario` (
  `CiPersona` varchar(8) NOT NULL,
  `NombrePersona` varchar(25) DEFAULT NULL,
  `ApellidoPersona` varchar(25) DEFAULT NULL,
  `TipoUsuario` varchar(13) NOT NULL,
  `ContraseñaUsuario` varchar(25) NOT NULL,
  `AprobacionUsuario` tinyint(1) NOT NULL,
  PRIMARY KEY (`CiPersona`),
  CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`CiPersona`) REFERENCES `persona` (`CiPersona`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES ('00000000','Victoria','Bolsi','Administrador','00000000',1),('12345678','Ignacio','Rodríguez','Funcionario','12345678',1);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Final view structure for view `asignaturasgrupo`
--

/*!50001 DROP VIEW IF EXISTS `asignaturasgrupo`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `asignaturasgrupo` AS select distinct `asignatura`.`NombreAsignatura` AS `NombreAsignatura`,concat(`persona`.`NombrePersona`,' ',`persona`.`ApellidoPersona`) AS `NombreProfesor`,`grupo`.`Grado` AS `Grado`,`grupo`.`IdGrupo` AS `IdGrupo` from ((((`tiene_ta` join `asignatura`) join `genera`) join `persona`) join `grupo`) where ((`genera`.`Grado` = '1') and (`genera`.`IdGrupo` = 'BG') and (`genera`.`IdOrientacion` = `grupo`.`IdOrientacion`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `asignaturasorientaciones`
--

/*!50001 DROP VIEW IF EXISTS `asignaturasorientaciones`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `asignaturasorientaciones` AS select `tiene_ta`.`IdOrientacion` AS `IdOrientacion`,`tiene_ta`.`Grado` AS `Grado`,`asignatura`.`IdAsignatura` AS `IdAsignatura`,`tiene_ta`.`CargaHoraria` AS `CargaHoraria`,`asignatura`.`NombreAsignatura` AS `NombreAsignatura` from (`tiene_ta` join `asignatura`) where (`tiene_ta`.`IdAsignatura` = `asignatura`.`IdAsignatura`) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `asignaturastomadas`
--

/*!50001 DROP VIEW IF EXISTS `asignaturastomadas`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `asignaturastomadas` AS select `tiene_ag`.`IdAsignatura` AS `IdAsignatura`,`tiene_ag`.`IdGrupo` AS `IdGrupo`,`tiene_ag`.`Grado` AS `Grado` from `tiene_ag` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `calendario`
--

/*!50001 DROP VIEW IF EXISTS `calendario`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `calendario` AS select `asignatura`.`IdAsignatura` AS `IdAsignatura`,`genera`.`HoraInicio` AS `HoraInicio`,date_format(`genera`.`HoraInicio`,'%H:%i') AS `HoraOrden`,concat(date_format(`genera`.`HoraInicio`,'%H:%i'),' - ',date_format(`genera`.`HoraFin`,'%H:%i')) AS `Hora`,`genera`.`Dia` AS `Dia`,concat(`genera`.`Grado`,' ',`genera`.`IdGrupo`) AS `Grupo`,concat(`persona`.`NombrePersona`,' ',`persona`.`ApellidoPersona`) AS `NombreProfesor`,`persona`.`CiPersona` AS `CiPersona`,`asignatura`.`NombreAsignatura` AS `Materia` from ((`genera` join `asignatura`) join `persona`) where ((`genera`.`IdAsignatura` = `asignatura`.`IdAsignatura`) and (`genera`.`CiPersona` = `persona`.`CiPersona`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `datosgrupos`
--

/*!50001 DROP VIEW IF EXISTS `datosgrupos`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `datosgrupos` AS select `grupo`.`IdSalon` AS `Salon`,`orientacion`.`IdOrientacion` AS `IdOrientacion`,`orientacion`.`NombreOrientacion` AS `Orientacion`,`curso`.`NombreCurso` AS `Curso`,`grupo`.`Grado` AS `Grado`,`grupo`.`IdGrupo` AS `IdGrupo`,`turno`.`NombreTurno` AS `NombreTurno` from (((`curso` join `orientacion`) join `grupo`) join `turno`) where ((`grupo`.`IdTurno` = `turno`.`IdTurno`) and (`orientacion`.`IdOrientacion` = `grupo`.`IdOrientacion`) and (`orientacion`.`IdCurso` = `curso`.`IdCurso`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `grupos`
--

/*!50001 DROP VIEW IF EXISTS `grupos`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `grupos` AS select `grupo`.`IdGrupo` AS `IdGrupo`,concat(`grupo`.`Grado`,`grupo`.`IdGrupo`) AS `Grupo` from `grupo` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `profesorensenia`
--

/*!50001 DROP VIEW IF EXISTS `profesorensenia`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `profesorensenia` AS select `calendario`.`HoraOrden` AS `HoraOrden`,`calendario`.`Dia` AS `Dia`,`calendario`.`CiPersona` AS `CiPersona`,concat(`persona`.`NombrePersona`,' ',`persona`.`ApellidoPersona`) AS `NombreProfesor` from (`calendario` join `persona`) where (`calendario`.`CiPersona` = `persona`.`CiPersona`) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-10-26 21:50:30
