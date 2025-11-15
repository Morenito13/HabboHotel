-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         12.0.2-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.11.0.7065
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para habbo_hotel
CREATE DATABASE IF NOT EXISTS `habbo_hotel` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci */;
USE `habbo_hotel`;

-- Volcando estructura para tabla habbo_hotel.habitacion
CREATE TABLE IF NOT EXISTS `habitacion` (
  `idHabitacion` int(11) NOT NULL AUTO_INCREMENT,
  `numero` int(11) DEFAULT NULL,
  `tipo` varchar(50) DEFAULT NULL,
  `capacidad` int(11) DEFAULT NULL,
  `precioNoche` decimal(10,2) DEFAULT NULL,
  `disponible` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`idHabitacion`),
  KEY `numero` (`numero`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para procedimiento habbo_hotel.psa_actualizar_habitacion
DELIMITER //
CREATE PROCEDURE `psa_actualizar_habitacion`(
	IN `_idHabitacion` INT,
	IN `_numero` INT,
	IN `_tipo` VARCHAR(50),
	IN `_capacidad` INT,
	IN `_precioNoche` DECIMAL(10,2),
	IN `_disponible` TINYINT
)
BEGIN
	UPDATE habitacion
	   SET
	      numero = _numero,
	      tipo = _tipo,
	      capacidad = _capacidad,
	      precioNoche = _precioNoche,
	      disponible = _disponible
	   WHERE
	      idHabitacion = _idHabitacion;
END//
DELIMITER ;

-- Volcando estructura para procedimiento habbo_hotel.psa_buscarHabitacionPorNumero
DELIMITER //
CREATE PROCEDURE `psa_buscarHabitacionPorNumero`(
	IN `_numero` INT
)
BEGIN
	SELECT * FROM habitacion WHERE numero = _numero;
END//
DELIMITER ;

-- Volcando estructura para procedimiento habbo_hotel.psa_buscarReservasPorFecha
DELIMITER //
CREATE PROCEDURE `psa_buscarReservasPorFecha`(
	IN `p_fecha` DATETIME
)
BEGIN
	SELECT 
      idReserva,
      id_habitacion,
      nombreHuesped,
      fechaIngreso,
      fechaSalida,
      observacion
    FROM 
      reservas
    WHERE 
      (p_fecha >= fechaIngreso) AND (p_fecha < fechaSalida);
END//
DELIMITER ;

-- Volcando estructura para procedimiento habbo_hotel.psa_buscarReservasPorHuesped
DELIMITER //
CREATE PROCEDURE `psa_buscarReservasPorHuesped`(
	IN `p_nombreHuesped` VARCHAR(50)
)
BEGIN
	SELECT 
      idReserva,
      id_habitacion,
      nombreHuesped,
      fechaIngreso,
      fechaSalida,
      observacion
    FROM 
      reservas
    WHERE 
      nombreHuesped = p_nombreHuesped;
END//
DELIMITER ;

-- Volcando estructura para procedimiento habbo_hotel.psa_eliminar_habitacion
DELIMITER //
CREATE PROCEDURE `psa_eliminar_habitacion`(
	IN `_idHabitacion` INT
)
BEGIN
	DELETE FROM habitacion WHERE idHabitacion = _idHabitacion;
END//
DELIMITER ;

-- Volcando estructura para procedimiento habbo_hotel.psa_guardar_habitacion
DELIMITER //
CREATE PROCEDURE `psa_guardar_habitacion`(
	IN `_numero` INT,
	IN `_tipo` VARCHAR(50),
	IN `_capacidad` INT,
	IN `_precioNoche` DECIMAL(10,2),
	IN `_disponible` TINYINT
)
BEGIN
	INSERT INTO habitacion(numero, tipo, capacidad, precioNoche, disponible)
   VALUES (_numero, _tipo, _capacidad, _precioNoche, _disponible);
END//
DELIMITER ;

-- Volcando estructura para procedimiento habbo_hotel.psa_guardar_reserva
DELIMITER //
CREATE PROCEDURE `psa_guardar_reserva`(
	IN `_idHabitacion` INT,
	IN `_nombreHuesped` VARCHAR(50),
	IN `_fechaIngreso` DATETIME,
	IN `_fechaSalida` DATETIME,
	IN `_observacion` VARCHAR(255)
)
BEGIN
	INSERT INTO reservas(id_habitacion, nombreHuesped, fechaIngreso, fechaSalida, observacion) 
   VALUES (_idHabitacion,  _nombreHuesped, _fechaIngreso, _fechaSalida, _observacion);
END//
DELIMITER ;

-- Volcando estructura para procedimiento habbo_hotel.psa_listadoHabitaciones
DELIMITER //
CREATE PROCEDURE `psa_listadoHabitaciones`()
BEGIN
    SELECT 
      idHabitacion,
      numero,
      tipo,
      capacidad,
      precioNoche,
      disponible
    FROM 
      habitacion;
END//
DELIMITER ;

-- Volcando estructura para procedimiento habbo_hotel.psa_listarHabitacionesDisponibles
DELIMITER //
CREATE PROCEDURE `psa_listarHabitacionesDisponibles`()
BEGIN
	SELECT 
	   idHabitacion, 
	   numero,       
	   tipo,         
	   capacidad,    
	   precioNoche,  
	   disponible    
	FROM 
	   habitacion
	WHERE 
	   disponible = TRUE;
END//
DELIMITER ;

-- Volcando estructura para procedimiento habbo_hotel.psa_listarHabitacionesOcupadas
DELIMITER //
CREATE PROCEDURE `psa_listarHabitacionesOcupadas`()
BEGIN
	SELECT 
      idHabitacion, 
      numero,       
      tipo,         
      capacidad,   
      precioNoche,  
      disponible    
    FROM 
      habitacion
    WHERE 
      disponible = FALSE;
END//
DELIMITER ;

-- Volcando estructura para procedimiento habbo_hotel.psa_listarTodasLasReservas
DELIMITER //
CREATE PROCEDURE `psa_listarTodasLasReservas`()
BEGIN
	SELECT 
      idReserva,
      id_habitacion,
      nombreHuesped,
      fechaIngreso,
      fechaSalida,
      observacion
    FROM 
      reservas;
END//
DELIMITER ;

-- Volcando estructura para procedimiento habbo_hotel.psa_listar_reservas_activas
DELIMITER //
CREATE PROCEDURE `psa_listar_reservas_activas`()
BEGIN
	SELECT * FROM reservas
   	WHERE 
      	fechaIngreso <= CURDATE()
    	AND 
       	fechaSalida >= CURDATE();
END//
DELIMITER ;

-- Volcando estructura para procedimiento habbo_hotel.psa_verificar_disponibilidad
DELIMITER //
CREATE PROCEDURE `psa_verificar_disponibilidad`(
	IN `_idHabitacion` INT,
	IN `_fechaIngreso` DATETIME,
	IN `_fechaSalida` DATETIME
)
BEGIN
	SELECT COUNT(r.idReserva)
    FROM reservas r
    WHERE 
        r.id_habitacion = _idHabitacion
    AND
        (r.fechaIngreso < _fechaSalida) 
    AND 
        (r.fechaSalida > _fechaIngreso);
END//
DELIMITER ;

-- Volcando estructura para tabla habbo_hotel.reservas
CREATE TABLE IF NOT EXISTS `reservas` (
  `idReserva` int(11) NOT NULL AUTO_INCREMENT,
  `id_habitacion` int(11) DEFAULT NULL,
  `nombreHuesped` varchar(50) DEFAULT NULL,
  `fechaIngreso` date DEFAULT NULL,
  `fechaSalida` date DEFAULT NULL,
  `observacion` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idReserva`),
  KEY `FK_habitacion` (`id_habitacion`),
  CONSTRAINT `FK_habitacion` FOREIGN KEY (`id_habitacion`) REFERENCES `habitacion` (`idHabitacion`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

-- La exportación de datos fue deseleccionada.

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
