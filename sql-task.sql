SELECT DISTINCT ClientName,
                Datepart(MONTH, Date) AS MONTH,
                SUM(Amount) OVER (PARTITION BY ClientName
                                  ORDER BY Datepart(MONTH, Date)) AS SumAmount
FROM Persons
WHERE Date >= DATEFROMPARTS(2017, 01, 01)
  AND Date <= DATEFROMPARTS(2017, 12, 31)
ORDER BY ClientName,
         MONTH