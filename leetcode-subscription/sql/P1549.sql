/*
https://leetcode.com/problems/the-most-recent-orders-for-each-product/
https://leetcode.com/submissions/detail/452452600/
*/

/* Write your T-SQL query statement below */
SELECT
  p.product_name,
  p.product_id,
  o.order_id,
  o.order_date
FROM 
  Products p
JOIN
  Orders o ON p.product_id = o.product_id
JOIN
(
  SELECT
    p.product_id,
    MAX(o.order_date) order_date
  FROM 
    Products p
  JOIN
    Orders o ON p.product_id = o.product_id
  GROUP BY
    p.product_id
) a ON p.product_id = a.product_id AND 
       o.order_date = a.order_date
ORDER BY
  p.product_name,
  p.product_id,
  o.order_id

