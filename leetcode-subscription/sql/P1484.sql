/*
https://leetcode.com/problems/group-sold-products-by-the-date/
https://leetcode.com/submissions/detail/451459811/

*/

/* Write your T-SQL query statement below */

SELECT
  a.sell_date,
  COUNT(*) num_sold,
  STUFF(
   (SELECT ',' + t.product 
    FROM (SELECT DISTINCT sell_date, product FROM Activities) t
    WHERE a.sell_date = t.sell_date
    ORDER BY product
    FOR XML PATH (''))
    , 1, 1, '')  AS products
FROM
(
  SELECT DISTINCT sell_date, product
  FROM Activities
) a
GROUP BY
  a.sell_date

