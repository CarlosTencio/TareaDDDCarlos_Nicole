------ Insert Person

------CREATE PROCEDURE InsertPerson
------    @Identification VARCHAR(10),
------    @FirstName VARCHAR(50),
------    @LastName VARCHAR(50),
------    @SecondLastName VARCHAR(50),
------    @Email VARCHAR(100)
------AS
------BEGIN
------    INSERT INTO Person ([Identification], FirstName, LastName, SecondLastName, Email)
------    VALUES (@Identification, @FirstName, @LastName, @SecondLastName, @Email);
------END;

-----------------------------------
-- --Get All Persons

--CREATE PROCEDURE GetAllPersons
--AS
--BEGIN
--    SELECT Id,[Identification],[FirstName],[LastName],[SecondLastName],[Email] FROM Person;
--END;

-----------------------------------
-- --Get Person By ID

--CREATE PROCEDURE GetPersonByID
--    @ID INT
--AS
--BEGIN
--    SELECT Id,[Identification],[FirstName],[LastName],[SecondLastName],[Email] FROM Person WHERE ID = @ID;
--END;

-----------------------------------
-- --Update Person

--CREATE PROCEDURE UpdatePerson
--    @ID INT,
--    @Identification VARCHAR(10),
--    @FirstName VARCHAR(50),
--    @LastName VARCHAR(50),
--    @SecondLastName VARCHAR(50),
--    @Email VARCHAR(100)
--AS
--BEGIN
--    UPDATE Person
--    SET [Identification] = @Identification,
--        FirstName = @FirstName,
--        LastName = @LastName,
--        SecondLastName = @SecondLastName,
--        Email = @Email
--    WHERE ID = @ID;
--END;



-----------------------------------


--CREATE PROCEDURE DeletePerson
--    @ID INT
--AS
--BEGIN
--    DELETE FROM Person WHERE ID = @ID;
--END;

