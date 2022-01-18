/*
https://leetcode.com/problems/create-a-session-bar-chart/
https://leetcode.com/submissions/detail/451464744/
Twitch
*/

/* Write your T-SQL query statement below */

SELECT
  a.bin,
  ISNULL(s.total, 0) total
FROM
(
  SELECT DISTINCT * FROM (
    VALUES ('[0-5>'), ('[5-10>'), ('[10-15>'), ('15 or more')) 
  AS a(bin)
) a
LEFT JOIN
(
  SELECT
    CASE 
      WHEN s.bin = 0 THEN '[0-5>'
      WHEN s.bin = 1 THEN '[5-10>'
      WHEN s.bin = 2 THEN '[10-15>'
      WHEN s.bin = 3 THEN '15 or more' END bin,
    COUNT(*) total
  FROM
  (
    SELECT
      CASE 
        WHEN duration / 60 BETWEEN 0 AND 4 THEN 0
        WHEN duration / 60 BETWEEN 5 AND 9 THEN 1
        WHEN duration / 60 BETWEEN 10 AND 14 THEN 2
        WHEN duration / 60 >= 15 THEN 3 
      END as bin
    FROM 
      Sessions
  ) s
  GROUP BY
    CASE 
      WHEN s.bin = 0 THEN '[0-5>'
      WHEN s.bin = 1 THEN '[5-10>'
      WHEN s.bin = 2 THEN '[10-15>'
      WHEN s.bin = 3 THEN '15 or more' END
) s
ON a.bin = s.bin




