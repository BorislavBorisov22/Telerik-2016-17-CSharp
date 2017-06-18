USING TelerikAcademy

--1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) 
-- and Accounts(Id(PK), PersonId(FK), Balance).
CREATE TABLE Persons(
	Id int IDENTITY PRIMARY KEY,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	SSN nvarchar(50) NOT NULL
)

GO

CREATE TABLE Accounts(
	Id int IDENTITY PRIMARY KEY,
	Balance money NOT NULL,
	PersonId int NOT NULL
	CONSTRAINT FK_Accounts_Persons FOREIGN KEY (PersonId) REFERENCES Persons(Id)
)
GO

INSERT INTO Persons VALUES
('Ivan', 'Ivanov', 'SSSSN'),
('Anthony', 'Joshua', 'TopSecurity'),
('Wladimir', 'Klitschko', 'TopSecurity'),
('Kubrat', 'Pulev', 'HighSecurity')
GO

INSERT INTO Accounts VALUES
(20, 1),
(200000, 2),
(100000, 3),
(10000, 4)
GO

--2. reate a stored procedure that accepts a number as a parameter and returns all persons who have more
-- money in their accounts than the supplied number.
CREATE PROCEDURE usp_GetPeopleWithMoreMoneyThan(@minBalance money)
AS 
	SELECT p.FirstName, p.LastName, a.Balance
	FROM Persons p
	JOIN Accounts a
	ON p.Id = a.PersonId
	WHERE a.Balance > @minBalance
GO

EXEC usp_GetPeopleWithMoreMoneyThan 1000
GO

--3. Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
CREATE FUNCTION ufn_CalculateSumForPeriod(@sum money, @yearlyInterest money, @numberOfMonths int)
RETURNS money
AS BEGIN
	DECLARE @monthlyInterest money
	SET @monthlyInterest = @yearlyInterest / 12 / 100
	
	DECLARE @resultSum money
	SET @resultSum = @sum + (@sum * @monthlyInterest * @numberOfMonths)

	RETURN @resultSum
END 
GO

SELECT dbo.ufn_CalculateSumForPeriod(400, 120, 4) AS [New Sum]
GO

--4. Create a stored procedure that uses the function from the previous example to give an interest to a person's
-- account for one month. 
CREATE PROCEDURE usp_GivePersonInterestForOneMonth(@accountId int, @interestRate money)
AS
	DECLARE @months money
	SET @months = 1

	UPDATE Accounts
	SET Balance = dbo.ufn_CalculateSumForPeriod(Balance, @interestRate, @months)
	WHERE Id = @accountId
GO

EXEC usp_GivePersonInterestForOneMonth 1, 120
GO

--5. Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney(AccountId, money)
-- that operate in transactions.
CREATE PROCEDURE usp_WithdrawMoney(@accountId int, @money money)
AS
	BEGIN TRANSACTION
	UPDATE Accounts
	SET Balance = Balance - @money
	WHERE Id = @accountId
	COMMIT TRANSACTION
GO

CREATE PROCEDURE usp_DepositMoney(@accountId int, @money money)
AS
	BEGIN TRANSACTION
	UPDATE Accounts
	SET Balance = Balance + @money
	WHERE Id = @accountId
	COMMIT TRANSACTION
GO

EXEC usp_DepositMoney 1, 0.5
EXEC usp_WithdrawMoney 1, 22

SELECT * FROM Accounts
GO

--6. Create another table – Logs(LogID, AccountID, OldSum, NewSum).
   -- * Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an 
   -- account changes.

CREATE TABLE Logs(
	Id int IDENTITY PRIMARY KEY,
	OldSum money NOT NULL,
	NewSum money NOT NuLL,
	AccountId int NOT NULL,
	CONSTRAINT FK_Logs_Accounts FOREIGN KEY(AccountId) REFERENCES Accounts(Id)
)
GO

CREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE
AS 
	DECLARE @oldSum money, @newSum money, @accountId int

	SELECT @oldSum = Balance, @accountId = Id FROM deleted
	SELECT @newSum = Balance FROM inserted

	INSERT INTO Logs Values (@oldSum, @newSum, @accountId)
GO 

-- 7. Define a function in the database TelerikAcademy that returns all Employee's names
-- (first or middle or last name) and all town's names that are comprised of given set of letters. 
CREATE FUNCTION ufn_CheckIfNameCanBeComprisedOf(@pattern nvarchar(50), @name nvarchar(50))
RETURNS BIT
AS
BEGIN
	DECLARE @nameIndex int, @nameChar nvarchar(50)
	SET @nameIndex = 1

	DECLARE @currentChar nvarchar(1)
	WHILE (@nameIndex <= LEN(@name))
		BEGIN
			SET @currentChar = SUBSTRING(@name, @nameIndex, 1)
			IF (CHARINDEX(@currentChar, @pattern) <= 0)
				BEGIN
					RETURN 0
				END
			SET @nameIndex = @nameIndex + 1
		END 
	RETURN 1
END
GO

CREATE FUNCTION ufn_GetNamesComprisedByPattern(@pattern nvarchar(50))
RETURNS TABLE
AS 
RETURN(
	SELECT FirstName AS NAME FROM Employees
	WHERE dbo.ufn_CheckIfNameCanBeComprisedOf(@pattern, FirstName) = 1
	UNION
	SELECT MiddleName AS NAME FROM Employees
	WHERE dbo.ufn_CheckIfNameCanBeComprisedOf(@pattern, MiddleName) = 1
	UNION
	SELECT LastName AS NAME FROM Employees
	WHERE dbo.ufn_CheckIfNameCanBeComprisedOf(@pattern, LastName) = 1
	UNION
	SELECT Name AS NAME FROM Towns
	WHERE dbo.ufn_CheckIfNameCanBeComprisedOf(@pattern, Name) = 1
)
GO

DECLARE @pattern nvarchar(50)
SET @pattern = 'oistmiahf'
SELECT * FROM dbo.ufn_GetNamesComprisedByPattern(@pattern)


--8. Using database cursor write a T-SQL script that scans all employees and their addresses and prints
-- all pairs of employees that live in the same town.
DECLARE empCursor  CURSOR READ_ONLY FOR 
SELECT e.FirstName AS [1.First Name], e.LastName AS [1.Last Name], t.Name AS [Town Name],
 e2.FirstName AS [2.First Name], e2.LastName AS [2.Last Name] 
FROM Employees e
JOIN Addresses a
ON e.AddressID = a.AddressID
JOIN Towns t
ON t.TownID = a.TownID,
Employees e2
JOIN Addresses a2
ON e2.AddressID = a2.AddressID
WHERE a.TownID = a2.TownID AND e.EmployeeID <> e2.EmployeeID
ORDER BY e.FirstName, e2.FirstName

OPEN empCursor

	DECLARE @firstName1 nvarchar(50), 
			@lastName1 nvarchar(50),
			@firstName2 nvarchar(50), 
			@lastName2 nvarchar(50),
			@townName nvarchar(50)

	FETCH NEXT FROM empCursor INTO @firstName1, @lastName1, @townName, @firstName2, @lastName2

	WHILE @@FETCH_STATUS = 0
		BEGIN
			PRINT @firstName1 + ' ' +  @lastName1 + ', ' +  @firstName2 + ' ' +  @lastName2 + ' -> ' + @townName

			FETCH NEXT FROM empCursor INTO @firstName1, @lastName1, @townName, @firstName2, @lastName2
		END 
CLOSE empCursor
DEALLOCATE empCursor

--------------------------------------------------------------------------------------
-- 09. Write a T-SQL script that shows for each town a list of all employees that live in it. 
---------------------------------------------------------------------------------------

IF NOT EXISTS (
    SELECT value
    FROM sys.configurations
    WHERE name = 'clr enabled' AND value = 1
)
BEGIN
    EXEC sp_configure @configname = clr_enabled, @configvalue = 1
    RECONFIGURE
END
GO


IF (OBJECT_ID('dbo.concat') IS NOT NULL) 
    DROP Aggregate concat; 
GO 

IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
    DROP assembly concat_assembly; 
GO      

CREATE Assembly concat_assembly 
   AUTHORIZATION dbo 
   FROM 'D:\TelerikAcademy\C#\Data Bases\Homeworks\09. Transact-SQL\SqlStringConcatenation.dll' --- CHANGE THE LOCATION
   WITH PERMISSION_SET = SAFE; 
GO 

CREATE AGGREGATE dbo.concat ( 
    @Value NVARCHAR(MAX),
    @Delimiter NVARCHAR(4000) 
) 
    RETURNS NVARCHAR(MAX) 
    EXTERNAL Name concat_assembly.concat; 
GO 

DECLARE empCursor CURSOR READ_ONLY FOR 
SELECT t.Name, dbo.concat(e.FirstName + ' ' + e.LastName, ', ')
FROM Employees e
JOIN Addresses a
ON a.AddressID = e.AddressID
JOIN Towns t
ON t.TownID = a.TownID
GROUP BY t.Name
GO

OPEN empCursor
	DECLARE @townName nvarchar(50),
	 @employees nvarchar(max)

	 FETCH NEXT FROM empCursor INTO @townName, @employees

	 WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT @townName + ' => ' + @employees

		FETCH NEXT FROM empCursor INTO @townName, @employees
	END 
CLOSE empCursor
DEALLOCATE empCursor

DROP Aggregate concat; 
DROP assembly concat_assembly; 
GO