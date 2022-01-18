/*
https://leetcode.com/problems/shortest-distance-in-a-plane/
https://leetcode.com/submissions/detail/452414846/
Microsoft
*/

/* Write your T-SQL query statement below */
SELECT
  TOP 1 ROUND(SQRT((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y)), 2) shortest
FROM
(
  SELECT
    x, y,
    ROW_NUMBER() OVER (ORDER BY CAST(x as varchar) + '.' + CAST(y as varchar)) row
  FROM
    point_2d
) a
JOIN
(
  SELECT
    x, y,
    ROW_NUMBER() OVER (ORDER BY CAST(x as varchar) + '.' + CAST(y as varchar)) row
  FROM
    point_2d
) b
ON a.row < b.row
ORDER BY
  1 