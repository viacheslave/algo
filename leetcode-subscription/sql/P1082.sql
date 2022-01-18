/*
https://leetcode.com/problems/sales-analysis-i/
https://leetcode.com/submissions/detail/451023940/
Amazon
*/

/* Write your T-SQL query statement below */


SELECT
  a.seller_id
FROM
(
  SELECT
    s.seller_id,
    SUM(s.price) as price
  FROM 
    Sales s
  GROUP BY 
    s.seller_id
) a
JOIN
(
  SELECT
    MAX(p.price) as pr
  FROM
  (
    SELECT
      s.seller_id,
      SUM(s.price) as price
    FROM 
      Sales s
    GROUP BY 
      s.seller_id
  ) p
) b
ON a.price = b.pr