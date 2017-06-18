USE Northwind

--1. Create table Cities with (CityId, Name)
CREATE TABLE Cities
(
	CityId int PRIMARY KEY IDENTITY,
	Name nvarchar(50)
)

--2. Create table Cities with (CityId, Name)
INSERT INTO Cities(Name)
	SELECT City FROM Employees
	UNION
	SELECT City FROM Suppliers
	UNION
	SELECT City FROM Customers
--3. Add CityId into Employees, Suppliers, Customers tables which is Foreign Key to CityId in Cities
ALTER TABLE Employees
ADD CityId int FOREIGN KEY REFERENCES Cities(CityId)

ALTER TABLE Suppliers
ADD CityId int FOREIGN KEY REFERENCES Cities(CityId)

ALTER TABLE Customers
ADD CityId int FOREIGN KEY REFERENCES Cities(CityId)

--4. Update Employees, Suppliers, Customers tables with CityId which is in the Cities table
UPDATE Employees
SET CityId  = 
	(SELECT CityId FROM Cities
	WHERE Name = Employees.City AND Employees.City IS NOT NULL)

UPDATE Suppliers
SET CityId = 
	(SELECT CityId FROM Cities
	WHERE NAME = Suppliers.City)

UPDATE Customers
SET CityId = 
	(SELECT CityId FROM Cities
	WHERE Name = Customers.City)

--5. Make the column Name in Cities Unique
ALTER TABLE Cities
ADD UNIQUE (Name)

--6. Now after looking at the database again we found there are Cities (ShipCity) in the Orders table as well :D (always read before start coding). Insert those cities please. (RESULT: 1 row(s) affected)
INSERT INTO Cities(Name)
	SELECT DISTINCT ShipCity AS Name
	FROM Orders o
		WHERE NOT EXISTS 
		(SELECT Name FROM Cities
		WHERE Name = o.ShipCity)

--7. Add CityId column in Orders with Foreign Key to CityId in Cities
ALTER TABLE Orders
ADD CityId int FOREIGN KEY REFERENCES Cities(CityId)

--8. Now rename that column to be ShipCityId to be consistent (use stored procedure :) )
EXECUTE sp_rename 'Orders.CityId', 'ShipCityId'

--9. Update ShipCityId in Orders table with values from Cities table (RESULT: 830 row(s) affected)
UPDATE Orders
SET ShipCityId = c.CityId
	FROM cities c
	WHERE c.Name  = Orders.ShipCity

--10. Drop column ShipCity from Orders
ALTER TABLE Orders
DROP COLUMN ShipCity

--11. Create table Countries with columns CountryId and Name (Unique)
CREATE TABLE Countries
(
	CountryId int PRIMARY KEY IDENTITY,
	Name nvarchar(50) UNIQUE
)

--12. Add CountryId to Cities with Foreign Key to CountryId in Countries
ALTER TABLE Cities
ADD CountryId int FOREIGN KEY REFERENCES Countries(CountryId)

--13. Insert all the Countries from Employees, Customers, Suppliers and Orders (RESULT: 25 row(s) affected)
INSERT INTO Countries(Name)
		SELECT Country FROM Employees
		WHERE Country IS NOT NULL
		UNION 
		SELECT Country FROM Customers
		WHERE Country IS NOT NULL
		UNION 
		SELECT Country FROM Suppliers
		WHERE Country IS NOT NULL	

--14. Update CountryId in Cities table with values from Countries table
UPDATE Cities
SET CountryId = CitiesAndCountries.CountryId
FROM (
	SELECT * FROM
	(
		SELECT Country, CityId FROM Employees
		UNION
		SELECT Country, CityId FROM Suppliers
		UNION
		SELECT Country, CityId FROM Customers
		UNION 
		SELECT ShipCountry, ShipCityId FROM Orders
	) UnionCitiesAndCountries
	JOIN Countries c
	ON UnionCitiesAndCountries.Country = c.Name
) CitiesAndCountries
WHERE
 CitiesAndCountries.CityId = Cities.CityId

 --15. Drop column City and ShipCity from Employees, Suppliers, Customers and Orders tables
DROP INDEX Customers.City

ALTER TABLE Employees
DROP COLUMN City

ALTER TABLE Suppliers
 DROP COLUMN City

ALTER TABLE Customers
DROP COLUMN City

ALTER TABLE Orders
DROP COLUMN ShipCity

--16. Drop column Country and ShipCountry from Employees, Customers, Suppliers and Orders tables
ALTER TABLE Employees
DROP COLUMN Country

ALTER TABLE Suppliers
 DROP COLUMN Country

ALTER TABLE Customers
DROP COLUMN Country

ALTER TABLE Orders
DROP COLUMN ShipCountry