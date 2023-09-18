SELECT DISTINCT ClientName,
                Datepart(MONTH, Date) AS MONTH,
                SUM(Amount) OVER (PARTITION BY ClientName
                                  ORDER BY Datepart(MONTH, Date)) AS SumAmount
FROM Supplies
WHERE YEAR(Date) = 2017
ORDER BY ClientName,
         MONTH