/*
https://leetcode.com/problems/sellers-with-no-sales/
https://leetcode.com/submissions/detail/450742733/
*/

/* Write your T-SQL query statement below */
SELECT
  a.seller_name
FROM
(
  SELECT
    seller_name
  FROM
    Seller
) a
LEFT JOIN
(
  SELECT
    DISTINCT(seller_name) as seller_name
  FROM
    Orders o
  JOIN
    Seller s ON o.seller_id = s.seller_id
  WHERE
    YEAR(o.sale_date) = 2020
) m 
ON 
  a.seller_name = m.seller_name
WHERE 
  m.seller_name IS NULL
ORDER BY
  1




