/*
https://leetcode.com/problems/biggest-single-number/
https://leetcode.com/submissions/detail/451042592/

*/

/* Write your T-SQL query statement below */
SELECT
  CASE WHEN p.cnt = 1 THEN p.num ELSE NULL END as num
FROM
(
  SELECT 
    TOP 1 
      num AS num, 
      COUNT(*) AS cnt
  FROM
    my_numbers
  GROUP BY
    num
  ORDER BY
    COUNT(*) ASC,
    num DESC
) p
  
