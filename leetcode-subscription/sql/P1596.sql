/*
https://leetcode.com/problems/the-most-frequently-ordered-products-for-each-customer/
https://leetcode.com/submissions/detail/458434092/

*/

/* Write your T-SQL query statement below */

SELECT
  x.customer_id,
  x.product_id,
  p.product_name
FROM
(
  SELECT
    a.customer_id,
    a.product_id,
    COUNT(*) num
  FROM
    Orders a
  GROUP BY
    a.customer_id,
    a.product_id
) x
JOIN 
  Products p ON x.product_id = p.product_id
CROSS APPLY
(
  SELECT TOP 1 COUNT(*) mx
  FROM Orders o
  WHERE o.customer_id = x.customer_id
  GROUP BY o.product_id
  ORDER BY COUNT(*) DESC
) y
WHERE 
  x.num = y.mx


