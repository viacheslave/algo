/*
https://leetcode.com/problems/project-employees-ii/
https://leetcode.com/submissions/detail/450954633/
Facebook
*/

/* Write your T-SQL query statement below */
SELECT
  p.project_id
FROM
  Project p
GROUP BY 
  p.project_id
HAVING
  COUNT(*) = 
  (
    SELECT TOP 1 COUNT(*)
    FROM Project 
    JOIN Employee ON Project.employee_id = Employee.employee_id
    GROUP BY Project.project_id
    ORDER BY COUNT(*) DESC
  )
  