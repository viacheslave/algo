/*
https://leetcode.com/problems/highest-grade-for-each-student/
https://leetcode.com/submissions/detail/452465817/
Coursera
*/

/* Write your T-SQL query statement below */
SELECT
  DISTINCT e.student_id,
  a.course_id,
  a.grade
FROM
  Enrollments e
CROSS APPLY
(
  SELECT
    TOP 1 course_id,
    grade
  FROM
    Enrollments
  WHERE
    student_id = e.student_id
  ORDER BY
    grade DESC,
    course_id ASC
) a
ORDER BY
  e.student_id

