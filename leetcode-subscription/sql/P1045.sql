/*
https://leetcode.com/problems/customers-who-bought-all-products/
https://leetcode.com/submissions/detail/451038338/
Amazon
*/

/* Write your T-SQL query statement below */
SELECT
  c.customer_id
FROM
  Customer c
GROUP BY
  c.customer_id
HAVING
  COUNT(DISTINCT(c.product_key)) = (SELECT COUNT(*) FROM Product)
