/*
https://leetcode.com/problems/product-sales-analysis-ii/
https://leetcode.com/submissions/detail/451010548/
Amazon
*/

/* Write your MySQL query statement below */
SELECT
  p.product_id,
  SUM(s.quantity) as total_quantity
FROM
  Product p
JOIN
  Sales s ON p.product_id = s.product_id
GROUP BY
  p.product_id