/*
https://leetcode.com/problems/product-sales-analysis-i/
https://leetcode.com/submissions/detail/451009921/
Amazon
*/

/* Write your T-SQL query statement below */
SELECT
  p.product_name,
  s.year,
  s.price
FROM
  Product p
JOIN
  Sales s ON p.product_id = s.product_id
  

