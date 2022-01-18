/*
https://leetcode.com/problems/replace-employee-id-with-the-unique-identifier/
https://leetcode.com/submissions/detail/451090725/
Point72
*/

/* Write your MySQL query statement below */
SELECT
  uni.unique_id,
  e.name
FROM
  Employees e
LEFT JOIN
  EmployeeUNI uni
ON 
  e.id = uni.id