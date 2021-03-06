-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Хост: 127.0.0.1
-- Время создания: Июн 29 2020 г., 04:29
-- Версия сервера: 5.5.25
-- Версия PHP: 5.3.13

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- База данных: `employee`
--

-- --------------------------------------------------------

--
-- Структура таблицы `personal data`
--

CREATE TABLE IF NOT EXISTS `personal data` (
  `login` varchar(20) NOT NULL,
  `surname` varchar(50) NOT NULL,
  `name` varchar(50) NOT NULL,
  `patronymic` varchar(50) DEFAULT NULL,
  `ticket window` int(11) DEFAULT NULL,
  `photo` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`login`),
  KEY `ticket window` (`ticket window`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `personal data`
--

INSERT INTO `personal data` (`login`, `surname`, `name`, `patronymic`, `ticket window`, `photo`) VALUES
('admin', 'Иерофантов', 'Анатолий', 'Иннокентьевич', 0, NULL),
('e0001', 'Смирнова', 'Мария', 'Васильевна', 1, 'z:\\user_photos\\kwpy9v6nsdqeh2at.jpg'),
('e0003', 'Андрафонов', 'Никандр', 'Феоктистович', 3, NULL),
('e0005', 'Соколов', 'Борис', 'Андреевич', 5, NULL),
('e0006', 'Дроздова', 'Виталина', 'Владиславовна', 1, NULL),
('galaxie', 'Галактионова', 'Валентина', 'Геннадьевна', 2, NULL),
('uzhasnakryliahnochi', 'Ван Дер Эретайн', 'Детлафф', '', 4, 'z:\\user_photos\\uzhasnakryliahnochi.png');

-- --------------------------------------------------------

--
-- Структура таблицы `sold tickets`
--

CREATE TABLE IF NOT EXISTS `sold tickets` (
  `ticket window` int(11) NOT NULL,
  `sold` int(11) NOT NULL,
  `sum` decimal(18,2) NOT NULL,
  PRIMARY KEY (`ticket window`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `sold tickets`
--

INSERT INTO `sold tickets` (`ticket window`, `sold`, `sum`) VALUES
(1, 0, '0.00'),
(2, 15, '68910.15'),
(3, 0, '0.00'),
(4, 15, '37039.20'),
(5, 0, '0.00');

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `login` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL DEFAULT '0000',
  `privileged` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`login`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`login`, `password`, `privileged`) VALUES
('admin', 'admin', 1),
('e0001', '0000', 0),
('e0003', '0000', 0),
('e0005', 'sokolov', 0),
('e0006', '0000', 0),
('galaxie', 'valya', 0),
('uzhasnakryliahnochi', 'sianna', 0);

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `personal data`
--
ALTER TABLE `personal data`
  ADD CONSTRAINT `personal@0020data_ibfk_1` FOREIGN KEY (`login`) REFERENCES `users` (`login`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
