-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: localhost    Database: agencia_viajes
-- ------------------------------------------------------
-- Server version	5.7.30-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `agentesviajes`
--

DROP TABLE IF EXISTS `agentesviajes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agentesviajes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `NombreCompleto` varchar(255) NOT NULL,
  `CorreoElectronico` varchar(100) NOT NULL,
  `Contrasena` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agentesviajes`
--

LOCK TABLES `agentesviajes` WRITE;
/*!40000 ALTER TABLE `agentesviajes` DISABLE KEYS */;
/*!40000 ALTER TABLE `agentesviajes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contactoemergencia`
--

DROP TABLE IF EXISTS `contactoemergencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contactoemergencia` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `NombresCompletos` varchar(255) NOT NULL,
  `TelefonoContacto` varchar(20) NOT NULL,
  `ReservaId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `ReservaId` (`ReservaId`),
  CONSTRAINT `contactoemergencia_ibfk_1` FOREIGN KEY (`ReservaId`) REFERENCES `reservas` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contactoemergencia`
--

LOCK TABLES `contactoemergencia` WRITE;
/*!40000 ALTER TABLE `contactoemergencia` DISABLE KEYS */;
/*!40000 ALTER TABLE `contactoemergencia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `datosreserva`
--

DROP TABLE IF EXISTS `datosreserva`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `datosreserva` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FechaEntrada` date NOT NULL,
  `FechaSalida` date NOT NULL,
  `NombresHuespedes` varchar(255) NOT NULL,
  `NumeroHabitaciones` int(11) NOT NULL,
  `ReservaId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `ReservaId` (`ReservaId`),
  CONSTRAINT `datosreserva_ibfk_1` FOREIGN KEY (`ReservaId`) REFERENCES `reservas` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `datosreserva`
--

LOCK TABLES `datosreserva` WRITE;
/*!40000 ALTER TABLE `datosreserva` DISABLE KEYS */;
/*!40000 ALTER TABLE `datosreserva` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `habitaciones`
--

DROP TABLE IF EXISTS `habitaciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `habitaciones` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Tipo` varchar(50) NOT NULL,
  `CostoBase` decimal(10,2) NOT NULL,
  `Impuestos` decimal(5,2) NOT NULL,
  `HotelId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `HotelId` (`HotelId`),
  CONSTRAINT `habitaciones_ibfk_1` FOREIGN KEY (`HotelId`) REFERENCES `hoteles` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `habitaciones`
--

LOCK TABLES `habitaciones` WRITE;
/*!40000 ALTER TABLE `habitaciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `habitaciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hoteles`
--

DROP TABLE IF EXISTS `hoteles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hoteles` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(255) NOT NULL,
  `Direccion` varchar(255) NOT NULL,
  `Telefono` varchar(20) DEFAULT NULL,
  `CorreoElectronico` varchar(100) DEFAULT NULL,
  `Habilitado` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hoteles`
--

LOCK TABLES `hoteles` WRITE;
/*!40000 ALTER TABLE `hoteles` DISABLE KEYS */;
/*!40000 ALTER TABLE `hoteles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pasajeros`
--

DROP TABLE IF EXISTS `pasajeros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pasajeros` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `NombresApellidos` varchar(255) NOT NULL,
  `FechaNacimiento` date NOT NULL,
  `Genero` varchar(20) NOT NULL,
  `TipoDocumento` varchar(50) NOT NULL,
  `NumeroDocumento` varchar(50) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `TelefonoContacto` varchar(20) DEFAULT NULL,
  `ReservaId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `ReservaId` (`ReservaId`),
  CONSTRAINT `pasajeros_ibfk_1` FOREIGN KEY (`ReservaId`) REFERENCES `reservas` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pasajeros`
--

LOCK TABLES `pasajeros` WRITE;
/*!40000 ALTER TABLE `pasajeros` DISABLE KEYS */;
/*!40000 ALTER TABLE `pasajeros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reservas`
--

DROP TABLE IF EXISTS `reservas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reservas` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FechaReserva` datetime NOT NULL,
  `NombresHuespedes` varchar(255) NOT NULL,
  `NumeroHabitaciones` int(11) NOT NULL,
  `FechaEntrada` date NOT NULL,
  `FechaSalida` date NOT NULL,
  `HotelId` int(11) DEFAULT NULL,
  `HabitacionId` int(11) DEFAULT NULL,
  `DatosReservaId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `HotelId` (`HotelId`),
  KEY `HabitacionId` (`HabitacionId`),
  KEY `DatosReservaId` (`DatosReservaId`),
  CONSTRAINT `reservas_ibfk_1` FOREIGN KEY (`HotelId`) REFERENCES `hoteles` (`Id`),
  CONSTRAINT `reservas_ibfk_2` FOREIGN KEY (`HabitacionId`) REFERENCES `habitaciones` (`Id`),
  CONSTRAINT `reservas_ibfk_3` FOREIGN KEY (`DatosReservaId`) REFERENCES `datosreserva` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservas`
--

LOCK TABLES `reservas` WRITE;
/*!40000 ALTER TABLE `reservas` DISABLE KEYS */;
/*!40000 ALTER TABLE `reservas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reservashabitaciones`
--

DROP TABLE IF EXISTS `reservashabitaciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reservashabitaciones` (
  `ReservaId` int(11) NOT NULL,
  `HabitacionId` int(11) NOT NULL,
  PRIMARY KEY (`ReservaId`,`HabitacionId`),
  KEY `HabitacionId` (`HabitacionId`),
  CONSTRAINT `reservashabitaciones_ibfk_1` FOREIGN KEY (`ReservaId`) REFERENCES `reservas` (`Id`),
  CONSTRAINT `reservashabitaciones_ibfk_2` FOREIGN KEY (`HabitacionId`) REFERENCES `habitaciones` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservashabitaciones`
--

LOCK TABLES `reservashabitaciones` WRITE;
/*!40000 ALTER TABLE `reservashabitaciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `reservashabitaciones` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-08-11 19:14:10
