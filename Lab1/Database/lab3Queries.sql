Select title from books where published_year = 1997;

Select * from loans where not returned AND return_date<current_date;

Select b1.title, b2.name FROM books b1, borrowers b2, loans l WHERE l.borrower_id = b2.borrower_id AND
    l.book_id = b1.book_id  AND b2.name = 'Rami Chami';

SELECT COUNT(book_id) AS numberOfBooks FROM books;

DROP view Popular_Books;
CREATE VIEW Popular_Books AS
    SELECT b.book_id,b.title, nbOfLoans FROM
    (SELECT book_id, COUNT(book_id) AS nbOfLoans FROM loans GROUP BY book_id ORDER BY nbOfLoans DESC)
    AS a JOIN books b ON a.book_id = b.book_id LIMIT 5;


CREATE PROCEDURE BORROW_BOOK(book_id INT,borrower_id INT,loan_date date, return_date date)
   LANGUAGE sql
AS $$
           
       
        INSERT INTO loans(loan_id, book_id, borrower_id, loan_date, return_date, returned)
        VALUES((SELECT max(loan_id)+1 FROM loans),BORROW_BOOK.book_id,BORROW_BOOK.borrower_id,BORROW_BOOK.loan_date,BORROW_BOOK.return_date,false);
$$;
CALL BORROW_BOOK(3,3,'2025-1-13','2025-03-03');

CREATE PROCEDURE GET_BOOK(name VARCHAR)
LANGUAGE sql
AS $$
    SELECT * FROM BOOKS WHERE name IN (SELECT title from books);
    $$;
CALL GET_BOOK('Star Wars');

    





