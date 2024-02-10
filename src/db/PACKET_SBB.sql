-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Feb 10, 2024 at 01:52 PM
-- Server version: 8.0.31
-- PHP Version: 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sbb_database`
--

-- --------------------------------------------------------

--
-- Table structure for table `packet`
--

DROP TABLE IF EXISTS `packet`;
CREATE TABLE IF NOT EXISTS `packet` (
  `PacketID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(191) NOT NULL,
  `Price` double NOT NULL,
  PRIMARY KEY (`PacketID`),
  UNIQUE KEY `Name` (`Name`)
) ENGINE=MyISAM AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `packet`
--

INSERT INTO `packet` (`PacketID`, `Name`, `Price`) VALUES
(1, 'NET 30', 1000),
(2, 'NET 50', 2000),
(3, 'NET 100', 3000),
(4, 'TV 100', 1000),
(5, 'TV 500', 500),
(6, 'TV 1000', 1500),
(7, 'BOX 4', 2000),
(8, 'BOX 6', 3000),
(9, 'BOX 10', 5000),
(10, 'TV 250', 750),
(11, 'TEST', 500),
(12, 'TESTTV', 1000),
(13, 'TESTCOMB', 3000),
(14, 'TESTTV2', 1500),
(15, 'TESTCOMB2', 1456),
(16, 'RAND', 1000),
(17, 'INT1', 50),
(18, 'INT 2', 300);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
