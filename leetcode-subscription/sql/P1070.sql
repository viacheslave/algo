/*
https://leetcode.com/problems/product-sales-analysis-iii/
https://leetcode.com/submissions/detail/451012516/
Amazon
*/

/* Write your T-SQL query statement below */
SELECT
  s.product_id,
  s.year as first_year,
  s.quantity,
  s.price
FROM
  Sales s
JOIN
(
  SELECT
    p.product_id,
    MIN(p.year) as year
  FROM
    Sales p
  GROUP BY
    p.product_id
) a 
ON 
  s.product_id = a.product_id AND
  s.year = a.year