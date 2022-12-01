-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema MeetingScheduler_DB
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema MeetingScheduler_DB
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `MeetingScheduler_DB` DEFAULT CHARACTER SET utf8 ;
USE `MeetingScheduler_DB` ;

-- -----------------------------------------------------
-- Table `MeetingScheduler_DB`.`Client`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MeetingScheduler_DB`.`Client` (
  `idClient` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(256) NOT NULL,
  `password` VARCHAR(64) NOT NULL,
  `document` VARCHAR(64) NOT NULL,
  `phone` VARCHAR(64) NOT NULL,
  `Email` VARCHAR(128) NOT NULL,
  `Office` VARCHAR(64) NOT NULL,
  PRIMARY KEY (`idClient`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MeetingScheduler_DB`.`Location`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MeetingScheduler_DB`.`Location` (
  `idLocation` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(128) NOT NULL,
  `address` VARCHAR(256) NOT NULL,
  `cep` VARCHAR(16) NOT NULL,
  `capacity` INT UNSIGNED NOT NULL,
  `room` VARCHAR(32) NOT NULL,
  PRIMARY KEY (`idLocation`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MeetingScheduler_DB`.`Appointment`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MeetingScheduler_DB`.`Appointment` (
  `idAppointment` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Client` INT UNSIGNED NOT NULL,
  `start_date_time` DATETIME NOT NULL,
  `end_date_time` DATETIME NOT NULL,
  `reason` VARCHAR(256) NOT NULL,
  PRIMARY KEY (`idAppointment`),
  INDEX `fk_Appointment_Client_idx` (`Client` ASC) VISIBLE,
  CONSTRAINT `fk_Appointment_Client`
    FOREIGN KEY (`Client`)
    REFERENCES `MeetingScheduler_DB`.`Client` (`idClient`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MeetingScheduler_DB`.`Meeting`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MeetingScheduler_DB`.`Meeting` (
  `idMeeting` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `start_date_time` DATETIME NOT NULL,
  `end_date_time` DATETIME NOT NULL,
  `Location` INT UNSIGNED NOT NULL,
  `description` VARCHAR(512) NOT NULL,
  `subject` VARCHAR(128) NOT NULL,
  `name` VARCHAR(64) NOT NULL,
  `priority` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`idMeeting`, `Location`),
  INDEX `fk_Meeting_Location1_idx` (`Location` ASC) VISIBLE,
  CONSTRAINT `fk_Meeting_Location1`
    FOREIGN KEY (`Location`)
    REFERENCES `MeetingScheduler_DB`.`Location` (`idLocation`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MeetingScheduler_DB`.`Client_has_Meeting`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MeetingScheduler_DB`.`Client_has_Meeting` (
  `Client` INT UNSIGNED NOT NULL,
  `Meeting` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`Client`, `Meeting`),
  INDEX `fk_Client_has_Meeting_Meeting1_idx` (`Meeting` ASC) VISIBLE,
  INDEX `fk_Client_has_Meeting_Client1_idx` (`Client` ASC) VISIBLE,
  CONSTRAINT `fk_Client_has_Meeting_Client1`
    FOREIGN KEY (`Client`)
    REFERENCES `MeetingScheduler_DB`.`Client` (`idClient`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Client_has_Meeting_Meeting1`
    FOREIGN KEY (`Meeting`)
    REFERENCES `MeetingScheduler_DB`.`Meeting` (`idMeeting`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
