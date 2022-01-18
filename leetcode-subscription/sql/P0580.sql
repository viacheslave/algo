/*
https://leetcode.com/problems/count-student-number-in-departments/
https://leetcode.com/submissions/detail/458081173/
Twitter
*/

/* Write your T-SQL query statement below */
SELECT
  d.dept_name,
  COUNT(CASE WHEN s.student_id IS NOT NULL THEN 1 END) as student_number
FROM
  department d
LEFT JOIN
  student s
    ON d.dept_id = s.dept_id
GROUP BY
  d.dept_name
ORDER BY
  COUNT(CASE WHEN s.student_id IS NOT NULL THEN 1 END) desc,
  d.dept_name asc
    
  