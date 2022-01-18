/*
https://leetcode.com/problems/customer-order-frequency/
https://leetcode.com/submissions/detail/451445958/
Amazon
*/

/* Write your T-SQL query statement below */

SELECT
  a.customer_id,
  a.name
FROM
(
  SELECT
    c.customer_id,
    c.name,
    SUM(o.quantity * p.price) amount
  FROM
    Orders o
  JOIN 
    Product p ON o.product_id = p.product_id
  JOIN 
    Customers c ON o.customer_id = c.customer_id
  WHERE
    o.order_date BETWEEN '2020-06-01' AND '2020-07-31'
  GROUP BY
    c.customer_id, YEAR(o.order_date), MONTH(o.order_date),
    c.name
  HAVING
    SUM(o.quantity * p.price) >= 100
) a
GROUP BY
  a.customer_id, a.name
HAVING 
  COUNT(*) = 2
  

