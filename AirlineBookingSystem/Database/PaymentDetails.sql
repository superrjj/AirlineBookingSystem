CREATE TABLE PaymentDetails
(
    book_ref VARCHAR(50) NULL,
    payment_method VARCHAR(50) NULL,
    account_name VARCHAR(50) NOT NULL,
    account_num BIGINT NULL,
    amount FLOAT NULL,
    FOREIGN KEY (book_ref) REFERENCES PassengerDetails(book_ref)
);