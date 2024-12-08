USE AirlineBookingDB;

CREATE TABLE PassengerDetails
(
    book_ref VARCHAR(50) NOT NULL PRIMARY KEY,
    book_date DATE NOT NULL,
    firstname VARCHAR(50) NOT NULL,
    middlename VARCHAR(50) NOT NULL,
    lastname VARCHAR(50) NOT NULL,
    gender VARCHAR(50) NULL,
    nationality VARCHAR(50) NULL,
    contact_no BIGINT NULL,
    departure_from VARCHAR(99) NULL,
    arrival_to VARCHAR(99) NULL,
    departure_date DATE NULL,
    seat_no VARCHAR(20) NULL,
    travel_class VARCHAR(50) NULL
);