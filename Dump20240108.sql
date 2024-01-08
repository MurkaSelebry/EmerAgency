-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: employment_agency
-- ------------------------------------------------------
-- Server version	8.0.35

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
-- Table structure for table `activitytypes`
--

DROP TABLE IF EXISTS `activitytypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `activitytypes` (
  `TypeID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `Description` text,
  PRIMARY KEY (`TypeID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `activitytypes`
--

LOCK TABLES `activitytypes` WRITE;
/*!40000 ALTER TABLE `activitytypes` DISABLE KEYS */;
INSERT INTO `activitytypes` VALUES (1,'IT','ИТ-компании'),(2,'Наука','Институты');
/*!40000 ALTER TABLE `activitytypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `deals`
--

DROP TABLE IF EXISTS `deals`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `deals` (
  `DealID` int NOT NULL AUTO_INCREMENT,
  `JobSeekerID` int DEFAULT NULL,
  `EmployerID` int DEFAULT NULL,
  `Position` varchar(255) DEFAULT NULL,
  `Commission` decimal(10,2) DEFAULT NULL,
  `ClosingDate` date DEFAULT NULL,
  PRIMARY KEY (`DealID`),
  KEY `JobSeekerID` (`JobSeekerID`),
  KEY `EmployerID` (`EmployerID`),
  CONSTRAINT `deals_ibfk_1` FOREIGN KEY (`JobSeekerID`) REFERENCES `jobseekers` (`JobSeekerID`),
  CONSTRAINT `deals_ibfk_2` FOREIGN KEY (`EmployerID`) REFERENCES `employers` (`EmployerID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `deals`
--

LOCK TABLES `deals` WRITE;
/*!40000 ALTER TABLE `deals` DISABLE KEYS */;
INSERT INTO `deals` VALUES (1,1,1,'Специалист',5000.00,'2024-01-08'),(2,1,1,'Специалист',5000.00,'2024-01-08'),(3,1,1,'Специалист',5000.00,'2024-01-08'),(4,1,1,'Специалист',5000.00,'2024-01-08');
/*!40000 ALTER TABLE `deals` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employers`
--

DROP TABLE IF EXISTS `employers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employers` (
  `EmployerID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `ActivityType` varchar(255) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `PhoneNumber` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`EmployerID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employers`
--

LOCK TABLES `employers` WRITE;
/*!40000 ALTER TABLE `employers` DISABLE KEYS */;
INSERT INTO `employers` VALUES (1,'Работадатель ООО Сбер','IT','Москва','123'),(2,'ГосТрансКонтроль','IT','Россия','123'),(3,'СПБГУ','Наука','СПБ','124'),(4,'Яндекс','IT','Кипр','1235');
/*!40000 ALTER TABLE `employers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jobseekers`
--

DROP TABLE IF EXISTS `jobseekers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `jobseekers` (
  `JobSeekerID` int NOT NULL AUTO_INCREMENT,
  `LastName` varchar(255) DEFAULT NULL,
  `FirstName` varchar(255) DEFAULT NULL,
  `Patronymic` varchar(255) DEFAULT NULL,
  `Qualification` varchar(255) DEFAULT NULL,
  `ActivityType` varchar(255) DEFAULT NULL,
  `OtherData` text,
  `ExpectedSalary` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`JobSeekerID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jobseekers`
--

LOCK TABLES `jobseekers` WRITE;
/*!40000 ALTER TABLE `jobseekers` DISABLE KEYS */;
INSERT INTO `jobseekers` VALUES (1,'Горбунов','Георгий','Анатольевич','Менеджер','IT','Привет, Я Георгий',90000.00),(2,'Ермолаев','Роман','Романович','Специалист','Наука','Привет, Я Роман',85000.00),(3,'Чистякова','Василиса','Константиновна','Работник','IT','Привет, Я Василиса',70000.00);
/*!40000 ALTER TABLE `jobseekers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vacancies`
--

DROP TABLE IF EXISTS `vacancies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vacancies` (
  `VacancyID` int NOT NULL AUTO_INCREMENT,
  `EmployerID` int DEFAULT NULL,
  `Description` text,
  `TypeID` int DEFAULT NULL,
  `StartingSalary` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`VacancyID`),
  KEY `EmployerID` (`EmployerID`),
  KEY `TypeID` (`TypeID`),
  CONSTRAINT `vacancies_ibfk_1` FOREIGN KEY (`EmployerID`) REFERENCES `employers` (`EmployerID`),
  CONSTRAINT `vacancies_ibfk_2` FOREIGN KEY (`TypeID`) REFERENCES `activitytypes` (`TypeID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vacancies`
--

LOCK TABLES `vacancies` WRITE;
/*!40000 ALTER TABLE `vacancies` DISABLE KEYS */;
INSERT INTO `vacancies` VALUES (1,1,'Работа Менеджером',1,100000.00),(3,2,'Работа Специалистом',1,70000.00),(4,3,'Научный сотрудник',2,60000.00),(5,4,'Программист',1,120000.00);
/*!40000 ALTER TABLE `vacancies` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-08 22:05:09
