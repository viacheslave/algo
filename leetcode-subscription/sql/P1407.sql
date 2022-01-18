/*
https://leetcode.com/problems/top-travellers/
https://leetcode.com/submissions/detail/451069630/
Point72
*/

/* Write your T-SQL query statement below */
SELECT
  u.name,
  ISNULL(SUM(r.distance), 0) as travelled_distance
FROM
  Users u
LEFT JOIN
  Rides r
ON 
  u.id = r.user_id
GROUP BY
  u.name
ORDER BY
  SUM(r.distance) DESC,
  u.name ASC

