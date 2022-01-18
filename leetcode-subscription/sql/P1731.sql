/*
https://leetcode.com/problems/the-number-of-employees-which-report-to-each-employee/
https://leetcode.com/submissions/detail/451432124/
CoderByte
*/

/* Write your T-SQL query statement below */
SELECT
  e.reports_to employee_id,
  a.name,
  COUNT(e.employee_id) reports_count,
  ROUND(1.0 * SUM(e.age) / COUNT(e.age), 0) average_age
FROM
  Employees e
JOIN
(
  SELECT employee_id, name
  FROM Employees
) a
ON
  e.reports_to = a.employee_id
WHERE 
  e.reports_to IS NOT NULL
GROUP BY
  e.reports_to,
  a.name
ORDER BY
  e.reports_to



