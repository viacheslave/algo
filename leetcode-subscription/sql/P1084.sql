/*
https://leetcode.com/problems/sales-analysis-iii/
https://leetcode.com/submissions/detail/451030710/
Amazon
*/

/* Write your T-SQL query statement below */

SELECT
  DISTINCT 
    p.product_id,
    p.product_name
FROM
  Product p
JOIN
  Sales s
ON 
  p.product_id = s.product_id
WHERE 
  s.sale_date BETWEEN '2019-01-01' AND '2019-03-31'
  AND p.product_id NOT IN
  (
    SELECT
      DISTINCT p.product_id
    FROM
      Product p
    JOIN
      Sales s
    ON 
      p.product_id = s.product_id
    WHERE
      s.sale_date < '2019-01-01' OR
      s.sale_date > '2019-03-31'
  )