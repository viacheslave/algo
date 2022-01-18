/*
https://leetcode.com/problems/unique-orders-and-customers-per-month/
https://leetcode.com/submissions/detail/450734266/
Whole Foods Market
*/

/* Write your T-SQL query statement below */
SELECT
  (CAST(YEAR(a.order_date) as varchar) + '-' + CAST(RIGHT('0' + RTRIM(MONTH(a.order_date)), 2) as varchar)) as month,
  COUNT(a.invoice) as order_count,
  COUNT(DISTINCT(a.customer_id)) as customer_count
FROM
(
  SELECT
    *
  FROM 
    Orders
  WHERE
    invoice > 20
) a
GROUP BY
  (CAST(YEAR(a.order_date) as varchar) + '-' + CAST(RIGHT('0' + RTRIM(MONTH(a.order_date)), 2) as varchar))

