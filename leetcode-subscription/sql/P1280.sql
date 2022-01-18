/*
https://leetcode.com/problems/students-and-examinations/
https://leetcode.com/submissions/detail/451089536/
Roblox
*/

/* Write your T-SQL query statement below */

SELECT
  cr.student_id,
  s.student_name,
  cr.subject_name,
  SUM(CASE WHEN e.student_id IS NULL THEN 0 ELSE 1 END) attended_exams
FROM
(
  SELECT
    s.student_id,
    s.student_name,
    sb.subject_name
  FROM
    Students s
  CROSS JOIN
    Subjects sb
) cr
JOIN
  Students s ON cr.student_id = s.student_id
LEFT JOIN
  Examinations e
ON 
  cr.student_id = e.student_id AND
  cr.subject_name = e.subject_name
GROUP BY
  cr.student_id,
  s.student_name,
  cr.subject_name
ORDER BY
  cr.student_id,
  s.student_name



