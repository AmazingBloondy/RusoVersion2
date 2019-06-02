-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 13-05-2019 a las 04:15:46
-- Versión del servidor: 10.1.37-MariaDB
-- Versión de PHP: 7.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `importadora`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

CREATE TABLE `clientes` (
  `cod_cliente` int(3) NOT NULL,
  `primer_nombre` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `segundo_nombre` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `primer_apellido` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `segundo_apellido` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `dpi` varchar(15) COLLATE utf8_unicode_ci NOT NULL,
  `sexo` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `fecha_nacimiento` date NOT NULL,
  `direccion` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`cod_cliente`, `primer_nombre`, `segundo_nombre`, `primer_apellido`, `segundo_apellido`, `dpi`, `sexo`, `fecha_nacimiento`, `direccion`) VALUES
(1, 'Juan', 'Jose', 'Gamez', 'Blanco', '6547859600101', 'Masculino', '1998-05-05', 'Por Ahi'),
(2, 'Gustavo', 'Andres', 'Perez', 'Garcia', '9465132', 'Masculino', '2019-05-23', 'su casa');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `compras`
--

CREATE TABLE `compras` (
  `cod_compra` int(3) NOT NULL,
  `cod_empleado` int(3) NOT NULL,
  `cod_vehiculo` int(3) NOT NULL,
  `exportador` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `fecha_compra` date NOT NULL,
  `precio_vehiculo_quetzales` int(10) NOT NULL,
  `precio_total_quetzales` int(10) NOT NULL,
  `precio_dolar` varchar(45) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `compras`
--

INSERT INTO `compras` (`cod_compra`, `cod_empleado`, `cod_vehiculo`, `exportador`, `fecha_compra`, `precio_vehiculo_quetzales`, `precio_total_quetzales`, `precio_dolar`) VALUES
(1, 2, 1, 'EXP1', '2019-05-07', 50000, 50000, '7.8'),
(7, 2, 1, 'EXP1', '2019-05-12', 5241, 5742, '574');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `correos`
--

CREATE TABLE `correos` (
  `cod_correo` int(11) NOT NULL,
  `cod_propietario` int(11) NOT NULL,
  `correo` varchar(100) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `documentos`
--

CREATE TABLE `documentos` (
  `cod_documento` int(3) NOT NULL,
  `cod_vehiculo` int(3) NOT NULL,
  `num_titulo` int(20) NOT NULL,
  `num_tarjeta` int(20) NOT NULL,
  `placa` varchar(45) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empleados`
--

CREATE TABLE `empleados` (
  `cod_empleado` int(3) NOT NULL,
  `primer_nombre` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `segundo_nombre` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `primer_apellido` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `segundo_apellido` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `dpi` varchar(15) COLLATE utf8_unicode_ci NOT NULL,
  `sexo` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `fecha_nacimiento` date NOT NULL,
  `puesto` varchar(45) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `empleados`
--

INSERT INTO `empleados` (`cod_empleado`, `primer_nombre`, `segundo_nombre`, `primer_apellido`, `segundo_apellido`, `dpi`, `sexo`, `fecha_nacimiento`, `puesto`) VALUES
(2, 'randy', 'gabriel', 'choc', 'montes', '6451320', 'Masculino', '1998-05-05', 'COMPRADOR'),
(3, 'Edgar', 'ruben', 'casa', 'sola', '`6548132', 'Masculino', '2019-05-29', 'COMPRADOR');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estados_vehiculos`
--

CREATE TABLE `estados_vehiculos` (
  `cod_estado` int(3) NOT NULL,
  `estado` varchar(45) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `estados_vehiculos`
--

INSERT INTO `estados_vehiculos` (`cod_estado`, `estado`) VALUES
(1, 'mal');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `exportadores`
--

CREATE TABLE `exportadores` (
  `cod_exportador` int(3) NOT NULL,
  `nombre_exportador` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `pais` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `sitio_web` varchar(100) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `exportadores`
--

INSERT INTO `exportadores` (`cod_exportador`, `nombre_exportador`, `pais`, `sitio_web`) VALUES
(1, 'EXP1', 'USA', 'WWW.EXP1.COM'),
(3, 'EXPO', 'ucrania', 'www.expocaroskis.uc');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `formas_pago`
--

CREATE TABLE `formas_pago` (
  `cod_forma` int(3) NOT NULL,
  `forma` varchar(45) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `formas_pago`
--

INSERT INTO `formas_pago` (`cod_forma`, `forma`) VALUES
(1, 'gratis');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `log`
--

CREATE TABLE `log` (
  `NO` int(11) NOT NULL,
  `Usuario` varchar(255) NOT NULL,
  `operacion` text NOT NULL,
  `fecha` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `log`
--

INSERT INTO `log` (`NO`, `Usuario`, `operacion`, `fecha`) VALUES
(1, 'gus', 'LOG IN', '8/05/2019 11:52:43 p. m.'),
(2, 'gus', 'LOG IN', '8/05/2019 11:54:53 p. m.'),
(3, 'gus', 'LOG IN', '8/05/2019 11:56:26 p. m.'),
(4, 'gus', 'LOG IN', '9/05/2019 12:14:00 a. m.'),
(5, 'gus', 'LOG IN', '9/05/2019 12:14:30 a. m.'),
(6, 'gus', 'LOG IN', '9/05/2019 12:25:19 a. m.'),
(7, 'gus', 'LOG IN', '9/05/2019 12:29:49 a. m.'),
(8, 'gus', 'LOG IN', '9/05/2019 12:30:55 a. m.'),
(9, 'gus', 'LOG IN', '9/05/2019 12:37:56 a. m.'),
(10, 'gus', 'LOG IN', '9/05/2019 12:43:18 a. m.'),
(11, 'gus', 'LOG IN', '9/05/2019 12:44:25 a. m.'),
(12, 'gus', 'LOG IN', '9/05/2019 12:45:05 a. m.'),
(13, 'gus', 'LOG IN', '9/05/2019 12:46:01 a. m.'),
(14, 'Gustavo', 'LOG IN', '9/05/2019 12:46:59 a. m.'),
(15, 'gus', 'LOG IN', '12/05/2019 12:07:11 a. m.'),
(16, 'gus', 'LOG IN', '12/05/2019 12:18:48 a. m.'),
(17, 'gus', 'LOG IN', '12/05/2019 12:48:03 a. m.'),
(18, 'gus', 'DELETE FROM Talleres  WHERE  cod_taller =7', '12/05/2019 12:48:20 a. m.'),
(19, 'gus', 'LOG IN', '12/05/2019 12:48:36 a. m.'),
(20, 'gus', 'LOG IN', '12/05/2019 12:54:55 a. m.'),
(21, 'gus', 'LOG IN', '12/05/2019 2:08:43 a. m.'),
(22, 'Gustavo', 'LOG IN', '12/05/2019 2:30:22 a. m.'),
(23, 'gus', 'LOG IN', '12/05/2019 12:07:13 p. m.'),
(24, 'gus', 'LOG IN', '12/05/2019 12:12:27 p. m.'),
(25, 'gus', 'LOG IN', '12/05/2019 12:18:48 p. m.'),
(26, 'gus', 'LOG IN', '12/05/2019 12:20:45 p. m.'),
(27, 'gus', 'LOG IN', '12/05/2019 12:49:16 p. m.'),
(28, 'gus', 'LOG IN', '12/05/2019 12:50:03 p. m.'),
(29, 'gus', 'LOG IN', '12/05/2019 12:51:24 p. m.'),
(30, 'gus', 'LOG IN', '12/05/2019 12:51:55 p. m.'),
(31, 'gus', 'LOG IN', '12/05/2019 12:52:25 p. m.'),
(32, 'gus', 'LOG IN', '12/05/2019 12:52:50 p. m.'),
(33, 'gus', 'LOG IN', '12/05/2019 12:54:22 p. m.'),
(34, 'gus', 'LOG IN', '12/05/2019 12:55:46 p. m.'),
(35, 'gus', 'LOG IN', '12/05/2019 12:57:08 p. m.'),
(36, 'gus', 'LOG IN', '12/05/2019 12:59:31 p. m.'),
(37, 'gus', 'LOG IN', '12/05/2019 1:03:19 p. m.'),
(38, 'gus', 'LOG IN', '12/05/2019 1:06:02 p. m.'),
(39, 'gus', 'LOG IN', '12/05/2019 1:09:59 p. m.'),
(40, 'gus', 'LOG IN', '12/05/2019 1:10:27 p. m.'),
(41, 'gus', 'LOG IN', '12/05/2019 1:11:31 p. m.'),
(42, 'gus', 'LOG IN', '12/05/2019 1:22:41 p. m.'),
(43, 'gus', 'LOG IN', '12/05/2019 1:30:01 p. m.'),
(44, 'gus', 'LOG IN', '12/05/2019 1:31:15 p. m.'),
(45, 'gus', 'LOG IN', '12/05/2019 1:35:36 p. m.'),
(46, 'gus', 'LOG IN', '12/05/2019 1:35:52 p. m.'),
(47, 'gus', 'LOG IN', '12/05/2019 1:37:49 p. m.'),
(48, 'gus', 'LOG IN', '12/05/2019 1:41:22 p. m.'),
(49, 'gus', 'LOG IN', '12/05/2019 1:42:57 p. m.'),
(50, 'gus', 'LOG IN', '12/05/2019 1:53:13 p. m.'),
(51, 'gus', 'LOG IN', '12/05/2019 1:54:26 p. m.'),
(52, 'gus', 'LOG IN', '12/05/2019 1:55:25 p. m.'),
(53, 'gus', 'LOG IN', '12/05/2019 1:57:21 p. m.'),
(54, 'gus', 'LOG IN', '12/05/2019 1:58:12 p. m.'),
(55, 'gus', 'LOG IN', '12/05/2019 1:59:23 p. m.'),
(56, 'gus', 'INSERT INTO compras(cod_empleado, cod_vehiculo, exportador, fecha_compra, precio_vehiculo_quetzales, precio_total_quetzales, precio_dolar) VALUES (2,1,EXP1,2019-05-12,584455,856475,85)', '12/05/2019 1:59:44 p. m.'),
(57, 'gus', 'LOG IN', '12/05/2019 2:01:05 p. m.'),
(58, 'gus', 'DELETE FROM compras  WHERE  cod_compra =6', '12/05/2019 2:01:17 p. m.'),
(59, 'gus', 'LOG IN', '12/05/2019 2:02:28 p. m.'),
(60, 'gus', 'LOG IN', '12/05/2019 2:03:23 p. m.'),
(61, 'gus', 'LOG IN', '12/05/2019 2:04:48 p. m.'),
(62, 'gus', 'LOG IN', '12/05/2019 2:05:26 p. m.'),
(63, 'gus', 'LOG IN', '12/05/2019 3:01:53 p. m.'),
(64, 'gus', 'INSERT INTO compras(cod_empleado, cod_vehiculo, exportador, fecha_compra, precio_vehiculo_quetzales, precio_total_quetzales, precio_dolar) VALUES (2,1,EXP1,2019-05-12,5241,5742,574)', '12/05/2019 3:02:08 p. m.'),
(65, 'gus', 'LOG IN', '12/05/2019 3:03:46 p. m.'),
(66, 'gus', 'LOG IN', '12/05/2019 3:04:41 p. m.'),
(67, 'gus', 'UPDATE compras SET cod_empleado =2, cod_vehiculo = 1, exportador=EXP1, fecha_compra= 2019-05-12, precio_vehiculo_quetzales=5241,precio_total_quetzales=5742,precio_dolar=574 WHERE  cod_compra =7', '12/05/2019 3:04:47 p. m.'),
(68, 'gus', 'DELETE FROM compras  WHERE  cod_compra =2', '12/05/2019 3:05:01 p. m.'),
(69, 'gus', 'LOG IN', '12/05/2019 3:06:17 p. m.'),
(70, 'gus', 'LOG IN', '12/05/2019 3:07:17 p. m.'),
(71, 'gus', 'LOG IN', '12/05/2019 3:18:18 p. m.'),
(72, 'gus', 'LOG IN', '12/05/2019 3:19:09 p. m.'),
(73, 'gus', 'LOG IN', '12/05/2019 3:19:55 p. m.'),
(74, 'gus', 'LOG IN', '12/05/2019 4:01:40 p. m.'),
(75, 'gus', 'LOG IN', '12/05/2019 4:07:54 p. m.'),
(76, 'gus', 'INSERT INTO vehiculos(marca, modelo, transmision, millas, vin, anio, cc, color) VALUES (MAZDA,lkma,AUTOMATICA,6485,ad5,1998,50,verde)', '12/05/2019 4:08:28 p. m.'),
(77, 'gus', 'LOG IN', '12/05/2019 4:09:13 p. m.'),
(78, 'gus', 'INSERT INTO vehiculos(marca, modelo, transmision, millas, vin, anio, cc, color) VALUES (MAZDA,almkdlks,AUTOMATICA,876453,a;dl,sld,999,1600,kaka)', '12/05/2019 4:09:37 p. m.'),
(79, 'gus', 'DELETE FROM vehiculos  WHERE  cod_vehiculo =3', '12/05/2019 4:09:44 p. m.'),
(80, 'gus', 'LOG IN', '12/05/2019 4:25:33 p. m.'),
(81, 'gus', 'LOG IN', '12/05/2019 4:35:10 p. m.'),
(82, 'gus', 'UPDATE vehiculos SET marca= MAZDA, modelo=lkma,transmision=AUTOMATICA,millas=6485,vin=ad5,anio=1998,cc=50,color=verde WHERE cod_vehiculo=2', '12/05/2019 4:35:20 p. m.'),
(83, 'gus', 'UPDATE vehiculos SET marca= MAZDA, modelo=pocomchi,transmision=AUTOMATICA,millas=6485,vin=ad5,anio=1998,cc=50,color=verde WHERE cod_vehiculo=2', '12/05/2019 4:35:40 p. m.'),
(84, 'gus', 'LOG IN', '12/05/2019 5:15:18 p. m.'),
(85, 'gus', 'LOG IN', '12/05/2019 5:15:46 p. m.'),
(86, 'gus', 'LOG IN', '12/05/2019 5:25:30 p. m.'),
(87, 'gus', 'INSERT INTO clientes(primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, dpi, sexo, fecha_nacimiento, direccion) VALUES (Gustavo,andres,Perez,Garcia,9465132,Masculino,2019-05-23,su casa)', '12/05/2019 5:26:11 p. m.'),
(88, 'gus', 'LOG IN', '12/05/2019 5:27:31 p. m.'),
(89, 'gus', 'INSERT INTO clientes(primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, dpi, sexo, fecha_nacimiento, direccion) VALUES (adlka,lk,mlk,l,khml,Masculino,2019-05-12,lkm)', '12/05/2019 5:27:50 p. m.'),
(90, 'gus', 'DELETE FROM clientes  WHERE  cod_cliente =3', '12/05/2019 5:27:58 p. m.'),
(91, 'gus', 'LOG IN', '12/05/2019 5:29:35 p. m.'),
(92, 'gus', 'LOG IN', '12/05/2019 5:38:37 p. m.'),
(93, 'gus', 'LOG IN', '12/05/2019 5:39:15 p. m.'),
(94, 'gus', 'LOG IN', '12/05/2019 5:40:20 p. m.'),
(95, 'gus', 'UPDATE clientes SET primer_nombre= Gustavo,segundo_nombre=Andres,primer_apellido=Perez,segundo_apellido=Garcia,dpi=9465132,sexo=Masculino,fecha_nacimiento=2019-05-23,direccion=su casa		 WHERE cod_cliente = 2', '12/05/2019 5:40:32 p. m.'),
(96, 'gus', 'LOG IN', '12/05/2019 5:41:28 p. m.'),
(97, 'gus', 'LOG IN', '12/05/2019 5:49:24 p. m.'),
(98, 'gus', 'LOG IN', '12/05/2019 5:49:49 p. m.'),
(99, 'gus', 'LOG IN', '12/05/2019 5:52:25 p. m.'),
(100, 'gus', 'INSERT INTO empleados(primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, dpi, sexo, fecha_nacimiento, puesto) VALUES (Edgar,ruben,casa,sola,`6548132,Masculino,2019-05-29,COMPRADOR)', '12/05/2019 5:53:02 p. m.'),
(101, 'gus', 'LOG IN', '12/05/2019 5:53:57 p. m.'),
(102, 'gus', 'LOG IN', '12/05/2019 5:54:24 p. m.'),
(103, 'gus', 'UPDATE empleados SET primer_nombre= Edgar,segundo_nombre=ruben,primer_apellido=casa,segundo_apellido=sola,dpi=`6548132,sexo=Masculino,fecha_nacimiento=2019-05-29,puesto=COMPRADOR		 WHERE cod_empleado = 3', '12/05/2019 5:54:30 p. m.'),
(104, 'gus', 'INSERT INTO empleados(primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, dpi, sexo, fecha_nacimiento, puesto) VALUES (a,a,a,aa,a,Masculino,2019-05-29,COMPRADOR)', '12/05/2019 5:54:53 p. m.'),
(105, 'gus', 'LOG IN', '12/05/2019 5:55:29 p. m.'),
(106, 'gus', 'DELETE FROM empleados  WHERE  cod_empleado =4', '12/05/2019 5:55:34 p. m.'),
(107, 'gus', 'LOG IN', '12/05/2019 6:10:06 p. m.'),
(108, 'gus', 'INSERT INTO exportadores(nombre_exportador, pais, sitio_web) VALUES (EXPO,UCRANIA,www,expocars.com)', '12/05/2019 6:10:48 p. m.'),
(109, 'gus', 'DELETE FROM exportadores  WHERE  cod_exportador =2', '12/05/2019 6:11:00 p. m.'),
(110, 'gus', 'INSERT INTO exportadores(nombre_exportador, pais, sitio_web) VALUES (a,A,A)', '12/05/2019 6:11:11 p. m.'),
(111, 'gus', 'UPDATE Talleres SET nombre_exportador =EXPO, pais = ucrania, sitio_web=www.expocaroskis.uc WHERE  cod_exportador =3', '12/05/2019 6:11:47 p. m.'),
(112, 'gus', 'LOG IN', '12/05/2019 7:30:27 p. m.'),
(113, 'gus', 'LOG IN', '12/05/2019 7:31:07 p. m.'),
(114, 'gus', 'LOG IN', '12/05/2019 7:34:41 p. m.'),
(115, 'gus', 'INSERT INTO reparaciones(cod_vehiculo, cod_taller, fecha_entrega , fecha_devolucion, estado, detalles, precio_total) VALUES (2 - MAZDA verde,2,2019-05-17,2019-06-08,mal,aklsdml,50)', '12/05/2019 7:35:01 p. m.'),
(116, 'gus', 'LOG IN', '12/05/2019 7:37:13 p. m.'),
(117, 'gus', 'UPDATE reparaciones SET cod_vehiculo=2, cod_taller=2,fecha_entrega=2019-05-17,fecha_devolucion=2019-06-08,detalles=aklsdml,estado=mal,precio_total=50 WHERE cod_reparacion=1', '12/05/2019 7:37:22 p. m.'),
(118, 'gus', 'UPDATE reparaciones SET cod_vehiculo=2, cod_taller=2,fecha_entrega=2019-05-17,fecha_devolucion=2019-06-08,detalles=no tiene,estado=mal,precio_total=50 WHERE cod_reparacion=1', '12/05/2019 7:37:34 p. m.'),
(119, 'gus', 'INSERT INTO reparaciones(cod_vehiculo, cod_taller, fecha_entrega , fecha_devolucion, estado, detalles, precio_total) VALUES (1 - MAZDA AZUL,4,2019-05-17,2019-06-08,mal,lkaml,5)', '12/05/2019 7:38:00 p. m.'),
(120, 'gus', 'DELETE FROM reparaciones  WHERE  cod_reparacion =2', '12/05/2019 7:38:05 p. m.'),
(121, 'gus', 'LOG IN', '12/05/2019 7:42:28 p. m.'),
(122, 'gus', 'LOG IN', '12/05/2019 7:59:37 p. m.'),
(123, 'gus', 'LOG IN', '12/05/2019 8:01:17 p. m.'),
(124, 'gus', 'INSERT INTO ventas(cod_empleado, cod_vehiculo, cod_cliente, fecha_venta , forma_pago,  precio_total) VALUES (2,1,2,2019-05-31,gratis,50000)', '12/05/2019 8:01:36 p. m.'),
(125, 'gus', 'LOG IN', '12/05/2019 8:02:29 p. m.'),
(126, 'gus', 'LOG IN', '12/05/2019 8:03:47 p. m.'),
(127, 'gus', 'LOG IN', '12/05/2019 8:04:25 p. m.'),
(128, 'gus', 'UPDATE ventas SET cod_empleado= 2, cod_vehiculo=1, cod_cliente=2,fecha_venta=2019-05-31,forma_pago=gratis,precio_total=50000 WHERE cod_venta=2', '12/05/2019 8:04:37 p. m.'),
(129, 'gus', 'DELETE FROM ventas  WHERE  cod_venta =2', '12/05/2019 8:04:44 p. m.'),
(130, 'gus', 'LOG IN', '12/05/2019 8:13:18 p. m.'),
(131, 'gus', 'UPDATE ventas SET cod_empleado= 3, cod_vehiculo=1, cod_cliente=2,fecha_venta=2019-05-07,forma_pago=gratis,precio_total=5000 WHERE cod_venta=1', '12/05/2019 8:13:49 p. m.');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `marcas`
--

CREATE TABLE `marcas` (
  `cod_marca` int(3) NOT NULL,
  `marca` varchar(45) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `marcas`
--

INSERT INTO `marcas` (`cod_marca`, `marca`) VALUES
(1, 'MAZDA');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `puestos`
--

CREATE TABLE `puestos` (
  `cod_puesto` int(3) NOT NULL,
  `puesto` varchar(45) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `puestos`
--

INSERT INTO `puestos` (`cod_puesto`, `puesto`) VALUES
(1, 'COMPRADOR');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `reparaciones`
--

CREATE TABLE `reparaciones` (
  `cod_reparacion` int(3) NOT NULL,
  `cod_vehiculo` int(3) NOT NULL,
  `cod_taller` int(3) NOT NULL,
  `fecha_entrega` date NOT NULL,
  `fecha_devolucion` date NOT NULL,
  `estado` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `detalles` text COLLATE utf8_unicode_ci NOT NULL,
  `precio_total` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `reparaciones`
--

INSERT INTO `reparaciones` (`cod_reparacion`, `cod_vehiculo`, `cod_taller`, `fecha_entrega`, `fecha_devolucion`, `estado`, `detalles`, `precio_total`) VALUES
(1, 2, 2, '2019-05-17', '2019-06-08', 'mal', 'no tiene', 50);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sexos`
--

CREATE TABLE `sexos` (
  `cod_sexo` int(3) NOT NULL,
  `sexo` varchar(45) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `sexos`
--

INSERT INTO `sexos` (`cod_sexo`, `sexo`) VALUES
(2, 'Femenino'),
(1, 'Masculino');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `talleres`
--

CREATE TABLE `talleres` (
  `cod_taller` int(3) NOT NULL,
  `encargado` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `nombre_taller` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `direccion` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `talleres`
--

INSERT INTO `talleres` (`cod_taller`, `encargado`, `nombre_taller`, `direccion`) VALUES
(1, 'askma', 'LKAMSD', 'LAKSMDA'),
(2, 'a', 'a', 'a'),
(4, 'b', 'b', 'b'),
(5, 'a', 'a', 'a'),
(6, 'a', 'a', 'a');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `telefonos`
--

CREATE TABLE `telefonos` (
  `cod_telefono` int(3) NOT NULL,
  `cod_propietario` int(3) NOT NULL,
  `telefono` varchar(45) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `transmisiones`
--

CREATE TABLE `transmisiones` (
  `cod_transmision` int(3) NOT NULL,
  `transmision` varchar(45) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `transmisiones`
--

INSERT INTO `transmisiones` (`cod_transmision`, `transmision`) VALUES
(1, 'AUTOMATICA');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `Usuario` varchar(250) NOT NULL,
  `Password` varchar(250) DEFAULT NULL,
  `Nivel` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`Usuario`, `Password`, `Nivel`) VALUES
('5b6e65a1347c98855e86d1a4562d5342', 'b4288d9c0ec0a1841b3b3728321e7088', 'Admin'),
('84a26c4612a7f9958174ee6552625282', '84a26c4612a7f9958174ee6552625282', 'Admin');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `vehiculos`
--

CREATE TABLE `vehiculos` (
  `cod_vehiculo` int(3) NOT NULL,
  `marca` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `modelo` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `transmision` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `millas` int(10) NOT NULL,
  `vin` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `anio` int(4) NOT NULL,
  `cc` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `color` varchar(45) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `vehiculos`
--

INSERT INTO `vehiculos` (`cod_vehiculo`, `marca`, `modelo`, `transmision`, `millas`, `vin`, `anio`, `cc`, `color`) VALUES
(1, 'MAZDA', '3', 'AUTOMATICA', 1000, '63895KK', 2010, '1300', 'AZUL'),
(2, 'MAZDA', 'pocomchi', 'AUTOMATICA', 6485, 'ad5', 1998, '50', 'verde');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventas`
--

CREATE TABLE `ventas` (
  `cod_venta` int(3) NOT NULL,
  `cod_empleado` int(3) NOT NULL,
  `cod_vehiculo` int(3) NOT NULL,
  `cod_cliente` int(3) NOT NULL,
  `fecha_venta` date NOT NULL,
  `forma_pago` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `precio_total` varchar(45) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `ventas`
--

INSERT INTO `ventas` (`cod_venta`, `cod_empleado`, `cod_vehiculo`, `cod_cliente`, `fecha_venta`, `forma_pago`, `precio_total`) VALUES
(1, 3, 1, 2, '2019-05-07', 'gratis', '5000');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`cod_cliente`),
  ADD KEY `sexo` (`sexo`);

--
-- Indices de la tabla `compras`
--
ALTER TABLE `compras`
  ADD PRIMARY KEY (`cod_compra`),
  ADD KEY `exportador` (`exportador`),
  ADD KEY `cod_empleado` (`cod_empleado`),
  ADD KEY `cod_vehiculo` (`cod_vehiculo`);

--
-- Indices de la tabla `correos`
--
ALTER TABLE `correos`
  ADD PRIMARY KEY (`cod_correo`),
  ADD KEY `cod_propietario` (`cod_propietario`);

--
-- Indices de la tabla `documentos`
--
ALTER TABLE `documentos`
  ADD PRIMARY KEY (`cod_documento`),
  ADD KEY `cod_vehiculo` (`cod_vehiculo`);

--
-- Indices de la tabla `empleados`
--
ALTER TABLE `empleados`
  ADD PRIMARY KEY (`cod_empleado`),
  ADD KEY `tipo_puesto` (`puesto`),
  ADD KEY `sexo` (`sexo`);

--
-- Indices de la tabla `estados_vehiculos`
--
ALTER TABLE `estados_vehiculos`
  ADD PRIMARY KEY (`cod_estado`),
  ADD KEY `estado` (`estado`);

--
-- Indices de la tabla `exportadores`
--
ALTER TABLE `exportadores`
  ADD PRIMARY KEY (`cod_exportador`),
  ADD KEY `nombre_exportador` (`nombre_exportador`);

--
-- Indices de la tabla `formas_pago`
--
ALTER TABLE `formas_pago`
  ADD PRIMARY KEY (`cod_forma`),
  ADD KEY `forma` (`forma`);

--
-- Indices de la tabla `log`
--
ALTER TABLE `log`
  ADD PRIMARY KEY (`NO`);

--
-- Indices de la tabla `marcas`
--
ALTER TABLE `marcas`
  ADD PRIMARY KEY (`cod_marca`),
  ADD KEY `marca` (`marca`);

--
-- Indices de la tabla `puestos`
--
ALTER TABLE `puestos`
  ADD PRIMARY KEY (`cod_puesto`),
  ADD KEY `puesto` (`puesto`);

--
-- Indices de la tabla `reparaciones`
--
ALTER TABLE `reparaciones`
  ADD PRIMARY KEY (`cod_reparacion`),
  ADD KEY `cod_vehiculo` (`cod_vehiculo`),
  ADD KEY `cod_taller` (`cod_taller`),
  ADD KEY `estado` (`estado`);

--
-- Indices de la tabla `sexos`
--
ALTER TABLE `sexos`
  ADD PRIMARY KEY (`cod_sexo`),
  ADD KEY `sexo` (`sexo`);

--
-- Indices de la tabla `talleres`
--
ALTER TABLE `talleres`
  ADD PRIMARY KEY (`cod_taller`);

--
-- Indices de la tabla `telefonos`
--
ALTER TABLE `telefonos`
  ADD PRIMARY KEY (`cod_telefono`),
  ADD KEY `cod_propietario` (`cod_propietario`);

--
-- Indices de la tabla `transmisiones`
--
ALTER TABLE `transmisiones`
  ADD PRIMARY KEY (`cod_transmision`),
  ADD KEY `transmision` (`transmision`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`Usuario`);

--
-- Indices de la tabla `vehiculos`
--
ALTER TABLE `vehiculos`
  ADD PRIMARY KEY (`cod_vehiculo`),
  ADD KEY `marca` (`marca`),
  ADD KEY `transmision` (`transmision`);

--
-- Indices de la tabla `ventas`
--
ALTER TABLE `ventas`
  ADD PRIMARY KEY (`cod_venta`),
  ADD KEY `cod_empleado` (`cod_empleado`),
  ADD KEY `cod_vehiculo` (`cod_vehiculo`),
  ADD KEY `cod_cliente` (`cod_cliente`),
  ADD KEY `forma_pago` (`forma_pago`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `clientes`
--
ALTER TABLE `clientes`
  MODIFY `cod_cliente` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `compras`
--
ALTER TABLE `compras`
  MODIFY `cod_compra` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de la tabla `correos`
--
ALTER TABLE `correos`
  MODIFY `cod_correo` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `documentos`
--
ALTER TABLE `documentos`
  MODIFY `cod_documento` int(3) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `empleados`
--
ALTER TABLE `empleados`
  MODIFY `cod_empleado` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `estados_vehiculos`
--
ALTER TABLE `estados_vehiculos`
  MODIFY `cod_estado` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `exportadores`
--
ALTER TABLE `exportadores`
  MODIFY `cod_exportador` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `formas_pago`
--
ALTER TABLE `formas_pago`
  MODIFY `cod_forma` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `log`
--
ALTER TABLE `log`
  MODIFY `NO` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=132;

--
-- AUTO_INCREMENT de la tabla `marcas`
--
ALTER TABLE `marcas`
  MODIFY `cod_marca` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `puestos`
--
ALTER TABLE `puestos`
  MODIFY `cod_puesto` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `reparaciones`
--
ALTER TABLE `reparaciones`
  MODIFY `cod_reparacion` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `sexos`
--
ALTER TABLE `sexos`
  MODIFY `cod_sexo` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `talleres`
--
ALTER TABLE `talleres`
  MODIFY `cod_taller` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `telefonos`
--
ALTER TABLE `telefonos`
  MODIFY `cod_telefono` int(3) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `transmisiones`
--
ALTER TABLE `transmisiones`
  MODIFY `cod_transmision` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `vehiculos`
--
ALTER TABLE `vehiculos`
  MODIFY `cod_vehiculo` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `ventas`
--
ALTER TABLE `ventas`
  MODIFY `cod_venta` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD CONSTRAINT `clientes_ibfk_1` FOREIGN KEY (`sexo`) REFERENCES `sexos` (`sexo`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `compras`
--
ALTER TABLE `compras`
  ADD CONSTRAINT `compras_ibfk_1` FOREIGN KEY (`cod_empleado`) REFERENCES `empleados` (`cod_empleado`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `compras_ibfk_2` FOREIGN KEY (`cod_vehiculo`) REFERENCES `vehiculos` (`cod_vehiculo`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `compras_ibfk_3` FOREIGN KEY (`exportador`) REFERENCES `exportadores` (`nombre_exportador`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `correos`
--
ALTER TABLE `correos`
  ADD CONSTRAINT `correos_ibfk_1` FOREIGN KEY (`cod_propietario`) REFERENCES `empleados` (`cod_empleado`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `correos_ibfk_2` FOREIGN KEY (`cod_propietario`) REFERENCES `clientes` (`cod_cliente`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `correos_ibfk_3` FOREIGN KEY (`cod_correo`) REFERENCES `talleres` (`cod_taller`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `correos_ibfk_4` FOREIGN KEY (`cod_propietario`) REFERENCES `exportadores` (`cod_exportador`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `documentos`
--
ALTER TABLE `documentos`
  ADD CONSTRAINT `documentos_ibfk_1` FOREIGN KEY (`cod_vehiculo`) REFERENCES `vehiculos` (`cod_vehiculo`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `empleados`
--
ALTER TABLE `empleados`
  ADD CONSTRAINT `empleados_ibfk_1` FOREIGN KEY (`puesto`) REFERENCES `puestos` (`puesto`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `empleados_ibfk_2` FOREIGN KEY (`sexo`) REFERENCES `sexos` (`sexo`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `reparaciones`
--
ALTER TABLE `reparaciones`
  ADD CONSTRAINT `reparaciones_ibfk_1` FOREIGN KEY (`estado`) REFERENCES `estados_vehiculos` (`estado`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `reparaciones_ibfk_2` FOREIGN KEY (`cod_taller`) REFERENCES `talleres` (`cod_taller`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `reparaciones_ibfk_3` FOREIGN KEY (`cod_vehiculo`) REFERENCES `vehiculos` (`cod_vehiculo`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `telefonos`
--
ALTER TABLE `telefonos`
  ADD CONSTRAINT `telefonos_ibfk_1` FOREIGN KEY (`cod_propietario`) REFERENCES `empleados` (`cod_empleado`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `telefonos_ibfk_2` FOREIGN KEY (`cod_propietario`) REFERENCES `clientes` (`cod_cliente`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `telefonos_ibfk_3` FOREIGN KEY (`cod_propietario`) REFERENCES `talleres` (`cod_taller`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `telefonos_ibfk_4` FOREIGN KEY (`cod_propietario`) REFERENCES `exportadores` (`cod_exportador`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `vehiculos`
--
ALTER TABLE `vehiculos`
  ADD CONSTRAINT `vehiculos_ibfk_1` FOREIGN KEY (`marca`) REFERENCES `marcas` (`marca`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `vehiculos_ibfk_2` FOREIGN KEY (`transmision`) REFERENCES `transmisiones` (`transmision`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `ventas`
--
ALTER TABLE `ventas`
  ADD CONSTRAINT `ventas_ibfk_1` FOREIGN KEY (`cod_empleado`) REFERENCES `empleados` (`cod_empleado`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `ventas_ibfk_2` FOREIGN KEY (`forma_pago`) REFERENCES `formas_pago` (`forma`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `ventas_ibfk_3` FOREIGN KEY (`cod_cliente`) REFERENCES `clientes` (`cod_cliente`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `ventas_ibfk_4` FOREIGN KEY (`cod_vehiculo`) REFERENCES `vehiculos` (`cod_vehiculo`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
