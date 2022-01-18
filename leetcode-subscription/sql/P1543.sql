/*
https://leetcode.com/problems/fix-product-name-format/
https://leetcode.com/submissions/detail/450735807/
*/

/* Write your T-SQL query statement below */
SELECT
  LOWER(LTRIM(RTRIM(product_name))) as product_name,
  (CAST(YEAR(sale_date) as varchar) + '-' + CAST(RIGHT('0' + RTRIM(MONTH(sale_date)), 2) as varchar)) as sale_date,
  COUNT(*) as total
FROM
  Sales
GROUP BY
  (CAST(YEAR(sale_date) as varchar) + '-' + CAST(RIGHT('0' + RTRIM(MONTH(sale_date)), 2) as varchar)),
  LOWER(LTRIM(RTRIM(product_name)))


