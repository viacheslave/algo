/*
https://leetcode.com/problems/list-the-products-ordered-in-a-period/
https://leetcode.com/submissions/detail/451434632/
Amazon
*/

/* Write your T-SQL query statement below */
SELECT
  p.product_name,
  SUM(o.unit) unit
FROM
  Products p
JOIN
  Orders o
ON p.product_id = o.product_id
WHERE 
  o.order_date BETWEEN '2020-02-01' AND '2020-02-29'
GROUP BY
  p.product_name
HAVING 
  SUM(o.unit) >= 100

