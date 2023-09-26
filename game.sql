-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Apr 16, 2023 at 05:25 PM
-- Server version: 5.7.24
-- PHP Version: 8.0.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `game`
--

-- --------------------------------------------------------

--
-- Table structure for table `cost_table`
--

CREATE TABLE `cost_table` (
  `id_cost` int(10) UNSIGNED NOT NULL,
  `valiecost` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `cost_table`
--

INSERT INTO `cost_table` (`id_cost`, `valiecost`) VALUES
(1, 2000),
(2, 4000),
(3, 10000),
(4, 25000),
(5, 75000);

-- --------------------------------------------------------

--
-- Table structure for table `player`
--

CREATE TABLE `player` (
  `Id` int(11) UNSIGNED NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Endurance` varchar(101) NOT NULL,
  `Level` int(10) UNSIGNED NOT NULL,
  `Experiense` int(255) NOT NULL,
  `SkillPoint` int(10) UNSIGNED NOT NULL,
  `Points_pursuit` int(100) NOT NULL,
  `Money` varchar(100) NOT NULL,
  `CostExpLevelUP` int(10) UNSIGNED NOT NULL,
  `LoseAttack` tinyint(1) NOT NULL,
  `gamewin` int(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `player`
--

INSERT INTO `player` (`Id`, `Name`, `Endurance`, `Level`, `Experiense`, `SkillPoint`, `Points_pursuit`, `Money`, `CostExpLevelUP`, `LoseAttack`, `gamewin`) VALUES
(0, 'Player1', '100', 1, 0, 2, 0, '16000', 1000, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `skills`
--

CREATE TABLE `skills` (
  `id` int(11) UNSIGNED NOT NULL,
  `Name` varchar(100) NOT NULL,
  `numbplayer` int(10) UNSIGNED NOT NULL,
  `Description` text NOT NULL,
  `Level` int(2) UNSIGNED NOT NULL,
  `GroupsSkills` int(2) UNSIGNED NOT NULL,
  `EnergoCost` int(10) UNSIGNED NOT NULL,
  `Attackcostmoney` int(10) UNSIGNED NOT NULL,
  `Status` tinyint(1) NOT NULL,
  `id_cost` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Характеристики умений(скилов)';

--
-- Dumping data for table `skills`
--

INSERT INTO `skills` (`id`, `Name`, `numbplayer`, `Description`, `Level`, `GroupsSkills`, `EnergoCost`, `Attackcostmoney`, `Status`, `id_cost`) VALUES
(1, 'УПО1', 1, 'Угроза незначительного потенциала, направленная на уязвимости программного обеспечения', 1, 1, 4, 500, 0, 1),
(2, 'УПО2', 1, 'Угроза низкого потенциала, направленная на уязвимости программного обеспечения', 2, 1, 10, 1000, 0, 2),
(3, 'УПО3', 1, 'Угроза среднего потенциала, направленная на уязвимости программного обеспечения', 3, 1, 16, 2000, 0, 3),
(4, 'УПО4', 1, 'Угроза высокого потенциала, направленная на уязвимости программного обеспечения', 4, 1, 22, 5000, 0, 4),
(5, 'УПО5', 1, 'Угроза наивысшего потенциала, направленная на уязвимости программного обеспечения', 5, 1, 30, 7500, 0, 5),
(6, 'УСУБД1', 1, 'Угроза незначительного потенциала, направленная на уязвимости средств управления базами данных', 1, 2, 4, 500, 0, 1),
(7, 'УСУБД2', 1, 'Угроза низкого потенциала, направленная на уязвимости средств управления базами данных', 2, 2, 10, 1000, 0, 2),
(8, 'УСУБД3', 1, 'Угроза среднего потенциала, направленная на уязвимости средств управления базами данных', 3, 2, 16, 2000, 0, 3),
(9, 'УСУБД4', 1, 'Угроза высокого потенциала, направленная на уязвимости средств управления базами данных', 4, 2, 22, 5000, 0, 4),
(10, 'УСУБД5', 1, 'Угроза наивысшего потенциала, направленная на уязвимости средств управления базами данных', 5, 2, 30, 7500, 0, 5),
(11, 'УОС1', 1, 'Угроза незначительного потенциала, направленная на уязвимости операционной системы', 1, 3, 4, 500, 0, 1),
(12, 'УОС2', 1, 'Угроза низкого потенциала, направленная на уязвимости операционной системы', 2, 3, 10, 1000, 0, 2),
(13, 'УОС3', 1, 'Угроза среднего потенциала, направленная на уязвимости операционной системы', 3, 3, 16, 2000, 0, 3),
(14, 'УОС4', 1, 'Угроза высокого потенциала, направленная на уязвимости операционной системы', 4, 3, 22, 5000, 0, 4),
(15, 'УОС5', 1, 'Угроза наивысшего потенциала, направленная на уязвимости операционной системы', 5, 3, 30, 7500, 0, 5),
(16, 'УСУ1', 1, 'Угроза незначительного потенциала, направленная на уязвимости сетевых устройств', 1, 4, 4, 500, 0, 1),
(17, 'УСУ2', 1, 'Угроза низкого потенциала, направленная на уязвимости сетевых устройств', 2, 4, 10, 1000, 0, 2),
(18, 'УСУ3', 1, 'Угроза среднего потенциала, направленная на уязвимости сетевых устройств', 3, 4, 16, 2000, 0, 3),
(19, 'УСУ4', 1, 'Угроза высокого потенциала, направленная на уязвимости сетевых устройств', 4, 4, 22, 5000, 0, 4),
(20, 'УСУ5', 1, 'Угроза наивысшего потенциала, направленная на уязвимости сетевых устройств', 5, 4, 30, 7500, 0, 5),
(21, 'Research', 1, 'Исследование уязвимости предприятия', 0, 0, 10, 2000, 0, 1);

-- --------------------------------------------------------

--
-- Table structure for table `vulnerabilities`
--

CREATE TABLE `vulnerabilities` (
  `id` int(11) UNSIGNED NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Description` text NOT NULL,
  `Level` int(2) UNSIGNED NOT NULL,
  `GroupsVulner` int(2) UNSIGNED NOT NULL,
  `Prize` int(10) UNSIGNED NOT NULL,
  `Exp` int(8) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `vulnerabilities`
--

INSERT INTO `vulnerabilities` (`id`, `Name`, `Description`, `Level`, `GroupsVulner`, `Prize`, `Exp`) VALUES
(1, 'BDU:2022-00828', 'Уязвимость функции postclose() ядра операционной системы Linux ', 1, 1, 2000, 100),
(2, 'BDU:2019-00630', 'Уязвимость компонента Server: Packaging системы управления базами данных Oracle MySQL Server, связаная с недостатками контроля доступа', 1, 2, 2000, 100),
(3, 'BDU:2021-05414', 'Уязвимость программного обеспечения графических процессоров NVIDIA GeForce, Studio, RTX/Quadro, NVS и Tesla, связаная с ошибками обработки жестких ссылок', 1, 3, 2000, 100),
(4, 'BDU:2021-04500', 'Уязвимость DNS-клиента стеков TCP/IP NicheLite и InterNiche, связаная с недостатками прогнозирования', 1, 4, 2000, 100),
(5, 'BDU:2022-00783', 'Уязвимость Защитника Microsoft (Windows Defender) операционных систем Windows, связаная с ошибками в настройках безопасности', 2, 1, 5000, 200),
(6, 'BDU:2021-00517', 'Уязвимость компонента InnoDB системы управления базами данных MySQL Server, связанная с недостаточной проверки входных данных', 2, 2, 5000, 200),
(7, 'BDU:2022-00589', 'Уязвимость стандартного пакета служебных утилит командной строки util-linux, связаная с некорректными разрешениями и привилегиями доступа', 2, 3, 5000, 200),
(8, 'BDU:2021-01918', 'Уязвимость реализации механизма разделения сетей пятого поколения (5G-сети) на множество независимых виртуальных сетей «Network Slicing», связаная с отсутствием сопоставления между идентификаторами прикладного и транспортного уровней', 2, 4, 5000, 200),
(9, 'BDU:2022-00788', 'Уязвимость файловой системы Resilient File System (ReFS) операционных систем Windows, связаная с ошибками управления генерацией кода', 3, 1, 10000, 500),
(10, 'BDU:2021-00693', 'Уязвимость компонента Server: Replication системы управления базами данных MySQL Server связана с недостатками разграничения доступа', 3, 2, 10000, 500),
(11, 'BDU:2022-00628', 'Уязвимость программ просмотра и редактирования PDF-файлов Adobe Acrobat, связаная с раскрытием информации', 3, 3, 10000, 500),
(12, 'BDU:2022-00517', 'язвимость микропрограммного обеспечения IP-Cisco IP Phone, связаная с незашифрованным хранением конфиденциальной информации', 3, 4, 10000, 500),
(13, 'BDU:2022-00784', 'Уязвимость компонента Windows Installer операционных систем Windows, связаная с недостатками разграничения доступа', 4, 1, 15000, 1000),
(14, 'BDU:2020-03627', 'Уязвимость компонента Server: Security: Privileges системы управления базами данных Oracle MySQL Server, связаная с недостатками разграничения доступа', 4, 2, 15000, 1000),
(15, 'BDU:2022-00745', 'Уязвимость реализации push-уведомлений браузера Google Chrome, связаная с некорректной проверкой безопасности для стандартных элементов', 4, 3, 15000, 1000),
(16, 'BDU:2022-00476', 'язвимость встроенного программного обеспечения Wi-Fi роутеров NETGEAR, связаная с отсутствием мер по очистке входных данных', 4, 4, 15000, 1000),
(17, 'BDU:2022-00696', 'Уязвимость компонента Windows Security Center API операционной системы Windows, связанная с неверным управлением генерацией кода', 5, 1, 20000, 2000),
(18, 'BDU:2016-01121', 'Уязвимость системы управления базами данных MySQL, связаная с ошибками в коде', 5, 2, 20000, 2000),
(19, 'BDU:2022-00583', 'Уязвимость компонента PIL.ImageMath.eval библиотеки изображений Python Pillow, связаная с использованием опасных методов или функций', 5, 3, 20000, 2000),
(20, 'BDU:2022-00762', 'Уязвимость микропрограммного обеспечения беспроводных маршрутизаторов D-Link DIR-882, связаная с некорректной обработкой параметра LocalIPAddress', 5, 4, 20000, 2000),
(21, 'BDU:2019-03234', 'Уязвимость подкомпонента Server : Compiling компонента MySQL Server системы управления базами данных Oracle MySQL связана с неправильным контролем доступа. ', 1, 2, 2000, 100),
(22, 'BDU:2020-00272', 'Уязвимость компонента Server: Information Schema системы управления базами данных MySQL Server связана с недостатками контроля доступа.', 2, 2, 5000, 200),
(23, 'BDU:2021-02476', 'язвимость компонента Server: Options системы управления базами данных Oracle MySQL Server связана с недостаточной проверкой входных данных', 3, 2, 10000, 500),
(24, 'BDU:2020-03699', 'Уязвимость компонента Server: Optimizer системы управления базами данных MySQL Server связана с недостаточной проверкой вводимых данных', 4, 2, 15000, 1000),
(25, 'BDU:2021-05512', 'Уязвимость системы торговых центров электронной коммерции ECShop связана с непринятием мер по нейтрализации специальных элементов, используемых в SQL-запросах', 5, 2, 20000, 2000),
(26, 'BDU:2021-02142', 'Уязвимость реализации стека протоколов Treck TCP/IP связана с переполнением буфера в стеке', 1, 4, 2000, 100),
(28, 'BDU:2022-00303', 'Уязвимость класса Http2MultiplexHandler сетевого программного средства Netty связана с некорректной обработкой запроса при преобразовании HTTP/2 потока в HTTP/1.1', 2, 4, 5000, 200),
(29, 'BDU:2022-00882', 'Уязвимость веб-интерфейса управления службы защиты конечных точек Cisco Orbital связана с использованием открытой переадресации', 3, 4, 10000, 500),
(30, 'BDU:2022-00522', 'Уязвимость веб-интерфейса управления программного средства управления жизненным циклом сетей Cisco Prime Infrastructure и программного средства управления сетевыми сервисами Cisco Evolved Programmable Network Manager связана с недостаточной защитой структуры веб-страницы', 4, 4, 15000, 1000),
(31, 'BDU:2021-04493', 'Уязвимость DNS-клиента стеков TCP/IP NicheLite и InterNiche связана с ошибками при обработке параметров длины входных данных', 5, 4, 20000, 2000),
(32, 'BDU:2022-00094', 'Уязвимость функции pep_sock_accept (net/phonet/pep.c) ядра операционных систем Linux связана с недостаточной защитой служебных данных', 1, 1, 2000, 100),
(33, 'BDU:2021-06114', 'Уязвимость компонента Preferences операционных систем Mac OS, tvOS, iOS, iPadOS и watchOS связана с недостатками проверки имени пути к каталогу с ограниченным доступом', 2, 1, 4000, 200),
(34, 'BDU:2022-00869', 'Уязвимость реализации функции kvm_s390_guest_sida_op() подсистемы виртуализации Kernel-based Virtual Machine (KVM) ядра операционных систем Linux связана с недостаточной защитой служебных данных', 3, 1, 10000, 500),
(35, 'BDU:2022-00767', 'Уязвимость библиотеки Microsoft DWM Core Library операционных систем Windows связана с недостатками разграничения доступа', 4, 1, 15000, 1000),
(36, 'BDU:2022-00163', 'Уязвимость сетевого стека HTTP Protocol Stack операционных систем Microsoft Windows связана с выходом операции за границы буфера в памяти', 5, 1, 20000, 2000),
(37, 'BDU:2021-06406', 'Уязвимость утилиты iconv системной библиотеки GNU C Library (glibc) связана с переходом в бесконечный цикл', 1, 3, 2000, 100),
(38, 'BDU:2021-06010', 'Уязвимость утилиты cURL, связана с граничной ошибкой при отправке данных на сервер MQTT', 2, 3, 4000, 200),
(39, 'BDU:2022-00332', 'Уязвимость набора программных инструментов и библиотек для работы со смарт-картами OpenSC связана с выходом операции за границы буфера в памяти', 3, 3, 10000, 500),
(40, 'BDU:2022-00376', 'Уязвимость реализации проприетарного протокола управления микропрограммного обеспечения мультисервисных платформ Hitachi Energy FOX615 и XCM20 связана с недостатками обработки данных', 4, 3, 15000, 1000),
(41, 'BDU:2021-01657', 'Уязвимость интерфейса iControl REST API средств защиты приложений BIG-IP связана с недостатками разграничения доступа', 5, 3, 20000, 2000);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `cost_table`
--
ALTER TABLE `cost_table`
  ADD PRIMARY KEY (`id_cost`),
  ADD KEY `id_cost` (`id_cost`);

--
-- Indexes for table `player`
--
ALTER TABLE `player`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `skills`
--
ALTER TABLE `skills`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_cost` (`id_cost`),
  ADD KEY `id` (`id`);

--
-- Indexes for table `vulnerabilities`
--
ALTER TABLE `vulnerabilities`
  ADD UNIQUE KEY `id` (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `cost_table`
--
ALTER TABLE `cost_table`
  MODIFY `id_cost` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `player`
--
ALTER TABLE `player`
  MODIFY `Id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `skills`
--
ALTER TABLE `skills`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `vulnerabilities`
--
ALTER TABLE `vulnerabilities`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=42;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `skills`
--
ALTER TABLE `skills`
  ADD CONSTRAINT `skills_ibfk_1` FOREIGN KEY (`id_cost`) REFERENCES `cost_table` (`id_cost`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
