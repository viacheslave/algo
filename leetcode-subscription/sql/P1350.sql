/*
https://leetcode.com/problems/students-with-invalid-departments/
https://leetcode.com/submissions/detail/451454199/
Amazon
*/

/* Write your T-SQL query statement below */
SELECT
  s.id, s.name
FROM
  Students s
LEFT JOIN 
  Departments d
ON 
  s.department_id = d.id
WHERE d.id IS NULL