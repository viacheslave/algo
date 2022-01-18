/*
https://leetcode.com/problems/count-apples-and-oranges/
https://leetcode.com/submissions/detail/450710656/
*/

/* Write your T-SQL query statement below */
SELECT
  SUM(i.apple_count) as apple_count,
  SUM(i.orange_count) as orange_count
FROM
(
  SELECT 
    b.apple_count + ISNULL(c.apple_count, 0) as apple_count,
    b.orange_count + ISNULL(c.orange_count, 0) as orange_count
  FROM
    Boxes b
  LEFT JOIN
    Chests c ON b.chest_id = c.chest_id
) i

