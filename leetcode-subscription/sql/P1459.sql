/*
https://leetcode.com/problems/rectangles-area/
https://leetcode.com/submissions/detail/458403861/
Twitter
*/

/* Write your T-SQL query statement below */
SELECT 
  a.id p1,
  b.id p2,
  ABS((a.x_value - b.x_value) * (a.y_value - b.y_value)) area
FROM
  Points a
JOIN
  Points b ON a.id < b.id
WHERE 
  ABS((a.x_value - b.x_value) * (a.y_value - b.y_value)) > 0
ORDER BY 
  3 DESC,
  1 ASC,
  2 ASC

