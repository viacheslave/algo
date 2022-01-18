/*
https://leetcode.com/problems/calculate-salaries/
https://leetcode.com/submissions/detail/458345017/
Startup
*/

/* Write your T-SQL query statement below */
SELECT
  s.company_id,
  s.employee_id,
  s.employee_name,
  ROUND(s.salary * o.coeff, 0) as salary
FROM
  Salaries s
JOIN
(
  SELECT
    company_id,
    CASE WHEN MAX(salary) < 1000 THEN 1.0
         WHEN MAX(salary) > 10000 THEN 0.51
         ELSE 0.76 END as coeff
  FROM 
    Salaries
  GROUP BY
    company_id
) o
ON s.company_id = o.company_id

