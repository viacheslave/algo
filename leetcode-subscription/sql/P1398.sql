/*
https://leetcode.com/problems/customers-who-bought-products-a-and-b-but-not-c/
https://leetcode.com/submissions/detail/458340995/
Amazon
*/

/* Write your T-SQL query statement below */
SELECT
  o.customer_id,
  c.customer_name
FROM
(
  SELECT
    customer_id,
    COUNT(CASE WHEN product_name = 'A' THEN 1 END) A,
    COUNT(CASE WHEN product_name = 'B' THEN 1 END) B,
    COUNT(CASE WHEN product_name = 'C' THEN 1 END) C
  FROM
    Orders
  GROUP BY
    customer_id
) o
JOIN Customers c
  ON o.customer_id = c.customer_id
WHERE
  o.A > 0 AND o.B > 0 AND o.C = 0

