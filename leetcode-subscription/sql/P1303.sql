/*
https://leetcode.com/problems/find-the-team-size/
https://leetcode.com/submissions/detail/451191816/
Amazon
*/

/* Write your T-SQL query statement below */
SELECT
  employee_id,
  size team_size
FROM 
  Employee
JOIN
(
  SELECT
    team_id,
    COUNT(*) size
  FROM
    Employee
  GROUP BY
    team_id
) a
ON Employee.team_id = a.team_id