/*
https://leetcode.com/problems/shortest-distance-in-a-line/
https://leetcode.com/submissions/detail/450773771/

*/

/* Write your T-SQL query statement below */

SELECT
  MIN(b.x - a.x) as shortest
FROM
(
  SELECT 
    x,
    ROW_NUMBER() OVER(ORDER BY x) row_num
  FROM point
) b
LEFT JOIN
(
  SELECT 
    x,
    ROW_NUMBER() OVER(ORDER BY x) row_num
  FROM point
) a
ON 
  b.row_num = a.row_num + 1
WHERE 
  a.x IS NOT NULL


