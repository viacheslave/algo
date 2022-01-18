/*
https://leetcode.com/problems/queries-quality-and-percentage/
https://leetcode.com/submissions/detail/451452800/
Facebook
*/

/* Write your T-SQL query statement below */
SELECT
  query_name,
  ROUND(SUM((1.0 * rating / position)) / COUNT(*), 2) as quality,
  ROUND(100.0 * COUNT(CASE WHEN rating < 3 THEN 1 END) / COUNT(*), 2) as poor_query_percentage
FROM
  Queries
GROUP BY
  query_name

