-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 18, 2024 at 01:03 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dressup`
--

-- --------------------------------------------------------

--
-- Table structure for table `characters`
--

CREATE TABLE `characters` (
  `id` int(11) NOT NULL,
  `name` varchar(50) DEFAULT NULL,
  `age` varchar(20) DEFAULT NULL,
  `role` varchar(20) DEFAULT NULL,
  `bodytype` varchar(20) DEFAULT NULL,
  `skintone` varchar(20) DEFAULT NULL,
  `eyecolor` varchar(20) DEFAULT NULL,
  `markings` varchar(50) DEFAULT NULL,
  `expression` varchar(50) DEFAULT NULL,
  `hairstyle` varchar(50) DEFAULT NULL,
  `haircolor` varchar(50) DEFAULT NULL,
  `background` varchar(50) DEFAULT NULL,
  `lipcolor` varchar(50) DEFAULT NULL,
  `eyeshadow` varchar(50) DEFAULT NULL,
  `eyeliner` varchar(50) DEFAULT NULL,
  `eyebrow` varchar(50) DEFAULT NULL,
  `blush` varchar(50) DEFAULT NULL,
  `dress` varchar(50) DEFAULT NULL,
  `top` varchar(50) DEFAULT NULL,
  `bottom` varchar(50) DEFAULT NULL,
  `footwear` varchar(50) DEFAULT NULL,
  `weapon` varchar(50) DEFAULT NULL,
  `jewelry` varchar(50) DEFAULT NULL,
  `aura` tinyint(1) DEFAULT NULL,
  `protection` int(11) DEFAULT NULL,
  `healing` int(11) DEFAULT NULL,
  `divination` int(11) DEFAULT NULL,
  `curse` int(11) DEFAULT NULL,
  `manifestation` int(11) DEFAULT NULL,
  `affinity` varchar(50) DEFAULT NULL,
  `spell` varchar(50) DEFAULT NULL,
  `companion` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `characters`
--

INSERT INTO `characters` (`id`, `name`, `age`, `role`, `bodytype`, `skintone`, `eyecolor`, `markings`, `expression`, `hairstyle`, `haircolor`, `background`, `lipcolor`, `eyeshadow`, `eyeliner`, `eyebrow`, `blush`, `dress`, `top`, `bottom`, `footwear`, `weapon`, `jewelry`, `aura`, `protection`, `healing`, `divination`, `curse`, `manifestation`, `affinity`, `spell`, `companion`) VALUES
(1, 'Trisha', 'Middle-aged', 'Witch', 'Petite', 'Tan', 'Blue', 'Scars', 'Smiling', 'Curly', 'Fiery Red', 'Witch’s Potion Room', 'Dark Plum', 'Ocean Blue', 'Brown', 'Arched', 'None', 'Gothic', 'Crop Tops with Prints', 'Harem Pants', 'Magical Sandals', 'Mystic Orb', 'Elemental Bracelet', 1, 2, 1, 0, 3, 2, 'Water', 'Illusion Magic', 'Phoenix'),
(2, 'Cairelle', 'Toddler', 'Witch', 'Slim', 'Fair', 'Black', 'None', 'Smiling', 'Long', 'Brown', 'Enchanted Forest', 'Deep Black', 'None', 'None', 'Natural', 'None', 'Traditional', 'Flowy Bell Sleeve Tops', 'Long Flowing Skirts', 'Pointed Boots', 'Enchanted Staff', 'Moonstone Pendant', 1, 3, 3, 3, 1, 0, 'Fire', 'Potion Brewing', 'Frog');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `characters`
--
ALTER TABLE `characters`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `characters`
--
ALTER TABLE `characters`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
