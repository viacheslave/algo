/*
https://leetcode.com/problems/managers-with-at-least-5-direct-reports/
https://leetcode.com/submissions/detail/451664371/
Amazon
*/

/* Write your T-SQL query statement below */
SELECT
  e.Name
FROM 
  Employee e
JOIN
(
  SELECT
    ManagerId
  FROM
    Employee
  GROUP BY
    ManagerId
  HAVING 
    COUNT(*) >= 5 
) a
ON e.Id = a.ManagerId