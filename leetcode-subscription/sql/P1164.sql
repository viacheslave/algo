/*
https://leetcode.com/problems/product-price-at-a-given-date/
https://leetcode.com/submissions/detail/452502317/
Amazon
*/

/* Write your T-SQL query statement below */
SELECT
  DISTINCT p.product_id,
  CASE WHEN a.product_id IS NULL THEN 10 ELSE a.price END price
FROM
  Products p
LEFT JOIN
(
  SELECT
    p.product_id,
    CASE WHEN a.change_date IS NULL THEN 10 ELSE p.new_price END as price
  FROM
    Products p
  JOIN
  (
    SELECT
      product_id,
      MAX(change_date) change_date
    FROM Products
    WHERE change_date <= '2019-08-16'
    GROUP BY product_id
  ) a
  ON p.product_id = a.product_id AND
     p.change_date = a.change_date
) a
ON p.product_id = a.product_id
