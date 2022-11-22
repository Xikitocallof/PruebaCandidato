-- SQL --

USE Northwind
GO 

-- 1---

SELECT
	P.ProductName AS PRODUCTO,
	C.CategoryName AS CATEGORIA

FROM Products P WITH(NOLOCK)

LEFT OUTER JOIN Categories C WITH(NOLOCK)
ON P.CategoryID = C.CategoryID

WHERE P.Discontinued = 0

ORDER BY P.ProductName

-----------------

-- 2 --

SELECT DISTINCT
	C.ContactName AS CONTACTO

FROM Orders O WITH(NOLOCK)

LEFT OUTER JOIN Employees E WITH(NOLOCK)
ON O.EmployeeID = E.EmployeeID

LEFT OUTER JOIN Customers C WITH(NOLOCK)
ON O.CustomerID = C.CustomerID

WHERE E.FirstName = 'Nancy' 
	AND E.LastName = 'Davolio'

ORDER BY ContactName

-----------------

-- 3 --

SELECT 
	YEAR(O.OrderDate) AS AÑO,
	CONCAT(CAST(SUM(OD.UnitPrice * OD.Quantity * (1 - OD.Discount)) AS DECIMAL(20,2)), ' $') AS VENTAS

FROM Orders O WITH(NOLOCK)

LEFT OUTER JOIN Employees E WITH(NOLOCK)
ON O.EmployeeID = E.EmployeeID

LEFT OUTER JOIN [Order Details] OD WITH(NOLOCK)
ON O.OrderID = OD.OrderID

WHERE E.FirstName = 'Steven' 
	AND E.LastName = 'Buchanan'

GROUP BY 
	YEAR(O.OrderDate)

-----------------

-- 4 --

SELECT 
	CONCAT(E.FirstName, ' ', E.LastName) AS EMPLEADO

FROM Employees E WITH(NOLOCK)

WHERE E.ReportsTo = (SELECT E.EmployeeID FROM Employees E WITH(NOLOCK) WHERE E.FirstName = 'Andrew'	AND E.LastName = 'Fuller')
	OR E.ReportsTo IN (SELECT E.EmployeeID FROM Employees E WITH(NOLOCK) WHERE E.ReportsTo = (SELECT E.EmployeeID FROM Employees E WITH(NOLOCK) WHERE E.FirstName = 'Andrew' AND E.LastName = 'Fuller'))

-----------------