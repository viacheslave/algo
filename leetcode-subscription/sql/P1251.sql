/*
https://leetcode.com/problems/average-selling-price/
https://leetcode.com/submissions/detail/451095496/
Amazon
*/

/* Write your T-SQL query statement below */
SELECT
  u.product_id,
  ROUND(1.0 * SUM(u.units * p.price) / SUM(u.units), 2) as average_price
FROM
  UnitsSold u
JOIN
  Prices p
ON 
  u.product_id = p.product_id AND
  u.purchase_date BETWEEN p.start_date AND p.end_date
GROUP BY
  u.product_id

