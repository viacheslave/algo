/*
https://leetcode.com/problems/percentage-of-users-attended-a-contest/
https://leetcode.com/submissions/detail/450749908/
Facebook
*/

/* Write your MySQL query statement below */
SELECT
  a.contest_id,
  ROUND(100.0 * a.cnt / u.cnt, 2) as percentage
FROM
(
  SELECT
    contest_id,
    COUNT(*) as cnt
  FROM 
    Register
  GROUP BY
    contest_id
) a
CROSS JOIN
(
  SELECT 
    COUNT(*) as cnt 
  FROM 
    Users
) u
ORDER BY
  percentage DESC,
  contest_id ASC