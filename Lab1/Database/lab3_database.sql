--
-- PostgreSQL database dump
--

-- Dumped from database version 17.2 (Debian 17.2-1.pgdg120+1)
-- Dumped by pg_dump version 17.2 (Debian 17.2-1.pgdg120+1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: book_borrow(integer, integer, date, date); Type: PROCEDURE; Schema: public; Owner: ALIJAD
--

CREATE PROCEDURE public.book_borrow(IN book_id integer, IN borrower_id integer, IN loan_date date, IN return_date date)
    LANGUAGE sql
    AS $$
           
       
        INSERT INTO loans(loan_id, book_id, borrower_id, loan_date, return_date, returned)
        VALUES((SELECT max(loan_id)+1 FROM loans),BOOK_BORROW.book_id,BOOK_BORROW.borrower_id,BOOK_BORROW.loan_date,BOOK_BORROW.return_date,false);
$$;


ALTER PROCEDURE public.book_borrow(IN book_id integer, IN borrower_id integer, IN loan_date date, IN return_date date) OWNER TO "ALIJAD";

--
-- Name: borrow_book(integer, integer, date, date); Type: PROCEDURE; Schema: public; Owner: ALIJAD
--

CREATE PROCEDURE public.borrow_book(IN book_id integer, IN borrower_id integer, IN loan_date date, IN return_date date)
    LANGUAGE sql
    AS $$
           
       
        INSERT INTO loans(loan_id, book_id, borrower_id, loan_date, return_date, returned)
        VALUES((SELECT max(loan_id)+1 FROM loans),BORROW_BOOK.book_id,BORROW_BOOK.borrower_id,BORROW_BOOK.loan_date,BORROW_BOOK.return_date,false);
$$;


ALTER PROCEDURE public.borrow_book(IN book_id integer, IN borrower_id integer, IN loan_date date, IN return_date date) OWNER TO "ALIJAD";

--
-- Name: get_book(character varying); Type: PROCEDURE; Schema: public; Owner: ALIJAD
--

CREATE PROCEDURE public.get_book(IN name character varying)
    LANGUAGE sql
    AS $$
    SELECT * FROM BOOKS WHERE name IN (SELECT title from books);
    $$;


ALTER PROCEDURE public.get_book(IN name character varying) OWNER TO "ALIJAD";

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: authors; Type: TABLE; Schema: public; Owner: ALIJAD
--

CREATE TABLE public.authors (
    author_id integer NOT NULL,
    name character varying(30),
    birth_date date,
    country character varying(20)
);


ALTER TABLE public.authors OWNER TO "ALIJAD";

--
-- Name: books; Type: TABLE; Schema: public; Owner: ALIJAD
--

CREATE TABLE public.books (
    book_id integer NOT NULL,
    title character varying(20),
    author_id integer,
    isbn character varying(30),
    published_year integer
);


ALTER TABLE public.books OWNER TO "ALIJAD";

--
-- Name: borrowers; Type: TABLE; Schema: public; Owner: ALIJAD
--

CREATE TABLE public.borrowers (
    borrower_id integer NOT NULL,
    name character varying(30),
    email character varying(50),
    phone character varying(30)
);


ALTER TABLE public.borrowers OWNER TO "ALIJAD";

--
-- Name: loans; Type: TABLE; Schema: public; Owner: ALIJAD
--

CREATE TABLE public.loans (
    loan_id integer NOT NULL,
    book_id integer,
    borrower_id integer,
    loan_date date,
    return_date date,
    returned boolean
);


ALTER TABLE public.loans OWNER TO "ALIJAD";

--
-- Name: popular_books; Type: VIEW; Schema: public; Owner: ALIJAD
--

CREATE VIEW public.popular_books AS
 SELECT b.book_id,
    b.title,
    a.nbofloans
   FROM (( SELECT loans.book_id,
            count(loans.book_id) AS nbofloans
           FROM public.loans
          GROUP BY loans.book_id
          ORDER BY (count(loans.book_id)) DESC) a
     JOIN public.books b ON ((a.book_id = b.book_id)))
 LIMIT 5;


ALTER VIEW public.popular_books OWNER TO "ALIJAD";

--
-- Data for Name: authors; Type: TABLE DATA; Schema: public; Owner: ALIJAD
--

COPY public.authors (author_id, name, birth_date, country) FROM stdin;
1	George Orwell	1903-07-25	United Kingdom
2	Jane Austen	1775-12-16	United Kingdom
3	Mark Twain	1835-11-30	United States
4	Haruki Murakami	1949-01-12	Japan
5	Tony Robins	1976-03-01	United States
\.


--
-- Data for Name: books; Type: TABLE DATA; Schema: public; Owner: ALIJAD
--

COPY public.books (book_id, title, author_id, isbn, published_year) FROM stdin;
1	Harry Potter and the	1	9780439708180	1997
2	Star Wars	2	9780451524935	1949
3	Animal Farm	2	9780451526342	1945
4	Pride and Prejudice	3	9781503290563	1813
5	The Adventures of To	4	9780486400778	1876
6	Norwegian Wood	5	9780375704024	1987
\.


--
-- Data for Name: borrowers; Type: TABLE DATA; Schema: public; Owner: ALIJAD
--

COPY public.borrowers (borrower_id, name, email, phone) FROM stdin;
1	Ahmad Khalil	ahmad.khalil@email.com	71-123456
2	Rami Chami	rami.chami@email.com	76-234567
3	Layal Haddad	layal.haddad@email.com	03-345678
4	Nadine Mansour	nadine.mansour@email.com	70-456789
5	Karim El Khatib	karim.khatib@email.com	78-567890
\.


--
-- Data for Name: loans; Type: TABLE DATA; Schema: public; Owner: ALIJAD
--

COPY public.loans (loan_id, book_id, borrower_id, loan_date, return_date, returned) FROM stdin;
1	1	2	2024-01-10	2024-01-20	t
2	3	1	2024-01-12	2024-01-22	t
3	5	3	2024-02-01	2024-02-11	f
4	2	4	2024-02-05	2024-02-15	f
5	6	5	2024-02-07	2024-02-17	f
6	4	2	2024-02-12	2024-02-22	t
7	3	3	2024-02-15	2024-02-25	f
8	1	4	2024-02-18	2024-02-28	f
9	2	1	2024-02-20	2024-03-05	t
10	5	5	2024-02-25	2024-03-10	f
11	6	2	2024-03-01	2024-03-15	t
12	1	3	2024-03-03	2024-03-18	f
13	4	5	2024-03-07	2024-03-21	f
14	3	1	2024-03-10	2024-03-24	t
15	2	4	2024-03-12	2024-03-26	f
16	5	2	2024-03-15	2024-03-30	f
17	6	3	2024-03-18	2024-04-01	t
18	1	5	2024-03-20	2024-04-05	f
19	4	4	2024-03-22	2024-04-07	f
20	2	3	2024-03-25	2024-04-10	t
21	1	2	2025-01-30	2025-02-20	f
22	2	1	2025-01-30	2025-02-20	f
23	6	4	2025-01-10	2025-03-20	t
24	1	2	2025-02-13	2026-01-01	f
25	1	2	2025-02-13	2026-01-01	f
26	1	2	2025-02-13	2026-01-01	f
27	3	3	2025-01-13	2025-03-03	f
\.


--
-- Name: authors authors_pk; Type: CONSTRAINT; Schema: public; Owner: ALIJAD
--

ALTER TABLE ONLY public.authors
    ADD CONSTRAINT authors_pk PRIMARY KEY (author_id);


--
-- Name: books book_id; Type: CONSTRAINT; Schema: public; Owner: ALIJAD
--

ALTER TABLE ONLY public.books
    ADD CONSTRAINT book_id PRIMARY KEY (book_id);


--
-- Name: borrowers borrow; Type: CONSTRAINT; Schema: public; Owner: ALIJAD
--

ALTER TABLE ONLY public.borrowers
    ADD CONSTRAINT borrow PRIMARY KEY (borrower_id);


--
-- Name: loans loans_pk; Type: CONSTRAINT; Schema: public; Owner: ALIJAD
--

ALTER TABLE ONLY public.loans
    ADD CONSTRAINT loans_pk PRIMARY KEY (loan_id);


--
-- Name: books books___fk; Type: FK CONSTRAINT; Schema: public; Owner: ALIJAD
--

ALTER TABLE ONLY public.books
    ADD CONSTRAINT books___fk FOREIGN KEY (author_id) REFERENCES public.authors(author_id);


--
-- Name: loans loans___fk; Type: FK CONSTRAINT; Schema: public; Owner: ALIJAD
--

ALTER TABLE ONLY public.loans
    ADD CONSTRAINT loans___fk FOREIGN KEY (book_id) REFERENCES public.books(book_id);


--
-- Name: loans loans___fk_2; Type: FK CONSTRAINT; Schema: public; Owner: ALIJAD
--

ALTER TABLE ONLY public.loans
    ADD CONSTRAINT loans___fk_2 FOREIGN KEY (borrower_id) REFERENCES public.borrowers(borrower_id);


--
-- PostgreSQL database dump complete
--

