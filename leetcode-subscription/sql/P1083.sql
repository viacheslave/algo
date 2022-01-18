/*
https://leetcode.com/problems/sales-analysis-ii/
https://leetcode.com/submissions/detail/451026079/
Amazon
*/

/* Write your T-SQL query statement below */

SELECT
  DISTINCT(buyer_id)
FROM
  Product p
JOIN 
  Sales s
ON 
  p.product_id = s.product_id
WHERE
  p.product_name = 'S8'
  AND buyer_id NOT IN
  (
    SELECT
      DISTINCT(buyer_id) as buyer_id
    FROM
      Product p
    JOIN 
      Sales s
    ON 
      p.product_id = s.product_id
    WHERE
      p.product_name = 'iPhone'
  )