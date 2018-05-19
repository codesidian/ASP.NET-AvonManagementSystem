SELECT [Customer Name],[Products],[Total] FROM
(SELECT [Customer].Id,concat([dbo].Customer.FirstName,' ',[dbo].Customer.LastName) AS [Customer Name]
FROM [Customer]) t1
LEFT JOIN
(SELECT [Order].CustomerID,sum([Order].Quantity) AS [Products], sum([Order].Price) AS [Total]
FROM [Order]
GROUP BY [Order].CustomerID) t2
ON Id = CustomerID