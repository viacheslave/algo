/*
https://leetcode.com/problems/consecutive-available-seats/
https://leetcode.com/submissions/detail/452491148/

*/

/* Write your T-SQL query statement below */
SELECT
  a.seat_id
FROM
(
  SELECT
    seat_id,
    COUNT(CASE WHEN free = '1' THEN 1 END) OVER(ORDER BY seat_id ROWS BETWEEN CURRENT ROW AND 1 FOLLOWING) f,
    COUNT(CASE WHEN free = '1' THEN 1 END) OVER(ORDER BY seat_id ROWS BETWEEN 1 PRECEDING AND CURRENT ROW) p
  FROM
    cinema
) a
WHERE f = 2 OR p = 2

