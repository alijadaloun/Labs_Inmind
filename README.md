# **Lab 3 Summary**

In **Lab 3**, we delved deep into how **databases** work and how they are queried in **PostgreSQL**. Then, we had a general overview of how to run **Docker** as an isolated virtual machine on our computer and deploy **PostgreSQL** on it.

This lab introduced us to a variety of concepts in **.NET** related to **databases**, including:
- **Entity Framework (EF Core)** – C#'s official **Object-Relational Mapper (ORM)**.
- **LINQ (Language Integrated Query)** – A powerful tool that facilitates writing **queries** in **C#**.

These concepts help simplify **database interactions** and improve **query efficiency** within .NET applications.

# **Include Database in lab**

Since the database runs in a **Docker container**, it needs to be **exported** and included in the project so that it can be easily restored by anyone.

### **🔹 Step 1: Export the Database from the Running PostgreSQL Container**
The following command exports the database from the **Docker container** into an sql filw
docker exec -t lab3-postgres pg_dump -U myuser -d lab3db -F c -p >lab3_database.backup
-p: is for plain text
then the file should be placed in database folder in our project

