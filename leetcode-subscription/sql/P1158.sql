/*
https://leetcode.com/problems/market-analysis-i/
https://leetcode.com/submissions/detail/451561105/
Poshmark
*/

/* Write your T-SQL query statement below */
SELECT
  u.user_id buyer_id,
  u.join_date,
  COUNT(CASE WHEN o.order_date BETWEEN '2019-01-01' AND '2019-12-31' THEN 1 END) orders_in_2019
FROM
  Users u
LEFT JOIN
  Orders o
ON
  o.buyer_id = u.user_id
--WHERE
--  o.order_date BETWEEN '2019-01-01' AND '2019-12-31' OR
--  o.order_date IS NULL
GROUP BY
  u.user_id,
  u.join_date

  

