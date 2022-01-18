/*
https://leetcode.com/problems/the-most-recent-three-orders/
https://leetcode.com/submissions/detail/452460821/
*/

/* Write your T-SQL query statement below */
SELECT
  c.name customer_name,
  c.customer_id,
  a.order_id,
  a.order_date
FROM
  Customers c
CROSS APPLY
(
  SELECT 
    TOP 3 
      order_id,
      order_date
  FROM
    Orders
  WHERE
    customer_id = c.customer_id
  ORDER BY
    order_date DESC
) a
ORDER BY
  c.name ASC,
  c.customer_id ASC,
  a.order_date DESC

