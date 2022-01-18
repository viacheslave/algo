/*
https://leetcode.com/problems/project-employees-iii/
https://leetcode.com/submissions/detail/450956946/
Facebook
*/

/* Write your T-SQL query statement below */
SELECT 
  Project.project_id,
  Project.employee_id
FROM 
  Project
JOIN
  Employee ON Project.employee_id = Employee.employee_id
JOIN
(
  SELECT
    p.project_id,
    MAX(experience_years) as max_years
  FROM
    Project p
  JOIN 
    Employee e ON p.employee_id = e.employee_id
  GROUP BY
    p.project_id
) a
ON 
  Project.project_id = a.project_id
WHERE 
  Employee.experience_years = a.max_years