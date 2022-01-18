/*
https://leetcode.com/problems/all-valid-triplets-that-can-represent-a-country/
https://leetcode.com/submissions/detail/450744826/
Amazon
*/

/* Write your T-SQL query statement below */
SELECT
  a.student_name as member_A,
  b.student_name as member_B,
  c.student_name as member_C
FROM
  SchoolA a
CROSS JOIN
  SchoolB b
CROSS JOIN
  SchoolC c
WHERE 
  a.student_id <> b.student_id AND
  b.student_id <> c.student_id AND
  c.student_id <> a.student_id AND
  a.student_name <> b.student_name AND
  b.student_name <> c.student_name AND
  c.student_name <> a.student_name
  




