-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Хост: 127.0.0.1
-- Время создания: Июн 26 2020 г., 14:52
-- Версия сервера: 5.5.25
-- Версия PHP: 5.3.13

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- База данных: `traffic`
--

-- --------------------------------------------------------

--
-- Структура таблицы `all traffic`
--

CREATE TABLE IF NOT EXISTS `all traffic` (
  `flight` int(11) NOT NULL,
  `departure point` varchar(30) NOT NULL,
  `destination` varchar(30) NOT NULL,
  `train` int(11) NOT NULL,
  `platform` int(11) NOT NULL,
  `arrivalH` int(11) NOT NULL,
  `arrivalM` int(11) NOT NULL,
  `departureH` int(11) NOT NULL,
  `departureM` int(11) NOT NULL,
  `total` int(11) NOT NULL,
  `left` int(11) NOT NULL,
  KEY `flight` (`flight`,`train`),
  KEY `train` (`train`),
  KEY `departure point` (`departure point`),
  KEY `destination` (`destination`),
  KEY `destination_2` (`destination`),
  KEY `platform` (`platform`),
  KEY `arrivalH` (`arrivalH`),
  KEY `arrivalM` (`arrivalM`),
  KEY `departureM` (`departureM`),
  KEY `departureH` (`departureH`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `all traffic`
--

INSERT INTO `all traffic` (`flight`, `departure point`, `destination`, `train`, `platform`, `arrivalH`, `arrivalM`, `departureH`, `departureM`, `total`, `left`) VALUES
(123, 'Адлер', 'Санкт-Петербург', 1, 3, 12, 32, 12, 35, 216, 79),
(2314, 'Адлер', 'Москва', 2, 3, 21, 53, 22, 6, 184, 49);

-- --------------------------------------------------------

--
-- Структура таблицы `price`
--

CREATE TABLE IF NOT EXISTS `price` (
  `rout` int(11) NOT NULL,
  `train` int(11) NOT NULL,
  `departure` varchar(30) NOT NULL,
  `destination` varchar(30) NOT NULL,
  `type` varchar(2) NOT NULL,
  `cost` decimal(18,2) NOT NULL,
  KEY `train` (`type`),
  KEY `type` (`type`),
  KEY `rout` (`rout`),
  KEY `train_2` (`train`),
  KEY `departure` (`departure`),
  KEY `destination` (`destination`),
  KEY `type_2` (`type`),
  KEY `train_3` (`train`),
  KEY `departure_2` (`departure`),
  KEY `destination_2` (`destination`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `price`
--

INSERT INTO `price` (`rout`, `train`, `departure`, `destination`, `type`, `cost`) VALUES
(2314, 2, 'Краснодар', 'Москва', 'К', '4300.00'),
(2314, 2, 'Краснодар', 'Москва', 'СВ', '13000.00'),
(123, 1, 'Краснодар', 'Ростов', 'К', '1550.00'),
(123, 1, 'Краснодар', 'Ростов', 'СВ', '3600.00'),
(2314, 2, 'Краснодар', 'Ростов', 'П', '900.00'),
(2314, 2, 'Краснодар', 'Ростов', 'К', '1600.00'),
(123, 1, 'Краснодар', 'Лихая', 'К', '1900.00'),
(123, 1, 'Краснодар', 'Лихая', 'СВ', '4800.00'),
(2314, 2, 'Краснодар', 'Лихая', 'П', '1300.00'),
(2314, 2, 'Краснодар', 'Лихая', 'К', '2000.00'),
(123, 1, 'Краснодар', 'Каменская', 'К', '2300.00'),
(123, 1, 'Краснодар', 'Каменская', 'СВ', '5400.00'),
(2314, 2, 'Краснодар', 'Каменская', 'К', '2100.00'),
(2314, 2, 'Краснодар', 'Каменская', 'П', '1400.00'),
(123, 1, 'Краснодар', 'Россошь', 'К', '2700.00'),
(123, 1, 'Краснодар', 'Россошь', 'СВ', '6400.00'),
(2314, 2, 'Краснодар', 'Россошь', 'К', '2700.00'),
(2314, 2, 'Краснодар', 'Россошь', 'П', '1700.00'),
(123, 1, 'Краснодар', 'Воронеж', 'К', '3400.00'),
(123, 1, 'Краснодар', 'Воронеж', 'СВ', '7400.00'),
(2314, 2, 'Краснодар', 'Воронеж', 'К', '3200.00'),
(2314, 2, 'Краснодар', 'Воронеж', 'П', '1900.00'),
(123, 1, 'Краснодар', 'Грязи', 'К', '3500.00'),
(123, 1, 'Краснодар', 'Грязи', 'СВ', '7800.00'),
(123, 1, 'Краснодар', 'Мичуринск', 'П', '3100.00'),
(123, 1, 'Краснодар', 'Мичуринск', 'К', '4600.00'),
(123, 1, 'Краснодар', 'Богоявленск', 'К', '4400.00'),
(123, 1, 'Краснодар', 'Богоявленск', 'СВ', '7600.00'),
(123, 1, 'Краснодар', 'Рязань', 'К', '4900.00'),
(123, 1, 'Краснодар', 'Рязань', 'СВ', '9800.00'),
(123, 1, 'Краснодар', 'Тверь', 'К', '6100.00'),
(123, 1, 'Краснодар', 'Тверь', 'СВ', '11300.00'),
(123, 1, 'Краснодар', 'Вышний Волочек', 'К', '6100.00'),
(123, 1, 'Краснодар', 'Вышний Волочек', 'СВ', '11100.00'),
(123, 1, 'Краснодар', 'Бологое', 'П', '3600.00'),
(123, 1, 'Краснодар', 'Бологое', 'К', '5900.00'),
(123, 1, 'Краснодар', 'Окуловка', 'К', '6600.00'),
(123, 1, 'Краснодар', 'Окуловка', 'СВ', '11800.00'),
(123, 1, 'Краснодар', 'Малая Вишера', 'П', '4400.00'),
(123, 1, 'Краснодар', 'Малая Вишера', 'К', '4200.00'),
(123, 1, 'Краснодар', 'Санкт-Петербург', 'П', '4200.00'),
(123, 1, 'Краснодар', 'Санкт-Петербург', 'К', '7000.00');

-- --------------------------------------------------------

--
-- Структура таблицы `rout`
--

CREATE TABLE IF NOT EXISTS `rout` (
  `flight` int(11) NOT NULL,
  `station` varchar(30) NOT NULL,
  `id` int(11) NOT NULL,
  `travel time` varchar(15) DEFAULT NULL,
  `stop time` int(11) DEFAULT NULL,
  KEY `flight` (`flight`,`id`),
  KEY `flight_2` (`flight`),
  KEY `station` (`station`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `rout`
--

INSERT INTO `rout` (`flight`, `station`, `id`, `travel time`, `stop time`) VALUES
(123, 'Сочи', 1, '0:34', 4),
(123, 'Лазаревск', 2, '0:30', 6),
(123, 'Туапсе', 3, '1:30', 12),
(123, 'Горячий Ключ', 4, '1:50', 42),
(123, 'Краснодар', 5, '1:30', 4),
(123, 'Ростов', 6, '2:50', 18),
(123, 'Лихая', 7, '3:45', 26),
(123, 'Каменская', 8, '0:55', 2),
(123, 'Россошь', 9, '3:00', 13),
(123, 'Воронеж', 10, '1:45', 39),
(123, 'Грязи', 11, '1:30', 5),
(123, 'Мичуринск', 12, '2:20', 12),
(123, 'Богоявленск', 13, '1:15', 2),
(123, 'Рязань', 14, '1:10', 12),
(123, 'Тверь', 15, '3:40', 2),
(123, 'Вышний Волочек', 16, '1:20', 1),
(123, 'Бологое', 17, '0:40', 1),
(123, 'Окуловка', 18, '0:50', 3),
(123, 'Малая Вишера', 19, '0:50', 1),
(123, 'Санкт-Петербург', 20, '2:30', 0),
(2314, 'Адлер', 1, NULL, NULL),
(2314, 'Сочи', 2, '0:34', 10),
(2314, 'Лазаревск', 3, '1:19', 3),
(2314, 'Туапсе', 4, '0:57', 16),
(2314, 'Горячий Ключ', 5, '1:25', 42),
(2314, 'Краснодар', 6, '1:47', 13),
(2314, 'Ростов', 7, '3:43', 21),
(2314, 'Новочеркас', 8, '0:54', 2),
(2314, 'Шахтная', 9, '0:41', 2),
(2314, 'Сулин', 10, '0:33', 2),
(2314, 'Зверево', 11, '0:22', 2),
(2314, 'Лихая', 12, '0:57', 17),
(2314, 'Каменская', 13, '0:27', 2),
(2314, 'Миллерово', 14, '1:03', 2),
(2314, 'Кутейкиново', 15, '0:56', 3),
(2314, 'Россошь', 16, '2:04', 14),
(2314, 'Лиски', 17, '1:35', 4),
(2314, 'Воронеж', 18, '1:30', 45),
(2314, 'Курбатово', 19, '1:33', 2),
(2314, 'Касторн К', 20, '1:45', 10),
(2314, 'Черемисин', 21, '0:58', 15),
(2314, 'Курск', 22, '1:13', 54),
(2314, 'Орел', 23, '1:50', 8),
(2314, 'Тула', 24, '4:31', 22),
(2314, 'Москва', 25, '3:08', NULL),
(123, 'Адлер', 0, NULL, NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `trains`
--

CREATE TABLE IF NOT EXISTS `trains` (
  `departureH` int(11) NOT NULL,
  `departureM` int(11) NOT NULL,
  `flight` int(11) NOT NULL,
  `train` int(11) NOT NULL,
  `railway carriage` int(11) NOT NULL,
  `type` varchar(2) NOT NULL,
  `total` int(11) NOT NULL,
  `left` int(11) NOT NULL,
  KEY `railway carriage` (`railway carriage`,`type`),
  KEY `type` (`type`),
  KEY `departureH` (`departureH`),
  KEY `departureM` (`departureM`),
  KEY `flight` (`flight`),
  KEY `train` (`train`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `trains`
--

INSERT INTO `trains` (`departureH`, `departureM`, `flight`, `train`, `railway carriage`, `type`, `total`, `left`) VALUES
(12, 35, 123, 1, 3, 'К', 108, 42),
(12, 35, 123, 1, 2, 'П', 108, 37),
(22, 6, 2314, 2, 4, 'К', 144, 20),
(22, 6, 2314, 2, 2, 'СВ', 40, 29);

-- --------------------------------------------------------

--
-- Структура таблицы `types`
--

CREATE TABLE IF NOT EXISTS `types` (
  `type` varchar(2) NOT NULL,
  `name` varchar(30) NOT NULL,
  PRIMARY KEY (`type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `types`
--

INSERT INTO `types` (`type`, `name`) VALUES
('К', 'Купейный'),
('М', 'Мягкий'),
('П', 'Плацкартный'),
('С', 'Сидячий'),
('СВ', 'Спальный');

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `price`
--
ALTER TABLE `price`
  ADD CONSTRAINT `price_ibfk_5` FOREIGN KEY (`destination`) REFERENCES `rout` (`station`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `price_ibfk_1` FOREIGN KEY (`rout`) REFERENCES `all traffic` (`flight`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `price_ibfk_2` FOREIGN KEY (`train`) REFERENCES `all traffic` (`train`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `price_ibfk_3` FOREIGN KEY (`type`) REFERENCES `types` (`type`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `price_ibfk_4` FOREIGN KEY (`departure`) REFERENCES `rout` (`station`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `rout`
--
ALTER TABLE `rout`
  ADD CONSTRAINT `rout_ibfk_1` FOREIGN KEY (`flight`) REFERENCES `all traffic` (`flight`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `trains`
--
ALTER TABLE `trains`
  ADD CONSTRAINT `trains_ibfk_1` FOREIGN KEY (`type`) REFERENCES `types` (`type`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `trains_ibfk_2` FOREIGN KEY (`departureH`) REFERENCES `all traffic` (`departureH`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `trains_ibfk_4` FOREIGN KEY (`flight`) REFERENCES `all traffic` (`flight`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `trains_ibfk_5` FOREIGN KEY (`train`) REFERENCES `all traffic` (`train`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `trains_ibfk_6` FOREIGN KEY (`departureM`) REFERENCES `all traffic` (`departureM`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
