/*
https://leetcode.com/problems/employee-bonus/
https://leetcode.com/submissions/detail/450757345/
Netsuite
*/

/* Write your T-SQL query statement below */
SELECT
  e.name,
  b.bonus
FROM
  Employee e
LEFT JOIN
  Bonus b 
ON 
  e.empId = b.empId
WHERE 
  b.bonus < 1000 OR b.bonus IS NULL
  