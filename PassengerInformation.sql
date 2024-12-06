USE AirlineBookingDB;

CREATE TABLE PassengerInformation(
firstname varchar(99) NOT NULL,
middlename varchar(99) NOT NULL,
lastname varchar(99) NOT NULL,
nationality varchar(99) NULL,
contact_no bigint NOT NULL,
gender varchar(50) NULL,
departure_from varchar(199) NULL,
arrival_to varchar(199) NULL,
departure_date datetime NULL,
number_seats int NOT NULL
);